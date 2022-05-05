import sys
from typing import SupportsIndex

def sumCalc(filePath):
    try:
        with open(filePath, ) as fp:
            values = fp.readlines()
            total = 0 
            for x in values:
                realNum = int(x)
                total += realNum
    except:
        print('Incorrect file name/path')
        main()
    return total

def averageCalc(sumTotal, totalCount):
    try:
        if totalCount == 0:
            check = input('File is empty or division by 0, try again? (y/n)')
            main() if check == 'y' else sys.exit()            
        else:
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

def getMedian(filePath):
    listTotal = realNum(filePath)
    sort = sorted(listTotal)
    if len(listTotal) % 2 == 0:
        index = len(listTotal) / 2
        index2 = index - 1
        median = (sort[int(index)]+sort[int(index2)]) / 2
    elif len(listTotal) % 2 != 0:
        indexO = (len(listTotal) - 1) / 2
        median = sort[int(indexO)]
    return median

def getMode(filePath):
    lists = realNum(filePath)
    numCount = {}
    modes = []
    for x in lists:
        if x in numCount:
            numCount[x] += 1
        else:
            numCount[x] = 1
    check = max(numCount.values())
    for key, value in numCount.items():
        if value == check:
            modes.append(key)
    return modes

def main():
    again = True
    while (again): 
        filePath = input('File name.txt: ')
        totalCount = len(realNum(filePath))
        sumTotal = sumCalc(filePath)
        aveTotal = averageCalc(sumTotal, totalCount)
        finalNumList = realNum(filePath)
        maximum = max(finalNumList)
        minimum = min(finalNumList)
        range = maximum - minimum  
        median = getMedian(filePath)
        mode = getMode(filePath)

        print('Sum: ', sumTotal)
        print('Count: ', totalCount)
        print('Average: ', aveTotal)
        print('Maximum: ', maximum)
        print('Minimum: ', minimum)
        print('Range: ',  range)
        print('Median: ', median)
        print('Mode: ', str(mode).replace('[', '').replace(']', ''))
            
        again = input('Try another one? (y/n)')
        if (again != 'y'):
            again = False  
main()
#C:\Users\stuwu\Desktop\FS21 Classes\IT 1040\NumStat 2\numbers.txt
#C:\Users\stuwu\Desktop\FS21 Classes\IT 1040\NumStat 2\numbers2.txt
#C:\Users\stuwu\Desktop\FS21 Classes\IT 1040\NumStat 2\numbers3.txt
#C:\Users\stuwu\Desktop\FS21 Classes\IT 1040\NumStat 2\numbers4.txt