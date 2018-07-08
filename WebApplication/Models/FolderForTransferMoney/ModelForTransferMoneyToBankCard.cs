using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.FolderForTransferMoney
{
    public class ModelForTransferMoneyToBankCard
    {
        [Required(ErrorMessage = "Введите номер банковской карты получателя")]
        [Display(Name = "Номер банковской карты получателя")]
        [CreditCard]
        public string BankCardAddressee { get; set; }

        [Required(ErrorMessage = "Введите сумму")]
        [Display(Name = "Сумма")]
        [Range(10, 500000, ErrorMessage = "Минимальное сумма равняется 10 и заканчивается 500000")]
        public int Sum { get; set; }
    }
}