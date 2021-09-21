using System;
using Project_sushi.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_sushi
{
    public static class ClientInput
    {
        public static int sum;
        public static string ready;
        public static bool isInput = true;
        public static int minOrder = 30;
        public static string Email { get; set; }
        public static void Input()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите порядковый номер желаемой позиции и количество через пробел.");
            Console.WriteLine("Для подтверждения Заказа введите 'готово'");
            Console.ResetColor();

            while (isInput)
            {
                ready = Console.ReadLine();
                if ((ready.ToUpper().Equals("ГОТОВО")))
                {
                    if (sum <= minOrder)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Минимальная сумма заказа для доставки {minOrder} BYN. А у Вас {sum} BYN.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Выберите что-нибудь еще и для подтверждения Заказа введите 'готово'");
                        Console.ResetColor();
                        ready = Console.ReadLine();
                    }
                    else
                        return;
                }

                ClientOrder currentOrder = new ClientOrder();
                ConvertInput conv = new ConvertInput();

                currentOrder.PositionId = conv.ConvertNumberDish(ready);
                currentOrder.PositionAmount = conv.ConvertCountDish(ready);

                if (currentOrder.PositionId > Menu.menuPositions.Count || currentOrder.PositionId <1)
                {
                    LoggingService.Log.Info("Пользователь ввел некорректный номер позиции");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Выберите номер позиции из списка");
                    Console.ResetColor();
                    ready = Console.ReadLine();

                    currentOrder.PositionId = conv.ConvertNumberDish(ready);
                    currentOrder.PositionAmount = conv.ConvertCountDish(ready);
                }

                for (int i = 0; i < Menu.menuPositions.Count; i++)
                {
                    if ((i + 1).Equals(currentOrder.PositionId))
                    {
                        Menu.AddToTheOrderList(Menu.menuPositions[currentOrder.PositionId - 1]);
                        Menu.menuPositions[i].Count = currentOrder.PositionAmount;
                        sum += currentOrder.Sum(currentOrder.PositionAmount, Menu.menuPositions[currentOrder.PositionId - 1].Price);
                    }
                }
            }
        } 
    }
}