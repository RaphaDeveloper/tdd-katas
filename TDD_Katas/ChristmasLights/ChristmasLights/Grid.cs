namespace ChristmasLights
{
    public class Grid
    {
        private bool[,] grid = new bool[3, 3];
        private int[,] grid2 = new int[3, 3];

        #region Turn On

        public void TurnOn(int firstColumn, int firstLine, int lastColumn, int lastLine)
        {
            ExecuteActionOnGridsColumn(TurnOn, firstColumn, firstLine, lastColumn, lastLine);
        }

        public void TurnOn(int column, int line)
        {
            grid[column, line] = true;
            grid2[column, line]++;
        }

        #endregion

        #region Turn Off

        public void TurnOff(int firstColumn, int firstLine, int lastColumn, int lastLine)
        {
            ExecuteActionOnGridsColumn(TurnOff, firstColumn, firstLine, lastColumn, lastLine);
        }

        public void TurnOff(int column, int line)
        {
            grid[column, line] = false;

            if (grid2[column, line] > 0)
                grid2[column, line]--;
        }

        #endregion

        #region Toggle

        public void Toggle(int firstColumn, int firstLine, int lastColumn, int lastLine)
        {
            ExecuteActionOnGridsColumn(Toggle, firstColumn, firstLine, lastColumn, lastLine);
        }

        public void Toggle(int column, int line)
        {
            grid[column, line] = !grid[column, line];
            grid2[column, line] += 2;
        }

        #endregion

        private static void ExecuteActionOnGridsColumn(Action<int, int> action, int firstColumn, int firstLine, int lastColumn, int lastLine)
        {
            for (int column = firstColumn; column <= lastColumn; column++)
            {
                for (int line = firstLine; line <= lastLine; line++)
                {
                    action(column, line);
                }
            }
        }

        public bool LightIsOn(int column, int line)
        {
            return grid[column, line];
        }

        public int GetBrightness(int column, int line)
        {
            return grid2[column, line];
        }
    }
}