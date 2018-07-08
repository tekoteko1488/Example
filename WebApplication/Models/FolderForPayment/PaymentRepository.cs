using System.Data.SqlClient;

namespace WebApplication.Models.FolderForPayment
{
    public class PaymentRepository
    {
        DataContext db = new DataContext();
       
        public string Pay(long PassportData, decimal Payment, int Id_MobileNumber, string procedure)
        {
            string endpoint = "";

            switch (procedure)
            {
                case "dbo.InternetPay":
                    endpoint = "интернет";
                    break;
                case "dbo.TelephonePay":
                    endpoint = "телефон";
                    break;
                case "dbo.ElectricityPay":
                    endpoint = "электричество";
                    break;
                case "dbo.ApartmentPay":
                    endpoint = "квартиру";
                    break;
            }

            procedure += " @PassportData, @Payment, @Id_MobileNumber";

            db.Database.ExecuteSqlCommand(procedure,
                new SqlParameter("@PassportData", PassportData),
                new SqlParameter("@Payment", Payment),
                new SqlParameter("@Id_MobileNumber", Id_MobileNumber));

            string result = $"{Payment.ToString()} руб. успешно оплачено за {endpoint} ";

            return result;
        }
    }
}