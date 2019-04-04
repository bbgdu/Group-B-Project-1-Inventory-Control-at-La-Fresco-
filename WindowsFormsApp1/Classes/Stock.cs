using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    class Stock
    {
        public Int64 id { get; set; }
        public string fname { get; set; }
        public string company { get; set; }
        public string amount { get; set; }
        public int quantity { get; set; }
        public float cost_price { get; set; }
        public float selling_price { get; set; }
        public string barcode { get; set; }
        public DateTime exp_date { get; set; }
        public DateTime mfg_date { get; set; }
    }
}
