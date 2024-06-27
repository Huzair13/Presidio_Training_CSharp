#LIST - CREATING
print()
fruits = ["apple", "banana", "cherry", "dates", "kiwi"]
print(f"Fruits list: {fruits}")
print()

#LIST - ACCESSS
print()
print(f"First : {fruits[0]}")     
print(f"Second : {fruits[1]}")    
print(f"Last : {fruits[-1]}")
print()

# SLICING
print()
print(f"First 3 fruits: {fruits[:3]}")
print(f"Last 2 fruits: {fruits[-2:]}")
print()

# MODIFYING ELEMENT
print()
fruits[1] = "Cucumber"
print(f"Modified list: {fruits}")
print()

# ADDING ELEMENT
print()
fruits.append("MANGO")
print(f"Fruits after Add : {fruits}")
print()

# REMOVE ELEMENT
print()
removed_fruit = fruits.pop(3)
print(f"Removed fruit at index 3: {removed_fruit}")
print(f"Fruits list after removal: {fruits}")
print()

# USING LOOPS FOR LIST ITERATION
print()
for fruit in fruits:
    print(fruit)
print()

print()
numbers = [1, 2, 3, 4, 5]
squared_numbers = [num ** 2 for num in numbers]
print(f"Original numbers: {numbers}")
print(f"Squared numbers: {squared_numbers}")
