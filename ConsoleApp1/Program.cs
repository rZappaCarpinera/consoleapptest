
using System;


namespace ConsoleApp1;

  class ConsoleApp1{

    static void Main(string[] arg) {

        BankAccount c1= new BankAccount("franco",5050);
        Console.WriteLine(c1.ToString());
        Console.WriteLine("------------------------");
        c1.Deposito("Farmacia", DateTime.Now, 45);
        Console.WriteLine("------------------------");
        Console.WriteLine(c1.ToString());
        Console.WriteLine("------------------------");
        c1.Prelievo("Farmacia", DateTime.Now, -45);       
        Console.WriteLine("------------------------");
        Console.WriteLine(c1.ToString());
        




    }
}
