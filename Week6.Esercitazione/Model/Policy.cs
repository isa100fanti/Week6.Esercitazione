using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.Esercitazione.Model
{
    public class Policy
    {
        public int Number { get; set; }
        public DateTime DateOfSign { get; set; }
        public float InsuredAmount { get; set; }
        public float MonthlyRate { get; set; }
        //collegamento tab client
        public Client Client { get; set; }    //navigation property
        public String CFClient { get; set; } //FK di collegamento

    }
}
