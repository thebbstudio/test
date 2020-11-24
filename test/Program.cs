using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        // Написать автотесты
        //Проверка точности ввода
        //Алгоритм решения
        //Стеки

        static void Main(string[] args)
        {
            //Уравнение на вход
            string[] tests = { 
             //  "1+2",                        //1             
             //  "1-2",                        //2
             //  "1*2",                        //3
             //  "1/2",                        //4
             //  "-1-2-3-4 +5",                //5
             //  "1+2*(3+4/2-(1+2))*2+1",      //6
             //  "3 * ( 1 + 4)",               //7
             //  "3@5",                        //8
             //  "3+16,5",                     //9
             //  "3/5",                        //10
               "9*4 - 18*10"                //11
             //  "-3 - 9",                     //12
             //  "-3 + 6"                      //13
            };

            int i = 1;
            Task1 task1 = new Task1();

            foreach (var test in tests)
            {

                Console.WriteLine("test " + i++ + ": " + test);

                Console.WriteLine("Ответ: " + task1.EquationSolution(test));

                Console.WriteLine();

            }
            
            Console.ReadLine();

        }
    }
}
