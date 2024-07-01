#Polymorphism in Class Methods
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

cat1 = Cat("Tom", 3)
dog1 = Dog("Leo", 4)

for animal in (cat1, dog1):
    animal.info()
    animal.make_sound()


#polymorphism Mehtod Overriding
class Vehicle:
    def __init__(self, brand):
        self.brand = brand

    def display_info(self):
        return f"Vehicle: {self.brand}"

class Car(Vehicle):
    def __init__(self, brand, model):
        super().__init__(brand)
        self.model = model

    def display_info(self):
        return f"Car: {self.brand} {self.model}"

class Truck(Vehicle):
    def __init__(self, brand, capacity):
        super().__init__(brand)
        self.capacity = capacity

    def display_info(self):
        return f"Truck: {self.brand}, Capacity: {self.capacity} tons"

vehicle = Vehicle("Generic")
car = Car("Toyota", "Camry")
truck = Truck("Ford", 5)

print(vehicle.display_info())  
print(car.display_info()) 
print(truck.display_info())  
