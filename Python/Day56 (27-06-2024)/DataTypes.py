# Integer - immutable
intExample = 42
print(f"Integer: {intExample}")
print(type(intExample))
print()

# Float - immutable
floatExample = 3.14
print(f"Float: {floatExample}")
print(type(floatExample))
print()

# String - immutable
stringExample = "Hello, World!"
print(f"String: {stringExample}")
print(type(stringExample))
print()

# List - mutable
listExample = [1, 2, 3, 4, 5]
print(f"List: {listExample}")
print(type(listExample))
print()

# Tuple - immutable
tupleExample = (1, 2, 3)
print(f"Tuple: {tupleExample}")
print(type(tupleExample))
print()

# Dictionary - mutable
dictExample = {'name': 'Alice', 'age': 25}
print(f"Dictionary: {dictExample}")
print(type(dictExample))
print()

# Set - mutable
setExample = {1, 2, 3, 4, 5}
print(f"Set: {setExample}")
print(type(setExample))
print()

# Boolean - immutable
boolExample = True
print(f"Boolean: {boolExample}")
print(type(boolExample))
print()

# None Type - immutable
noneExample = None
print(f"NoneType: {noneExample}")
print(type(noneExample))
print()

# Complex - immutable
complexTypeExample = 1 + 2j
print(f"Complex number: {complexTypeExample}")
print(type(complexTypeExample))
print()

# Bytes - immutable
bytesExample = b'hello'
print(f"Bytes: {bytesExample}")
print(type(bytesExample))
print()

# Bytearray - mutable
byteArrayExample = bytearray(b'hello')
print(byteArrayExample)      
print(type(byteArrayExample))

# Modifying bytearray
byteArrayExample[0] = 87 
print(byteArrayExample)   

# Range - immutable
rangeExample = range(5)
print(f"Range: {list(rangeExample)}")
print(type(rangeExample))
print()

# Frozen Set - immutable
frozenSetExample = frozenset([1, 2, 3, 4, 5])
print(f"Frozenset: {frozenSetExample}")
print(type(frozenSetExample))
print()
