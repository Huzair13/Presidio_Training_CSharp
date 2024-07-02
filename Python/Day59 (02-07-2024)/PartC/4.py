class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        def dfs(current, open, close):
            if open == n and close == n:
                result.append(current)
                return
            if open < n:
                dfs(current + '(', open + 1, close)
            if close < open:
                dfs(current + ')', open, close + 1)
        
        if n == 0:
            return []
        
        result = []
        dfs('', 0, 0)
        return result
            