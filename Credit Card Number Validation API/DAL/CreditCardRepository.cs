using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Wasenshi.CreditCard.DAL.Interfaces;
using Wasenshi.CreditCard.DAL.Models;

namespace Wasenshi.CreditCard.DAL
{
    public class CreditCardRepository : ICreditCardRepository
    {
        public bool CheckCardNumberExist(string cardNumber)
        {
            using (var db = new CreditCardContext())
            {
                var p1 = new SqlParameter("@CardNumber", cardNumber);

                var output = new SqlParameter();
                output.ParameterName = "@ReturnValue";
                output.SqlDbType = SqlDbType.Int;
                output.Direction = ParameterDirection.Output;

                var row = db.Database.SqlQuery<object>("EXEC @ReturnValue = dbo.CheckCardNumberExist @CardNumber", output, p1).Count();

                if ((int)output.Value == 1) return true;
                return false;
            }
        }
    }
}
