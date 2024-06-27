# Take name, age, date of birth and phone print details in proper format
def printPersonalData(name, age, dob, phone):
    print("\n===== Person Details =====\n")
    print(f"Name          : {name}")
    print(f"Age           : {age}")
    print(f"Date of Birth : {dob}")
    print(f"Phone Number  : {phone}")
    print("\n==========================\n")

name = input("Enter your Name : ")
age = input("Enter your Age : ")
dob = input("Enter your DOB : ")
phone = input("Enter your Mobile Number : ")
printPersonalData(name, age, dob, phone)