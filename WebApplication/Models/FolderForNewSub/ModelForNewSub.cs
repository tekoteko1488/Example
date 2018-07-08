using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.FolderForNewSub
{
    public class ModelForNewSub
    {
        [Required(ErrorMessage ="Введите фамилию")]
        [RegularExpression("[А-Я][а-яА-Я]{1,40}",ErrorMessage = "С заглавной буквы и только кириллица")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        [RegularExpression("[А-Я][а-яА-Я]{1,40}", ErrorMessage = "С заглавной буквы и только кириллица")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите отчество")]
        [RegularExpression("[А-Я][а-яА-Я]{1,40}", ErrorMessage = "С заглавной буквы и только кириллица")]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Выберите пол")]
        public char Sex { get; set; }
        [Required(ErrorMessage = "Выберите дату")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Введите паспортные данные")]
        [RegularExpression(@"\d{10}",ErrorMessage = "В поле может быть только 10 цифр")]
        public long PassportData { get; set; }
        [Required(ErrorMessage = "Введите номер дома")]
        [RegularExpression(@"\d{1,5}")]
        public short House { get; set; }
        [RegularExpression(@"\d{1,3}")]
        public short? Housing { get; set; }
        [RegularExpression(@"\d{1,5}")]
        public short? Apartment { get; set; }
        [Required(ErrorMessage = "Выберите регион")]
        public byte Id_Region { get; set; }
        [Required(ErrorMessage = "Выберите город")]
        public short Id_City { get; set; }
        [Required(ErrorMessage = "Выберите район")]
        public int Id_District { get; set; }
        [Required(ErrorMessage = "Выберите улицу")]
        public int Id_Street { get; set; }
        public short? Id_CityOfBirth { get; set; }
        public short? Id_Republic { get; set; }
        [Required(ErrorMessage = "Введите номер рабочего")]
        [RegularExpression(@"\d{1}")]
        public int Id_Worker { get; set; }
    }
}