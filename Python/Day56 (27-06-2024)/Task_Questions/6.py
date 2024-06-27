# Find if the given number is prime 
def is_prime(number):
    if number <= 1:
        return False 
    
    for i in range(2, number//2+1):
        if number % i == 0:
            return False
    return True

num1 = int(input("Enter the Number : "))
if is_prime(num1):
    print(f"{num1} is a prime number")
else:
    print(f"{num1} is not a prime number")
