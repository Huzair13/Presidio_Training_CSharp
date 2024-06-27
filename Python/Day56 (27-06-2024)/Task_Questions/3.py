# Take name and gender print greet with salutation
def greetWithSalutaion(name, gender):
    if gender.lower() == "male":
        print(f"Hello, Mr. {name}!")
    elif gender.lower() == "female":
        print(f"Hello, Ms. {name}!")
    else:
        print(f"Hello, {name}!")  

name1 = input("Enter your Name : ")
gender1 = input("Enter your gender : ")
greetWithSalutaion(name1, gender1)