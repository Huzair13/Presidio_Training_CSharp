import datetime
import pandas as pd
from validate_email import validate_email
import xlwt
import xlrd

class Employee:
    def __init__(self, name, dob, phone, email):
        self.name = name
        self.dob = dob
        self.phone = phone
        self.email = email
        self.age = self.calculate_age()

    def calculate_age(self):
        today = datetime.date.today()
        dob_date = datetime.datetime.strptime(self.dob, "%d-%m-%Y").date()
        age = today.year - dob_date.year - ((today.month, today.day) < (dob_date.month, dob_date.day))
        return age
    
def validate_phone(phoneNumber):
    try:
        if(len(phoneNumber)<10 or len(phoneNumber)>10):
            raise ValueError("Invalid Phone Number")
        return True 
    except ValueError:
        return False

def validate_dob(dob):
    try:
        dob_date = datetime.datetime.strptime(dob, "%d-%m-%Y").date()
        day, month, year = dob_date.day, dob_date.month, dob_date.year
        if not (1 <= day <= 31 and 1 <= month <= 12 and year >= 1900 and year <= datetime.date.today().year):
            raise ValueError("Invalid date components.")
        if dob_date > datetime.date.today():
            raise ValueError("Date of birth cannot be in the future.")
        return True
    except ValueError:
        return False

def read_from_excel(file_path):
    employee_list = []
    try:
        workbook = xlrd.open_workbook(file_path)
        sheet = workbook.sheet_by_index(0)

        for row in range(1, sheet.nrows):
            name = sheet.cell_value(row, 0)
            try:
                dob_value = sheet.cell_value(row, 1)
                if isinstance(dob_value, float):
                    dob = xlrd.xldate_as_tuple(dob_value, workbook.datemode)
                    dob_date = datetime.datetime(*dob).date()
                    dob_str = dob_date.strftime("%d-%m-%Y")
                else:
                    dob_str = str(dob_value).strip() 
                    raise ValueError("Invalid date format.")
            except ValueError as e:
                print(f"Skipping row {row + 1}: {e}")
                continue
            
            phone = str(int(sheet.cell_value(row, 2)))
            email = sheet.cell_value(row, 3)
            
            if not validate_dob(dob_str):
                print(f"Skipping invalid DOB for {name} at row {row + 1}.")
                continue
            
            if not validate_phone(phone):
                print(f"Skipping invalid Phone Number for {name} at row {row + 1}.")
                continue
            
            if not validate_email(email):
                print(f"Skipping invalid Email for {name} at row {row + 1}.")
                continue

            employee = Employee(name, dob_str, phone, email)
            employee_list.append(employee)
        
    except xlrd.XLRDError as e:
        print(f"Error reading Excel file: {e}")

    return employee_list

def save_to_excel(employee_list):
    workbook = xlwt.Workbook()
    sheet = workbook.add_sheet("Employee Details")

    headers = ["Name", "DOB", "Phone", "Email", "Age"]
    for col, header in enumerate(headers):
        sheet.write(0, col, header)

    for row, employee in enumerate(employee_list, start=1):
        sheet.write(row, 0, employee.name)
        sheet.write(row, 1, employee.dob)
        sheet.write(row, 2, employee.phone)
        sheet.write(row, 3, employee.email)
        sheet.write(row, 4, employee.age)
    
    workbook.save("employee_details.xls")

def main():
    employees = []
    while True:
        print("\nEmployee Details Manager 🎉😎")
        print("1. Enter Employee Details")
        print("2. Save to Excel")
        print("3. Bulk Read from Excel")
        print("4. Exit")
        choice = input("Enter your choice (1-4): ")

        if choice == "1":
            name = input("Enter Employee Name: ")
            dob = input("Enter Employee DOB (DD-MM-YYYY): ")

            if not validate_dob(dob):
                print("Invalid DOB 👎! Please enter valid DOB")
                continue

            phone = input("Enter Employee Mobile Number: ")

            if not validate_phone(phone):
                print("Invalid Mobile Number 👎! Please enter valid mobile Number")
                continue

            email = input("Enter Employee E-Mail: ")

            if not validate_email(email):
                print("Invalid Email 👎! Please enter a valid email address.")
                continue

            employee = Employee(name, dob, phone, email)
            employees.append(employee)
            print("Employee Details Added!")

        elif choice == "2":
            if not employees:
                print("No employee details to save!")
                continue
            save_to_excel(employees)
            print("Employee details saved to Excel file.")

        elif choice == "3":
            file_path = input("Enter the path to the Excel file: ")
            employees += read_from_excel(file_path)
            for i in employees:
                print("Name:",i.name," ","Age :",i.age)            

        elif choice == "4":
            print("Exiting Program.")
            break

        else:
            print("Invalid choice! Please enter a number between 1 and 4.")

if __name__ == "__main__":
    main()
