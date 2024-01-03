using System;
using System.Collections.Generic;

public class Solution {
    // Function to check if a character is an opening bracket
    private bool IsOpenBracket(char ch) {
        return ch == '(' || ch == '{' || ch == '[';
    }

    // Function to check if a given string has valid parentheses
    public bool IsValid(string s) {
        // Mapping of closing brackets to their corresponding opening brackets
        Dictionary<char, char> map = new Dictionary<char, char> {
            {')', '('},
            {']', '['},
            {'}', '{'}
        };

        // Stack to keep track of opening brackets
        Stack<char> st = new Stack<char>();

        // Iterate through each character in the input string
        foreach (char ch in s) {
            if (IsOpenBracket(ch)) {
                // If the character is an opening bracket, push it onto the stack
                st.Push(ch);
            } else if (st.Count != 0) {
                // If the character is a closing bracket and the stack is not empty
                // Check if the top of the stack matches the corresponding opening bracket
                if (st.Peek() != map[ch]) {
                    return false; // Mismatch, not a valid expression
                }
                st.Pop(); // Pop the matching opening bracket from the stack
            } else {
                return false; // Closing bracket without a corresponding opening bracket
            }
        }

        // Check if there are any remaining opening brackets in the stack
        return st.Count == 0;
    }
}

class Program {
    static void Main() {
        // Example usage of the Solution class
        Solution solution = new Solution();
        string input = "({[]})";
        bool isValid = solution.IsValid(input);
        Console.WriteLine($"Is '{input}' valid? {isValid}");
    }
}
