using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Transaction
    {
        private string _casuale;
        private DateTime _data;
        private decimal _importo;

        public string Casuale { get => _casuale; set => _casuale = value; }
        public DateTime Data { get => _data; set => _data = value; }
        public decimal Importo { get => _importo; set => _importo = value; }

        public Transaction(string nota,DateTime data,decimal importo) 
        {
            _casuale = nota;
            _data = data;
            _importo = importo;
        }
    }
}
