class Solution:
    def multiply(self, num1: str, num2: str) -> str:
        len1, len2 = len(num1), len(num2)
        result = [0] * (len1 + len2)
        for i in range(len1 - 1, -1, -1):
            for j in range(len2 - 1, -1, -1):
                product = int(num1[i]) * int(num2[j])
                sum_val = product + result[i + j + 1]
                result[i + j] += sum_val // 10
                result[i + j + 1] = sum_val % 10
        
        while len(result) > 1 and result[0] == 0:
            result.pop(0)
        
        return ''.join(map(str, result))
        