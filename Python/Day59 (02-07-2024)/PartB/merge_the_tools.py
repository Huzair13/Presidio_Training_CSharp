def merge_the_tools(string, k):
    n = len(string)
    split_numbers = n // k 
    result = [string[i:i + k] for i in range(0, n, k)]
    
    for substr in result:
        seen = set()
        unique_chars = []
        for char in substr:
            if char not in seen:
                seen.add(char)
                unique_chars.append(char)
        print(''.join(unique_chars))
