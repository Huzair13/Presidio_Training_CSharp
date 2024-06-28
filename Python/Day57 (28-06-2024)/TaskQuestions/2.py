# 2) Print the list of prime numbers up to a given number
def is_prime(num):
    if num <= 1:
        return False
    for i in range(2, num//2 + 1):
        if num % i == 0:
            return False
    return True

def list_primes(n):
    return [x for x in range(2, n + 1) if is_prime(x)]

n = int(input("Enter the N value : "))
print(list_primes(n))
