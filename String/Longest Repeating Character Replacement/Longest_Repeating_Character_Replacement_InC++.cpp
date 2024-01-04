class Solution {
public:
    int characterReplacement(string s, int k) {
        // Initialize variables
        int maxSubLength = INT_MIN;  // Maximum length of substring with at most k replacements
        int maxFreq = 0;  // Maximum frequency of any character in the current window
        unordered_map<char, int> map;  // Map to store the frequency of characters
        int j = -1, i = 0;  // Pointers for the sliding window

        // Iterate through the string
        while (i < s.length()) {
            // Add the current character to the window
            map[s[i]]++;
            // Update the maximum frequency in the current window
            maxFreq = max(maxFreq, map[s[i]]);

            // Check if the number of replacements needed is more than k
            if ((i - j) - maxFreq > k) {
                // Move the left pointer of the window to the right
                j++;
                // Update the frequency of the character going out of the window
                map[s[j]]--;
            }

            // Update the maximum length of the substring
            maxSubLength = max(maxSubLength, i - j);

            // Move the right pointer to the next character
            i++;
        }

        // Return the maximum length of the substring
        return maxSubLength;
    }
};