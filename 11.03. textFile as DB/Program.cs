using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Contracts;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace _11._03.textFile_as_DB
{
    public class RunMethodes
    {
        public int Run()
        {
            Console.WriteLine("Mely szűrési paramétereket kívánod beállítani?");
            Console.WriteLine("ID: 1");
            Console.WriteLine("Name: 2");
            Console.WriteLine("Gender: 3");
            Console.WriteLine("Status: 4");
            Console.WriteLine("Email: 5");
            Console.WriteLine("All Users: 6");

            var answer = Convert.ToInt32(Console.ReadLine());

            return answer;


        }
    }

    class Users
    {
        public int id;
        public string name;
        public string gender;
        public bool status;
        public string email;

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Users> usersDB = new List<Users>();
            List<Users> userFilter = new List<Users>();

            var rm = new RunMethodes();

            FileStream fs = new FileStream(@"C:\Users\mrpet\Documents\UsersDatabase.xlog", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            string line = "";

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] parts = line.Split(';');
                Users u = new Users();
                u.id = Convert.ToInt32(parts[0]);
                u.name = parts[1];
                u.gender = parts[2];
                u.status = Convert.ToBoolean(parts[3]);
                u.email = parts[4];
                usersDB.Add(u);
            }

            sr.Close();
            fs.Close();

            /*
            foreach (Users item in usersDB)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"ID: {item.id}");
                Console.WriteLine($"Name: {item.name}");
                Console.WriteLine($"Gender: {item.gender}");
                Console.WriteLine($"Status: {item.status}");
                Console.WriteLine($"email: {item.email}");
            }
            */

            var counter = 0;


            /*
            foreach (Users item in usersDB)
            {
                if (item.status == true)
                {
                    counter++;
                    userFilter.Add(item);
                }
            }*/

            List<bool> vizsgalat = new List<bool>();

            int filterID = -1;
            string filterName = null;
            string filterGender = null;
            bool filterStatus = false;
            string filterEmail = null;
            string para = "";
            var a = "";

            Proba(rm, ref filterID, ref filterName, ref filterGender, ref filterStatus, ref filterEmail, ref para, ref a);

            Console.WriteLine($"Szűrési paraméter: {para}. Szűrési érték: {a}");

            for (int i = 0; i < usersDB.Count; i++)
            {

                bool vizsgal;


                if (filterID != -1)
                {
                    vizsgal = usersDB[i].id == filterID;
                }
                else if (filterName != null)
                {
                    vizsgal = usersDB[i].name == filterName;
                }
                else if (filterGender != null)
                {
                    vizsgal = usersDB[i].gender == filterGender;
                }
                else if (filterStatus == false || filterStatus == true)
                {
                    vizsgal = usersDB[i].status == filterStatus;
                }
                else if (filterEmail != null)
                {
                    vizsgal = usersDB[i].email == filterEmail;
                }
                else
                {
                    vizsgal = usersDB[i].id < usersDB.Count;
                }



                if (vizsgal)
                {
                    counter++;
                    userFilter.Add(usersDB[i]);
                }
            }


            Console.WriteLine($"A felhasználók száma: {userFilter.Count} db");
            foreach (var item in userFilter)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"ID: {item.id}");
                Console.WriteLine($"Name: {item.name}");
                Console.WriteLine($"Gender: {item.gender}");
                Console.WriteLine($"Status: {item.status}");
                Console.WriteLine($"email: {item.email}");
            }

            Console.ReadKey();
        }

        private static void Proba(RunMethodes rm, ref int filterID, ref string filterName, ref string filterGender, ref bool filterStatus, ref string filterEmail, ref string para, ref string a)
        {

            switch (rm.Run())
            {

                case 1:
                    {
                        Console.WriteLine("Mi a kifejezés amit keresel?");
                        filterID = Convert.ToInt32(Console.ReadLine());
                        para = nameof(filterID);
                        a = Convert.ToString(filterID);
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Mi a kifejezés amit keresel?");
                        filterName = Console.ReadLine();
                        para = nameof(filterName);
                        a = filterName;
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("Mi a kifejezés amit keresel?");
                        filterGender = Console.ReadLine();
                        para = nameof(filterGender);
                        a = filterGender;
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Mi a kifejezés amit keresel?");
                        filterStatus = Convert.ToBoolean(Console.ReadLine());
                        para = nameof(filterStatus);
                        a = Convert.ToString(filterStatus);
                    }
                    break;
                case 5:
                    {
                        Console.WriteLine("Mi a kifejezés amit keresel?");
                        filterEmail = Console.ReadLine();
                        para = nameof(filterEmail);
                        a = filterEmail;
                    }
                    break;
                case 6:
                    {

                    }
                    break;

            }
        }
    }
}
