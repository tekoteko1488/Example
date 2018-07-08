using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WebApplication.Models.FolderInfoAboutSub;

namespace WebApplication.Models
{
    public class Repository
    {
        DataContext db = new DataContext();

        public string SelectMobileNumber(int Id_MobileNumber)
        {
            string mobilenumber = "";

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SelectMobileNumber", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_MobileNumber", Id_MobileNumber);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    mobilenumber = reader.GetInt64(0).ToString();
                }
                reader.Close();
            }
            return mobilenumber;
        }

        public List<ModelForReviewServiceConnectedService> SelectServiceWhichUserHave(int Id_MobileNumber)
        {
            List<ModelForReviewServiceConnectedService> list = new List<ModelForReviewServiceConnectedService>();

            using (SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("dbo.OutputOfServicesThatAreConnectedToTheUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id_MobileNumber", Id_MobileNumber);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ModelForReviewServiceConnectedService ob = new ModelForReviewServiceConnectedService()
                    {
                        NameOfService = reader.GetString(0)
                    };
                    list.Add(ob);
                }
                reader.Close();
            }
            return list;
        }
    }
}