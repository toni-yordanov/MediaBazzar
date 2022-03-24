using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediaBazzarWebsite.Classes;
using MediaBazzarWebsite.Data;

namespace MediaBazzarWebsite.Pages.Account
{
    public class LogInModel : PageModel
    {
        

        Data.DataHelper dataHelper;
        private List<Classes.Employee> accounts;
        
        [Required]
        [BindProperty]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LogInModel()
        {
            dataHelper = new DataHelper();
            accounts = dataHelper.GetEmployees(); 
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
               foreach (Classes.Employee account in accounts)
               {
                    if (account.Email.Equals(Email) && account.Password.Equals(Password))
                    {
                        var claims = new List<Claim> {
                            new Claim(ClaimTypes.Email, account.Email),
                            new Claim(ClaimTypes.Name, account.Firstname)
                        };
                        var identity = new ClaimsIdentity(claims, "CookieAuth");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

                        return Redirect("/Index");
                    }
                }
                return Page();
            }
            catch(Exception ex)
            {
                return Page();
            }
             
        }
    }
}
