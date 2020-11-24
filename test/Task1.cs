using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Task1
    {
        
        public double EquationSolution(string str)
        {
            //Индикатор конца строки
            str += '!';

            //Удалим пробелы
            str = str.Replace(" ", "");

            //Проверим правильность введённой строки
            string mistake = CheckingTheEnteredString(str);
            if (mistake != "")
            {
                //Если есть ошибки, то выведем в консоль ошибку

                Console.WriteLine(mistake);
                return -1;
            }

            //Храним числа
            var numbers = new Models.Stack<double>();
            //Храним число пока полностью не считаем из строки
            string number = "";

            //Храним операции Операции
            var operetions = new Models.Stack<char>();
            char[] elements = { '(', ')', '*', '/', '+', '-' };
            //Каждый раз писать str[0], чтобы взять первый элемент строки стало лень поэтому я выделил отдельный чар
            char e;

            while (str.Length != 0)
            {
                e = str[0];

                //Если это оператор или скобка
                if (elements.Any(element => element == e))
                {
                    //Считываение числа закончилось, можно и в стек добавить
                    if (number.Length != 0 && number != "-")
                    {
                        numbers.Add(Convert.ToDouble(number));
                        number = "";
                    }
                    else if (number == "-")
                    {
                        while (operetions.Look() != '(' || operetions.IsEmpty)
                            numbers.Add(Сalculation(numbers.PickUp(), numbers.PickUp(), operetions.PickUp()));
                        operetions.Add('+');
                        goto aute;
                    }


                    //Если минус то два путя: просто добавим - к числу 
                    //или если начало строки или перед скобкой добавим вместо него + в стек
                    if (e == '-')
                    {
                        if (!(numbers.IsEmpty))
                            operetions.Add('+');
                        number += '-';
                    }

                    //Добавдяем элемент если есек пуст, до этого была скобка или этот элемент скобка
                    if (operetions.IsEmpty || operetions.Look() == '(' || e == '(')
                    {
                        operetions.Add(e);
                    }
                    //Если + или - то мы выполняем предидущие операции пока стек с операциями не будет пуст 
                    //или не встретим скобку
                    else if (e == '+')
                    {
                        while (operetions.Look() != '(' || !operetions.IsEmpty)
                        {
                            numbers.Add(Сalculation(numbers.PickUp(), numbers.PickUp(), operetions.PickUp()));
                        }
                        operetions.Add(e);
                    }
                    //Добавляем операцию, если это умножить или разделить и до этого был плюс или минус 
                    else if ((e == '*' || e == '/') && (operetions.Look() == '+' || operetions.Look() == '-' || operetions.Look() != '('))
                        operetions.Add(e);

                    else if (e == '*' || e == '/')
                    {
                        while (operetions.IsEmpty || operetions.Look() == '(' && (operetions.Look() == '+' || operetions.Look() == '-'))
                            numbers.Add(Сalculation(numbers.PickUp(), numbers.PickUp(), operetions.PickUp()));
                        operetions.Add(e);
                    }
                    //Если мы здесь значит осталась скобка
                    else
                    {
                        while (operetions.Look() != '(')
                        {
                            numbers.Add(Сalculation(numbers.PickUp(), numbers.PickUp(), operetions.PickUp()));
                        }
                        operetions.Delete();
                    }

                }
                //Если это конец строки
                else if (e == '!')
                {
                    if (number.Length != 0)
                    {
                        numbers.Add(Convert.ToDouble(number));
                        number = "";
                    }
                    while (!operetions.IsEmpty)
                        numbers.Add(Сalculation(numbers.PickUp(), numbers.PickUp(), operetions.PickUp()));
                }
                //Это либо число, либо запятая
                else
                {
                    number += e;
                }

                 aute:

                //Удаляем первый элемент строки
                str = str.Remove(0, 1);

            }


            return numbers.PickUp();
        }




        static double Сalculation(double number1, double number2, char operetion)
        {
            Console.WriteLine(number2 + " " + operetion + " " + number1);
            switch (operetion)
            {
                case '+':
                    return (double)(number1 + number2);
                case '-':
                    return (double)(number2 - number1);
                case '*':
                    return (double)(number1 * number2);
                case '/':
                    return (double)(number2 / number1);
                
            }
            return 0;

        }

        static string CheckingTheEnteredString(string str)
        {

            char[] allowedСharacters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','*', '/', '+', '-' , ',' , '(', ')', '!' };
            char[] operetions = { '*', '/', '+', '-' };
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string number = "";

            //Проверка пустая ли строка 
            if (str.Length == 1)
                return "Строка пустая";

            //Проверка на символы которые не возможны в уравнение. При нахождении не требуется дальнейшая проверка
            foreach (var item in str)
            {
                if (!(allowedСharacters.Any(e => e == item)))
                    return "Введён невозможный символ";
            }
            
            //Скобки всегда парами. Посчитаем, расделим на два  и если остаток будет не ноль, Ошибка ввода
            int i = 0;
            foreach (var item in str)
            {

                if (item == '(')
                    i++;
                else if (item == ')')
                    i--;

            }
            if (i != 0)
                return "При введении уравнения была пропущенна скобка";


            i = 0;
            //Уравнение может начаться с минуса, числа или открывающей скобки. В остальных случаях ошибка ввода
            char previousСharacter;
            if (numbers.Any(n => n == str[i]) || str[i] == '-' || str[i] == '(')
            {
                previousСharacter = str[i];
            }
            else
                return "Неверное начало уровнения" + str[i];




            i++;

            /* 
             * Проверка на порядок сивмолов. 
             * Ранее мы определили первый символ.
             * Далее символы будут зависеть от (символ + 1), кроме чисел им не важно 
             * Число мы будем проверять на правильность. Чтобы не было двух запятых
             */



            while (i < (str.Length- 1))
            {
                // Если число или запятая, добавляем к строке "число"
                if (numbers.Any(n => n == str[i]) || str[i] == ',')
                    number += str[i];

                else
                {
                    if (number.Length == 0 || double.TryParse(number, out double resultParse))
                    {
                        //Обнуляем для дельнейшей проверки
                        number = "";
                    }
                    else
                        return "Число не преобразованно в double " + number;







                    //Если это оператор, то ожидается число, или откр. скобка
                    if (operetions.Any(o => o == previousСharacter) && !(str[i] == '(' || numbers.Any(o => o == str[i])))
                        return "Строка введена неверно1" + previousСharacter;
                    //Если это закрывающая скобка, то ожидается оператор или закр. скобка или конец строки
                    else if (previousСharacter == ')' && !(str[i] == ')' || operetions.Any(o => o == str[i] || str[i] == '!')))
                        return "Строка введена неверно2" + previousСharacter;
                    //Если это откр скобка, то ожидается число, минус или откр. скобка
                    else if (previousСharacter == '(' && !(str[i] == '(' || str[i] == '-' || numbers.Any(o => o == str[i] )))
                        return "Строка введена неверно3" + previousСharacter;
                    //После запятой всегда идёт число
                    else if (previousСharacter == ',' && !numbers.Any(n => n == str[i]))
                        return "Строка введена неверно4" + previousСharacter;
                }
                
                previousСharacter = str[i++];
                
            }

            i++;

            return "";
        }


    }
}
