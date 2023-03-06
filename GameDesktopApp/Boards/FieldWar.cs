using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSeaBattle.Boards
{
    public class FieldWar
    {
        public int fourshipcell = 1; //+ корабли
        public int threeshipcell = 2; //+
        public int twoshipcell = 3; //+
        public int oneshipcell = 4; //+
        public int[,] CopyFieldWar = new int[10, 10]; //0 - пустая клетка, 1 - корабль, 2 - попадание по кораблю, 3 - промах
                                                      //отдельный массив для перезаписи состояния
        public string[] StrTopBottom = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" }; //+
        public string[] StrLeftRight = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }; //+
        public int Step = new int();
        public int[] Letter = new int[101];
        public int[] Index = new int[101];
        public int Points = 0;
        public static int Indent = 2;
        public int Number = 0;

        public static int[,] BotField = new int[10, 10];

        public static int[,] UserField = new int[10, 10];

        public void Display(int[,] Field)  //+
        {
            Console.Write("   ");

            if (Indent > 20)
            {
                Indent = 2;
                Console.Clear();
            }
            for (int i = 0; i < StrTopBottom.Length; i++)       // в этом цикле отрисовка верхней строки abcd  //+
            {
                Console.Write(StrTopBottom[i] + " ");
            } // в этом цикле отрисовка верхней строки abcd  //+     
            for (int i = 0; i < StrLeftRight.Length; i++) // в этом цикле отрисовка Боковой строки 12345 //+
            {
                Console.WriteLine();
                Console.Write(StrLeftRight[i]);
                if (i < 9)
                {
                    Console.Write(" |");
                }
                else if (i == 9)
                {
                    Console.Write("|");
                } // в этом цикле отрисовка Боковой строки 12345 //+


                for (int j = 0; j < StrTopBottom.Length; j++) // в этом цикле отрисовка основного поля строки //+--
                {
                    DisplayIcons(UserField[i, j]);
                    Console.Write(" ");
                } // в этом цикле отрисовка основного поля строки //+-- нужно 
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < StrTopBottom.Length; i++) // в этом цикле отрисовка верхней строки abcd 2 поля  //+
            {
                Console.Write(StrTopBottom[i] + " ");
            } // в этом цикле отрисовка верхней строки abcd 2 поля  //+
            for (int i = 0; i < StrLeftRight.Length; i++) // в этом цикле отрисовка боковой строки 1234 2 поля  //+
            {
                Console.WriteLine();
                Console.Write(StrLeftRight[i]);
                if (i < 9)
                {
                    Console.Write(" |");
                }
                else if (i == 9)
                {
                    Console.Write("|");
                } // в этом цикле отрисовка Боковой строки 12345 //+

                for (int j = 0; j < StrTopBottom.Length; j++) // в этом цикле отрисовка основного 2 поля строки //+--
                {
                    DisplayIcons(Field[i, j]);
                    Console.Write(" ");
                } // в этом цикле отрисовка основного 2 поля строки //+
            }
        }
        public void DisplayIcons(int a) //+ 
        {
            switch (a)
            {
                case 0:
                    Console.Write('-');
                    break;
                case 1:
                    Console.Write('*');
                    break;
                case 2:
                    Console.Write('X');
                    break;
                case 3:
                    Console.Write('M');
                    break;
            }
        }   //+ 
        protected void Strike(int[,] Field, int i, int j)
        {
            int Long = 1; //ячейка
            int x = j; //ячейка в которую попали, под каким индексом в двухмерном массмве
            int y = i; //ячейка в которую попали, под каким индексом в двухмерном массмве
            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i - k, j] == 2) //проверяем какой корабль, если я или бот
                                              //добили его полностью, чтобы вокруг корабля реализовать шаговый барьер на расстояние,
                                              //которого не могли стоять корабли 0 - пустая клетка, 1 - корабль, 2 - попадание по кораблю, 3 - промах
                    {
                        Long++;
                        y--;
                    }
                    if (Field[i - k, j] == 1)
                    {
                        return;
                    }
                    if (Field[i - k, j] == 0 || Field[i - k, j] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i + k, j] == 2)
                    {
                        Long++;
                    }
                    if (Field[i + k, j] == 1)
                    {
                        return;
                    }
                    if (Field[i + k, j] == 0 || Field[i + k, j] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            if (Long > 1)
            {
                for (int k = y - 1; k < y + Long + 1 && k < 10; k++)
                {
                    if (k < 0)
                    {
                        k++;
                    }
                    for (int l = x - 1; l < x + 2 && l < 10; l++)
                    {
                        if (l < 0)
                        {
                            l++;
                        }
                        if (Field[k, l] != 2)
                        {
                            Field[k, l] = 3;
                            CopyFieldWar[k, l] = 3;
                        }
                    }
                }
                return;
            }

            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i, j - k] == 2)
                    {
                        Long++;
                        x--;
                    }
                    if (Field[i, j - k] == 1)
                    {
                        return;
                    }
                    if (Field[i, j - k] == 0 || Field[i, j - k] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i, j + k] == 2)
                    {
                        Long++;
                    }
                    if (Field[i, j + k] == 1)
                    {
                        return;
                    }
                    if (Field[i, j + k] == 0 || Field[i, j + k] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            if (Long > 1)
            {
                for (int l = y - 1; l < y + 2 && l < 10; l++)
                {
                    for (int k = x - 1; k < x + Long + 1 && k < 10; k++)
                    {
                        if (k < 0)
                        {
                            k++;
                        }
                        if (l < 0)
                        {
                            l++;
                        }
                        if (Field[l, k] != 2)
                        {
                            Field[l, k] = 3;
                            CopyFieldWar[l, k] = 3;
                        }
                    }
                }
                return;
            }

            if (Long == 1)
            {
                for (int k = y - 1; k < y + 2 && k < 10; k++)
                {
                    if (k < 0)
                    {
                        k = 0;
                    }
                    for (int l = x - 1; l < x + 2 && l < 10; l++)
                    {
                        if (l < 0)
                        {
                            l = 0;
                        }
                        if (Field[k, l] != 2)
                        {
                            Field[k, l] = 3;
                            CopyFieldWar[k, l] = 3;
                        }
                    }
                }
            }
        }
    }

}
