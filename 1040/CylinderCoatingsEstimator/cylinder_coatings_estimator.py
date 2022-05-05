from math import pi

def surfacearea_calc(r, h):
    a = 2*pi*r*h + 2*pi*r**2
    return a 

def round_pints(a):
    p = (round (a/50))
    return p

def total_cost(p,c):
    tc = p*c
    return tc

def main():
    do_calculation = True
    while(do_calculation):
        while True:
            try:
                r = float(input('Enter Radius: '))
                if (r <= 0):
                    print('Enter positive value.')
                    continue
            except ValueError:
                    print('Invalid value, please enter numerical value.')
            else:
                break
        while True:
            try:
                h = float(input('Enter Height: '))
                if (h <= 0):
                    print('Enter positive value.')
                    continue
            except ValueError:
                    print('Invalid value, please enter numerical value.')
            else:
                break
        while True:
            try:
                c = float(input('Enter cost per pint: '))
                if (r <= 0):
                    print ('Enter positive value.')
                    continue
            except ValueError:
                print ('Invalid value, please enter numerical value.')
            else:
                break
        
        
        a = surfacearea_calc(r, h)
        p = round_pints (a)
        tc = total_cost(p,c)
        print (p,'pints are required costing $',format(tc, ',.2f'))
        another_calculation = input('Start another calculation? (y/n): ')
        if (another_calculation != 'y'):
            do_calculation = False

main()
