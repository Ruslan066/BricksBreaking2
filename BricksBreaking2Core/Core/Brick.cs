using System;
using System.Collections.Generic;
using System.Text;

namespace BricksBreaking2Core.Core
{
    [Serializable]
    public class Brick
    {
        Field field;
        Print print;
        private int[] currentPostionCursor;
        private int newx =0;
        private int newy =0;

        private int rowCount = 0;
        private int columnCount = 0;

        public Brick(Field field, int[] currentPostionCursor, Print print)
        {
            this.field = field;
            this.print = print;
            rowCount = this.field.rowCount;
            columnCount = this.field.columnCount;
            this.currentPostionCursor = currentPostionCursor;
        }
        public Brick(Field field, int x, int y)
        {
            this.field = field;
            rowCount = this.field.rowCount;
            columnCount = this.field.columnCount;
            int tt = x;
            int yy = y;
            this.newx =x;
            this.newy =y;
        }

        public void Destroy()
        {
            field.click++;
            int[,] Tempfield = new int[rowCount, columnCount];
            int[,] Tempfield2 = new int[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    Tempfield[i, j] = 0;


            int x = newx;
            //int x = currentPostionCursor[0];
            //int y = currentPostionCursor[1];
            int y = newy;
            Tempfield[x, y] = 1;

            //-------------------

            int flag1 = 0;
            int test = 0;
            Find(Tempfield, x, y);
            Array.Copy(Tempfield, Tempfield2, rowCount);
            Tempfield2[x, y] = 2;
            do
            {
                for (int i = 0; i < rowCount; i++)
                    for (int j = 0; j < columnCount; j++)
                        if (Tempfield[i, j] == 1)
                        {
                            Find(Tempfield, i, j);
                            //if (Tempfield2[i, j] == 0)
                            //{
                            //    test = Tempfield[i, j];
                            //    Tempfield2[i, j] = test;
                            //}
                            Tempfield2[i, j] = 2;
                        }


                flag1++;

            }
            while (flag1 < 3);


            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    if (Tempfield[i, j] == 1)
                    {
                        field.field[i, j] = "-";
                        field.score += 10;
                    }
            move();
        }

        private void Find(int[,] Tempfield, int x, int y)
        {
            int tempX = x;
            int tempY = y;
            while (tempX != 0)
            {
                if (field.field[tempX, y] == field.field[tempX - 1, y])
                {
                    Tempfield[tempX - 1, y] = 1;
                    tempX = tempX - 1;
                }
                else
                {
                    tempX = 0;
                }

            }
            tempX = x;
            while (tempX != rowCount - 1)
            {
                if (field.field[tempX, y] == field.field[tempX + 1, y])
                {
                    Tempfield[tempX + 1, y] = 1;
                    tempX = tempX + 1;
                }
                else
                {
                    tempX = rowCount - 1;
                }

            }
            tempY = y;
            while (tempY != 0)
            {
                if (field.field[x, tempY] == field.field[x, tempY - 1])
                {
                    Tempfield[x, tempY - 1] = 1;
                    tempY = tempY - 1;
                }
                else
                {
                    tempY = 0;
                }

            }
            tempY = y;
            while (tempY != columnCount - 1)
            {
                if (field.field[x, y] == field.field[x, tempY + 1])
                {
                    Tempfield[x, tempY + 1] = 1;
                    tempY = tempY + 1;
                }
                else
                {
                    tempY = columnCount - 1;
                }

            }
        }

        private void move()
        {
            bool flag = false;
            string[,] Tempfield = field.field;
            int k = 0;
            do
            {
                for (int i = 0; i < rowCount; i++)
                    for (int j = 0; j < columnCount; j++)
                        if (field.field[i, j] == "-")
                        {
                            try
                            {
                                field.field[i, j] = field.field[i - 1, j];
                                field.field[i - 1, j] = "-";
                                flag = true;
                            }
                            catch (Exception)
                            {
                                flag = false;
                            }
                        }

                k++;
                if ((k % 10) == 0)
                    if (Tempfield == field.field)
                        flag = false;
                Tempfield = field.field;
                //print.PrintField(field.click, field.score);
            } while (flag);
        }
    }
}
