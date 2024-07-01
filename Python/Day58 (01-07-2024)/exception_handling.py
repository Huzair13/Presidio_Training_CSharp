#specific Eception - one exception handling
def divide(x, y):
    try:
        result = x / y
    except ZeroDivisionError:
        print("Error: Division by zero!")
    else:
        print(f"{x} divided by {y} is {result}")
    finally:
        print("Division operation completed.")

divide(10, 2)  
divide(10, 0)   

#multiple Exception
def fecth_element(lst, index):
    try:
        result = lst[index]
    except IndexError:
        print(f"Error: Index {index} is out of range!")
    except TypeError:
        print("Error: Invalid index type!")
    else:
        print(f"Element at index {index}: {result}")

my_list = [1, 2, 3]
fecth_element(my_list, 1)  
fecth_element(my_list, 5)    
fecth_element(my_list, 'a')   

#custom exception

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

process_value(50)  
process_value(120) 


