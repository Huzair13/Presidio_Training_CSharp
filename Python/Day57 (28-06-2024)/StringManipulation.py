# string padding
#left padding --- end of the string
text = "Python"  
padded_text = text.ljust(10)  
print(len(padded_text))
print(padded_text)  

#left padding with symbol
padded_text2 = text.ljust(10, '-') 
print(len(padded_text2)) 
print(padded_text2)  

#right padding - beginning of the string
padded_text3 = text.rjust(10)  
print(len(padded_text3))
print(padded_text3)  

# right padding with symbols
padded_text4 = text.rjust(10,'$')  
print(len(padded_text4))
print(padded_text4)  

#center padding 
padded_text5 = text.center(10, '*')  
len(padded_text5)
print(padded_text5)  


#STRING SPLITTING
splitString = "Hello world, Welcome to great Kirikalan Magic Show"  
splitStringWords = splitString.split()  
print(splitStringWords)  

mobilesString = "samsung,apple,nokia,oneplus"  
mobiles = mobilesString.split(',')  
print(mobiles) 

mobilesString2 = "samsung+apple+nokia+oneplus"  
mobiles2 = mobilesString2.split('+')  
print(mobiles2) 

fruitsString = "apple-banana-orange-grape"  
fruits = fruitsString.split('-', maxsplit=2)  
print(fruits)  


#STRING FORMATTING
name = "Huzair"  
age = 22  
greeting = f"Hello, my name is {name} and I'm {age} years old."  
print(greeting)  

price = 12.3456  
formatted_price = f"The price is Rupees {price:.2f}"  
print(formatted_price)  


#ELIMINATING UNNECCESSARY CHARACTERS
uglyText = "!!!Hello, World!!!"  
clean_text = uglyText.strip("!")  
print(clean_text)  

#CONCAT STRINGS
string1 = "Huzair"  
string2 = "Ahmed"  
result = string1 + " " + string2  
print(result)  

delimiter = " "  
my_list = ["apple", "banana", "cherry"]  
result = delimiter.join(my_list)  
print(result)

#SEARCH IN THE STRING
searchString = 'Huzair Ahmed is a good boy working in Presidio Solutions'  
print(searchString.find('Huzair'))  
print(searchString.find('good'))  
print(searchString.find('Presidio'))  

print(searchString.index('Huzair'))  
print(searchString.index('good'))  
# print(searchString.index('Genspark'))  Gives error

#REVERSE THE STRING
name = "Ahmed"  
print(name[::-1])  

#REGULAR EXPRESSION FOR PATTERN SEARCH
import re  
string = "Welcome to Great Kirikalan Magic Show"  
pattern = r"Great"  
match = re.search(pattern, string)  
if match:  
    print("Match found!")  
else:  
    print("Match not found.")  

#OTHER METHODS
#Capitalize
txt = "hello, and welcome to Huzair's World."
x = txt.capitalize()
print (x)

txt = "huzair is FUN!"
x = txt.capitalize()
print (x)

#casefold
x = txt.casefold()
print(x)

#upper
print(txt.upper())

#lower
print(txt.lower())

#title
print(txt.title())

#swapcase
print(txt.swapcase())

#isAlphaNumeric
word = 'number32'
print(word.isalnum())

#isUpper()
word = 'HUZAIR'
print(word.isupper())

#isLower()
word = 'huzair'
print(word.islower())

word = "123"
print(word.isdigit())
