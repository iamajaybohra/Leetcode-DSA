using System;
using System.Collections.Generic;

public class Solution {
    public int CharacterReplacement(string s, int k) {
        // Initialize variables
        int maxSubLength = int.MinValue;  // Maximum length of substring with at most k replacements
        int maxFreq = 0;  // Maximum frequency of any character in the current window
        Dictionary<char, int> map = new Dictionary<char, int>();  // Dictionary to store the frequency of characters
        int j = -1, i = 0;  // Pointers for the sliding window

        // Iterate through the string
        while (i < s.Length) {
            // Add the current character to the window
            if (!map.ContainsKey(s[i]))
                map[s[i]] = 0;
            
            map[s[i]]++;
            
            // Update the maximum frequency in the current window
            maxFreq = Math.Max(maxFreq, map[s[i]]);

            // Check if the number of replacements needed is more than k
            if ((i - j) - maxFreq > k) {
                // Move the left pointer of the window to the right
                j++;
                // Update the frequency of the character going out of the window
                map[s[j]]--;
            }

            // Update the maximum length of the substring
            maxSubLength = Math.Max(maxSubLength, i - j);

            // Move the right pointer to the next character
            i++;
        }

        // Return the maximum length of the substring
        return maxSubLength;
    }
}