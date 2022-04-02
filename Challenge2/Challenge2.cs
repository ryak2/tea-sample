namespace Challenge2;
public class Challenge2
{
    /// <summary>
    /// This method implements the following specification:
    /// 
    /// Implement MaxDistance to return the maximum distance for a pair of letters in the string input. 
    /// The maximum distance is defined as the largest difference between any input[i] and input[j] where 
    /// i < j and input[i] comes before input[j] in the alphabet.
    /// 
    /// Runs in O(n) time and uses O(1) memory.
    /// 
    /// </summary>
    /// <param name="input">A string to calculate the max distance for.</param>
    /// <returns>The maximum distance, according to the specification.</returns>
   public static int MaxDistance(string input)
   {
       // Handle invalid input and the base case.
       if (input == null || input.Length < 2)
       {
           return 0;
       }

       // Assumption: The requirements state to use the order of "the alphabet" for comparisons.  I am interpreting
       // this to mean that capital and lowercase letters are interchangeable for ordering purposes.
       
       // As usual, I would verify this with the product owner in a real product.

       // I take advantage of the characters all being lowercase later to efficiently calculate the distance.  If we instead
       // needed to sort capital letters before lowercase (for example), i would use a different comparison method.
       input = input.ToLower();

       // Iterate through the string.  Keep track of the smallest character we have seen so far.
       // Also keep track of the largest distance seen.  When we reach the end of the string,
       // the largestDistanceSeen is the max distance.
       char smallestSeenCharacter = input[0];
       int largestDistanceSeen = 0;
       for (int i=1; i<input.Length; i++)
       {
           int distance = GetDistanceBetween(smallestSeenCharacter, input[i]);
           largestDistanceSeen = Math.Max(distance, largestDistanceSeen);
           smallestSeenCharacter = (char)Math.Min(input[i], smallestSeenCharacter);
       }
       return largestDistanceSeen;
   }

    /// <summary>
    /// Returns the positive distance between the first character and the second character.
    /// 
    /// Return 0 if the characters are the same or if the second character is not larger than the first.
    /// 
    /// </summary>
    /// <param name="first">the first character</param>
    /// <param name="second">the second character</param>
    /// <returns>The distance between first and second, or 0 if first >= second</returns>
   public static int GetDistanceBetween(char first, char second)
   {
       if (first >= second)
       {
           return 0;
       }

       return (byte)second - (byte)first - 1;
   }
}
