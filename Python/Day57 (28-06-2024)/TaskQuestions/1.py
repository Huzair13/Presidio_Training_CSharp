# 1) Longest Substring Without Repeating Characters. That is in a given string find the longest substring that does not contain any character twice.

# string = "ABBCCDEFGHIELMMA"
string ="AABBQWERTYUIOKKLJHZXCVBNMQWE"
string_dictionary ={}
longest_substring =""
small_substring =""
for char in string:
    if(char in string_dictionary):
        string_dictionary[char]+=1
        if(len(small_substring)>len(longest_substring)) :
            longest_substring = small_substring
        small_substring=""
    else:
        string_dictionary[char]=1
        small_substring = small_substring+char
print(longest_substring)