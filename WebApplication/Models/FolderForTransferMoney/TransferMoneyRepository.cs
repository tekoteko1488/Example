using System.Data.SqlClient;

namespace WebApplication.Models.FolderForTransferMoney
{
    public class TransferMoneyRepository
    {
        DataContext db = new DataContext();

        public void ProcedureTransferMoneyToBankCard(int Id_MobileNumber, decimal Summa, string NumberBankCard)
        {
            db.Database.ExecuteSqlCommand("dbo.TransferMoneyToBankCardProcedure @Id_MobileNumber, @Summa, @NumberBankCard",
                new SqlParameter("@Id_MobileNumber", Id_MobileNumber),
                new SqlParameter("@Summa", Summa),
                new SqlParameter("@NumberBankCard", NumberBankCard));
        }

        public void TransferMoneytoMobileNumberProcedure(int Id_MobileNumber, decimal Summa, long MobileNumberAddressee)
        {
            db.Database.ExecuteSqlCommand("dbo.TransferMoneyToMobileNumberProcedure @Id_MobileNumber, @MobileNumberAddressee, @Sum",
                new SqlParameter("@Id_MobileNumber", Id_MobileNumber),
                new SqlParameter("@MobileNumberAddressee", MobileNumberAddressee),
                new SqlParameter("@Sum", Summa));
        }
    }
}