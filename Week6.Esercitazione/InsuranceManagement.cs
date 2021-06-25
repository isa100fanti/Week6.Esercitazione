using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Esercitazione.Model;
using Week6.Esercitazione.Repository;

namespace Week6.Esercitazione
{
    public class InsuranceManagement
    {
        private static IRepositoryClient repoClient = new RepositoryClient();
        private static IRepositoryPolicy repoPolicy = new RepositoryPolicy();
        internal static bool Menu()
        {
            Console.WriteLine("Hello?");
            Console.WriteLine("1- insert client");
            Console.WriteLine("2. insert policy for a client");
            Console.WriteLine("3. print");
            Console.WriteLine("4.  exit");
            bool success = Int32.TryParse(Console.ReadLine(), out int choice);
            while(!success)
            {
                Console.WriteLine("not a correct value!");
                choice = Int32.Parse(Console.ReadLine());
            }
            return ChoiceManagement(choice);
        }

        private static bool ChoiceManagement(int choice)
        {
            bool goon = true;
            switch(choice)
            {
                case 1: //inserisci cliente
                    InsertClient();
                    break;
                case 2: //inserisci polizza per cliente

                    InsertPolicy();
                    break;
                case 3: //stampa
                    Print();
                    break;
                case 4: //esci
                    Console.WriteLine("bye bye!");
                    goon = false;
                    break;
                
            }
            return goon;
        }

        private static void InsertClient()
        {
            Console.WriteLine("insert CF");
            string cf = Console.ReadLine();
            Console.WriteLine("insert Name");
            string name = Console.ReadLine();
            Console.WriteLine("insert Last name");
            string lastname = Console.ReadLine();
            Console.WriteLine("insert address");
            string address = Console.ReadLine();

            Client client = new Client()
            {
                CF = cf,
                FirstName = name,
                LastName = lastname,
                Address = address
            };
            Console.WriteLine("Creato cliente!");
        }

        private static void InsertPolicy()
        {
            Policy policy;
            Console.WriteLine("insert the CF of the client");
            string CF = Console.ReadLine();
            Console.WriteLine("which kind of policy? 1-life, 2-theft 3-RC car");
            int policyType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert the number");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("insert the date of sign");
            bool success = DateTime.TryParse(Console.ReadLine(), out DateTime dSign);
            while(!success)
            {
                Console.WriteLine("insert the correct date");
                dSign = DateTime.Parse(Console.ReadLine());
            }

            Console.WriteLine("insert the insured amount");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert the monthly rate");
            int rate = Convert.ToInt32(Console.ReadLine());



            if (policyType ==1)
            {
                Console.WriteLine("insert your age");
                int age = Convert.ToInt32(Console.ReadLine());
                policy = new PolicyLife()
                {
                    Number = number,
                    DateOfSign = dSign,
                    InsuredAmount = amount,
                    MonthlyRate = rate,
                    AgeClient = age
                };
            }
            else if (policyType == 2)
            {
                Console.WriteLine("insert the percentage covered");
                int perc = Convert.ToInt32(Console.ReadLine());
                policy = new PolicyTheft()
                {
                    Number = number,
                    DateOfSign = dSign,
                    InsuredAmount = amount,
                    MonthlyRate = rate,
                    PercentageCovered = perc
                };
            }
            else
            {
                Console.WriteLine("insert the plate number");
                string plate = Console.ReadLine();
                Console.WriteLine("insert the displacement");
                int displ = Convert.ToInt32(Console.ReadLine());
                policy = new PolicyRCCar()
                {
                    Number = number,
                    DateOfSign = dSign,
                    InsuredAmount = amount,
                    MonthlyRate = rate,
                    Plate = plate,
                    Displacement = displ
                };
            }

            bool verify = repoClient.InsertPolicy(CF,policy);
            if(verify)
            {
                Console.WriteLine("all added!");
            }
            else
            {
                Console.WriteLine("retry");
            }
            
        }

        //modifica
        public static Client GetClient(string cf)
        {
            Console.WriteLine("insert the CF of the client");
            string CF = Console.ReadLine();
            Client client = null;
            return client;
        }

       

        private static void Print()
        {
            //Console.WriteLine("insert the CF of the client");
            //string CF = Console.ReadLine();

            var policy = repoPolicy.GetAll();

        }
    }
}
