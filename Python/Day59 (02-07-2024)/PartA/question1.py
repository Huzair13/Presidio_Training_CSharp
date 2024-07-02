def missingCharacters(s):
    # Write your code here
    # letters = ['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s', 't','u','v','w','x','y','z']
    letters = set('abcdefghijklmnopqrstuvwxyz')
    numbers = set('1234567890')
    given_letters =[]
    given_number =[]
    for i in s:
        if(i.isalpha()):
            given_letters.append(i)
        if(i.isdigit()):
            given_number.append(i)
            
    given_letters_set = set(given_letters)
    given_numbers_set = set(given_number)
    
    missing_letters = sorted(letters - given_letters_set)
    missing_numbers = sorted(numbers - given_numbers_set)
    
    missing_letters_string = ''.join(map(str,missing_letters))
    missing_numbers_string = ''.join(map(str,missing_numbers))
    
    result = missing_numbers_string + missing_letters_string
   
    return result
