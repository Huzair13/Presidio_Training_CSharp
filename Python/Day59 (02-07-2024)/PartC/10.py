class Solution:
    def fullJustify(self, words: List[str], maxWidth: int) -> List[str]:
        result = []
        current_line = []
        current_length = 0
        
        for word in words:
            if current_length + len(current_line) + len(word) > maxWidth:
                if len(current_line) == 1:
                    # Left justify if there's only one word in the line
                    result.append(current_line[0] + ' ' * (maxWidth - len(current_line[0])))
                else:
                    # Calculate spaces between words
                    total_spaces = maxWidth - current_length
                    spaces_between_words = total_spaces // (len(current_line) - 1)
                    extra_spaces = total_spaces % (len(current_line) - 1)
                    
                    justified_line = ''
                    for i in range(len(current_line) - 1):
                        justified_line += current_line[i]
                        justified_line += ' ' * spaces_between_words
                        if i < extra_spaces:
                            justified_line += ' '
                    
                    justified_line += current_line[-1]  
                    result.append(justified_line)
                current_line = []
                current_length = 0
            
            current_line.append(word)
            current_length += len(word)
        last_line = ' '.join(current_line)
        last_line += ' ' * (maxWidth - len(last_line))
        result.append(last_line)
        
        return result