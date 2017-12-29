using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppForSoap.ServiceRef;

namespace ConsoleAppForSoap
{
    class Program
    {
        static void Main(string[] args)
        {
            //"BasicHttpBinding_IService1" ligger i App.config.
            Service1Client client = new Service1Client("BasicHttpBinding_IService1");
            foreach (var VARIABLE in client.VisListen())
            {
                ChangeClassName tempobj = new ChangeClassName();
                tempobj.ChangeString = VARIABLE.ChangeString;
                tempobj.ChangeDouble = VARIABLE.ChangeDouble;
                tempobj.ChangeInteger = VARIABLE.ChangeInteger;
                tempobj.Id = VARIABLE.Id;
                Console.WriteLine($"ID: {tempobj.Id}, Name: {tempobj.ChangeString}, Løn: {tempobj.ChangeDouble}, arbejdsdage: {tempobj.ChangeInteger}");
            }
            
            Console.WriteLine("Skriv et ID og beregn løn * arbejdsdage");
            
            while (true)
            {
                var readInput = Console.ReadLine();
                int number;
                bool result = Int32.TryParse(readInput, out number);
                if (result)
                {
                    Console.WriteLine(client.UdregnObjekt(number));
                }
                else Console.WriteLine("Dit input skal være nummer");
                
                if (readInput == "exit")
                {
                    break;
                }
            }
            
        }
    }
}
