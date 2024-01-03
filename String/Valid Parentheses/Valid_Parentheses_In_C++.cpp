class Solution {
private:
    // Function to check if a character is an opening bracket
    bool isOpenBracket(char ch) {
        if(ch == '(' || ch == '[' || ch == '{') {
            return true;
        }
        return false;
    }

public:
    // Function to check if a given string has valid parentheses
    bool isValid(string s) {
        // Mapping of closing brackets to their corresponding opening brackets
        unordered_map<char, char> map;
        map[')'] = '(';
        map[']'] = '[';
        map['}'] = '{';

        // Stack to keep track of opening brackets
        stack<char> st;

        // Iterate through each character in the input string
        for(int i = 0; i < s.length(); i++) {
            if(isOpenBracket(s[i])) {
                // If the character is an opening bracket, push it onto the stack
                st.push(s[i]);
            } else if(st.size() != 0) {
                // If the character is a closing bracket and the stack is not empty
                // Check if the top of the stack matches the corresponding opening bracket
                if((st.top() - map[s[i]]) != 0) {
                    return false; // Mismatch, not a valid expression
                }
                st.pop(); // Pop the matching opening bracket from the stack
            } else {
                return false; // Closing bracket without a corresponding opening bracket
            }
        }

        // Check if there are any remaining opening brackets in the stack
        return st.size() != 0 ? false : true;
    }
