class Solution {
public:
    void dfs(int i, int j, vector<vector<int>> &visited, vector<vector<char>> &grid) {
        // Base cases to check if the current cell is out of bounds, water, or already visited
        if (i < 0 || j < 0 || i >= grid.size() || j >= grid[0].size() || grid[i][j] == '0' || visited[i][j] == 1) {
            return;
        }

        // Mark the current cell as visited
        visited[i][j] = 1;

        // Define the possible moves (up, down, left, right)
        vector<int> rowCh = {-1, +1, 0, 0};
        vector<int> colCh = {0, 0, -1, +1};

        // Explore neighbors recursively
       // Explore neighbors recursively using defined moves
        for (int k = 0; k < rowCh.size(); k++) {
            dfs(i + rowCh[k], j + colCh[k], visited, grid);
        }
    }

    // Main function to count the number of islands in the grid
    int numIslands(vector<vector<char>>& grid) {
        int row = grid.size();
        int col = grid[0].size();
        int count = 0;

        // Use a 2D vector for the visited array, initialized with all elements set to 0
        vector<vector<int>> visited(row, vector<int>(col, 0));

        // Traverse the grid
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                // If the current cell is unvisited and part of an island, start DFS to mark connected land cells
                if (visited[i][j] == 0 && grid[i][j] == '1') {
                    dfs(i, j, visited, grid);
                    count++;
                }
            }
        }

        // Return the total number of islands
        return count;
    }
};
