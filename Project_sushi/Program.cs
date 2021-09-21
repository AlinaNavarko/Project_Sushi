using Project_sushi.Validations;
using System;
using System.Reflection;

namespace Project_sushi
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggingService.AddEventToLog($"Start of application {typeof(Program)}");
            Client user = new Client();
            user.Notify += Services.Notifications.NotifyAboutClientComplaint; // Добавление обработчика для события Notify
            user.Introduction();
            Menu.OpenMenu();
            ClientInput.Input();
            LoggingService.Log.Info("Пользователь оформил заказ");
            Console.WriteLine(Menu.DisplayOrderSummary());
            user.EnterPhoneNumber();
            ValidateUserInfo(user);
            Services.Notifications.SendMessage();
            user.InputFeedback();
            LoggingService.AddEventToLog($"Termination of application {typeof(Program)}");      
        }
        static bool ValidateUserInfo(Client user)
        {
            Type userInfo = user.GetType();
            foreach (PropertyInfo property in userInfo.GetProperties())
            {
                foreach (Attribute attribute in property.GetCustomAttributes())
                {
                    if (attribute is not PhoneAttribute phoneAttribute)
                        continue;
                    if (phoneAttribute.CheckNumber(property.GetValue(user) as string))

                    {
                        Console.WriteLine(string.Empty);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Спасибо. По этому номеру с Вами свяжется оператор.");
                        Console.ResetColor();
                    }
                    else
                    {
                        user.EnterPhoneNumber();
                        ValidateUserInfo(user);
                    }
                }
            }
            return true;
        }
    }
}
