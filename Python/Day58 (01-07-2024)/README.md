learning from
*https://docs.python.org/3/tutorial/classes.html
https://www.geeksforgeeks.org/inheritance-in-python/
https://www.programiz.com/python-programming/polymorphism*

**---------------------------------- CLASS -------------------------------------------**
we can Declare class using keyword --> "class"
eg :
    class ClassName:

constructor :
eg :
    class ClassName:
        def__init__(self,parameter1,parameter2):
            self.param1 = paramater1
            self.param2 = parameter2

Using the class methods
eg :
    Y= MyClass()
    print(Y.f())

Class Variables Shares same variable for all instance of the class
Instance Variable unique for all different instances
eg :
    class Car:

    vehicle_type = 'automobile'  # class variable

    def__init__(self, make, model):
        self.make = make         # instance variable
        self.model = model       # instance variable

    def update_model(self, new_model):
        self.model = new_model

update the instance variable
eg :

    class Laptop:
        brand = 'HP'
        processor = 'intel 5'
    w1 = Laptop()
    print(w1.brand, w1.processor)
    w2 = Laptop()
    w2.processor = 'intel 7'
    print(w2.brand, w2.processor)
    

__str__() used to define how a class object should be represented as a string
eg :
    class MyData:
    def __init__(self, name, company):
        self.name = name
        self.company = company
    def __str__(self):
        return f"My name is {self.name} and I work in {self.company}."

we can have a data specific class by importing dataclass
eg :
    from dataclasses import dataclass
    @dataclass
    class Employee:
        name: str
        dept: str
        salary: int

**------------------------------------- INHERITANCE ---------------------------------------------**

1) We can call the parent class __init__ using super() keyword
   Eg :
   def __init__(self, name, id, company, salary):
       super().__init__(name, id, company)
       self.salary = salary
   or we can directly call it like the bleow
       Employee.__init__(self,name, id, company)
2) Multiple Inheritance is not supported in other languages due toe the diamond problem
   A
   / B   C   ----- DIAMOND PROBLEM
   \ /
   D
   but python supports multiple inheritance with the help of MRO(METHOD RESOLUTION ORDER)

   eg :
   class A:
       def method(self):
           print("Method from A")
   class B(A):
       def method(self):
           print("Method from B")
   class C(A):
       def method(self):
           print("Method from C")
   class D(B, C):
       pass
   d = D()
   d.method()
   print(D.mro())
3) Multilevel Inheritance
   eg :
   class Animal:
       def __init__(self, name):
           self.name = name
       def speak(self):
           pass
   class Dog(Animal):
       def speak(self):
           return f"{self.name} says Woof!"
   class Labrador(Dog):
       def speak(self):
           return f"{self.name} says Woof Woof!"
5) Hierarchical inheritance
   eg:
   class Animal:
       def __init__(self, name):
           self.name = name
       def speak(self):
           pass
   class Dog(Animal):
       def speak(self):
           return f"{self.name} says Woof!"
   class Cat(Animal):
       def speak(self):
           return f"{self.name} says Meow!"
6) Hybrid Inheritance - combination of all the inheritance
   eg :
   class Person:
       def __init__(self, name):
           self.name = name
       def display_name(self):
           return f"Name: {self.name}"
   class Employee(Person):
       def __init__(self, name, emp_id):
           super().__init__(name)
           self.emp_id = emp_id
       def display_details(self):
           return f"{super().display_name()}, Employee ID: {self.emp_id}"
   class Manager(Employee):
       def __init__(self, name, emp_id, department):
           super().__init__(name, emp_id)
           self.department = department
       def display_details(self):
           return f"{super().display_details()}, Department: {self.department}"
   class Worker(Person):
       def __init__(self, name, role):
           super().__init__(name)
           self.role = role
       def display_details(self):
           return f"{super().display_name()}, Role: {self.role}"

**--------------------------- POLYMORPHISM ---------------------------------------**

1) method overriding
   eg :
   class Vehicle:
       def display_info(self):
           return "Vehicle"
   class Car(Vehicle):
       def display_info(self):
           return "Car"
   class Truck(Vehicle):
       def display_info(self):
           return "Truck"
2) polymorphism in class methods
   eg :
   class Cat:
       def __init__(self, name, age):
           self.name = name
           self.age = age
       def info(self):
           print(f"I am a cat. My name is {self.name}. I am {self.age} years old.")
       def make_sound(self):
           print("Meow")
   class Dog:
       def __init__(self, name, age):
           self.name = name
           self.age = age
       def info(self):
           print(f"I am a dog. My name is {self.name}. I am {self.age} years old.")
       def make_sound(self):
           print("Bark")

**-------------------------- MODULES -------------------------------------**
learnt from
https://docs.python.org/3/tutorial/modules.html
https://www.w3schools.com/python/python_modules.asp

1) we can import modules using
   import module_name
   module_name.methodName()
2) import with alias name
   eg :
   import modules_names as alias_name
3) import only particular methods
   eg:
   from module_name import method1
4) Built in modules
   eg:
   (i) import platform
   dir(platform)
   platform.system()
   (ii) import sys
   print(dir(sys))

**------------------------- EXCEPTION HANDLING -----------------------------**
learning from
https://www.geeksforgeeks.org/python-exception-handling/

1) we can handle the specifi exception using the keyword try and except
   eg:
   try :
       print(3/0)
   except ZeroDivisionError:
       print("cannot divide a number with 0")
2) Using Finally keyword to execute after try except
   eg :
   try :
       print(3/0)
   except ZeroDivisionError:
       print("cannot divide a number with 0")
   finally:
       print("executed")
3) Raise exception using Raise Keyword
   eg :
   try:
       raise NameError("Hi there")
   except NameError:
       print ("An exception")
4) custom exception
   eg :
   class ValueTooHighError(Exception):
       def __init__(self, message="Value is too high!"):
           self.message = message
           super().__init__(self.message)
       def process_value(value):
       try:
           if value > 100:
           raise ValueTooHighError
       except ValueTooHighError as e:
       print(f"Error: {e}")
       else:
           print(f"Processed value: {value}")

**--------------------------- FILES ---------------------------------**
LEARNING FROM
https://www.programiz.com/python-programming/file-operation

1) read file
   eg :
   file1 = open("files/test.txt")
   content = file1.read()
2) write file
   eg:
   file2 = open('files/file2.txt', 'w')
   file2.write('Programming is Fun.\n')
3) close file
   eg:
   file1.close()
4) using with open -- when we use with open it closes the file automatically outside the with
   eg :
   with open("files/test.txt", "r") as file1:
   content = file1.read()
   print(content)
   1) We can use xlwt module to read and write in excel file
      eg

      import xlw

      from xlwt import Workbook

      wb = Workbook()

      sheet1 = wb.add_sheet('Sheet 1')

      sheet1.write(1, 0, 'ISBT DEHRADUN')
