def main():
    openfile = input('Enter the file name')
    num = 0 
    try: 
        file = open(openfile, 'r' )
        count = 0 
        total = 0 
        average = 0 
        maximum = 0 
        minimum = 0 
        range1 = 0 
        for line in file:
            num = int(line)
            count = count + 1
            total += num

            if count == 1:
                maximum = num 
                minimum = num
            else:
                if num > maximum:
                    maximum = num
                if num < minimum:
                    minimum = num
        if count > 0:
            average = total / count
            range1 = maximum - minimum
    except Exception as error:
        print(error)
    
    print("The file: ", openfile)
    print("The sum of numbers: ", total)
    print("The count of numbers is: ", count)
    print('The average: ', average)
    print('The Maximum: ', maximum)
    print('The Minimum: ', minimum)
    print('The range: ', range1)

    file.close()

    input('Press ENTER to exit')
main()