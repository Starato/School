from os import error
from typing import final


def readfile(filePath):
    lines = []
    try:
        with open(filePath, 'r') as fp:
            lines = fp.readlines()
    except Exception as error:
        print(error)
    return lines

def main():
    filePath = 'randomnum.txt'
    theLines = readfile(filePath)

    while True:
        try:
            print('List of random numbers in randomnum.txt: ')
            for line in theLines:
                print(line)
            data = len(theLines)
            print('Random number Count', data)
        except Exception as error:
            print(error)
        else:
            break

    input('Press ENTER to exit')

main()

  
            
        
      
    


    
   
    

main()