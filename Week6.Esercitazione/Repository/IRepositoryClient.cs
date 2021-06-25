using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Esercitazione.Model;

namespace Week6.Esercitazione.Repository
{
    public interface IRepositoryClient : IRepository<Client>
    {
        public Client GetByCF(string CF); //mi restituisce un oggetto
        public bool InsertPolicy(string CF, Policy Policy);

    }
}
