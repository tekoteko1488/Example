using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //руты для NewSub ******

            routes.MapRoute(
                "RegionsList", "NewSub/Regions/List", new { controller = "NewSub", action = "RegionList" });

            routes.MapRoute(
                "CitiesList", "NewSub/Cities/List/{id_Region}", new { controller = "NewSub", action = "SelectCityOfTheRegion", Id_Region = "" });

            routes.MapRoute(
                "DistrictsList", "NewSub/Districts/List/{id_City}", new { controller = "NewSub", action = "SelectDistrictOfTheCity", Id_City = "" });

            routes.MapRoute(
                "StreetsList", "NewSub/Streets/List/{id_District}",
                new { controller = "NewSub", action = "SelectStreetOfTheDistrict", Id_District = "" });

            routes.MapRoute(
                "RepublicsList", "NewSub/Republics/List", new { controller = "NewSub", action = "SelectRepublic" });

            routes.MapRoute(
                "USSRCitiesList", "NewSub/USSRCities/List/{Id_Republic}",
                new { controller = "NewSub", action = "SelectCityOfTheRepublic", Id_Republic = "" });

            routes.MapRoute(
                "MobileNumbersList", "NewSub/MobileNumbers/List/{PrestigeOfNumber}",
                new { controller = "NewSub", action = "MobileNumberList", PrestigeOfNumber = "" });

            routes.MapRoute(
                "PrestigesList", "NewSub/Prestiges/List", new { controller = "NewSub", action = "PrestigeList" });

            routes.MapRoute(
                "Kek", "NewSub/Kek/List/{Id_MobileNumber}",
                new { controller = "NewSub", action = "ConnectMobileNumber", Id_MobileNumber = "" });

            //руты для InfoSub **********************************************

            routes.MapRoute(
                "CheckPassportData", "InfoSub/CheckPassportData/List/{PassportData}", 
                new { controller = "InfoSub", action = "CheckPassportData", PassportData="" });

            routes.MapRoute(
                "MobileNumberList", "InfoSub/MobileNumber/List", 
                new { controller = "InfoSub", action = "MobileNumberList" });

            routes.MapRoute(
                "InfoSubsList", "InfoSub/InfoSubs/List/{Id_MobileNumber}/{PassportData}",
                new { controller = "InfoSub", action = "InfoSubList", Id_MobileNumber = "",PassportData="" });

            routes.MapRoute(
                "ServicesConnectedByUser", "InfoSub/ServicesConnectedByUser/List/{Id_MobileNumber}",
                new { controller = "InfoSub", action = "NameOfServiceList", Id_MobileNumber = ""});

            //Руты для смены тарифа 
            routes.MapRoute(
                "InfoSubTarifList", "InfoSub/ChangeTarifJSON/List", new { controller = "InfoSubChangeTarif", action = "ChangeTarifJSON" });

            routes.MapRoute(
                "DescriptionOfTarif", "InfoSubChangeTarif/DescriptionOfTarif/{Id_Tarif}",
                new { controller = "InfoSubChangeTarif", action = "DescriptionOfTarif", Id_Tarif = "" });

            //Руты для смены услуг
            routes.MapRoute(
                "InfoSubServiceWhichUserDoNotHaveList", "InfoSub/ServiceWhichUserDoNotHave/List",
                new { controller = "InfoSubChangeService", action = "ServiceWhichUserDoNotHaveList" });

            routes.MapRoute(
                "InfoSubServiceWhichUserHaveList", "InfoSub/ServiceWhichUserHave/List",
                new { controller = "InfoSubChangeService", action = "ServiceWhichUserHaveList" });

            routes.MapRoute(
                "InfoSubNameOfServiceList", "InfoSub/NameOfService/List/{Id_MobileNumber}",
                new { controller = "InfoSubChangeService", action = "NameOfServiceList", Id_MobileNumber = "" });

            routes.MapRoute(
                "InfoSubDescriptionOfServiceList", "InfoSub/DescriptionOfService/List/{Id_Service}",
                new { controller = "InfoSubChangeService", action = "SelectDescriptionOfServiceList", Id_Service = "" });

            //Руты для истории счёта

            routes.MapRoute(
                "HistoryReplenishmentList", "ViewingAccountHistory/AccountHistoryReplenishment/List",
                new { controller = "ViewingAccountHistory", action = "AccountHistoryReplenishment" });

            routes.MapRoute(
                "HistoryWithdrawalList", "ViewingAccountHistory/AccountHistoryWithdrawal/List",
                new { controller = "ViewingAccountHistory", action = "AccountHistoryWithdrawal" });

            routes.MapRoute(
                "HistoryBankCardList", "ViewingAccountHistory/AccountHistoryBankCard/List",
                new { controller = "ViewingAccountHistory", action = "AccountHistoryBankCard" });

            routes.MapRoute(
                "HistoryMobileNumberAddresseeList", "ViewingAccountHistory/AccountHistoryMobileNumberAddressee/List",
                new { controller = "ViewingAccountHistory", action = "AccountHistoryMobileNumberAddressee" });

            routes.MapRoute(
                "HistoryPaymentForTheApartmentList", "ViewingAccountHistory/AccountHistoryPaymentForTheApartment/List",
                new { controller = "ViewingAccountHistory", action = "AccountHistoryPaymentForTheApartment" });

            routes.MapRoute(
                "HistoryPaymentForElectricityList", "ViewingAccountHistory/AccountHistoryPaymentForElectricity/List",
                new { controller = "ViewingAccountHistory", action = "AccountHistoryPaymentElectricity" });

            routes.MapRoute(
                "HistoryPaymentForTelephoneList", "ViewingAccountHistory/AccountHistoryPaymentForTelephone/List",
                new { controller = "ViewingAccountHistory", action = "AccountHistoryPaymentTelephone" });

            routes.MapRoute(
                "HistoryPaymentForInternetList", "ViewingAccountHistory/AccountHistoryPaymentForInternet/List",
                new { controller = "ViewingAccountHistory", action = "AccountHistoryPaymentInternet" });


            //Рут по умолчанию
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
