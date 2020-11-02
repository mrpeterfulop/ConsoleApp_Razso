using System.Collections.Generic;

namespace _11._02.Karsa_11_partialClass__Interface
{
    public class Customer
    {
        public int Id;
        public string Name;
        public List<Order> Orders;

        public Customer()
        {
            Orders = new List<Order>();
            System.Console.WriteLine("Konstruktor 1.");

        }

        public Customer(int id):this() //A ":this()" paraméterrel megadhatjuk hogy melyik konstruktor után fusson le az adott konstruktor!
        {
            this.Id = id;
            System.Console.WriteLine("Konstruktor 2.");

        }
        public Customer(int id, string name) : this(id) //A ":this()" paraméterrel megadhatjuk hogy melyik konstruktor után fusson le az adott konstruktor!
        {
            this.Id = id;
            this.Name = name;

            System.Console.WriteLine("Konstruktor 3.");
        }

    }
}
