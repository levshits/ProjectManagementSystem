using Levshits.Data.Item;

namespace PMS.Common.ListItem
{
    public class PrincipalListItem: BaseItem
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}