def main():
    for n in range(1, 101):
        if n%15 == 0:
            print(n, "FizzBuzz")
        if n%3 == 0:
            print(n, "Fizz")
        if n%5 == 0:
            print(n, "Buzz")
        if n%3 != 0 and n%5 != 0:
            print(n)  
main()