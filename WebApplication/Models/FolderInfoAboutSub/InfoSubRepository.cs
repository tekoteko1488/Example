using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Models.FolderInfoAboutSub
{
    public class InfoSubRepository
    {
        DataContext db = new DataContext();

        public string Authorization(string PassportData)
        {
            SqlParameter outParametrResult = new SqlParameter()
            {
                ParameterName = "Result",
                SqlDbType = SqlDbType.NVarChar,
                Size = 5,
                Direction = ParameterDirection.Output
            };

            db.Database.ExecuteSqlCommand("Check_Passport_Data @PassportDate, @Result OUT",
                new SqlParameter("@PassportDate", PassportData),
                outParametrResult);

            return outParametrResult.Value.ToString();
        }

        public List<InfoAboutSubModel> InfoAboutSub(long PassportData, int Id_MobileNumber)
        {
            List<InfoAboutSubModel> list = new List<InfoAboutSubModel>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("InfoAboutSub", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@PassportData", PassportData);
                command.Parameters.AddWithValue("@Id_MobileNumber", Id_MobileNumber);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    InfoAboutSubModel ob = new InfoAboutSubModel()
                    {
                        Id_Sub = reader.GetInt32(0),
                        Surname = reader.GetString(1),
                        Name = reader.GetString(2),
                        Patronymic = reader.GetString(3),
                        Sex = reader.GetString(4),
                        DateOfBirth =reader.GetDateTime(5).ToShortDateString(),
                        DateOfRegistration = reader.GetDateTime(6).ToShortDateString(),
                        NameOfTarif = reader.GetString(7),
                        Balance = reader.GetDecimal(8),
                        CountOfMinute = reader.GetDouble(9),
                        CountOfMB = reader.GetDouble(10),
                        CountOfSMS = reader.GetInt16(11),
                        CountOfMMS = reader.GetInt16(12),
                        ContractNumber = reader.GetInt32(13)                        
                    };                    
                    list.Add(ob);

                    DataForInfoAboutSub.ContractNumber = ob.ContractNumber;
                    DataForInfoAboutSub.NameOfTarif = ob.NameOfTarif;
                }
                reader.Close();
            }
            return list;
        }

        public List<MobileNomerForInfoSub> SelectContractNumberForInfoAboutSub(long PassportData)
        {
            List<MobileNomerForInfoSub> list = new List<MobileNomerForInfoSub>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SelectContractNumberForInfoAboutSub", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@PassportData", PassportData);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MobileNomerForInfoSub ob = new MobileNomerForInfoSub()
                    {
                        Id_MobileNumber = reader.GetInt32(0),
                        MobileNumber = reader.GetInt64(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        

        //Функция достающая услуги, которые не подключены у пользователя
        public List<ServiceForProcedure> ServiceWhichUserDoNotHaveList(int ContractNumber)
        {
            List<ServiceForProcedure> list = new List<ServiceForProcedure>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SelectServiceWhichUserDoNotHave", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ContractNumber", ContractNumber);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ServiceForProcedure ob = new ServiceForProcedure()
                    {
                        Id_Service = reader.GetInt16(0),
                        NameOfService = reader.GetString(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        //Функция, достающая подключённые услуги
        public List<ServiceForProcedure> SelectServiceWhichUserHave(int ContractNumber)
        {
            List<ServiceForProcedure> list = new List<ServiceForProcedure>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SelectServiceWhichUserHave", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ContractNumber", ContractNumber);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ServiceForProcedure ob = new ServiceForProcedure()
                    {
                        Id_Service = reader.GetInt16(0),
                        NameOfService = reader.GetString(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        // Вызов хранимой процедуры для смены тарифа
        public void UpdateTarif(int Id_Tarif)
        {
            db.Database.ExecuteSqlCommand("UpdateTheTarif @ContractNumber, @IdTarif",
                new SqlParameter("@ContractNumber", DataForInfoAboutSub.ContractNumber),
                new SqlParameter("@IdTarif", Id_Tarif));
        }

        // Вызов хранимой процедуры для добавления услуги
        public void AddService(int DoNotTheConnectedServices)
        {
            db.Database.ExecuteSqlCommand("AddService @ContractNumber, @Id_Service",
                new SqlParameter("@ContractNumber", DataForInfoAboutSub.ContractNumber),
                new SqlParameter("@Id_Service", DoNotTheConnectedServices));
        }

        // Вызов хранимой процедуры для удаления услуги
        public void DeleteService(int ConnectedServices)
        {
            db.Database.ExecuteSqlCommand("DeleteService @ContractNumber, @Id_Service",
                new SqlParameter("@ContractNumber", DataForInfoAboutSub.ContractNumber),
                new SqlParameter("@Id_Service", ConnectedServices));
        }

        public List<SelectDescriptionOfServiceMODEL> SelectDescriptionOfService(int Id_Service)
        {
            List<SelectDescriptionOfServiceMODEL> list = new List<SelectDescriptionOfServiceMODEL>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SelectDescriptionOfService", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_Service", Id_Service);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SelectDescriptionOfServiceMODEL ob = new SelectDescriptionOfServiceMODEL()
                    {
                        NameOfService = reader.GetString(0),
                        CostPerMonth = reader.GetDecimal(1),
                        Description = reader.GetString(2)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        //Обращение к БД (вытаскивает наименование услуг, подключённых пользователю)
        public List<ServiceNameOfService> NameOfService(int Id_MobileNumber)
        {
            List<ServiceNameOfService> list = new List<ServiceNameOfService>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("ProcedureNameOfService", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_MobileNumber", Id_MobileNumber);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ServiceNameOfService ob = new ServiceNameOfService()
                    {
                        NameOfService = reader.GetString(0)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        //// Обращение к БД (вытаскиваем описание выбранного тарифа)
        //public TarifDescriptionModel ProcedureDescriptionOfTarif(short Id_Tarif)
        //{
        //    TarifDescriptionModel ob = new TarifDescriptionModel();

        //    using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
        //    {
        //        connection.Open();

        //        SqlCommand command = new SqlCommand("dbo.DescriptionOfTarif", connection)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };

        //        command.Parameters.AddWithValue("@Id_Tarif", Id_Tarif);

        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            string specifier = "0.00";

        //            string value;

        //            value = reader.GetDecimal(0).ToString(specifier);
        //            if (value == "0.00")
        //                ob.SubscriptionFee = "Бесплатно";
        //            else
        //                ob.SubscriptionFee = value + " руб.";

        //            value = reader.GetDecimal(1).ToString(specifier);
        //            if (value == "0.00")
        //                ob.Price = "Бесплатно";
        //            else
        //                ob.Price = value + " руб.";

        //            ob.InternetPackagePerMonthMB = reader.GetInt32(2);

        //            value = reader.GetDecimal(3).ToString(specifier);
        //            if(value == "0,00")
        //                ob.CallsToTele2PhonesFromHomeRegion = "Бесплатно";
        //            else
        //                ob.CallsToTele2PhonesFromHomeRegion = value + " руб.";

        //            value = reader.GetDecimal(4).ToString(specifier);
        //            if (value == "0,00")
        //                ob.CallsToTele2PhonesInRussia = "Бесплатно";
        //            else
        //                ob.CallsToTele2PhonesInRussia = value + " руб.";

        //            value = reader.GetString(5);
        //            if (value == "0,00")
        //                ob.CallsToPhonesOfOtherHomeRegionOperators = "Бесплатно";
        //            else
        //                ob.CallsToPhonesOfOtherHomeRegionOperators = value + " руб.";

        //            value = reader.GetDecimal(6).ToString(specifier);
        //            if (value == "0,00")
        //                ob.InTripsAroundTheRussiaIncoming = "Бесплатно";
        //            else
        //                ob.InTripsAroundTheRussiaIncoming = value + " руб.";

        //            value = reader.GetString(7);
        //            if (value == "0,00")
        //                ob.InTripsToRussiaOutgoing = "Бесплатно";
        //            else
        //                ob.InTripsToRussiaOutgoing = value + " руб.";

        //            ob.SMSToHomeRegionPhones = reader.GetInt16(8);

        //            value = reader.GetString(9);
        //            if (value == "0,00")
        //                ob.SMSWhenTravelingInRussiaOutgoingToTheHomeRegion = "Бесплатно";
        //            else
        //                ob.SMSWhenTravelingInRussiaOutgoingToTheHomeRegion = value + " руб.";

        //            value = reader.GetString(10);
        //            if (value == "-")
        //                ob.Additional500MBOfTraffic = value;
        //            else
        //                ob.Additional500MBOfTraffic = value + " руб.";

        //            value = reader.GetString(11);
        //            if (value == "-")
        //                ob.Additional100MBOfTraffic = value;
        //            else
        //                ob.Additional100MBOfTraffic = value + " руб.";

        //            value = reader.GetString(12);
        //            if (value == "-")
        //                ob.Additional10MBOfTraffic = value;
        //            else
        //                ob.Additional10MBOfTraffic = value + " руб.";

        //            value = reader.GetString(13);
        //            if (value == "-")
        //                ob.FirstMBPerDay = value;
        //            else
        //                ob.FirstMBPerDay = value + " руб.";

        //            value = reader.GetString(14);
        //            if (value == "-")
        //                ob.Additional1MBOfTraffic = value;
        //            else
        //                ob.Additional1MBOfTraffic = value + " руб.";

        //            value = reader.GetDecimal(15).ToString(specifier);
        //            if (value == "0,00")
        //                ob.OnTele2PhonesOfHomeRegionInAMinute = "Бесплатно";
        //            else
        //                ob.OnTele2PhonesOfHomeRegionInAMinute = value + " руб.";

        //            value = reader.GetDecimal(16).ToString(specifier);
        //            if (value == "0,00")
        //                ob.OnTele2PhonesOfRussiaInAMinute = "Бесплатно";
        //            else
        //                ob.OnTele2PhonesOfRussiaInAMinute = value + " руб.";

        //            value = reader.GetDecimal(17).ToString(specifier);
        //            if (value == "0,00")
        //                ob.ForOtherPhonesInYourHomeRegionInAMinute = "Бесплатно";
        //            else
        //                ob.ForOtherPhonesInYourHomeRegionInAMinute = value + " руб.";

        //            value = reader.GetDecimal(18).ToString(specifier);
        //            if (value == "0,00")
        //                ob.OnOtherPhonesOfTheRussiaInAMinute = "Бесплатно";
        //            else
        //                ob.OnOtherPhonesOfTheRussiaInAMinute = value + " руб.";

        //            value = reader.GetDecimal(19).ToString(specifier);
        //            if (value == "0,00")
        //                ob.InTheCISInAMinute = "Бесплатно";
        //            else
        //                ob.InTheCISInAMinute = value + " руб.";

        //            value = reader.GetDecimal(20).ToString(specifier);
        //            if (value == "0,00")
        //                ob.ToEuropeAndTheBalticStatesInAMinute = "Бесплатно";
        //            else
        //                ob.ToEuropeAndTheBalticStatesInAMinute = value + " руб.";

        //            value = reader.GetDecimal(21).ToString(specifier);
        //            if (value == "0,00")
        //                ob.InOtherCountriesInAMinute = "Бесплатно";
        //            else
        //                ob.InOtherCountriesInAMinute = value + " руб.";

        //            value = reader.GetDecimal(22).ToString(specifier);
        //            if (value == "0,00")
        //                ob.SatelliteCommunicationInAMinute = "Бесплатно";
        //            else
        //                ob.SatelliteCommunicationInAMinute = value + " руб.";

        //            ob.SMSInTheHomeRegionToAllPhonesInTheHomeRegion = reader.GetDecimal(23);
        //            ob.SMSInTheHomeRegionToAllPhonesOfTheRussia = reader.GetDecimal(24);
        //            ob.MMSInTheHomeRegionToAllPhonesOfTheRussia = reader.GetDecimal(25);
        //            ob.InTheHomeRegionSMSToTele2PhonesOfHomeRegion = reader.GetDecimal(26);
        //            ob.MMSToAllPhonesOfTheRussia = reader.GetDecimal(27);
        //            ob.SMSToAllPhonesOfTheRussia = reader.GetDecimal(28);
        //            ob.CountOfMinute = reader.GetDecimal(29);
        //            ob.CountOfSMS = reader.GetInt32(30);
        //            ob.CountOfMMS = reader.GetInt32(31);
        //        }
        //        reader.Close();
        //    }
        //    return ob;
        //}
    }
}