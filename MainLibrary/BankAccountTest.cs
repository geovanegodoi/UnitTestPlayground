using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    [TestFixture]
    public class BankAccountTest
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            // arrange

            account = new BankAccount(100);
        }

        [Test]
        public void BankAccountShouldIncreaseOnPositiveDeposit()
        {
            // act
            account.Deposit(100);
            // assert
            Assert.That(account.Balance, Is.EqualTo(200));
        }

        [Test]
        public void BankAccountShouldDecreaseOnPositiveWithdraw()
        {
            // act
            account.Withdraw(50);
            // assert
            Assert.That(account.Balance, Is.EqualTo(50));
        }

        [Test]
        public void BankAccountShouldThrowOnPositiveAmount()
        {
            var ex = Assert.Throws<ArgumentException>(() => account.Deposit(-1));

            StringAssert.StartsWith("Deposit amount must be positive", ex.Message);
        }

        [Test]
        public void BankAccountLoginAndPasswordOk()
        {
            Assert.IsTrue(account.Login("geovane.godoi", "godoi123"));
        }

        [Test]
        public void BankAccountLoginNotOkAndPasswordOk()
        {
            Assert.IsFalse(account.Login("geovane", "godoi123"));
        }

        [Test]
        public void BankAccountLoginNotOkAndPasswordNotOk()
        {
            Assert.IsFalse(account.Login("geovane", "godoi"));
        }
    }
}
