def getLines(filePath):
    filter = []
    try:
        with open(filePath, 'r') as fp:
            lines = fp.read().splitlines()
            for line in lines:
                filter.append(line.lower().split(','))
    except Exception as error:
        print(error)
    return filter

def sortValue(filePath):
    lines = getLines(filePath)
    date = []
    dicts = {'sno': [], 'name': [], 'symbol': [], 'date': [], 'high': [], 'low': [], 'open': [], 'close': [], 'volume': [], 'marketcap': []}
    for d in lines[1:]:
        rmvT = str(d[3]).split(' ')
        splitDate = rmvT[0].split('-')
        date.append(splitDate)
    for x in lines[1:]:
        dicts['sno'].append(x[0])
        dicts['name'].append(x[1])
        dicts['symbol'].append(x[2])
        dicts['high'].append(x[4])
        dicts['low'].append(x[5])
        dicts['open'].append(x[6])
        dicts['close'].append(x[7])
        dicts['volume'].append(x[8])
        dicts['marketcap'].append(x[9])
    for i in date:
        dicts['date'].append(i[1]+'/'+i[2]+'/'+i[0][2:4]) 
    return dicts

def getAvg(category, lines):
    sumsClose = 0
    sumsOpen = 0
    a = len(lines)-1
    for x, y in zip(category['close'], category['open']):
        sumsClose+=float(x)
        sumsOpen+=float(y)
    totalClose = sumsClose / a
    totalOpen = sumsOpen / a
    return totalClose, totalOpen

def close(category):
    close = category['close']
    date = category['date']
    closeDate = []
    mins = min(map(float,close))
    maxes = max(map(float,close))
    lowcd = {mins: []}
    highcd = {maxes: []}
    for cl, d in zip(close, date):
        closeDate.append([cl,d])
    for y in closeDate:
        if float(y[0]) == mins:
            lowcd[mins].append(y[1])
        if float(y[0]) == maxes:
            highcd[maxes].append(y[1])
    return lowcd, highcd

def maxMarket(category):
    market = category['marketcap']
    date = category['date']
    marketDate = []
    maxs = max(map(float,market))
    highmd = {maxs: []}
    for mark, d in zip(market, date):
        marketDate.append([mark,d])
    for y in marketDate:
        if float(y[0]) == maxs:
            highmd[maxs].append(y[1])
    return highmd

def filterKV(category):
    lowcd, highcd = close(category)
    highmd = maxMarket(category)
    highKey = list(highcd.keys())[0]
    lowKey = list(lowcd.keys())[0]
    lowValue = lowcd.values()
    highValue = highcd.values()
    mktK = list(highmd.keys())[0]
    for lDates in lowValue:
        lDates
    for hDates in highValue:
        hDates
    for mV in highmd.values():
        mV
    return lowKey, lDates, highKey, hDates, mktK, mV

def main():
    another = True
    while(another):
        format = '${:,.2f}'.format
        filePath = input('Enter file name:')
        lines = getLines(filePath)
        category = sortValue(filePath)
        totalClose, totalOpen = getAvg(category, lines)
        marketcap = maxMarket(category)
        lowcd, highcd =close(category)
        lowKey, lDates, highKey, hDates, mktK, mV = filterKV(category)

        print('Crypto currency symbol:', str(category['symbol'][0]).upper())
        print('Crypto currency name:', str(category['name'][0]).capitalize())
        print('Highest closing price and date(s):', format(highKey), 'on', ', '.join(hDates))
        print('Lowest closing price and date(s):', format(lowKey), 'on', ', '.join(lDates))
        print('Highest market capitalization and date(s): ', format(mktK), 'on', ', '.join(mV))
        print('Average opening price: ', format(totalOpen))
        print('Average closing price: ', format(totalClose))
        print('Number of entries: ' , len(lines)-1)
        another = input('Enter another file? (y/n): ')
        if(another != 'y'):
            another = False
main()
