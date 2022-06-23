using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication
{
    public class Employee
    {
        //properties
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string DateOfBirth { get; set; } //DateTime?¿
        public string Gender { get; set; }
        public string BSN { get; set; }


        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Contracttype { get; set; }
        public double Wage { get; set; }


        public string PreferedShift { get; set; }
        public int ShiftCode { get; set; }
        public string Active { get; set; } //Active, Not-Active, PastWorker


        //Contracts

        public int Contract { get; set; }
        public string Position { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Zipcode { get; set; }
        public string Houly_Wage { get; set; }

        //public Contract myContract { get; set; }
        //public Availability myAvailability { get; set; }

        public int ContractID { get; set; }
        public int AvailabilityID { get; set; }
        public int Hours { get; set; }
        public bool Sick { get; set; }


        // automatic schedule
        public string PrefShift { get; set; }


        //constructor
        public Employee()
        {

        }

        public Employee(int employeeID, string firstname)
        {
            this.Firstname = firstname;
            this.ID = employeeID;
        }

        //FOR LOGIN
        public Employee(int ID, string Firstname, string Lastname, string DateOfBirth, string Gender, string BSN, string PhoneNumber, string Address,
            string PostalCode, string Email,string City, string Country, string Username, string Password, string DepartmentName, string Position, string Contracttype, double Wage)
        {
            this.ID = ID;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.BSN = BSN;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.PostalCode = PostalCode;
            this.Email = Email;
            this.City = City;
            this.Country = Country;
            this.Username = Username;
            this.Password = Password;
            this.DepartmentName = DepartmentName;
            this.Position = Position;
            this.DepartmentName = DepartmentName;
            this.Wage = Wage;
        }

        public Employee(int id, string firstname, string lastname, string Dateofbirth, string gender, string bsn, string phonenum, string address, string postalcode, string email, 
            string city, string country, string username)
        {

        }

        public Employee(int ID, string Firstname, string Lastname, string DateOfBirth, string Gender, string BSN, string PhoneNumber, string Address,
           string PostalCode, string Email, string City, string Country, string Username, string DepartmentName, string Position, string Contracttype, double Wage)
        {
            this.ID = ID;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.BSN = BSN;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.PostalCode = PostalCode;
            this.Email = Email;
            this.City = City;
            this.Country = Country;
            this.Username = Username;
            this.DepartmentName = DepartmentName;
            this.Position = Position;
            this.DepartmentName = DepartmentName;
            this.Wage = Wage;


        }


        public virtual string GetInfo()
        {
            return $"{this.Firstname} {this.Lastname} ; {this.ID}";
        }

        public override string ToString()
        {
            return $"{Firstname} ID:{ID}";
        }
    }

}

