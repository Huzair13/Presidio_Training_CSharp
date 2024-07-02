from collections import defaultdict
class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        anagram_groups = defaultdict(list)
        
        for word in strs:
            sorted_word = tuple(sorted(word))
            anagram_groups[sorted_word].append(word)

        for group in anagram_groups.values():
            print(group)
        
        return list(anagram_groups.values())