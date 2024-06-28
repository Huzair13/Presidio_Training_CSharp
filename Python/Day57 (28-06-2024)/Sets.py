#SET INTEGER TYPE
numbers = {100, 200, 300, 400, 500}
print('Numbers : ', numbers)

#SET STRING TYPE
vowel_letters = {'a', 'e', 'i', 'o', 'u'}
print('Vowel Letters:', vowel_letters)

# MIXED TYPE SET
mixed_set = {'Hello', 200, -10, 'Bye'}
print('Set of mixed data types:', mixed_set)

#Empty Sets
new_set = set()
print(type(new_set))

# Eliminate Duplicates
numbers = {1, 14, 16,34, 34, 1}
print(numbers)

#update
companies = {'Presidio', 'Genspark'}
tech_companies = ['apple', 'google', 'apple']

companies.update(tech_companies)
print(companies)

#discard
vehicles = {'car', 'bus', 'cycle'}
print(vehicles)
removedValue = vehicles.discard('bus')
print(vehicles)

#add
vehicles = {'car', 'bus', 'cycle'}
print(vehicles)
removedValue = vehicles.add('bike')
print(vehicles)


#union
numbers1 = {1, 3, 5}
numbers2 = {0, 2, 4}
print('Union using |:', numbers1 | numbers2)
print('Union using union():', numbers1.union(numbers2)) 

#intersections
print('Intersection using &:', numbers1 & numbers1)
print('Intersection using intersection():', numbers1.intersection(numbers1))

#difference
print('Difference using &:', numbers1 - numbers2)
print('Difference using difference():', numbers1.difference(numbers2)) 

#symmetric difference
A = {2, 3, 5}
B = {1, 2, 6}
print('using ^:', A ^ B)
print('using symmetric_difference():', A.symmetric_difference(B)) 