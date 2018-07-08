using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Models
{
    public class SubscriberBaseRepository
    {
        DataContext db = new DataContext();

        public int AddContract(int Id_Sub, int Id_MobileNumber)
        {
            SqlParameter ContractNumber = new SqlParameter()
            {
                ParameterName = "ContractNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            db.Database.ExecuteSqlCommand("AddContract @Id_Sub, @Id_MobileNumber, @ContractNumber OUT",
                new SqlParameter("@Id_Sub", Id_Sub),
                new SqlParameter("@Id_MobileNumber", Id_MobileNumber),
                ContractNumber);
            return (int)ContractNumber.Value;
        }
    }
}