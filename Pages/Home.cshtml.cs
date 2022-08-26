using Hotwired.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotwired.Pages
{
    public class HomeModel : PageModel
    {
       
        public List<CardType> CardTypes { get; set; }
        public void OnGet()
        {
            CardTypes = new List<CardType>();
        }
        public IActionResult OnGetCardTypes()
        {
            return Partial("CardType");
        }
        public IActionResult OnGetAddType()
        {
            var type = new CardType { Id = 0, Descr = String.Empty, IsVisit = false, IsUserAccount = false, ForcedLocation = false };
            return Partial("CardTypeAddEdit", type);

        }
        public IActionResult OnPostSaveType(int id, string descr, bool isVisit, bool isUserAccount, bool forcedLocation)
        {
            if (id == 0)
            {
                var type = new CardType { Id = Types.Instance.Count + 1, Descr = descr, IsVisit = isVisit, ForcedLocation = forcedLocation, IsUserAccount = isUserAccount };
                Types.Instance.Add(type);

                
                
            }
            else
            {
                var type = Types.Instance.Where(i => i.Id == id).FirstOrDefault();
                type.Descr = descr;
                type.IsVisit = isVisit;
                type.IsUserAccount = isUserAccount;
                type.ForcedLocation = forcedLocation;
                

            }
            return RedirectToPage("CardType");
        }

        public PartialViewResult OnGetEditType(int id)
        {
            var type = Types.Instance.Where(i => i.Id == id).FirstOrDefault();
            return Partial("CardTypeAddEdit", type);
        }

        public PartialViewResult OnPostDeleteType(int id)
        {
            var type = Types.Instance.Where(i => i.Id == id).FirstOrDefault();
            Types.Instance.Remove(type);

            Response.ContentType = "text/vnd.turbo-stream.html";
            return Partial("CardTypeDelete", type);
        }
    }
    public class Types : List<CardType>
    {
        private Types() { }
        private static List<CardType> _Instance = null;
        public static List<CardType> Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new List<CardType>();
                }
                return _Instance;
            }
        }
    }
}
