using System;
using NUnit.Framework;
using PodatnicyTests.Models;

namespace PodatnicyTests.Helpers
{
    class PodatnikAssertionHelper
    {
        public static void CheckAccountAssigned(BankAccount account, string expectedAccount, DateTime expectedTime)
        {
            Assert.IsNotNull(account.Result.RequestDateTime, $"Value of {account.Result.RequestDateTime} should not be null");
            Assert.IsNotNull(account.Result.RequestId, $"Value of {account.Result.RequestId} should not be null");
            Assert.IsNotNull(account.Result.AccountAssigned, $"Value of {account.Result.AccountAssigned} should not be null");
            Assert.IsNotEmpty(account.Result.RequestId, $"In dictionary called {account.Result.RequestId} should not be empty");
            Assert.IsNotEmpty(account.Result.AccountAssigned, $"In dictionary called {account.Result.AccountAssigned} should not be empty");
            Assert.AreEqual(expectedAccount, account.Result.AccountAssigned, $"State of AccountAssigned is incorrect. Should be: {expectedAccount} is: {account.Result.AccountAssigned}");
            Assert.LessOrEqual((expectedTime.Ticks - account.Result.RequestDateTime.Ticks) / 1000000, 50, $"Request time is incorrect. Should be: {expectedTime} is: {account.Result.RequestDateTime}");
        }

        public static void CheckFalse(BankAccount accountFalseAccount, string expectedCodeAccount, string expectedMessageAccount)
        {
            Assert.IsNotNull(accountFalseAccount.Code, $"Lack of error code: {expectedCodeAccount}");
            Assert.IsNotNull(accountFalseAccount.Message, $"Lack of message: {expectedMessageAccount}");
            Assert.AreEqual(expectedCodeAccount, accountFalseAccount.Code, $"Error message is incorrect. Should be:  {expectedCodeAccount}");
            Assert.AreEqual(expectedMessageAccount, accountFalseAccount.Message, $"Error message is incorrect. Should be: {expectedMessageAccount}");
        }

    }
}
