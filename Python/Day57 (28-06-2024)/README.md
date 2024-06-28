---------------------------------------- String Manipulation -----------------------------------------

Learnt from

https://www.freecodecamp.org/news/python-string-manipulation-handbook/
https://www.javatpoint.com/string-manipulation-in-python

examples is on StringManipulation.py

*********** Padding Strings ***********
We can Add paddings to the String upto the certain length
-- eg --
let the string be "Python"
now when we print the len(string) === output : 6
when we add 

string.ljust(10) --- adds padding to the end of the string and the len(string) ---> 10
similarly for => rjust
instead of white space we can add symbols in padding
-- eg -- 
ljust(10,'-') , rjust(10,'-')


*********** Spliting Strings ***********
we can split the strings using --- split() function
-- eg --
string.split(); ---> outputs array of words in the string

split using any separators 
-- eg --
string.split(',')
string.split('+')

*********** Formatting String ***********
we can use f to format the string with variables
-- eg --
name = "Huzair"  
age = 22  
greeting = f"Hello, my name is {name} and I'm {age} years old."  

we can specify the decimal points
-- eg --
price = 12.3456  
formatted_price = f"The price is Rupees {price:.2f}"  

*********** Eliminate Unneccessary characters in the String ***********

we can eliminate unneccessary characters in the string using 
strip() function
-- eg --
uglyText = "---Hello, World---"  
clean_text = uglyText.strip("-") 

here it will print only hello, World and removes all '-' character which is unneccessary

*********** Concat Strings ***********

We can concat string using '+' operator
-- eg --
"Hey" + " " + "Hello" ----> concats as "Hey Hello"
"Hey" + "Hello" -----> concats as "HeyHello"

we can also concat using join() 
-- eg --
delimiter = " "  
my_list = ["apple", "banana", "cherry"]  
result = delimiter.join(my_list)  

*********** Search in the Strings ***********
we can search the substring of any string using
find() function

find() - returns the index value of the starting character
-- eg --
string = "Huzair Ahmed"
print(string.find("Ahmed"))

output --- 8 (Because "Ahmed" starts from the index 8)

or we can also use the function index() -- that also returns the index value

*********** Reverser the Strings ***********
we can reverse the string using the slicing
-- eg --
name = "Huzair"  
print(name[::-1])  -- > double :: is used with -1 index number to reverse the string

*********** Regular Expression pattern matching in the Strings ***********
we can import re library to check if any regular expression pattern matching in the string
we can use like
re.search(pattern,string)

*********** OTHER METHODS IN STRING ***********
capitalize() -- makes the first character alone upper case and makes others as lower case
casefold() -- makes the string to be lower case
upper() -- makes the string to UPPER case
lower() -- makes the string to LOWER case
title() -- makes the first letter on every words to be on capital
swapcase() -- if the character is lower it converts to upper and vice versa
isalnum() -- to check if the string is alpha numeric
isupper() -- checks if the string is upper
islower() -- checks if the string is lower
isdigit() -- checks if the string is digit



---------------------------------------- Functions -----------------------------------------
*********** Functions ***********
learnt from
https://www.javatpoint.com/python-functions
example codes is in Functions.py File

Things Learnt
1) Creating The functions
2) Passing argument to the function
3) Function Argumnents 
        (i)  Default Arguments
            eg:
                def greet(name, message="Hello"):
                    return f"{message}, {name}!"

        (ii) keyword arguments
            eg:
                def keyword_argument( argument1, argument2 ):    
                    print("Argument 1 is: ", argument1)    
                    print("Argument 2 is: ", argument2)  
                keyword_argument( argument2 = 50, argument1 = 30)
            eg2:
                def my_function(**student):
                    print("His last name is " + student["lname"])
                my_function(fname = "Huzair", lname = "Ahmed")

        (iii) Required Arguments
            eg:
                def square_of_number( num ):    
                    return num**2     
                answer = square_of_number(6)    
                print( "Squared Number : ", answer )    
                # print(square_of_numbers()) #Gives error since parameter is not passing

        (iv) variable length Arguments
            eg:
                def average(*args):
                    if len(args) == 0:
                        return 0.0
                    return sum(args) / len(args)
                average_of_numbers = average(10, 20, 30)

4) Lambda Function  -- anonymous functions
        we can declare the lambda function like below
            eg: square_of_numbers_using_lambda = lambda x: x * x

5) Nested Functions
        eg:
            def words():
                print("Hello")
                def Numbers():
                    print("World")
                Numbers()
            words()

-------------------------------------- Tuples -------------------------------------------
Learning from 
https://www.geeksforgeeks.org/tuples-in-python/

1) Tuple declarations 
    eg :
        values : tuple[int | str, ...] = (1,2,4,"Geek")
        example_tuple = ("Huzair","Ahmed","Hello")
        example2_for_tuple = tuple(("Hello","World","Welcome"))
2) Accessing Tuples
    eg : 
        using indexes 0 to n
            or using -1 to -n
        print(example_tuple[0])
        print(example2_for_tuple[-1])
3) concat tuples : example_tuple + example2_for_tuple
4) nesting tuples : (example_tuple , example2_for_tuple)
5) Slicing Tuple :
        eg :
            slice1 = numbers[2:5]
            slice2 = numbers[:4]
            slice3 = numbers[5:]
            slice4 = numbers[::2]
            slice5 = numbers[1:8:2]



----------------------------------------- Dictionaries --------------------------------------------------
Learning from
https://docs.python.org/3/tutorial/datastructures.html#dictionaries
https://www.geeksforgeeks.org/python-dictionary/

1) Craetion --- eg : employee_id = {'Huzair': 200, 'Ahmed': 300}
2) Accessing ---- eg : print(employee_id['Huzair'])
3) Modifying ---- eg : employee_id['Surya'] = 500
4) Checking Conditions ---- eg : print('Surya' in employee_id)
                                 print('Vishal' not in employee_id)
5) Sorting Dictionary ---- eg : print(sorted(employee_id))
6) Print Dictionary as List ----- eg : print("List Output",list(employee_id))
7) Nested Ditionary 
    eg :
        Dict = {'Huzair': {1: 'Presidio'},
                'Employee': {'Name': 'Huzair'}} 
        print(Dict['Huzair'])
        print(Dict['Huzair'][1])
        print(Dict['Employee']['Name'])


------------------------------------------ Sets ----------------------------------------
learning from

1) Creating Sets   
        eg :
            mixed_set = {'Hello', 200, -10, 'Bye'}
            numbers = {100, 200, 300, 400, 500}
2) Creating Empty Set
        eg:
            empty_set = set() ---- if use {} to create empty set then it will become as dictionary so we want to use set() to create empty set
3) Sets eliminates Duplicate Elements
        eg :
            numbers = {2, 4, 6, 6, 2, 8}
4) Update Sets from other collecions 
        eg :   
            companies = {'Presidio', 'Genspark'}
            tech_companies = ['apple', 'google', 'apple']
            companies.update(tech_companies)
5) discard() -- to remove an element from set
6) add() - to add new element to the set
7) union - we can use union() or | to perform union of sets
8) intersection - we can use intersection() or & to perfom intersection of the sets
9) difference - we can use difference() or - to perfom intersection of the sets
10) Symmetric Difference - we can use symmetric_difference() or ^ operator

