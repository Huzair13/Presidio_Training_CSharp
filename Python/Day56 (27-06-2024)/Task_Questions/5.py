# Add validation the entered  name, age, date of birth and phone print details in proper format

def printPersonalData(name, age, dob, phone):
    try:
        age = int(age)
        if age < 0 or age > 150:
            raise ValueError("Age must be between 0 and 150")
    except ValueError:
        print("Invalid age. Please enter a valid integer age.")
        return
    
    if not dob or len(dob) != 10 or dob[4] != '-' or dob[7] != '-':
        print("Invalid date of birth. Please use YYYY-MM-DD.")
        return
    
    if not phone or len(phone) < 10:
        print("Invalid phone number.")
        return
    
    if not name.strip():
        print("Invalid name. Please enter a valid name.")
        return
    
    print("\n===== Person Details =====\n")
    print(f"Name         : {name}")
    print(f"Age          : {age}")
    print(f"Date of Birth: {dob}")
    print(f"Phone Number : {phone}")
    print("\n==========================\n")
    
name = input("Enter your Name : ")
age = input("Enter your Age : ")
dob = input("Enter your DOB : ")
phone = input("Enter your Mobile Number : ")
printPersonalData(name, age, dob, phone)