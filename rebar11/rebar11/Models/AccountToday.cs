using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rebar11.Models
{
    public class AccountToday
    {
        public int SumOrdersToday { get; set; }
        public double SumPriceToday { get; set; }
        public DateTime DateToday { get; set; }

        public AccountToday(int sumOrdersToday, double sumPriceToday, DateTime dateToday)
        {
            SumOrdersToday = sumOrdersToday;
            SumPriceToday = sumPriceToday;
            DateToday = dateToday;
        }
    }
}
