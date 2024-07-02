class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:
        nums.sort() 
        close_sum_value = float('inf')
        n = len(nums)

        for i in range(n - 2):
            left = i + 1
            right = n - 1

            while left < right:
                sum_value = nums[i] + nums[left] + nums[right]
                if sum_value == target:
                    return sum_value

                if abs(sum_value - target) < abs(close_sum_value - target):
                    close_sum_value = sum_value

                if sum_value < target:
                    left += 1
                else:
                    right -= 1

        return close_sum_value
