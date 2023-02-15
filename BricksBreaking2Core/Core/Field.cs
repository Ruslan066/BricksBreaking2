using BricksBreaking2Core.Entity;
using BricksBreaking2Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BricksBreaking2Core
{
    [Serializable]
    public class Field
    {
        public List<DataBase> dataBases = new List<DataBase>(50);
        public List<DataBase> SorteddataBases = new List<DataBase>(50);
        public string[,] field { get; set; }
        public string newName { get; set; }
        public string newComment { get; set; }

        public int rowCount { get; set; }
        public int columnCount { get; set; }
        public int click { get; set; }
        public int score { get; set; }

        public List<DataBase> content
        {
            get
            { return dataBases; }
            
        }
        public void SortedList()
        {
            dataBases= dataBases.OrderByDescending(x => x.Scores).ToList();

        }

        public Field(int rowCount, int columnCount, int click, int score)
        {
            this.rowCount = rowCount;
            this.columnCount = columnCount;
            this.click = click;
            this.score = score;

            CreateField();
        }

        public Field(int rowCount, int columnCount)
        {
            this.rowCount = rowCount;
            this.columnCount = columnCount;

            CreateField();
        }
        /* public Tile GetTile(int row, int column)
         {
             return _tiles[row, column];
         }

         public Tile this[int row, int column]
         {
             get { return _tiles[row, column]; }
         }
        */

        public void CreateField()
        {
            string[] symb = { "1", "2", "3", "4", "5" };
            field = new string[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    field[i, j] = symb[new Random().Next(0, symb.Length)];
        }

        public int GetScore()
        {
            return score;
        }
    }
}
