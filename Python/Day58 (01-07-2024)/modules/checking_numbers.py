def print_primes(limit):
    primes = []
    for num in range(2, limit + 1):
        is_prime = True
        for i in range(2, int(num ** 0.5) + 1):
            if num % i == 0:
                is_prime = False
                break
        if is_prime:
            primes.append(num)
            print(num, end=' ')
    print()
    
def print_even_numbers(limit):
    evens =[]
    for num in range(1,limit+1):
        is_even =True
        if(num%2 !=0):
            is_even =False
        if(is_even):
            evens.append(num)
    return evens