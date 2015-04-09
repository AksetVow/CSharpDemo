using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Sample
{
    class Program
    {

        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }

            public Address AddressLine1 { get; set; }
            public Address AddressLine2 { get; set; }
        }


        class Address
        {
            public string City { get; set; }
            public string Country { get; set; }
            public string Street { get; set; }
            public uint House { get; set; }
            public uint Apartment { get; set; }
            public string ZipCode { get; set; }
        }

        enum Degree { 
            Bachelor,
            Master,
            PhD
        }

        class UniversityDegree
        {
            public Degree Degree { get; set; }
            public bool IsCreditsRequeired { get; set; }

            public IEnumerable<string> Courses { get; set; }
            public IEnumerable<string> Prerequisites { get; set; } 
        }


        class UniversityProgram
        {
            public string ProgramName { get; set; }

            public Person Head { get; set; }

            public IEnumerable<Degree> Degrees { get; set; }
        }

        static void Main(string[] args)
        {
            var student = InputPerson();
            var professor = InputPerson();

            OutPutPerson(student);
            OutPutPerson(professor);

            var degree = new UniversityDegree()
            {
                Degree = Degree.PhD,
                Courses = new List<string>(new string[] { "History", "Computer Science", "Engineering" }),
                IsCreditsRequeired = true,
                Prerequisites = new List<string>(new string[] { "Bachelor degree"})
            };

            var program = new UniversityProgram()
            {
                ProgramName = "Computer Science",
                Head = professor,
                Degrees = new List<Degree>() { Degree.Bachelor, Degree.Master, Degree.PhD}
            };

            Console.ReadLine();
        }

        static Person InputPerson()
        { 
            Person p = new Person();
            DateTime date;

            Console.WriteLine("Input FirstName");
            p.FirstName = Console.ReadLine();

            Console.WriteLine("Input LastName");
            p.LastName = Console.ReadLine();

            Console.WriteLine("Input Birthdate");
            DateTime.TryParse(Console.ReadLine(), out date);
            p.BirthDate = date;


            Console.WriteLine("Input first address:");
            p.AddressLine1 = InputAddress();

            Console.WriteLine("Input second address:");
            p.AddressLine2 = InputAddress();


            return p;
        }

        static void OutPutPerson(Person p)
        {
            Console.WriteLine("FirstName : {0}, LastName : {1}, BirthDate {2}", p.FirstName, p.LastName, p.BirthDate);
            Console.WriteLine("First address");
            OutputAddress(p.AddressLine1);
            Console.WriteLine("Second address");
            OutputAddress(p.AddressLine2);
        }

        static Address InputAddress()
        {
            Address a = new Address();
            uint house, apartment;
            
            Console.WriteLine("Input City:");
            a.City = Console.ReadLine();
            Console.WriteLine("Input Country:");
            a.Country = Console.ReadLine();
            Console.WriteLine("Input Street:");
            a.Street = Console.ReadLine();
            Console.WriteLine("Input House:");
            UInt32.TryParse(Console.ReadLine(), out house);
            a.House = house;
            Console.WriteLine("Input Apartment:");
            UInt32.TryParse(Console.ReadLine(), out apartment);
            a.Apartment = apartment;
            Console.WriteLine("Input Zipcode:");
            a.ZipCode = Console.ReadLine();

            return a;
        }

        static void OutputAddress(Address a)
        {
            Console.WriteLine("City: {0} Country: {1} Street {2} House {3} Apartment {4} Zipcode {5}",
                a.City, a.Country, a.Street, a.House, a.Apartment, a.ZipCode);
        }
    }
}
