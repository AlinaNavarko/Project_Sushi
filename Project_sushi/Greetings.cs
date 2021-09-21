using System;

namespace Project_sushi
{
    public static class Greetings
    {
        public static void ShowTimeOfTheDay()
        {
            int morningStart = 9;
            int dayStart = 12;
            int eveningStart = 15;
            int nightStart = 22;
            
            int hour = DateTime.Now.Hour;

            switch (hour)
            {
                case int x when (hour >= morningStart && hour < dayStart):
                    Console.Write("Доброе Утро! ");
                    break;

                case int x when (hour >= dayStart && hour < eveningStart):
                    Console.Write("Добрый День! ");
                    break;

                case int x when (hour >= eveningStart && hour < nightStart):
                    Console.Write("Добрый Вечер! ");
                    break;

                default:
                    Console.Write("Доброй Ночи! ");
                    break;
            }
        }
    }
}
