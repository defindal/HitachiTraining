using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitachiTraining
{
    public class Gempa
    {
        private String _tanggal;
        public String Tanggal { set
            {
                _tanggal = value;
            }
        }
        public String Dirasakan { get; set; }
        public String Coordinates { get; set; }
        public String Wilayah { get; set; }

    }
}
