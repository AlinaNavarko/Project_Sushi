using System;
using System.Net;
using System.Net.Mail;

namespace Project_sushi.Services
{
    public class Notifications
    {
        public static void EnterEmail()
        {
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите свой email для получаения уведомлений по статусу Заказа:");
            Console.ResetColor();
            ClientInput.Email = Console.ReadLine();
        }

        public static void SendMessage()
        {
            try
            {
                EnterEmail();
                MailAddress from = new MailAddress("alina_navarko@mail.ru", "SUSHI");
                MailAddress to = new MailAddress(ClientInput.Email);
                MailMessage m = new MailMessage(from, to);

                m.Subject = "ДОСТАВКА SUSHI";
                m.Body = "<h2>Ваш заказ принят в работу. </h2>" + Menu.DisplayOrderSummary();
                m.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
                smtp.Credentials = new NetworkCredential("alina_navarko@mail.ru", "Nav5863AS_");
                smtp.EnableSsl = true;
                smtp.Send(m);
                Console.WriteLine("Спасибо. Информация по заказу отправлена на email.");
                LoggingService.Log.Info("Сообщение отправлено клиенту.");
            }
            catch
            {
                LoggingService.Log.Error("Ошибка при указании данных (Email).");
                Console.WriteLine(string.Empty);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы ввели некорректный Email.");
                Console.ResetColor();
                // EnterEmail();
                SendMessage();
            }
        }

        public static void NotifyAboutClientComplaint()
        {
            MailAddress from = new MailAddress("alina_navarko@mail.ru", "SUSHI CLIENT's SERVICE");
            MailAddress to = new MailAddress("alina_navarko@mail.ru");
            MailMessage m = new MailMessage(from, to);

            m.Subject = "ЖАЛОБА КЛИЕНТА";
            m.Body = "<h2>Просьба связаться с клиентом </h2>" + "email клиента:" + ClientInput.Email;
            m.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("alina_navarko@mail.ru", "Nav5863AS_");
            smtp.EnableSsl = true;
            smtp.Send(m);

            LoggingService.Log.Info("Уведомление о жалобе отправлено администратору.");
        }
    }
}
