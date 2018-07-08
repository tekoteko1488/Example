using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApplication.Models.FolderForNewSub;


namespace WebApplication.Models.FolderForNewSub
{
    public class NewSubRepository
    {
        DataContext db = new DataContext();

        public List<Region> SelectRegion()
        {
            List<Region> list = new List<Region>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.SelectRegion", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Region ob = new Region()
                    {
                        Id_Region = reader.GetByte(0),
                        NameOfRegion = reader.GetString(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        public List<City> SelectCityOfTheRegion(byte Id_Region)
        {
            List<City> list = new List<City>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.SelectCityOfTheRegion", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_Region", Id_Region);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    City ob = new City()
                    {
                        Id_City = reader.GetInt16(0),
                        NameOfCity = reader.GetString(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        public List<District> SelectDistrictOfTheCity(Int16 Id_City)
        {
            List<District> list = new List<District>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.SelectDistrictOfTheCity", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_City", Id_City);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    District ob = new District()
                    {
                        Id_District = reader.GetInt32(0),
                        NameOfDistrict = reader.GetString(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        public List<Street> SelectStreetOfTheDistrict(Int32 Id_District)
        {
            List<Street> list = new List<Street>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.SelectStreetOfTheDistrict", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_District", Id_District);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Street ob = new Street()
                    {
                        Id_Street = reader.GetInt32(0),
                        NameOfStreet = reader.GetString(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        public List<Republic> SelectRepublic()
        {
            List<Republic> list = new List<Republic>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.SelectRepublic", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Republic ob = new Republic()
                    {
                        Id_Republic = reader.GetByte(0),
                        NameOfRepublic = reader.GetString(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        public List<City> SelectCityOfTheRepublic(byte Id_Republic)
        {
            List<City> list = new List<City>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.SelectCityOfTheRepublic", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_Republic", Id_Republic);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    City ob = new City()
                    {
                        Id_City = reader.GetInt16(0),
                        NameOfCity = reader.GetString(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        public void AddNewSub(ModelForNewSub ob)
        {
            db.Database.ExecuteSqlCommand("dbo.AddNewSub @Surname, @Name, @Patronymic, @Sex, @DateOfBirth, @PassportData, @House, @Housing," +
                "@Apartment, @Id_City, @Id_District, @Id_Street, @Id_CityOfBirth, @Id_RepublicOfBirth, @Id_Worker",
                new SqlParameter("@Surname", ob.Surname),
                new SqlParameter("@Name", ob.Name),
                new SqlParameter("@Patronymic", ob.Patronymic),
                new SqlParameter("@Sex", ob.Sex),
                new SqlParameter("@DateOfBirth", ob.DateOfBirth),
                new SqlParameter("@PassportData", ob.PassportData),
                new SqlParameter("@House", ob.House),
                new SqlParameter("@Housing", ob.Housing),
                new SqlParameter("@Apartment", ob.Apartment),
                new SqlParameter("@Id_City", ob.Id_City),
                new SqlParameter("@Id_District", ob.Id_District),
                new SqlParameter("@Id_Street", ob.Id_Street),
                new SqlParameter("@Id_CityOfBirth", ob.Id_CityOfBirth),
                new SqlParameter("@Id_RepublicOfBirth", ob.Id_Republic),
                new SqlParameter("@Id_Worker", ob.Id_Worker));
        }

        public List<PrestigeOfNumber> SelectPrestige()
        {
            List<PrestigeOfNumber> list = new List<PrestigeOfNumber>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.SelectPrestige", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PrestigeOfNumber ob = new PrestigeOfNumber()
                    {
                        PrestigeCodeOfMobileNumber = reader.GetByte(0),
                        NameOfPrestige = reader.GetString(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        public List<PhoneNumber> SelectMobileNumberOfThePrestige(byte Prestige)
        {
            List<PhoneNumber> list = new List<PhoneNumber>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.SelectMobileNumberOfThePrestige", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@PrestigeCodeOfMobileNumber", Prestige);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PhoneNumber ob = new PhoneNumber()
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

        public string CreateContactNumberAndConnectMobileNumber(Int64 passportdata, Int32 Id_MobileNumber)
        {
            SqlParameter param = new SqlParameter()
            {
                ParameterName = "ContractNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            db.Database.ExecuteSqlCommand("dbo.CreateContactNumberAndConnectMobileNumber @PassportData, @Id_MobileNumber, @ContractNumber out",
                new SqlParameter("@PassportData", passportdata),
                new SqlParameter("@Id_MobileNumber", Id_MobileNumber),
                param);

            return param.Value.ToString();
        }

        public string CreateContactNumberAndConnectAlienMobileNumber(Int64 passportdata, long MobileNumber)
        {
            SqlParameter param = new SqlParameter()
            {
                ParameterName = "ContractNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            db.Database.ExecuteSqlCommand("dbo.MovingInMobileNumber @PassportData, @MobileNumber, @ContractNumber out",
                new SqlParameter("@PassportData", passportdata),
                new SqlParameter("@MobileNumber", MobileNumber),
                param);

            return param.Value.ToString();
        }

        public string CheckPassportData(string PassportData)
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
    }
}