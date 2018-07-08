using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using WebApplication.Models.FolderViewingAccountHistory;

namespace WebApplication.Models.FolderViewingAccountHistory
{
    public class ViewingAccountHistoryRepository
    {
        DataContext db = new DataContext();

        public List<ModelForAccountHistory> GetListHistory(int Id_MobileNumber,string sqlcommand)
        {
            List<ModelForAccountHistory> list = new List<ModelForAccountHistory>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlcommand, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_MobileNumber", Id_MobileNumber);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ModelForAccountHistory ob = new ModelForAccountHistory()
                    {
                        DateAndTime = reader.GetDateTime(0).ToLongDateString() + " " 
                        + reader.GetDateTime(0).ToShortTimeString(),
                        Summa = reader.GetDecimal(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        public List<ModelForOverviewBankCard> GetListHistoryBankCard(int Id_MobileNumber)
        {
            List<ModelForOverviewBankCard> list = new List<ModelForOverviewBankCard>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.AccountOverviewTransferMoneyToBankCard", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_MobileNumber", Id_MobileNumber);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ModelForOverviewBankCard ob = new ModelForOverviewBankCard()
                    {
                        DateAndTime = reader.GetDateTime(0).ToLongDateString() + " "
                        + reader.GetDateTime(0).ToShortTimeString(),
                        Summa = reader.GetDecimal(1),
                        NumberOfBankCard = reader.GetString(2)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        public List<ModelForOverviewTransferMonetToMobileNumber> GetListHistoryMobileNumberAddressee(int Id_MobileNumber)
        {
            List<ModelForOverviewTransferMonetToMobileNumber> list = new List<ModelForOverviewTransferMonetToMobileNumber>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.AccountOverviewTransferMoneyToMobileNumber", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_MobileNumber", Id_MobileNumber);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ModelForOverviewTransferMonetToMobileNumber ob = new ModelForOverviewTransferMonetToMobileNumber()
                    {
                        DateAndTime = reader.GetDateTime(0).ToLongDateString() + " "
                        + reader.GetDateTime(0).ToShortTimeString(),
                        Summa = reader.GetDecimal(1),
                        MobileNumberAddressee = reader.GetInt64(2)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }

        public List<ModelForAccountHistory> GetListHistoryPayment(long PassportData, string sqlcommand)
        {
            List<ModelForAccountHistory> list = new List<ModelForAccountHistory>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlcommand, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@PassportData", PassportData);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ModelForAccountHistory ob = new ModelForAccountHistory()
                    {
                        DateAndTime = reader.GetDateTime(0).ToLongDateString() + " "
                        + reader.GetDateTime(0).ToShortTimeString(),
                        Summa = reader.GetDecimal(1)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }
    }
}