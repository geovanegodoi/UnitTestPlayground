using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    [TestFixture]
    public class DataDrivenTest
    {
        private BankAccount account;

        [SetUp]
        public void SetUp()
        {
            account = new BankAccount(100);
        }

        [Test]
        [TestCase(50 , true ,  50)]
        [TestCase(100, true ,   0)]
        [TestCase(150, false, 100)]
        [TestCase(-50, false, 100)]
        public void TestMultipleWithdrawScenarios(int amountToWithdraw, bool shouldSucceed, int expectedBalance)
        {
            if (amountToWithdraw < 0)
            {
                var ex = Assert.Throws<ArgumentException>(() => account.Withdraw(amountToWithdraw));

                StringAssert.StartsWith("Withdraw amount must be positive", ex.Message);
            }
            else
            {
                var result = account.Withdraw(amountToWithdraw);

                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.EqualTo(shouldSucceed));

                    Assert.That(account.Balance, Is.EqualTo(expectedBalance));
                });
            }                        
        }
    }
}
