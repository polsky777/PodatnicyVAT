using NUnit.Framework;
using PodatnicyTests.Models;

namespace PodatnicyTests.Helpers
{
    class PodatnikAssertionHelper
    {

        public static void CheckAccount(BankAccount account)
        {

            Assert.IsNotEmpty(account.requestDataTime);
            Assert.IsNotEmpty(account.requestId);
            Assert.IsNotEmpty(account.accountAssigned);
            Assert.IsNotNull(account.requestDataTime);
            Assert.IsNotNull(account.requestId);
            Assert.IsNotNull(account.accountAssigned);


        }
       

    }
}
