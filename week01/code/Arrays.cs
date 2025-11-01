public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN FOR SOLVING MultiplesOf PROBLEM:
        // Step 1: Create a new array of doubles with size 'length'
        // Step 2: Use a for loop to iterate from 0 to length-1 (array indices)
        // Step 3: For each position i in the array, calculate the multiple:
        //         - The first multiple (i=0) should be number * 1
        //         - The second multiple (i=1) should be number * 2
        //         - The nth multiple (i=n-1) should be number * n
        //         - So the formula is: number * (i + 1)
        // Step 4: Store each calculated multiple in the corresponding array position
        // Step 5: Return the completed array

        // Step 1: Create array of the specified length
        double[] multiples = new double[length];
        
        // Step 2-4: Loop through each position and calculate the multiple
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple using formula: number * (position + 1)
            multiples[i] = number * (i + 1);
        }
        
        // Step 5: Return the array containing all multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN FOR SOLVING RotateListRight PROBLEM:
        // Example: data = {1,2,3,4,5,6,7,8,9}, amount = 3
        // Result should be: {7,8,9,1,2,3,4,5,6}
        // 
        // Key insight: "Rotate right by 3" means take the last 3 elements and move them to the front
        // 
        // Step 1: Calculate the split point where we need to cut the list
        //         - If we rotate right by 'amount', we take the last 'amount' elements
        //         - The split point is at index: data.Count - amount
        //         - Elements from this point to the end will move to the front
        // 
        // Step 2: Create two sublists using GetRange():
        //         - rightPart: elements that will move to the front (last 'amount' elements)
        //         - leftPart: elements that will move to the back (remaining elements)
        // 
        // Step 3: Clear the original list
        // Step 4: Add the rightPart first (these go to the front after rotation)
        // Step 5: Add the leftPart second (these go to the back after rotation)

        // Step 1: Calculate the split point
        int splitPoint = data.Count - amount;
        
        // Step 2: Create the two parts using list slicing
        // rightPart: from splitPoint to the end (these will become the new beginning)
        List<int> rightPart = data.GetRange(splitPoint, amount);
        
        // leftPart: from beginning to splitPoint (these will become the new end)
        List<int> leftPart = data.GetRange(0, splitPoint);
        
        // Step 3: Clear the original list to prepare for reconstruction
        data.Clear();
        
        // Step 4: Add rightPart first (the elements that were at the end now go to the front)
        data.AddRange(rightPart);
        
        // Step 5: Add leftPart second (the elements that were at the beginning now go to the back)
        data.AddRange(leftPart);
    }
}
