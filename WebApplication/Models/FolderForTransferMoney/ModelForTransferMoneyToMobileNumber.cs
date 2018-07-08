using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.FolderForTransferMoney
{
    public class ModelForTransferMoneyToMobileNumber
    {
        [Required(ErrorMessage = "Введите мобильный номер получателя")]
        [Display(Name ="Мобильный номер получателя")]
        [Phone(ErrorMessage ="Номер телефона введён некорректно")]
        public long MobileNumberAddressee { get; set; }

        [Required(ErrorMessage = "Введите сумму")]
        [Display(Name = "Сумма")]
        [Range(10,500000,ErrorMessage = "Минимальное сумма равняется 10 и заканчивается 500000")]
        public int Sum { get; set; }
    }
}