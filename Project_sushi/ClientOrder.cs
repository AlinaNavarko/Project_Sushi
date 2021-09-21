using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_sushi
{
    public class ClientOrder
    {
        public int PositionId { get; set; }
        public int PositionAmount { get; set; }
        public int Sum(int PositionAmount, int Price)
        {
            int Sum = PositionAmount * Price;
            return Sum;
        }
    }
}
