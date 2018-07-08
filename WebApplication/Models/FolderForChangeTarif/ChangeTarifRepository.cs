using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Models.FolderForChangeTarif
{
    public class ChangeTarifRepository
    {
        DataContext db = new DataContext();

        //Функция достающая тарифы, которые не подключены у пользователя
        public List<Tarif> SelectTarifs(int Id_MobileNumber)
        {
            List<Tarif> list = new List<Tarif>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SelectTarifWhichUserDoNotHave", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_MobileNumber", Id_MobileNumber);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Tarif ob = new Tarif()
                    {
                        Id_Tarif = reader.GetInt16(0),
                        NameOfTarif = reader.GetString(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        // Вызов хранимой процедуры для смены тарифа
        public void UpdateTarif(int Id_MobileNumber, short Id_Tarif)
        {
            db.Database.ExecuteSqlCommand("UpdateTheTarif @Id_MobileNumber, @IdTarif",
                new SqlParameter("@Id_MobileNumber", Id_MobileNumber),
                new SqlParameter("@IdTarif", Id_Tarif));
        }

        // Обращение к БД (вытаскиваем описание выбранного тарифа)
        public TarifDescriptionModel ProcedureDescriptionOfTarif(short Id_Tarif)
        {
            TarifDescriptionModel ob = new TarifDescriptionModel();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.DescriptionOfTarif", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_Tarif", Id_Tarif);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string specifier = "0.00";

                    string value;

                    value = reader.GetDecimal(0).ToString(specifier);
                    if (value == "0.00")
                        ob.SubscriptionFee = "Бесплатно";
                    else
                        ob.SubscriptionFee = value + " руб.";

                    value = reader.GetDecimal(1).ToString(specifier);
                    if (value == "0.00")
                        ob.Price = "Бесплатно";
                    else
                        ob.Price = value + " руб.";

                    ob.InternetPackagePerMonthMB = reader.GetInt32(2);

                    value = reader.GetDecimal(3).ToString(specifier);
                    if (value == "0,00")
                        ob.CallsToTele2PhonesFromHomeRegion = "Бесплатно";
                    else
                        ob.CallsToTele2PhonesFromHomeRegion = value + " руб.";

                    value = reader.GetDecimal(4).ToString(specifier);
                    if (value == "0,00")
                        ob.CallsToTele2PhonesInRussia = "Бесплатно";
                    else
                        ob.CallsToTele2PhonesInRussia = value + " руб.";

                    value = reader.GetString(5);
                    if (value == "0,00")
                        ob.CallsToPhonesOfOtherHomeRegionOperators = "Бесплатно";
                    else
                        ob.CallsToPhonesOfOtherHomeRegionOperators = value + " руб.";

                    value = reader.GetDecimal(6).ToString(specifier);
                    if (value == "0,00")
                        ob.InTripsAroundTheRussiaIncoming = "Бесплатно";
                    else
                        ob.InTripsAroundTheRussiaIncoming = value + " руб.";

                    value = reader.GetString(7);
                    if (value == "0,00")
                        ob.InTripsToRussiaOutgoing = "Бесплатно";
                    else
                        ob.InTripsToRussiaOutgoing = value + " руб.";

                    ob.SMSToHomeRegionPhones = reader.GetInt16(8);

                    value = reader.GetString(9);
                    if (value == "0,00")
                        ob.SMSWhenTravelingInRussiaOutgoingToTheHomeRegion = "Бесплатно";
                    else
                        ob.SMSWhenTravelingInRussiaOutgoingToTheHomeRegion = value + " руб.";

                    value = reader.GetString(10);
                    if (value == "-")
                        ob.Additional500MBOfTraffic = value;
                    else
                        ob.Additional500MBOfTraffic = value + " руб.";

                    value = reader.GetString(11);
                    if (value == "-")
                        ob.Additional100MBOfTraffic = value;
                    else
                        ob.Additional100MBOfTraffic = value + " руб.";

                    value = reader.GetString(12);
                    if (value == "-")
                        ob.Additional10MBOfTraffic = value;
                    else
                        ob.Additional10MBOfTraffic = value + " руб.";

                    value = reader.GetString(13);
                    if (value == "-")
                        ob.FirstMBPerDay = value;
                    else
                        ob.FirstMBPerDay = value + " руб.";

                    value = reader.GetString(14);
                    if (value == "-")
                        ob.Additional1MBOfTraffic = value;
                    else
                        ob.Additional1MBOfTraffic = value + " руб.";

                    value = reader.GetDecimal(15).ToString(specifier);
                    if (value == "0,00")
                        ob.OnTele2PhonesOfHomeRegionInAMinute = "Бесплатно";
                    else
                        ob.OnTele2PhonesOfHomeRegionInAMinute = value + " руб.";

                    value = reader.GetDecimal(16).ToString(specifier);
                    if (value == "0,00")
                        ob.OnTele2PhonesOfRussiaInAMinute = "Бесплатно";
                    else
                        ob.OnTele2PhonesOfRussiaInAMinute = value + " руб.";

                    value = reader.GetDecimal(17).ToString(specifier);
                    if (value == "0,00")
                        ob.ForOtherPhonesInYourHomeRegionInAMinute = "Бесплатно";
                    else
                        ob.ForOtherPhonesInYourHomeRegionInAMinute = value + " руб.";

                    value = reader.GetDecimal(18).ToString(specifier);
                    if (value == "0,00")
                        ob.OnOtherPhonesOfTheRussiaInAMinute = "Бесплатно";
                    else
                        ob.OnOtherPhonesOfTheRussiaInAMinute = value + " руб.";

                    value = reader.GetDecimal(19).ToString(specifier);
                    if (value == "0,00")
                        ob.InTheCISInAMinute = "Бесплатно";
                    else
                        ob.InTheCISInAMinute = value + " руб.";

                    value = reader.GetDecimal(20).ToString(specifier);
                    if (value == "0,00")
                        ob.ToEuropeAndTheBalticStatesInAMinute = "Бесплатно";
                    else
                        ob.ToEuropeAndTheBalticStatesInAMinute = value + " руб.";

                    value = reader.GetDecimal(21).ToString(specifier);
                    if (value == "0,00")
                        ob.InOtherCountriesInAMinute = "Бесплатно";
                    else
                        ob.InOtherCountriesInAMinute = value + " руб.";

                    value = reader.GetDecimal(22).ToString(specifier);
                    if (value == "0,00")
                        ob.SatelliteCommunicationInAMinute = "Бесплатно";
                    else
                        ob.SatelliteCommunicationInAMinute = value + " руб.";

                    ob.SMSInTheHomeRegionToAllPhonesInTheHomeRegion = reader.GetDecimal(23);
                    ob.SMSInTheHomeRegionToAllPhonesOfTheRussia = reader.GetDecimal(24);
                    ob.MMSInTheHomeRegionToAllPhonesOfTheRussia = reader.GetDecimal(25);
                    ob.InTheHomeRegionSMSToTele2PhonesOfHomeRegion = reader.GetDecimal(26);
                    ob.MMSToAllPhonesOfTheRussia = reader.GetDecimal(27);
                    ob.SMSToAllPhonesOfTheRussia = reader.GetDecimal(28);
                    ob.CountOfMinute = reader.GetDecimal(29);
                    ob.CountOfSMS = reader.GetInt32(30);
                    ob.CountOfMMS = reader.GetInt32(31);
                }
                reader.Close();
            }
            return ob;
        }
    }
}