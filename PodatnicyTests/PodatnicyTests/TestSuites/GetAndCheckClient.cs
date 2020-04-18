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

        public void GetAndCheckClientByNIP()
        {
            //Arrange:
            string expectedAccountAssigned = "NIE";
            // expectedAccount.Result.requestDateTime = "18-04-2020 13:51:44";
            string expectedCodeLengthNIP = "WL-113";
            string expectedMessageLengthNIP = "Pole 'NIP' ma nieprawidłową długość. Wymagane 10 znaków (111111111).";
            string expectedCodeLengthAccount = "WL-109";
            string expectedMessageLengthAccount = "Pole 'numer konta' ma nieprawidłową długość. Wymagane 26 znaków (9024900005024725631659673).";
            string expectedCodeSyntaxNIP = "WL-114";
            string expectedMessageSyntaxNIP = "Pole 'NIP' zawiera niedozwolone znaki. Wymagane tylko cyfry (x123456789).";
            string expectedCodeSyntaxAccount = "WL-110";
            string expectedMessageSyntaxAccount = "Pole 'numer konta' zawiera niedozwolone znaki. Wymagane tylko cyfry (9024900005024725631659673x).";
            string expectedCodeFalseNIP = "WL-115";
            string expectedMessageFalseNIP = "Nieprawidłowy NIP (1112111111).";
            string expectedCodeFalseAccount = "WL-111";
            string expectedMessageFalseAccount = "Nieprawidłowy numer konta bankowego (90249000050247256311596736).";

            //Act:
            BankAccount accountOK = GetBankAccountByNIP("1111111111", "90249000050247256316596736");
            BankAccount accountLengthNIP = GetBankAccountByNIP("111111111", "90249000050247256316596736");
            BankAccount accountLengthAccount = GetBankAccountByNIP("1111111111", "9024900005024725631659673");
            BankAccount accountSyntaxNIP = GetBankAccountByNIP("x123456789", "90249000050247256316596736");
            BankAccount accountSyntaxAccount = GetBankAccountByNIP("1111111111", "9024900005024725631659673x");
            BankAccount accountFalseNIP = GetBankAccountByNIP("1112111111", "90249000050247256316596736");
            BankAccount accountFalseAccount = GetBankAccountByNIP("1111111111", "90249000050247256311596736");

            //Assert
            PodatnikAssertionHelper.CheckAccountAssigned(accountOK, expectedAccountAssigned);
            PodatnikAssertionHelper.CheckFalse(accountLengthNIP, expectedCodeLengthNIP, expectedMessageLengthNIP);
            PodatnikAssertionHelper.CheckFalse(accountLengthAccount, expectedCodeLengthAccount, expectedMessageLengthAccount);
            PodatnikAssertionHelper.CheckFalse(accountSyntaxNIP, expectedCodeSyntaxNIP, expectedMessageSyntaxNIP);
            PodatnikAssertionHelper.CheckFalse(accountSyntaxAccount, expectedCodeSyntaxAccount, expectedMessageSyntaxAccount);
            PodatnikAssertionHelper.CheckFalse(accountFalseNIP, expectedCodeFalseNIP, expectedMessageFalseNIP);
            PodatnikAssertionHelper.CheckFalse(accountFalseAccount, expectedCodeFalseAccount, expectedMessageFalseAccount);
        }

        [Test]
        public void GetAndCheckClientByRegon()
        {
            //Arrange:
            string expectedAccountAssigned = "NIE";
            string expectedCodeLengthRegon = "WL-105";
            string expectedMessageLengtRegon = "Pole 'REGON' ma nieprawidłową długość. Wymagane 9 lub 14 znaków (67668587).";
            string expectedCodeLengthAccount = "WL-109";
            string expectedMessageLengthAccount = "Pole 'numer konta' ma nieprawidłową długość. Wymagane 26 znaków (9024900005024725631659673).";
            string expectedCodeSyntaxRegon = "WL-106";
            string expectedMessageSyntaxRegon = "Pole 'REGON' zawiera niedozwolone znaki. Wymagane tylko cyfry (67668587x).";
            string expectedCodeSyntaxAccount = "WL-110";
            string expectedMessageSyntaxAccount = "Pole 'numer konta' zawiera niedozwolone znaki. Wymagane tylko cyfry (x0249000050247256316596736).";
            string expectedCodeFalseRegon = "WL-107";
            string expectedMessageFalseRegon = "Nieprawidłowy REGON (82024460697221).";
            string expectedCodeFalseAccount = "WL-111";
            string expectedMessageFalseAccount = "Nieprawidłowy numer konta bankowego (90249000050247256311596736).";


            //Act:
            BankAccount account9OK = GetBankAccountByRegon("676685879", "90249000050247256316596736");
            BankAccount account14OK = GetBankAccountByRegon("82024460697228", "90249000050247256316596736");
            BankAccount accountLengthRegon = GetBankAccountByRegon("67668587", "90249000050247256316596736");
            BankAccount accountLengthAccount = GetBankAccountByRegon("676685879", "9024900005024725631659673");
            BankAccount accountSyntaxRegon = GetBankAccountByRegon("67668587x", "90249000050247256316596736");
            BankAccount accountSyntaxAccount = GetBankAccountByRegon("676685879", "x0249000050247256316596736");
            BankAccount accountFalseRegon = GetBankAccountByRegon("82024460697221", "90249000050247256316596736");
            BankAccount accountFalseAccount = GetBankAccountByRegon("82024460697228", "90249000050247256311596736");

            //Assert:
            PodatnikAssertionHelper.CheckAccountAssigned(account9OK, expectedAccountAssigned);
            PodatnikAssertionHelper.CheckAccountAssigned(account14OK, expectedAccountAssigned);
            PodatnikAssertionHelper.CheckFalse(accountLengthRegon, expectedCodeLengthRegon, expectedMessageLengtRegon);
            PodatnikAssertionHelper.CheckFalse(accountLengthAccount, expectedCodeLengthAccount, expectedMessageLengthAccount);
            PodatnikAssertionHelper.CheckFalse(accountSyntaxRegon, expectedCodeSyntaxRegon, expectedMessageSyntaxRegon);
            PodatnikAssertionHelper.CheckFalse(accountSyntaxAccount, expectedCodeSyntaxAccount, expectedMessageSyntaxAccount);
            PodatnikAssertionHelper.CheckFalse(accountFalseRegon, expectedCodeFalseRegon, expectedMessageFalseRegon);
            PodatnikAssertionHelper.CheckFalse(accountFalseAccount, expectedCodeFalseAccount, expectedMessageFalseAccount);
        }

    }
}
