using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSeaBattle
{

    public class FieldWar1
    {
        public string[] StrTopBottom = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
        public string[] StrLeftRight = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        public string Ship;

        public FieldWar1()
        {

        }

        public void Display()
        {
            Console.Write("   ");
            for (int i = 0; i < StrTopBottom.Length; i++) // в этом цикле отрисовка верхней строки abcd
            {
                Console.Write(StrTopBottom[i] + " ");
            } // в этом цикле отрисовка верхней строки abcd
            for (int i = 0; i < StrLeftRight.Length; i++) // в этом цикле отрисовка Боковой строки 12345
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
                } // в этом цикле отрисовка Боковой строки 12345

                for (int j = 0; j < 10; j++)  // в этом цикле отрисовка основного поля строки 
                {
                    //ShipOnDisplay();
                    if (Ship == "-")
                        Console.Write("- ");
                } // в этом цикле отрисовка основного поля строки 
            }
        }

        //public string ShipOnDisplay()
        //{
        //    //100

        //    //1-4++++,2-3+++,3-2++,4-1+

        //}
    }

}

