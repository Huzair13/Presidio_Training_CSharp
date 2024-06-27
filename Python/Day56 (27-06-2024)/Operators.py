# Arithmetic Operators
a = 10
b = 5
add = a+b
sub = a-b
mul = a*b
div = a/b
modulus = a%b
exponential = a ** b
floorDiv = a//b

print(f"Addition: {a} + {b} = {add}")
print(f"Subtraction: {a} - {b} = {sub}")
print(f"Multiplication: {a} * {b} = {mul}")
print(f"Division: {a} / {b} = {div}")
print(f"Modulus: {a} % {b} = {modulus}")
print(f"Exponentiation: {a} ** {b} = {exponential}")
print(f"Floor Division: {a} // {b} = {floorDiv}")
print()

# Comparison Operators
print(f"Equal: {a} == {b} : {a == b}")
print(f"Not equal: {a} != {b} : {a != b}")
print(f"Greater than: {a} > {b} : {a > b}")
print(f"Less than: {a} < {b} : {a < b}")
print(f"Greater than or equal to: {a} >= {b} is {a >= b}")
print(f"Less than or equal to: {a} <= {b} is {a <= b}")
print()

# Logical Operators
c = True
d = False
print(f"Logical AND: {c} and {d}  :  {c and d}")
print(f"Logical OR: {c} or {d} : {c or d}")
print(f"Logical NOT: not {c} : {not c}")
print()

# Bitwise Operators
a = 10  # 1010 
b = 4   # 0100 
print(f"Bitwise AND: {a} & {b} : {a & b}")
print(f"Bitwise OR: {a} | {b} : {a | b}")
print(f"Bitwise XOR: {a} ^ {b} : {a ^ b}")
print(f"Bitwise NOT: ~{a} : {~a}")
print(f"Left Shift: {a} << 2 : {a << 2}")
print(f"Right Shift: {a} >> 2 : {a >> 2}")
print()

# Assignment Operators
a = 10
print(f"Initial value: a = {a}")
a += 5
print(f"Add AND: a += 5 results in a = {a}")
a -= 3
print(f"Subtract AND: a -= 3 results in a = {a}")
a *= 2
print(f"Multiply AND: a *= 2 results in a = {a}")
a /= 4
print(f"Divide AND: a /= 4 results in a = {a}")
a %= 3
print(f"Modulus AND: a %= 3 results in a = {a}")
a **= 2
print(f"Exponent AND: a **= 2 results in a = {a}")
a //= 2
print(f"Floor Division AND: a //= 2 results in a = {a}")
print()

# Identity Operators
e = [1, 2, 3]
f = [1, 2, 3]
g = e
print(f"e is f: {e is f}")
print(f"e is g: {e is g}")
print(f"e is not f: {e is not f}")
print()

# Membership Operators
h = [1, 2, 3]
print(f"1 in h: {1 in h}")
print(f"4 in h: {4 in h}")
print(f"1 not in h: {1 not in h}")
print(f"4 not in h: {4 not in h}")
print()
