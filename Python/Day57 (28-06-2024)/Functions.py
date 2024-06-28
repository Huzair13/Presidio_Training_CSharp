#Functions with parameter
def square_of_number( num ):    
    return num**2     
answer = square_of_number(6)    
print( "Squared Number : ", answer )    
# print(square_of_numbers()) #Gives error since parameter is not passing

#Default arguments
def greet(name, message="Hello"):
    return f"{message}, {name}!"
print(greet("Alice")) 
print(greet("Bob", "Good morning")) 

#keyword arguments
def keyword_argument( argument1, argument2 ):    
    print("Argument 1 is: ", argument1)    
    print("Argument 2 is: ", argument2)  
keyword_argument( argument2 = 50, argument1 = 30)    

def my_function(**student):
  print("His last name is " + student["lname"])
my_function(fname = "Huzair", lname = "Ahmed")

#variable length arguments
def average(*args):
    if len(args) == 0:
        return 0.0
    return sum(args) / len(args)
average_of_numbers = average(10, 20, 30)
print(f"Average :  {average_of_numbers:.2f}")

#lambda functions
square_of_numbers_using_lambda = lambda x: x * x
print(square_of_numbers_using_lambda(4)) 

sum_of_numbers_using_lambda = lambda x,y: x + y
print(sum_of_numbers_using_lambda(4,22)) 


#nested Functions
def word():    
    string = 'Python functions Nested'    
    x = 5     
    def number():    
        print( string )   
        print( x )    
    number()    
word()  