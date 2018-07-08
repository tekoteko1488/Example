
using System.Data.SqlClient;

namespace WebApplication.Models
{
    public class TarifRepository
    {
        DataContext db = new DataContext();

        //public void UpdateTarif(int Id_Tarif)
        //{
        //    db.Database.ExecuteSqlCommand("UpdateTheTarif @ContractNumber, @IdTarif",
        //        new SqlParameter("@ContractNumber", DataForInfoAboutSub.ContractNumber),
        //        new SqlParameter("@IdTarif", Id_Tarif));
        //}
    }
}