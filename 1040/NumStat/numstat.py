from functools import total_ordering
from os import error
from typing import final

def sumCalc(filePath):
    try:
        with open(filePath, ) as fp:
            values = fp.readlines()
            total = 0 
            for x in values:
                realNum = int(x)
                total += realNum
    except Exception as error:
        print(error)
    return total

def averageCalc(sumTotal, totalCount):
    try:
        average = sumTotal / totalCount
    except Exception as error:
        print(error)
    return average

def realNum(filePath):
    convertedList = []
    try:  
        with open(filePath, ) as fp:
            theList = fp.readlines()
            for x in theList:
                convertedList.append(int(x))                
    except Exception as error:
        print(error)
    return convertedList

def main():
    again = True
    while (again):

        filePath = input('File name: ')
        totalCount = len(realNum(filePath))
        sumTotal = sumCalc(filePath)
        aveTotal = averageCalc(sumTotal, totalCount)
        finalNumList = realNum(filePath)
        maximum = max(finalNumList)
        minimum = min(finalNumList)
        numRange = maximum - minimum  

        try:      
            print('Sum: ', sumTotal)
            print('Count: ', totalCount)
            if (totalCount == 0 or sumTotal == 0 ):
                print('Average: Gimme something thats not zero')
            else:
                print('Average: ', aveTotal)
                print('Maximum: ', maximum)
                print('Minimum: ', minimum)
                print('Range: ',  numRange)
        except Exception as error:
            print(error)
        again = input('Try another one? (y/n)')
        if (again != 'y'):
            again = False
    
main()