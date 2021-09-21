using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project_sushi
{
    public static class Menu
    {
        public static List<MenuPosition> menuPositions;
        public static List<MenuPosition> menuPositionsSelected = new List<MenuPosition> { };
        public static void OpenMenu()
        {
            menuPositions = JsonConvert
                .DeserializeObject<List<MenuPosition>>(File.ReadAllText(path:@"..\..\..\MenuList\MenuPositions.json"));
            for (int i = 0; i < menuPositions.Count; i++)
            {
                int position = i + 1;
                Console.WriteLine(position + " " + menuPositions[i].Name + " " + menuPositions[i].Price.ToString() + " BYN");
            }
        }
        public static void AddToTheOrderList(MenuPosition menuPositions)
        {
            menuPositionsSelected.Add(menuPositions);
        }
        public static string DisplayOrderSummary()
        {
            Console.Clear();
            string orderSummary = "ВАШ ЗАКАЗ:" + "\n";
            /*  for (int i = 0; i < menuPositionsSelected.Count; i++)
              {
                  orderSummary += (menuPositionsSelected[i].Name + " " + menuPositionsSelected[i].Count + "шт" + "\n");
              }  */
            var menuPositionsSelectedSorted = menuPositionsSelected.Where(menuPosition => menuPosition.Count > 0);
            foreach (MenuPosition menuPosition in menuPositionsSelectedSorted)
            {
                orderSummary += menuPosition.Name + " x " + menuPosition.Count + " = " + menuPosition.Count * menuPosition.Price + "\n";
            }
            orderSummary += "К ОПЛАТЕ: " + ClientInput.sum + " BYN";
            Console.ForegroundColor = ConsoleColor.Green;
            return orderSummary;
            Console.ResetColor();
        }
    }
}