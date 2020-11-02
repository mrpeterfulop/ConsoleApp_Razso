using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._02.C_book_page_159
{

    public interface IEa
    {
        IEb GetEnumerator();
    }
     public interface IEb
    {
        bool MoveNext();
        void Reset();

        object Current { get; }
    }

    public class Animal
    {
        public Animal(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
    }

    public class AnimalContainer: IEa, IEb
    {
        private ArrayList container = new ArrayList();
        private int currPosition = -1;
        public AnimalContainer()
        {
            container.Add(new Animal("Füli"));
            container.Add(new Animal("Bundás"));
            container.Add(new Animal("Parizer"));
        }
        public bool MoveNext()
        {
            return (++currPosition < container.Count);
        }

        public object Current
        {
            get { return container[currPosition]; }
        }
        public void Reset()
        {
            currPosition = - 1;
        }

        public IEb GetEnumerator()
        {
            return (IEb)this;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            AnimalContainer ac = new AnimalContainer();

            foreach (Animal animal in ac)
            {
                Console.WriteLine(animal.Name);
            }


            Console.ReadLine();
        }
    }
}
