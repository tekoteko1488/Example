using System.ComponentModel.DataAnnotations;
namespace WebApplication.Models.FolderForNewSub
{
    public class AlienMobileNumberModel
    {
        [Required(ErrorMessage = "Введите мобильный номер")]
        [RegularExpression("[0-9]{11}",ErrorMessage ="Неправильно введён номер")]
        public long AlienMobileNumber { get; set; }
    }
}