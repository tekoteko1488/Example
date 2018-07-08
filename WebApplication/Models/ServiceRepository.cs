using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Models
{
    public class ServiceForProcedure
    {
        public short Id_Service { get; set; }

        public string NameOfService { get; set; }
    }


    public class ServiceRepository
    {
        DataContext db = new DataContext();

        public List<ServiceForProcedure> OutputOfServicesThatAreNotConnectedToTheUser(int ContractNumber)
        {
            List<ServiceForProcedure> list = new List<ServiceForProcedure>();

            using(SqlConnection connection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Output_Of_Services_That_Are_Not_Connected_To_The_User", connection)
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

        public void ConnectServices(int ContractNumber, int Id_Service)
        {
            db.Database.ExecuteSqlCommand("Connect_Services @Id_Service, @ContractNumber",
                new SqlParameter("@Id_Service", Id_Service),
                new SqlParameter("@ContractNumber", ContractNumber));
        }
    }
}