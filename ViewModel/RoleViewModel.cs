using System.ComponentModel.DataAnnotations;

namespace LMS.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}