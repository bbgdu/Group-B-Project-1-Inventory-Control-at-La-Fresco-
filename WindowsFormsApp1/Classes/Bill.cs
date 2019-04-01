using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    class Bill
    {
        public string bill_id { get; set; }
        public int customer_id { get; set; }
        public float amount { get; set; }
        public float final_discount { get; set; }
        public float grand_total { get; set; }
        public DateTime date_time { get; set; }
    }
}
