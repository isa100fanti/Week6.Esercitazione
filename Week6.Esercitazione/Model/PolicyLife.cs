using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.Esercitazione.Model
{
    public class PolicyLife : Policy
    {

        //EF gestisce l'ereditarietà creando una grande tabella: essa conterrà le proprietà della cl padre
        //e tutte quelle delle classi figlie; per la classe che non avrà la proprietà delle altre,il valore sarà null.
        //poi nella classe policy configuration indicherò il discriminator nella tabella,che in base
        //al tipo mi scriverà un determinato nome nella tab
        public int AgeClient { get; set; }    //anni di chi fa la policy
    }
}
