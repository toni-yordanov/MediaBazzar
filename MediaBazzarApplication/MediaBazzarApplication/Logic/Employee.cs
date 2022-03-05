using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication
{
    class Employee
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
        public Employee(int ID, string Firstname, string Lastname, string DateOfBirth, string PhoneNumber, string Address,
            string PostalCode, string Email, string BSN, string Password, string Position, string Username, string Gender,
            string City, string Country, int DepartmentID, string DepartmentName, string Active)
        {
            this.ID = ID;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.DateOfBirth = DateOfBirth;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.PostalCode = PostalCode;
            this.Email = Email;
            this.BSN = BSN;
            this.Password = Password;
            this.Position = Position;
            this.Username = Username;
            this.Gender = Gender;
            this.City = City;
            this.Country = Country;
            this.DepartmentID = DepartmentID;
            this.DepartmentName = DepartmentName;
            this.Active = Active;
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

