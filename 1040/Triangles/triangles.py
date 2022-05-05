from turtle import Turtle
from turtle import Turtle
import random

def triangle(turtle, size, length):
    colors = ['red', 'orange', 'yellow', 'green', 'blue', 'indigo', 'violet']
    turtle.color(random.choice(colors))
    turtle.pensize(size)
    turtle.forward(length)
    turtle.right(120)
    for x in range(20):
        turtle.backward(150)
        turtle.left(120)
        turtle.right(50)

    
    return triangle(turtle, size, length)

def main():
    t1 = Turtle()
    t1.speed(0)
    triangle(t1, 10, 150)
    input()

main()