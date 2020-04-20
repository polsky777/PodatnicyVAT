using NUnit.Framework;
using PodatnicyTests.Helpers;
using PodatnicyTests.Models;
using System;

namespace PodatnicyTests.TestSuites
{
    [TestFixture]
    public class GetAndCheckByRegonTestSuits : BasicPodatnikClient
    {
        [Test]
        public void GetAndCheckClientByRegon9ok()
        {
            //Arrange:
            string expectedAccountAssigned = "NIE";

            //Act:
            BankAccount account9OK = GetBankAccountByRegon("676685879", "90249000050247256316596736");
            DateTime expectedTime = Models.Timer.GetDateResponse();

            //Assert:
            PodatnikAssertionHelper.CheckAccountAssigned(account9OK, expectedAccountAssigned, expectedTime);
        }

        [Test]
        public void GetAndCheckClientByRegon14ok()
        {
            //Arrange:
            string expectedAccountAssigned = "NIE";

            //Act:
            BankAccount account14OK = GetBankAccountByRegon("82024460697228", "90249000050247256316596736");
            DateTime expectedTime = Models.Timer.GetDateResponse();

            //Assert:
            PodatnikAssertionHelper.CheckAccountAssigned(account14OK, expectedAccountAssigned, expectedTime);
        }

        [Test]
        public void GetAndCheckClientByRegonEmptyRegon()
        {
            //Arrange:
            string expectedCodetEmptyRegon = "WL-104";
            string expectedMessagetEmptyRegon = "Pole 'REGON' nie może być puste.";

            //Act:
            BankAccount accountEmptyRegon = GetBankAccountByRegon("", "90249000050247256311596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountEmptyRegon, expectedCodetEmptyRegon, expectedMessagetEmptyRegon);
        }
        [Test]
        public void GetAndCheckClientByRegonEmptyAccount()
        {
            //Arrange:
            string expectedCodetEmptyAccount = "WL-108";
            string expectedMessagetEmptyAccount = "Pole 'numer konta' nie może być puste.";

            //Act:
            BankAccount accountEmptyAccount = GetBankAccountByRegon("676685879", "");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountEmptyAccount, expectedCodetEmptyAccount, expectedMessagetEmptyAccount);
        }
        [Test]
        public void GetAndCheckClientByRegon9FalseAccount()
        {
            //Arrange:
            string expectedCodeFalseAccount = "WL-111";
            string expectedMessageFalseAccount = "Nieprawidłowy numer konta bankowego (90249000050247256311596736).";

            //Act:
            BankAccount accountFalseAccount = GetBankAccountByRegon("676685879", "90249000050247256311596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountFalseAccount, expectedCodeFalseAccount, expectedMessageFalseAccount);
        }
        [Test]
        public void GetAndCheckClientByRegon14FalseAccount()
        {
            //Arrange:
            string expectedCodeFalseAccount = "WL-111";
            string expectedMessageFalseAccount = "Nieprawidłowy numer konta bankowego (90249000050247256311596736).";

            //Act:
            BankAccount accountFalseAccount = GetBankAccountByRegon("82024460697228", "90249000050247256311596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountFalseAccount, expectedCodeFalseAccount, expectedMessageFalseAccount);
        }
        [Test]
        public void GetAndCheckClientByRegon14FalseRegon()
        {
            //Arrange:
            string expectedCodeFalseRegon = "WL-107";
            string expectedMessageFalseRegon = "Nieprawidłowy REGON (82024460697221).";

            //Act:
            BankAccount accountFalseRegon = GetBankAccountByRegon("82024460697221", "90249000050247256311596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountFalseRegon, expectedCodeFalseRegon, expectedMessageFalseRegon);
        }
        [Test]
        public void GetAndCheckClientByRegon9FalseRegon()
        {
            //Arrange:
            string expectedCodeFalseRegon = "WL-107";
            string expectedMessageFalseRegon = "Nieprawidłowy REGON (676685179).";

            //Act:
            BankAccount accountFalseRegon = GetBankAccountByRegon("676685179", "90249000050247256311596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountFalseRegon, expectedCodeFalseRegon, expectedMessageFalseRegon);
        }
        [Test]
        public void GetAndCheckClientByRegon14LengthRegon()
        {
            //Arrange:
            string expectedCodeLengthRegon = "WL-105";
            string expectedMessageLengtRegon = "Pole 'REGON' ma nieprawidłową długość. Wymagane 9 lub 14 znaków (820244606972).";

            //Act:
            BankAccount accountLengthRegon = GetBankAccountByRegon("820244606972", "90249000050247256311596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountLengthRegon, expectedCodeLengthRegon, expectedMessageLengtRegon);
        }
        [Test]
        public void GetAndCheckClientByRegon9LengthRegon()
        {
            //Arrange:
            string expectedCodeLengthRegon = "WL-105";
            string expectedMessageLengtRegon = "Pole 'REGON' ma nieprawidłową długość. Wymagane 9 lub 14 znaków (67668587).";

            //Act:
            BankAccount accountLengtRegon = GetBankAccountByRegon("67668587", "90249000050247256311596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountLengtRegon, expectedCodeLengthRegon, expectedMessageLengtRegon);
        }
        [Test]
        public void GetAndCheckClientByRegon9LengthAccount()
        {
            //Arrange:
            string expectedCodeLengthAccount = "WL-109";
            string expectedMessageLengthAccount = "Pole 'numer konta' ma nieprawidłową długość. Wymagane 26 znaków (9024900005024725631659673).";

            //Act:
            BankAccount accountLengtRegon = GetBankAccountByRegon("676685879", "9024900005024725631659673");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountLengtRegon, expectedCodeLengthAccount, expectedMessageLengthAccount);
        }
        [Test]
        public void GetAndCheckClientByRegon14LengthAccount()
        {
            //Arrange:
            string expectedCodeLengthAccount = "WL-109";
            string expectedMessageLengthAccount = "Pole 'numer konta' ma nieprawidłową długość. Wymagane 26 znaków (9024900005024725631659673).";

            //Act:
            BankAccount accountLengtRegon = GetBankAccountByRegon("82024460697228", "9024900005024725631659673");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountLengtRegon, expectedCodeLengthAccount, expectedMessageLengthAccount);
        }
        [Test]
        public void GetAndCheckClientByRegon14SyntaxAccount()
        {
            //Arrange:
            string expectedCodeSyntaxAccount = "WL-110";
            string expectedMessageSyntaxAccount = "Pole 'numer konta' zawiera niedozwolone znaki. Wymagane tylko cyfry (x0249000050247256316596736).";

            //Act:
            BankAccount accountSyntaxAccount = GetBankAccountByRegon("82024460697228", "x0249000050247256316596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountSyntaxAccount, expectedCodeSyntaxAccount, expectedMessageSyntaxAccount);
        }
        [Test]
        public void GetAndCheckClientByRegon9SyntaxAccount()
        {
            //Arrange:
            string expectedCodeSyntaxAccount = "WL-110";
            string expectedMessageSyntaxAccount = "Pole 'numer konta' zawiera niedozwolone znaki. Wymagane tylko cyfry (x0249000050247256316596736).";

            //Act:
            BankAccount accountSyntaxAccount = GetBankAccountByRegon("676685879", "x0249000050247256316596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountSyntaxAccount, expectedCodeSyntaxAccount, expectedMessageSyntaxAccount);
        }

        [Test]
        public void GetAndCheckClientByRegon9SyntaxRegon()
        {
            //Arrange:
            string expectedCodeSyntaxRegon = "WL-106";
            string expectedMessageSyntaxRegon = "Pole 'REGON' zawiera niedozwolone znaki. Wymagane tylko cyfry (67668587x).";

            //Act:
            BankAccount accountSyntaxAccount = GetBankAccountByRegon("67668587x", "90249000050247256316596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountSyntaxAccount, expectedCodeSyntaxRegon, expectedMessageSyntaxRegon);
        }
        [Test]
        public void GetAndCheckClientByRegon14SyntaxRegon()
        {
            //Arrange:
            string expectedCodeSyntaxRegon = "WL-106";
            string expectedMessageSyntaxRegon = "Pole 'REGON' zawiera niedozwolone znaki. Wymagane tylko cyfry (8202446069722x).";

            //Act:
            BankAccount accountSyntaxAccount = GetBankAccountByRegon("8202446069722x", "90249000050247256316596736");

            //Assert:
            PodatnikAssertionHelper.CheckFalse(accountSyntaxAccount, expectedCodeSyntaxRegon, expectedMessageSyntaxRegon);
        }
    };
}