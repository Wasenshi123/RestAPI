using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CreditCardDal : ICreditCardDal
    {
        public bool CheckCardNumberExist(string cardNumber)
        {
            using (var db = new CreditCardContext())
            {
                var p1 = new SqlParameter("@CardNumber", cardNumber);

                var result = db.Database.SqlQuery<int>("dbo.CheckCardNumberExist @CardNumber", p1).Single();

                if (result == 1) return true;
                return false;
            }
        }
    }
}
