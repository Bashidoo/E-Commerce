using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comemrce
{
    public class CardInfo
    {
        public double CardNumber { get; set; }
        public double Balance { get; set; }

        public int CCV { get; set; }

        public bool InternetPurchase { get; set; }

    }
}
