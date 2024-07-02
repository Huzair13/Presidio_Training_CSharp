class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        total_moves = m + n - 2
        right_moves = m - 1
        down_moves = n - 1
        paths = math.factorial(total_moves) // (math.factorial(right_moves) * math.factorial(down_moves))
        return paths
