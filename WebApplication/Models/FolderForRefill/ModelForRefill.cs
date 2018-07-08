using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.FolderForRefill
{
    public class ModelForRefill
    {
        [Required(ErrorMessage = "Введите сумму платежа")]
        
        public int Summa { get; set; }
    }
}