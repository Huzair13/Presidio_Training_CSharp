class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        substring =[]
        longest_substring=""
        small_substring = ""
        if(len(s)==1):
            return 1
        if(len(s)==0):
            return 0

        for i in s:
            if i not in small_substring:
                small_substring+=i
            else:
                if(len(longest_substring)<len(small_substring)):
                    longest_substring = small_substring
                substring.append(small_substring)
                index = small_substring.find(i)
                small_substring = small_substring[index+1:]
                small_substring+=i

        if(len(small_substring)>len(longest_substring)):
            longest_substring = small_substring
        print(longest_substring)

        return len(longest_substring)

        