from ast import Lambda
import time

def fetchSymbol(symbol):

    # symbol = input("Enter the stock symbol you are looking for: ").upper()
    if len(symbol) < 1 or len(symbol) > 7:
        raise Exception ("Symbol length must be between 1-7.")
    return symbol.upper()


def chartType(chartChoice):
    # print("Chart Types:")
    # print("------------")
    # print("1. Bar")
    # print("2. Line")
    # chart_type = int(input("Choose what type of chart you want (1, 2): "))
    chart_type = int(chartChoice)
    if chart_type != 1 and chart_type != 2:
        raise Exception("\nError: Please only enter 1 or 2\n")

    return chart_type

        
def get_time_series(series, intervalChoice):
    # again = True
    # while again:
    try: 
        interval = Lambda
        # print("Select the Time Series of the chart you want to Generate")
        # print("1. Intraday")
        # print("2. Daily")
        # print("3. Weekly")
        # print("4. Monthly")
        # series = input("Enter the time series option(1,2,3,4): ")
        series
        isIntra = False
        seriesOption = ["1", "2", "3", "4"]
        if series not in seriesOption:
            raise Exception("series option can only be 1-4.")

        if series == "1":
            isIntra = True
            # print("\n\n1. 1min")
            # print("2. 5min")
            # print("3. 15min")
            # print("4. 30min")
            # print("5. 60min")
            # intervalChoice = input("Please choose time interval: ")
            intervalChoice
            match intervalChoice:
                case "1":
                    interval = 1
                case "2":
                    interval = 5
                case "3":
                    interval = 15
                case "4":
                    interval = 30
                case "5":
                    interval = 60

        timeSeriesObject = {"series": series,
                            "interval": interval,
                            "isIntra" : isIntra}
        again = False
    except Exception as e:
        print(f"This is an unacceptable response, enter a valid value.\n{e}")
        
    return timeSeriesObject

        
def dateFormatCheck(date):
    
    #check if given date is numerical
    ymd = date.split("-")
    if len(ymd) != 3:
        raise Exception("Please use the correct format(YYYY-MM-DD).")

    for digit in ymd:
        if not digit.isdigit():
            raise Exception("Please enter numerical values only.")

    #check if variables are valid in length and value
    year = ymd[0]
    month = ymd[1]
    day = ymd[2]
    if len(year) != 4 or len(month) != 2 or len(day) != 2:
        raise Exception('Please make sure date is in "YYYY-MM-DD" format.')
    if int(month) > 12 or int(day) > 31:
        raise Exception("Please enter a valid Month/Day")

    #check if user time is in the future
    userTime = time.strptime(date, "%Y-%m-%d")
    currentTime = time.strptime(time.strftime("%Y-%m-%d"), "%Y-%m-%d")
    if userTime > currentTime:
        raise Exception("Date cannot be after today.")

    
def getDates(beginDate, endDate):

    # beginDate = input("Please enter the start date (YYYY-MM-DD) format: ")
    # endDate = input("Please enter the end date (YYYY-MM-DD) format: ")

    if endDate <= beginDate:
        raise Exception("The ending date must not be before the beginning date. \nPlease try again.")

    #date format check
    datesArray = [beginDate, endDate]
    for date in datesArray:
        dateFormatCheck(date)

    return datesArray

