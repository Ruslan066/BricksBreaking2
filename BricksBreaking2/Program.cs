using System;
using BricksBreaking2Core;
using BricksBreaking2Core.Core;
using BricksBreaking2;

namespace BricksBreaking2
{
    internal class Program
    {
        static void Main()
        {
            int rowCount =5 ,columnCount =5;
            int click = 0;
            int score = 0;
            Field field = new Field(rowCount, columnCount, click, score);
            Console_UI ui = new Console_UI(rowCount,columnCount, field, click, score);
        }
    }
}
