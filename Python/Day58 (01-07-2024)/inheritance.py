#single inheritance
# Parent class
class Employee:
    def __init__(self, name, id, company):
        self.name = name
        self.id = id
        self.company = company

    def Display(self):
        print(self.name, self.id, self.company)

employee = Employee("Huzair", 102, "Presidio")
employee.Display()

# Child class
class Salary(Employee):
    def __init__(self, name, id, company, salary):
        # super().__init__(name, id, company)
        # or 
        Employee.__init__(self,name, id, company)
        self.salary = salary

    def Display(self):
        print(self.name,self.id,self.company,self.salary)

salary = Salary("Huzair", 102, "Presidio", 5000)
salary.Display()

#Multiple Inheritance
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
print(D.mro()) #Prints the Method Resolution Order


#multilevel Inheritance
class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age
    def display(self):
        print(f"Name: {self.name}, Age: {self.age}")

class Employee(Person):
    def __init__(self, name, age, employee_id, company):
        super().__init__(name, age)
        self.employee_id = employee_id
        self.company = company
    def display(self):
        super().display()
        print(f"Employee ID: {self.employee_id}, Company: {self.company}")

class Manager(Employee):
    def __init__(self, name, age, employee_id, company, department):
        super().__init__(name, age, employee_id, company)
        self.department = department
    def display(self):
        super().display()
        print(f"Department: {self.department}")

manager = Manager("Huzair", 22, "101", "Presidio", "IT")
manager.display()


#Heierarchical Inheritance
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
dog = Dog("Leo")
cat = Cat("Toms")
print(dog.speak())  
print(cat.speak()) 


#hybrid inheritance
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

manager = Manager("Huzair", 101, "Engineering")
worker = Worker("Ahmed", "Full Stack Developer")
print(manager.display_details()) 
print(worker.display_details())   
