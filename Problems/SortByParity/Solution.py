# Online Python compiler (interpreter) to run Python online.
# Write Python 3 code in this online editor and run it.
class Solution(object):
    def sortArrayByParity(self, nums):
        """
        :type nums: List[int]
        :rtype: List[int]
        """
        return sorted(nums,key=lambda x: x % 2 == 0)
        
sol = Solution()
sol.sortArrayByParity([1, 3, 5, 2, 4, 8])
        