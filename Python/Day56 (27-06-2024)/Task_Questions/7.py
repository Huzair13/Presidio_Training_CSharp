# Take 10 numbers and find the average of all the prime numbers in the collection

def isPrime(number):
    if number <= 1:
        return False 
    for i in range(2, number//2 + 1):
        if number % i == 0:
            return False  
    return True

def averageOfPrimes(numbers):
    prime_numbers = [num for num in numbers if isPrime(num)]
    if not prime_numbers:
        return None 
    return sum(prime_numbers) / len(prime_numbers)

numbers = list(map(int, input("Enter the 10 Number : ").split()))
average = averageOfPrimes(numbers)

if average is None:
    print("NO prime Numbers Found")
else:
    print(f"Averag :  {average}")
