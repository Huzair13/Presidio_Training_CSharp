class Solution:
    def convert(self, s: str, numRows: int) -> str:
        if numRows == 1:
            return s
    
        rows = [''] * numRows
        current = 0
        direction = 1
        
        for i in s:
            rows[current] += i
            if current == 0:
                direction = 1
            elif current == numRows - 1:
                direction = -1
            current += direction
        # print(rows)
        return ''.join(rows)
        