print("hello world")

#string input
name = input("Enter your name: ")
print("Given Name: " + name)

#number input
number = int(input("Enter the Numbers: "))
#print("Given Number: "+number) #gives error (cannot convert int to str)
print(f'Given Number : {number}')

#List As Input
lst = []
n = int(input("Enter number of elements : "))
for i in range(0, n):
    ele = int(input())
    lst.append(ele)  
print(lst)

#multiple Input
x, y = input("Enter x and y : ").split()
print(f'x : {x}')
print(f'y : {y}')

a, b = map(int, input("Enter a and b : ").split())
print(f'a : {a}')
print(f'b : {b}')

#list input in single line using map
user_input_list = list(map(int, input("Enter the List of Number : ").split()))
print(user_input_list)


