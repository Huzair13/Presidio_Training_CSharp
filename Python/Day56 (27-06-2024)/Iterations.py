# FOR LOOPS
print("FOR LOOP USING RANGE :")
for i in range(1, 5):
    print(i)

#FOR LOOP - LIST
print("\nFOR LOOP USING LIST")
fruits = ["apple", "banana", "cherry"]
for fruit in fruits:
    print(fruit)

# WHILE LOOP
print("\nWHILE LOOP:")
count = 0
while count < 5:
    print(count)
    count += 1

#NESTED LOOPS
print("\nNESTED LOOPS:")
for i in range(1, 3):
    for j in range(1, 3):
        print(f"({i}, {j})")

# LOOPS IN DICTIONARY
print("\nLOOPS IN DICTIONARY:")
person = {"name": "Huzair", "age": 22, "city": "Salem"}

print("Keys:")
for key in person:
    print(key)

print("\nValues:")
for value in person.values():
    print(value)

print("\nKey-Value Pairs:")
for key, value in person.items():
    print(f"{key}: {value}")

# ENUMERATE 
print("\nENUMERATE:")
colors = ["red", "green", "blue"]

for index, color in enumerate(colors):
    print(f"Index {index}: {color}")

# LOOP CONTROLS
print("\nLOOP CONTROLS:")
numbers = [1, 2, 3, 4, 5]

for num in numbers:
    if num == 4:
        break 
    if num == 2:
        continue 
    print(num)
else:
    print("Loop finished")
