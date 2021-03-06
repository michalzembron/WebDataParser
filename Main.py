import datetime
import json
import os
import threading
from os import listdir
from os.path import isfile, join

import requests
from elasticsearch import Elasticsearch

es = Elasticsearch([{'host': 'localhost', 'port': 9200}])


def getDataByCountryAllStatus(folderName, countryName):
    startDate = datetime.date(2020, 3, 1)
    currentDate = datetime.date.today()
    url = "https://api.covid19api.com/country/" + countryName + "?" + \
          "from=" + str(startDate) + "T00:00:00Z&" + \
          "to=" + str(currentDate) + "T00:00:00Z"
    payload = {}
    headers = {}
    response = requests.request("GET", url, headers=headers, data=payload)
    parsedFile = json.loads(response.text.encode("utf8"))

    for element in parsedFile:
        element.pop('Province', None)
        element.pop('City', None)
        element.pop('CityCode', None)
        element.pop('ID', None)

    saveFile(startDate, folderName + '/', parsedFile)


def saveFile(startDate, folderName, parsedData):
    fileList = [f for f in listdir(folderName) if isfile(join(folderName, f))]
    i = startDate
    for json_obj in parsedData:
        filename = str(i) + '.json'
        if filename not in fileList:
            print("Saved: " + filename)
            with open(folderName + filename, 'w') as out_json_file:
                json.dump(json_obj, out_json_file, indent=4)
        i = i + + datetime.timedelta(days=1)
    mainMenu()


def loadFile(folderName, countryName):
    fileID = 1
    currentDate = datetime.date(2020, 3, 1)
    while currentDate <= (datetime.date.today() - datetime.timedelta(days=1)):
        if os.path.isfile(folderName + str(currentDate) + '.json'):
            with open(folderName + str(currentDate) + '.json') as file:
                loadedData = json.load(file)
            es.index(index="covid-" + countryName, id=fileID, body=loadedData)
            fileID = fileID + 1
        currentDate = currentDate + datetime.timedelta(days=1)
    print("Finished.")
    mainMenu()


def autoCheckForNewData(folderName, countryName):
    threading.Timer(30.0, autoCheckForNewData).start()
    print("Checking for changes...")
    getDataByCountryAllStatus(folderName, countryName)
    loadFile(folderName + "/", countryName)


def showCountries():
    url = "https://api.covid19api.com/countries"
    payload = {}
    headers = {}
    response = requests.request("GET", url, headers=headers, data=payload)
    parsedFile = json.loads(response.text.encode("utf8"))
    for i in range(len(parsedFile)):
        print("Country: " + parsedFile[i]['Country'] + ", Slug: " + parsedFile[i]['Slug'])
    mainMenu()


def mainMenu():
    menu = input(
        "\"1\" to download fresh data from 2020-03-01 to today (" + str(
            datetime.date.today()) + ") by country (written in lowercase)" +
        "\n\"2\" to push data to elasticsearch" +
        "\n\"3\" to check for new data every 30 seconds and if there is, push it to Elasticsearch" +
        "\n\"4\" to show all available countries" +
        "\n\"exit\" to exit" +
        "\n")

    if menu == "1":
        folderName = input("folder name (\"covid-poland\"): ")
        countryName = input("country name (\"poland\"): ")
        getDataByCountryAllStatus(folderName, countryName)
    elif menu == "2":
        folderName = input("folder name (default \"covid-poland\"): ")
        countryName = input("country name (\"poland\"): ")
        loadFile(folderName + "/", countryName)
    elif menu == "3":
        folderName = input("folder name (default \"covid-poland\"): ")
        countryName = input("country name (\"poland\"): ")
        autoCheckForNewData(folderName, countryName)
    elif menu == "4":
        showCountries()
    elif menu == "exit":
        print("Shutting down...")
    else:
        mainMenu()


mainMenu()
