using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BankAccount
    {
        private static int s_idConto = 2;     //convenzione che si scriva s(static) e _ ad intendere private
        private string _proprietario;  //field
        private decimal _saldo;
        private int _id;
        private List<Transaction> _AllTransaction = new List<Transaction>();




        //PROPERTY
        public int IdConto { get { return s_idConto; } }   //costruzione id nel construttore e non più modificabile

        public string proprietario { get { return _proprietario; } set { _proprietario = value; } }
        public decimal Saldo   //HO DUBBI
        {
            get
            {
                decimal saldo = 0;
                foreach (var i in _AllTransaction)
                {
                    saldo += i.Importo;
                }
                return this._saldo=saldo;
            }
            private set { }
        }




        //CONSTRUTTORI
        public BankAccount() { }

        public BankAccount(string proprietario, decimal saldoIniziale)
        {
            this._id = s_idConto;
            this._proprietario = proprietario;
            //this._saldo = saldoIniziale;     //NON VA BENE, MEMORIZZA, CHIAMA DEPOSITO E IN DEPO LO RISOMMA
            this.Deposito("Deposito iniziale", DateTime.Now, saldoIniziale);//PRIMO DEPOSITO
            s_idConto++;
        }

        //DEPOSITO
        public void Deposito(string nota, DateTime data, decimal importo)  //MODIFICARE CON LISTA
        {
            try
            {
                if (importo <= 0)
                    throw new IndexOutOfRangeException();
                else
                {
                    var deposito = new Transaction(nota, data, importo);
                    _AllTransaction.Add(deposito);
                    _saldo += importo;
                    Console.WriteLine($"Deposito effettuato, nuovo patrimonio; {_saldo}");
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("numero negativo non concesso!!");
            }
        }

        //PRELIEVO
        public void Prelievo(string nota, DateTime data, decimal importo)   //MODIFICARE
        {
            try
            {
                
                if (importo > this._saldo)
                    throw new IndexOutOfRangeException();
                if (_saldo - importo < 0) 
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    var deposito = new Transaction(nota, data, -importo);
                    _AllTransaction.Add(deposito);
                    _saldo -= Math.Abs(importo);
                    Console.WriteLine($"Prelievo effettuato, nuovo saldo; {_saldo}");
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Superamento del prelievo sul saldo disponibile!!");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Superamento del prelievo sul saldo disponibile!!");
            }
        }

        //CRONOLOGIA TRANSAZIONI
        //public string GetAccountHistory() 
        //{ 

        //}

        //EQUALS E HASHCODE
        public override bool Equals(object? obj)
        {
            return obj is BankAccount account &&
                   _id == account._id &&
                   _proprietario == account._proprietario &&
                   _saldo == account._saldo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id, _proprietario, _saldo);
        }

        //TOSTRING
        public override string ToString()
        {
            return $"[id cliente: {_id}\nIntestatario conto: {_proprietario}\nSaldo attuale: {_saldo}]";
        }



    }


}
