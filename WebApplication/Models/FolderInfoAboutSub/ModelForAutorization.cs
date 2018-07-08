using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.FolderInfoAboutSub
{
    public class ModelForAutorization
    {
        [Required(ErrorMessage = "Введите паспортные данные")]
        [RegularExpression("[0-9]{10}",ErrorMessage = "Только цифры (10 цифр)")]
        public long PassportData { get; set; }
        [Required(ErrorMessage = "Выберите мобильный номер")]
        public int Id_MobileNumber { get; set; }
    }
}