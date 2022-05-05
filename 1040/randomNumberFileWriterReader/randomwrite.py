from os import error
import random

def main():

    while True:
        try:
            amount = int(input('Amount of numbers to generate: '))
            if (amount < 0):
                print('Enter positive whole value.')
                continue
        except ValueError:
            print('Inivalid value, please enter numerical value.')
        else: 
            break
    while True:
        try:
            lowerBound = int(input('Enter lower range: '))
            if(lowerBound < 0):
                print('Enter positive value.')
                continue
        except ValueError:
            print('Invalid value, please enter numerical value.')
        else:
            break
    while True:
        try: 
            upperBound = int(input('Enter upper range: '))
            if(upperBound <= lowerBound):
                print('Upper range cannot be lower than Lower range.')
                continue
        except ValueError:
            print('Invalid value, please enter numerical value.')
        else:
            break  
    while True:
        try:
            with open('randomnum.txt', 'w') as fp:
                for x in range(amount):            
                    numLines = str(random.randrange(lowerBound,upperBound))
                    fp.write(numLines + '\n')
        except Exception as error:
            print(error)    
        finally:
            input('Values have been entered and logged. Press ENTER to exit.')
            break


main()