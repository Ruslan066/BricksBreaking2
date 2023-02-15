using System;
using System.Collections.Generic;
using System.Text;

namespace BricksBreaking2Core.Core
{
    [Serializable]
    public class ProcessInput
    {
        Field field;
        private int rowCount = 0;
        private int columnCount = 0;
        private int[] currentPostionCursor;
        Brick brick;
        public ProcessInput(Field field, int rowCount, int columnCount, int[] currentPostionCursor, Brick brick)
        {
            this.field = field;
            this.rowCount = rowCount;
            this.columnCount = columnCount;
            this.currentPostionCursor = currentPostionCursor;
            this.brick = brick;
        }
        public void Step()
        {

            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    currentPostionCursor[1] += 1;
                    if (currentPostionCursor[1] >= columnCount)
                        currentPostionCursor[1] = columnCount - 1;
                    break;
                case ConsoleKey.LeftArrow:
                    currentPostionCursor[1] -= 1;
                    if (currentPostionCursor[1] <= 0)
                        currentPostionCursor[1] = 0;
                    break;
                case ConsoleKey.DownArrow:
                    currentPostionCursor[0] += 1;
                    if (currentPostionCursor[0] >= rowCount)
                        currentPostionCursor[0] = rowCount - 1;
                    break;
                case ConsoleKey.UpArrow:
                    currentPostionCursor[0] -= 1;
                    if (currentPostionCursor[0] <= 0)
                        currentPostionCursor[0] = 0;
                    break;
                case ConsoleKey.Spacebar:
                    if (field.field[currentPostionCursor[0], currentPostionCursor[1]] != "-")
                        brick.Destroy();
                    break;
            }
        }
    }
}
