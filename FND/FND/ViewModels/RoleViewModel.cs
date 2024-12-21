using System.ComponentModel.DataAnnotations;

namespace FND.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
