namespace Hotwired.Models
{
    public class CardType
    {
        public int Id
        {
            get; set;
        }
        public bool IsVisit
        {
            get; set;
        }

        public bool ForcedLocation
        {
            get; set;
        }
        public bool IsUserAccount
        {
            get; set;
        }
        public string Descr
        {
            get; set;
        }
    }
}
