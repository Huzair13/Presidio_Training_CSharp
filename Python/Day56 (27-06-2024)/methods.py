# method 1
def addNumbers(a, b):
    return a + b
result1 = addNumbers(5, 3)
print(f"Eadd of 5 and 3 : {result1}")
print()

# merhod 2
def greet(name="Huzair"):
    return f"Hello, {name}!"
greeting1 = greet()
print(f"{greeting1}")

greeting2 = greet("Ahmed")
print(f"{greeting2}")
print()

#method 3 
def circle(radius):
    area = 3.14 * radius * radius
    perimeter = 2 * 3.14 * radius
    return area, perimeter

area, perimeter = circle(5)
print(f"area : {area:.2f} and perimeter : {perimeter:.2f}")
print()

# method 4
def average(*args):
    if len(args) == 0:
        return 0.0
    return sum(args) / len(args)
avg1 = average(10, 20, 30)
print(f"Average :  {avg1:.2f}")

avg2 = average()
print(f"Average : {avg2:.2f}")

print()
# method 5
def displayInfo(**kwargs):
    for key, value in kwargs.items():
        print(f"{key}: {value}")
        
displayInfo(name="Huzair", age=22, city="Salem")
