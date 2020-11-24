using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        

        static void Main(string[] args)
        {
            ////Уравнения на вход
            //string[] tests = { 
            // "1+2",                        
            // "1-2",                        
            // "1*2",                        
            // "1/2",                        
            // "-1-2-3-4 +5",                
            // "1+2*(3+4/2-(1+2))*2+1",      
            // "3 * ( 1 + 4)",               
            // "3@5",                        
            // "3+16,5",                     
            // "3/5",                        
            // "9*4 - 18*10",                
            // "-3 - 9",                     
            // "-3 + 6",                     
            // "3,3,3",                      
            // "1-(16/4)*(13 - 14)",
            // "29462,19-14000-2000"
            //};

            //int i = 1;
            //Task1 task1 = new Task1();

            //foreach (var test in tests)
            //{

            //    Console.WriteLine("test " + i++ + ": " + test);

            //    Console.WriteLine("Ответ: " + task1.EquationSolution(test));

            //    Console.WriteLine();

            //}

            string str = Console.ReadLine();

            Task1 task1 = new Task1();

            Console.WriteLine(task1.EquationSolution(str));

            Console.ReadLine();

        }
    }
}
