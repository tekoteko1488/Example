using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.FolderForPayment
{
    public class ModelForPayment
    {
        [Required(ErrorMessage = "Введите сумму")]
        [Range(50,100000,ErrorMessage = "Минимальная сумма - 10 руб. | Максимальная сумма - 100000 руб.")]
        [RegularExpression("[0-9]{1,7}", ErrorMessage = "В поле можно вводить только цифры")]
        public decimal Payment { get; set; }
    }
}