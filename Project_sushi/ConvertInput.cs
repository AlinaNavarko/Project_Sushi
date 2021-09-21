using System;

namespace Project_sushi
{
    public class ConvertInput
    {
        public int ConvertNumberDish(string currentOrder)
        {
            try
            {
                string[] words = currentOrder.Split(new char[] { ' ' });
                int PositionId = Convert.ToInt32(words[0]);
                return PositionId;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод номера позиции.");
                Console.ResetColor();
                return 0;
            }
        }
        public int ConvertCountDish(string currentOrder)
        {
            try
            {
                string[] words = currentOrder.Split(new char[] { ' ' });
                int PositionAmount = Convert.ToInt32(words[1]);
                return PositionAmount;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите номер желаемой позиции и необходимое кол-во еще раз или введите 'ГОТОВО', если заказ укомплектован.");
                Console.ResetColor();
                return 0;
            }
        }
    }
}
