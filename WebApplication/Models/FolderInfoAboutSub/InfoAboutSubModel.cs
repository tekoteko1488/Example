using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.FolderInfoAboutSub
{
    public class InfoAboutSubModel
    {
        public int Id_Sub { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Sex { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfRegistration { get; set; }
        public string NameOfTarif { get; set; }
        public decimal Balance { get; set; }
        public double CountOfMinute { get; set; }
        public double CountOfMB { get; set; }
        public short CountOfSMS { get; set; }
        public short CountOfMMS { get; set; }
        public int ContractNumber { get; set; }
        //public short? Id_Service { get => id_Service; set => id_Service = value; }
        //public string NameOfService { get => nameOfService; set => nameOfService = value; }
    }
}