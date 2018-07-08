using System.Data.SqlClient;

namespace WebApplication.Models.FolderForRefill
{
    public class RefillRepository
    {
        DataContext db = new DataContext();

        public void Refill(int AmountOfReplenishment, int Id_MobileNumber)
        {
            db.Database.ExecuteSqlCommand("dbo.Refill @AmountOfReplenishment, @Id_MobileNumber",
                new SqlParameter("@AmountOfReplenishment", AmountOfReplenishment),
                new SqlParameter("@Id_MobileNumber", Id_MobileNumber));
        }        
    }
}