using NUnit.Framework;
using PodatnicyTests.Helpers;
using PodatnicyTests.Models;

namespace PodatnicyTests.TestSuites
{
    [TestFixture]
  public class GetAndCheckClientTestSuits : BasicPodatnikClient
    {
        public GetAndCheckClientTestSuits() : base()
        {
        }
        [Test]

        public void GetAndCheckClient()
        {
            //Arrange:


            //Act:
            ResponseContent account= GetBankAccountByNIP("1111111111", "90249000050247256316596736");

            //Assert
            PodatnikAssertionHelper.CheckAccount(account);

        }

    }

}
