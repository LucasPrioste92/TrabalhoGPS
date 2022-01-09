using System.Collections.Generic;

namespace UnitedCalendar.ViewModels
{
    public class ManageUsersInRoleViewModel
    {
        public ManageUsersInRoleViewModel()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
