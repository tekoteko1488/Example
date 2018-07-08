
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.FolderForNewSub
{
    public class AliasMobileNomberModel
    {
        [Required(ErrorMessage = "Выберите престиж мобильного номера")]
        public byte PrestigeCodeOfMobileNumber { get; set; }
        [Required(ErrorMessage = "Выберите мобильный номер")]
        public int Id_MobileNumber { get; set; }
    }
}