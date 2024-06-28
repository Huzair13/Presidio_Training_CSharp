example_tuple = ("Huzair","Ahmed","Hello")
print(example_tuple)

values : tuple[int | str, ...] = (1,2,4,"Geek")
print(values)

values2 : tuple[str| float] = ("Hello", 2.10)
print(values2)

example2_for_tuple = tuple(("Hello","World","Welcome"))
print(example2_for_tuple)


#Accessing tuples
print(example_tuple[0])
print(example2_for_tuple[-1])

#concat of tuples
print(example_tuple + example2_for_tuple)

example3_for_tuples = (example_tuple,example2_for_tuple)
print(example3_for_tuples)

#tuple repeating
repeat_tuple = ("Huzair",)*3
print(repeat_tuple)

#tuple slicing
# Creating a tuple
numbers = (0, 1, 2, 3, 4, 5, 6, 7, 8, 9)

# Slicing the tuple
slice1 = numbers[2:5]
slice2 = numbers[:4]
slice3 = numbers[5:]
slice4 = numbers[::2]
slice5 = numbers[1:8:2]

print("Original tuple:", numbers)
print("Slice 1 (numbers[2:5]):", slice1)
print("Slice 2 (numbers[:4]):", slice2)
print("Slice 3 (numbers[5:]):", slice3)
print("Slice 4 (numbers[::2]):", slice4)
print("Slice 5 (numbers[1:8:2]):", slice5)
