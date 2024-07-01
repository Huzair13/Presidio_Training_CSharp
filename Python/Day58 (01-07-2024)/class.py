class Complex:
    def __init__(self, realpart, imagpart):
        self.r = realpart
        self.i = imagpart

x = Complex(3.0, -4.5)
print(x.r , x.i)

# The below code prints 16 even though x is an instance of the class Complex
# Dynamically adds counter attributes to the instance x
x.counter = 1
while x.counter < 10:
    x.counter = x.counter * 2
print(x.counter)
del x.counter

print(x.r)


class MyClass:
    i = 12345
    def f(self):
        return 'hello world'
    
Y= MyClass()
print("value of i in my class: ",Y.i)

#Below both are same
print(Y.f())
print(MyClass.f(Y))

#instance Variable and class Variable
class Car:

    vehicle_type = 'automobile'  # class variable

    def __init__(self, make, model):
        self.make = make         # instance variable
        self.model = model       # instance variable 

    def update_model(self, new_model):
        self.model = new_model   

car1 = Car('Toyota', 'Corolla')
car2 = Car('Honda', 'Civic')

print(car1.vehicle_type)
print(car2.vehicle_type)  

print(car1.make)  
print(car1.model) 
print(car2.make) 
print(car2.model) 

#update model
car1.update_model('Camry')
print(car1.model)

print(car2.model) 


#Anothe Example
class Dog:

    def __init__(self, name):
        self.name = name
        self.tricks = []   

    def add_trick(self, trick):
        self.tricks.append(trick)

d = Dog('Fido')
e = Dog('Buddy')
d.add_trick('roll over')
e.add_trick('play dead')

print(d.tricks)
print(e.tricks)


#update variables using through instance variable\
class Laptop:
   brand = 'HP'
   processor = 'intel 5'

w1 = Laptop()
print(w1.brand, w1.processor)
w2 = Laptop()
w2.processor = 'intel 7'
print(w2.brand, w2.processor)

#__str()__ exmaple
class MyData:
    def __init__(self, name, company):
        self.name = name
        self.company = company
    def __str__(self):
        return f"My name is {self.name} and I work in {self.company}."
my_data = MyData("Huzair", "Presidio")
print(my_data)


#data specific class
from dataclasses import dataclass

@dataclass
class Employee:
    name: str
    dept: str
    salary: int