using System.ComponentModel.DataAnnotations;
namespace WebApplication.Models
{
    public class TarifDescriptionModel
    {
        [Display(Name = "Абонентская плата")]
        public string SubscriptionFee { get; set; }
        [Display(Name = "Цена подключения")]
        public string Price { get; set; }
        [Display(Name = "Количество MB")]
        public int InternetPackagePerMonthMB { get; set; }
        [Display(Name = "Звонки на телефоны Теле2 из домашнего региона")]
        public string CallsToTele2PhonesFromHomeRegion { get; set; }
        [Display(Name = "Звонки на телефоны Теле2 по России")]
        public string CallsToTele2PhonesInRussia { get; set; }
        [Display(Name = "Звонки на телефоны других операторов домашнего региона")]
        public string CallsToPhonesOfOtherHomeRegionOperators { get; set; }
        [Display(Name = "Цена за другие звонки по России")]
        public string ForOtherPhonesInRussiaMinutes { get; set; }
        [Display(Name = "Звонки извне России в Россию")]
        public string InTripsAroundTheRussiaIncoming { get; set; }
        [Display(Name = "Звонки извне домашнего региона за границу")]
        public string InTripsToRussiaOutgoing { get; set; }
        [Display(Name = "Количество SMS, которые можно отправить на телефоны домашнего региона")]
        public short SMSToHomeRegionPhones { get; set; }
        [Display(Name = "Количество SMS, которые можно отправить извне домашнего региона в домашний регион")]
        public string SMSWhenTravelingInRussiaOutgoingToTheHomeRegion { get; set; }
        [Display(Name = "Дополнительные 500 МБ трафика")]
        public string Additional500MBOfTraffic { get; set; }
        [Display(Name = "Дополнительные 100 МБ трафика")]
        public string Additional100MBOfTraffic { get; set; }
        [Display(Name = "Дополнительные 10 МБ трафика")]
        public string Additional10MBOfTraffic { get; set; }
        [Display(Name = "Первый МБ за день")]
        public string FirstMBPerDay { get; set; }
        [Display(Name = "Дополнительные 1 МБ трафика")]
        public string Additional1MBOfTraffic { get; set; }
        [Display(Name = "На телефоны Теле2 домашнего региона за минуту")]
        public string OnTele2PhonesOfHomeRegionInAMinute { get; set; }
        [Display(Name = "На телефоны Теле2 извне домашнего региона за минуту")]
        public string OnTele2PhonesOfRussiaInAMinute { get; set; }
        [Display(Name = "На телефоны других операторов домашнего региона за минуту")]
        public string ForOtherPhonesInYourHomeRegionInAMinute { get; set; }
        [Display(Name = "На телефоны другого оператора вне домашнего региона за минуту")]
        public string OnOtherPhonesOfTheRussiaInAMinute { get; set; }
        [Display(Name = "Звонки в страны СНГ за минуту")]
        public string InTheCISInAMinute { get; set; }
        [Display(Name = "Звонки в Европу и балтийские страны за минуту")]
        public string ToEuropeAndTheBalticStatesInAMinute { get; set; }
        [Display(Name = "Звонки в другие страны за минуту")]
        public string InOtherCountriesInAMinute { get; set; }
        [Display(Name = "Звонки через спутниковую связь за минуту")]
        public string SatelliteCommunicationInAMinute { get; set; }
        [Display(Name = "SMS из домашнего региона на телефоны домашнего региона")]
        public decimal SMSInTheHomeRegionToAllPhonesInTheHomeRegion { get; set; }
        [Display(Name = "SMS из домашнего региона на телефоны извне РФ")]
        public decimal SMSInTheHomeRegionToAllPhonesOfTheRussia { get; set; }
        [Display(Name = "MMS из домашнего региона на телефоны извне РФ")]
        public decimal MMSInTheHomeRegionToAllPhonesOfTheRussia { get; set; }
        [Display(Name = "SMS на телефоны Теле2 из домашнего региона")]
        public decimal InTheHomeRegionSMSToTele2PhonesOfHomeRegion { get; set; }
        [Display(Name = "MMS на телефоны извне домашнего региона")]
        public decimal MMSToAllPhonesOfTheRussia { get; set; }
        [Display(Name = "SMS на телефоны извне домашнего региона")]
        public decimal SMSToAllPhonesOfTheRussia { get; set; }
        [Display(Name = "Количество минут")]
        public decimal CountOfMinute { get; set; }
        [Display(Name = "Количество SMS")]
        public decimal CountOfSMS { get; set; }
        [Display(Name = "Количество MMS")]
        public decimal CountOfMMS { get; set; }
    }
}