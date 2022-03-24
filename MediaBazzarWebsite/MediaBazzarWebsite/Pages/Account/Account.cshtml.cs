using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediaBazzarWebsite.Data;
using MediaBazzarWebsite.Classes;

namespace MediaBazzarWebsite.Pages.Account
{
    
    public class AccountModel : PageModel
    {
        DataHelper dh = new DataHelper();
        public string message;
        public int Id { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string SpouseName { get; set; }
        [BindProperty]
        public string SpouseContact { get; set; }
        [BindProperty]
        public string Department { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Salary { get; set; }

        public AccountModel()
        {

        }
        private void Set()
        {
            List<Employee> employees = dh.GetEmployees();
            foreach (var employee in employees)
            {
                if (employee.Firstname.Equals(User.Identity.Name))
                {
                    Id = employee.ID;
                    FirstName = employee.Firstname;
                    LastName = employee.Lastname;
                    Username = employee.Username;
                    Email = employee.Email;
                    Phone = employee.PhoneNumber;
                    Address = employee.Address;
                    Department = employee.DepartmentName;
                    Password = employee.Password;
                    Salary = employee.Houly_Wage;
                }
            }
        }
        public void OnGet()
        {
            try
            {
                this.Set();
            }
            catch (Exception ex)
            {

            }
        }

        public IActionResult OnPost()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/
            try
            {
                List<Employee> employees = dh.GetEmployees();
                foreach (var employee in employees)
                {
                    if (employee.Firstname.Equals(User.Identity.Name))
                    {
                        Id = employee.ID;
                    }
                }

                if (dh.UpdateAccount(Id, Phone, Address, Email) == true)
                {
                    this.Set();
                    return Page();
                }
                else
                {
                    message = "Update unsuccessful!";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                return Page();
            }
            return null;
        }
    }
}
