using System.ComponentModel.DataAnnotations;

namespace UnitedCalendar.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Nome Role")]
        public string RoleName { get; set; }
    }
}
