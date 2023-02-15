using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BricksBreaking2Core.Core
{
    [Serializable]
    public class Print
    {

        Field field;
        private int rowCount = 0;
        private int columnCount = 0;
        private int[] currentPostionCursor;
        private int click;
        private int score;

        public Print(Field field, int rowCount, int columnCount, int[] currentPostionCursor, int click, int score)
        {
            this.field = field;
            this.rowCount = rowCount;
            this.columnCount = columnCount;
            this.currentPostionCursor = currentPostionCursor;
            this.click = click;
            this.score = score;
        }
        public void PrintStartMenu()
        {
            Console.Clear();

            string BRICKSText = "BRICKS";
            string BREAKINGText = "BREAKING";
            string STARTText = "START";
            string PressText = "Press any key to start.";

            string INSTRUCTIONSText = "INSTRUCTIONS";
            string Text1 = "Destroy all the bricks by clicking them in groups\nof the same color. The more you get at once, the higher the score.\n\n The only way to remove a single\nbrick is to zap it with a magic wand.";

            int centerX1 = (Console.WindowWidth / 2) - (BRICKSText.Length / 2);
            int centerX2 = (Console.WindowWidth / 2) - (BREAKINGText.Length / 2);
            int centerX3 = (Console.WindowWidth / 2) - (STARTText.Length / 2);
            int centerX4 = (Console.WindowWidth / 2) - (PressText.Length / 2);
            int centerX5 = (Console.WindowWidth / 2) - (INSTRUCTIONSText.Length / 2);
            int centerY = (Console.WindowHeight / 2);

            Console.SetCursorPosition(centerX1, centerY - 5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(BRICKSText);

            Console.SetCursorPosition(centerX2, centerY - 4);
            Console.WriteLine(BREAKINGText);

            Console.SetCursorPosition(centerX3, centerY - 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(STARTText);

            Console.SetCursorPosition(centerX4, centerY - 2);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(PressText);

            ConsoleKey key = Console.ReadKey().Key;

            Console.Clear();

            Console.SetCursorPosition(centerX5, centerY - 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(INSTRUCTIONSText);
            Console.ForegroundColor = ConsoleColor.Gray;

            string[] lines = Regex.Split(Text1, "\r\n|\r|\n");
            int left = 0;
            int top = (Console.WindowHeight / 2) - (lines.Length / 2) - 1;
            for (int i = 0; i < lines.Length; i++)
            {
                left = (Console.WindowWidth / 2) - (lines[i].Length / 2);

                Console.SetCursorPosition(left, top);
                Console.WriteLine(lines[i]);

                top = Console.CursorTop;
            }
            Console.SetCursorPosition(centerX3, centerY + 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(STARTText);


            Console.SetCursorPosition(0, centerY + 5);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Enter name: ");
            
            
        }
        public void PrintField(int click, int score)
        {
            Console.SetCursorPosition(0, 9);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press Spasebar\nfor delete");
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < (Console.WindowWidth / 4) + 1 + columnCount; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("▄");
            }
            Console.SetCursorPosition((Console.WindowWidth / 4) / 3, 2);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("SCORE");
            Console.SetCursorPosition((Console.WindowWidth / 4) / 3, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(score);
            Console.SetCursorPosition((Console.WindowWidth / 4) / 3, 5);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("CLICK");
            Console.SetCursorPosition((Console.WindowWidth / 4) / 3, 6);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(click);
            //stars
            Console.SetCursorPosition((Console.WindowWidth / 4) / 3, 7);
            Console.WriteLine("         ");
            Console.SetCursorPosition((Console.WindowWidth / 4) / 3, 7);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if ((rowCount * columnCount) >= click * 3)
                Console.WriteLine("¤ ¤ ¤");
            else if ((rowCount * columnCount) >= click * 2)
                Console.WriteLine("¤ ¤");
            else
                Console.WriteLine("¤");

            for (int i = 1; i < 11; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 4) - 1, i);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("█");
            }
            for (int i = 1; i < 11; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 4) + columnCount, i);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("█");
            }
            for (int i = 0; i < (Console.WindowWidth / 4) + 1 + columnCount; i++)
            {
                Console.SetCursorPosition(i, 11);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("▀");
            }
            int z = 1;
            for (int i = 0; i < rowCount; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 4), z);
                z++;

                for (int j = 0; j < columnCount; j++)
                {
                    if (field.field[i, j] == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                    }
                    if (field.field[i, j] == "2")
                        Console.ForegroundColor = ConsoleColor.Blue;
                    if (field.field[i, j] == "3")
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    if (field.field[i, j] == "4")
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    if (field.field[i, j] == "5")
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    if (field.field[i, j] == "-")
                        Console.ForegroundColor = ConsoleColor.Black;

                    if (i == currentPostionCursor[0] && j == currentPostionCursor[1])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                    }
                    //Console.Write(field.field[i, j]);
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }

        public void PrintWin(int click, int score)
        {
            Console.Clear();
            for (int i = 0; i < (Console.WindowWidth / 4) + 11; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("▄");
            }

            for (int i = 1; i < 11; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 4) + 10, i);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("█");
            }
            for (int i = 0; i < (Console.WindowWidth / 4) + 11; i++)
            {
                Console.SetCursorPosition(i, 11);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("▀");
            }
            Console.SetCursorPosition(12, 4);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("WIN");

            Console.SetCursorPosition(8, 5);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"SCORE = {score}");

            Console.SetCursorPosition(8, 6);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"CLICKS = {click}");

            Console.SetCursorPosition(8, 7);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if ((rowCount * columnCount) >= click * 3)
                Console.WriteLine("¤ ¤ ¤");
            else if ((rowCount * columnCount) >= click * 2)
                Console.WriteLine("¤ ¤");
            else
                Console.WriteLine("¤");

        }
    }
}
