public class Solution {
    
    public int FindKthLargest(int[] nums, int k) {
        return qs(nums, nums.Length-k, 0, nums.Length-1);
        
    }
    int qs(int[] nums, int k, int l, int r){
        
            int pivot = partition(nums,l, r);
            if(k==pivot){
                return nums[pivot];
                
            }else if(k<pivot){
                return qs(nums, k, l, pivot-1);
            }else{
                return qs(nums, k, pivot+1,r);
            }

        
    }
    int partition(int[] nums, int l, int r){
        int pivot = nums[r], k=l;
        for(int i=l;i<r;i++){
            if(nums[i]<=pivot){
                (nums[k],nums[i]) = (nums[i], nums[k]);
                k++;
            }
        }
        (nums[k],nums[r]) = (nums[r], nums[k]);
        return k;
    }
}