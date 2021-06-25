using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.Esercitazione.Model
{
    public class Client
    {
        public String CF { get; set; }    //fixed 16
        public String FirstName { get; set; }  //vc 20
        public String LastName { get; set; } //vc 20
        public String Address { get; set; }  //vc 50
        public ICollection<Policy> Policies { get; set; } = new List<Policy>();    //lista di policy di collegamento 
    }
}
