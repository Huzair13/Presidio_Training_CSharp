#IF
x = 10

if x > 5:
    print("x is greater than 5")

#IF - ELSE
y = 3

if y % 2 == 0:
    print("y is even")
else:
    print("y is odd")

#IF - ELIF - ELSE
z = -5

if z > 0:
    print("z is positive")
elif z == 0:
    print("z is zero")
else:
    print("z is negative")

#NESTED IF
a = 15

if a > 0:
    if a % 2 == 0:
        print("a is a positive even number")
    else:
        print("a is a positive odd number")
else:
    print("a is not a positive number")

#IF USING LOGICAL OPERATORS
b = 20

if b > 10 and b % 2 == 0:
    print("b is greater than 10 and even")
elif b > 10 and b % 2 != 0:
    print("b is greater than 10 but odd")
else:
    print("b is not greater than 10")

# TERNARY OPERATOR
c = 25

result = "c is even" if c % 2 == 0 else "c is odd"
print(result)
