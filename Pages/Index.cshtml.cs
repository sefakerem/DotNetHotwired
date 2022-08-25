using System.Net.Mail;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotwired.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string UserName { get; set; }
        public string Password { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            if(!String.IsNullOrEmpty(UserName) || !String.IsNullOrEmpty(Password))
            {
                ViewData["Message"] = "Lutfen eksik bilgi girmeyiniz";
                
                return Page();
            }else
            {
                return new RedirectToPageResult("Home");
            }
        }
    }
}