public class Solution {
    // Helper function to perform depth-first search to mark connected land cells as visited
    private void fillTheLand(char[][] grid, int[][] isVisited, int cuI, int cuJ)
    {
        // Base cases to check if the current cell is out of bounds, visited, or not part of the land
        if (cuI < 0 || cuI >= grid.Length || cuJ < 0 || cuJ >= grid[0].Length || isVisited[cuI][cuJ] == 1 || grid[cuI][cuJ] == '0')
        {
            return;
        }

        // Mark the current cell as visited
        isVisited[cuI][cuJ] = 1;

        // Define the possible moves (up, down, left, right)
        int[] rowCh = { -1, +1, 0, 0 };
        int[] colCh = { 0, 0, -1, +1 };

        // Explore neighbors recursively
        for (int k = 0; k < rowCh.Length; k++)
        {
            fillTheLand(grid, isVisited, cuI + rowCh[k], cuJ + colCh[k]);
        }
    }

    // Main function to count the number of islands in the grid
    public int NumIslands(char[][] grid)
    {
        int row = grid.Length;
        int col = grid[0].Length;

        // Create a 2D array to keep track of visited cells
        int[][] isVisited = new int[row][];
        for (int i = 0; i < row; i++)
        {
            isVisited[i] = new int[col];

            // Initialize all cells as unvisited
            for (int j = 0; j < col; j++)
            {
                isVisited[i][j] = 0;
            }
        }

        int noOfIsland = 0;

        // Traverse the grid
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                // If the current cell is unvisited and part of an island, start DFS to mark connected land cells
                if (isVisited[i][j] == 0 && grid[i][j] == '1')
                {
                    fillTheLand(grid, isVisited, i, j);
                    noOfIsland++;
                }
            }
        }

        // Return the total number of islands
        return noOfIsland;
    }
}
