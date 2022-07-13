import time

def dateFormatCheck(userDate):

    #check if given date is numerical
    ymd = userDate.split("-")
    if len(ymd) != 3:
        print("Please use the correct format(YYYY-MM-DD).")
        return startDate()

    for digit in ymd:
        if not digit.isdigit():
            print("Please enter numerical values only.")
            return startDate()
    
    #check if variables are valid in length and value
    year = ymd[0]
    month = ymd[1]
    day = ymd[2]
    if len(year) != 4 or len(month) != 2 or len(day) != 2:
        print("Please make sure date is in \"YYYY-MM-DD\" format.")
        return startDate()
    if int(month) > 12 or int(day) > 31:
        print("Please enter a valid Month/Day")
        return startDate()

    #check if user time is in the future
    userTime = time.strptime(userDate, "%Y-%m-%d")
    currentTime = time.strptime(time.strftime("%Y-%m-%d"), "%Y-%m-%d")
    if userTime > currentTime:
        print("Date cannot be after today.")
        return startDate()
        

def startDate():
    userDate = input("Enter the start date (YYYY-MM-DD): ")
    dateFormatCheck(userDate)
        
startDate()