import modules.checking_numbers as checking_numbers
checking_numbers.print_primes(30)
evens = checking_numbers.print_even_numbers(10)
print(evens)

print(checking_numbers.__name__)

#import using alias name
import modules.checking_numbers as numbers_checking
numbers_checking.print_primes(20)

#import particular method
from modules.checking_numbers import print_even_numbers
print(print_even_numbers(50))

#variable modules
import modules.employee as variable_module
a = variable_module.employee1["age"]
print(a)

#built in modules
import platform
x = platform.system()
print(x)

x = dir(platform)
print(x)

import sys
print(dir(sys))
