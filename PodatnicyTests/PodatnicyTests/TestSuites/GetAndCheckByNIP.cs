using NUnit.Framework;
using PodatnicyTests.Helpers;
using PodatnicyTests.Models;
using System;

namespace PodatnicyTests.TestSuites
{
    [TestFixture]
    public class GetAndCheckByNIPTestSuits : BasicPodatnikClient
    {
        public GetAndCheckByNIPTestSuits() : base()
        {
        }
        [Test]

        public void GetAndCheckClientByNIPok()
        {
            //Arrange:
            string expectedAccountAssigned = "NIE";

            //Act:
            BankAccount accountOK = GetBankAccountByNIP("1111111111", "90249000050247256316596736");
            DateTime expectedTime = Models.Timer.GetDateResponse();

            //Assert:
            PodatnikAssertionHelper.CheckAccountAssigned(accountOK, expectedAccountAssigned, expectedTime);
        }

        [Test]
        public void GetAndCheckClientByNIPLengthNIP()
        {
            //Arrange:
            string expectedCodeLengthNIP = "WL-113";
            string expectedMessageLengthNIP = "Pole 'NIP' ma nieprawidłową długość. Wymagane 10 znaków (111111111).";

            //Act:
            BankAccount accountLengthNIP = GetBankAccountByNIP("111111111", "90249000050247256316596736");
         
            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountLengthNIP, expectedCodeLengthNIP, expectedMessageLengthNIP);

        }
        [Test]
        public void GetAndCheckClientByNIPLengthAccount()
        {
            //Arrange:
            string expectedCodeLengthAccount = "WL-109";
            string expectedMessageLengthAccount = "Pole 'numer konta' ma nieprawidłową długość. Wymagane 26 znaków (9024900005024725631659673).";

            //Act:
            BankAccount accountLengthAccount = GetBankAccountByNIP("1111111111", "9024900005024725631659673");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountLengthAccount, expectedCodeLengthAccount, expectedMessageLengthAccount);
        }

        [Test]
        public void GetAndCheckClientByNIPSyntaxNIP()
        {
            //Arrange:
            string expectedCodeSyntaxNIP = "WL-114";
            string expectedMessageSyntaxNIP = "Pole 'NIP' zawiera niedozwolone znaki. Wymagane tylko cyfry (x123456789).";
            

            //Act:
            BankAccount accountSyntaxNIP = GetBankAccountByNIP("x123456789", "90249000050247256316596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountSyntaxNIP, expectedCodeSyntaxNIP, expectedMessageSyntaxNIP);

        }

        [Test]
        public void GetAndCheckClientByNIPSyntaxAccount()
        {
            //Arrange:

            string expectedCodeSyntaxAccount = "WL-110";
            string expectedMessageSyntaxAccount = "Pole 'numer konta' zawiera niedozwolone znaki. Wymagane tylko cyfry (9024900005024725631659673x).";

            //Act:

            BankAccount accountSyntaxAccount = GetBankAccountByNIP("1111111111", "9024900005024725631659673x");

            //Assert
            PodatnikAssertionHelper.CheckFalse(accountSyntaxAccount, expectedCodeSyntaxAccount, expectedMessageSyntaxAccount);

        }

        [Test]
        public void GetAndCheckClientByNIPFalseNIP()
        {
            //Arrange:
            string expectedCodeFalseNIP = "WL-115";
            string expectedMessageFalseNIP = "Nieprawidłowy NIP (1112111111).";

            //Act:
            BankAccount accountFalseNIP = GetBankAccountByNIP("1112111111", "90249000050247256316596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountFalseNIP, expectedCodeFalseNIP, expectedMessageFalseNIP);
        }

        [Test]
        public void GetAndCheckClientByNIPFalseAccount()
        {
            //Arrange:
            string expectedCodeFalseAccount = "WL-111";
            string expectedMessageFalseAccount = "Nieprawidłowy numer konta bankowego (90249000050247256311596736).";

            //Act:
            BankAccount accountFalseAccount = GetBankAccountByNIP("1111111111", "90249000050247256311596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountFalseAccount, expectedCodeFalseAccount, expectedMessageFalseAccount);
        }

        [Test]
        public void GetAndCheckClientByNIPEmptyNIP()
        {
            //Arrange:
            string expectedCodetEmptyNIP = "WL-112";
            string expectedMessagetEmptyNIP = "Pole 'NIP' nie może być puste.";

            //Act:
            BankAccount accountEmptyNIP = GetBankAccountByNIP("", "90249000050247256316596736");

            //Assert
            PodatnikAssertionHelper.CheckFalse(accountEmptyNIP, expectedCodetEmptyNIP, expectedMessagetEmptyNIP);
        }

        [Test]
        public void GetAndCheckClientByNIPEmptyAccount()
        {
            //Arrange:
            string expectedCodetEmptyAccount = "WL-108";
            string expectedMessagetEmptyAccount = "Pole 'numer konta' nie może być puste.";

            //Act:
            BankAccount accountEmptyAccount = GetBankAccountByNIP("1111111111", "");


            //Assert
            PodatnikAssertionHelper.CheckFalse(accountEmptyAccount, expectedCodetEmptyAccount, expectedMessagetEmptyAccount);
        }

 


    }
}
