def findPermutations(input_string):
    if len(input_string) == 0:
        return ['']

    permutations = []
    
    for i in range(len(input_string)):
        first_char = input_string[i]
        
        remaining_chars = input_string[:i] + input_string[i+1:]
        sub_permutations = findPermutations(remaining_chars)
        
        for perm in sub_permutations:
            permutations.append(first_char + perm)
    
    return permutations

input_string = input("Enter the String : ")
permutations = findPermutations(input_string)
print(f'Permutation of the given string ')
for perm in permutations:
    print(perm)
