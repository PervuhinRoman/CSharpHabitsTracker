using System;
using ConsoleTables;
using System.Collections.Generic;


namespace HabitsTracker
{
    class HabitsTracker
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.WindowWidth + 5, Console.WindowHeight);
            int yearNow = DateTime.Now.Year;                          // текущий год
            bool yearNowState = false;                                // переменная отвечающая за проверку високосный год; високосный - true, обычный - false

            int monthNow = DateTime.Now.Month;                        // текущий месяц
            int numberDayOfWeekNow = (int)DateTime.Now.DayOfWeek;     // текущий день (номер)
            string dayOfWeekNow = "";                                 // текущий день (строка)

            string[] Week = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }; 
            dayOfWeekNow = Week[numberDayOfWeekNow - 1];              // вычисление дня недели по номеру текущего дня

            byte feb = 28;                                            // кол-во дней в феврале меняется, в зависимосте от года: високосный - 29, обычный - 28

            yearNowState = (yearNow % 4 != 0 || (yearNow % 100 == 0 & yearNow % 400 != 0)) ? false : true;   // проверка на високосный год
            feb = (byte)((yearNowState == true) ? 29 : 28);           // если високосный год, то 29 дней, если нет, то 28

            Console.WriteLine(" year: {0} \n month: {1} \n day: {2}", yearNow, monthNow, dayOfWeekNow);

            Dictionary<int, string> monthsNumber = new Dictionary<int, string>(12);  // словарь, который присвоит имя месяцу, по его известному номеру
            monthsNumber.Add(1, "January");
            monthsNumber.Add(2, "February");                          
            monthsNumber.Add(3, "March");
            monthsNumber.Add(4, "April");
            monthsNumber.Add(5, "May");
            monthsNumber.Add(6, "June");
            monthsNumber.Add(7, "July");
            monthsNumber.Add(8, "August");
            monthsNumber.Add(9, "September");
            monthsNumber.Add(10, "October");
            monthsNumber.Add(11, "November");
            monthsNumber.Add(12, "December");

            string selectMonth = monthsNumber[monthNow];                             // месяц, его название

            Dictionary<string, byte> months = new Dictionary<string, byte>(12);      // словарь, который присвоит переменной кол-во дней в соответсвии с месяцем
            months.Add("January", 31);
            months.Add("February", feb);         
            months.Add("March", 31);
            months.Add("April", 30);
            months.Add("May", 31);
            months.Add("June", 30);
            months.Add("July", 31);
            months.Add("August", 31);
            months.Add("September", 30);
            months.Add("October", 31);
            months.Add("November", 30);
            months.Add("December", 31);

            byte dayNumberInMonth = months[selectMonth];                             // число дней в месяце

            string[] rows = new string[dayNumberInMonth];

            for (int i = 0; i < dayNumberInMonth; i++)                               // заполняем таблицу стартовым статусом привычки
            {
                rows[i] = " ";
            }

            byte[] days = new byte[dayNumberInMonth];                                // создание массива дат текущего месяца

            for (int i = 0; i < dayNumberInMonth; i++)
            {
                days[i] = (byte)(i + 1);
            }

            Console.WriteLine();

            foreach (byte i in days)                                                 // вывод дат дней недели в соответствии текущего месяца
            {
                if(i < 10)
                {
                    Console.Write("  {0} ", i);
                } 
                else if (i >= 10)
                {
                    Console.Write(" {0} ", i);
                }
                
            }

            Console.WriteLine();

            var table = new ConsoleTable(rows);                                      // создание таблицы
            
            table.Write(Format.Alternative);
        }
    }
}
