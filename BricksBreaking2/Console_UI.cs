using BricksBreaking2Core;
using BricksBreaking2Core.Core;
using BricksBreaking2Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BricksBreaking2
{
    public class Console_UI
    {
        private readonly IScoreService _scoreService = new ScoreServiceFile();

        public Console_UI(int rowCount, int columnCount, Field field, int click, int score)
        {

            Run(rowCount, columnCount, field, click, score, _scoreService);
        }
        public static void Run(int rowCount, int columnCount, Field field, int click, int score, IScoreService _scoreService)
        {

            int[] currentPostionCursor = new int[2];
            currentPostionCursor[0] = 0;
            currentPostionCursor[1] = 0;

            field.CreateField();
            Print print = new Print(field, rowCount, columnCount, currentPostionCursor, click, score);


            string name = Environment.UserName;
            print.PrintStartMenu();
            name = Console.ReadLine();
            Console.Clear();
            do
            {

                Brick brick = new Brick(field, currentPostionCursor, print);

                ProcessInput processInput = new ProcessInput(field, rowCount, columnCount, currentPostionCursor, brick);

                print = new Print(field, rowCount, columnCount, currentPostionCursor, click, score);
                print.PrintField(field.click, field.score);
                processInput.Step();

                

            } while (Win(field, rowCount, columnCount));
            //_scoreService.AddScore(
              //  new Score { Player = name, Points = field.GetScore(), PlayedAt = DateTime.Now });


            print.PrintWin(field.click, field.score);
            PrintTopScores(_scoreService);
            ConsoleKey key = Console.ReadKey().Key;
            Run(rowCount, columnCount, field, click, score, _scoreService);
        }
        public static bool Win(Field field, int rowCount, int columnCount)
        {
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    if (field.field[i, j] != "-")
                        return true;
            return false;

        }
        private static void PrintTopScores(IScoreService SscoreService)
        {
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("---------------------  TOP SCORES ------------------------");
            foreach (var score in SscoreService.GetTopScores())
            {
                //Console.WriteLine("{0} {1} {2}", score.Player, score.Points, score.PlayedAt);
            }

            Console.WriteLine("----------------------------------------------------------");
        }

    }
}
