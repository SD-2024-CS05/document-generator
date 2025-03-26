using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeHandler.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Identity.Tests
{
    [TestClass]
    public class KeyVaultManagerTests
    {
        [TestMethod()]
        public void KeyVaultManagerTest()
        {
            try
            {
                KeyVaultManager keyVaultManager = new KeyVaultManager();
                Assert.IsNotNull(keyVaultManager);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Constructor threw an exception: {ex.Message}");
            }
        }

        [TestMethod()]
        public void GetSecretAsyncTest()
        {
            try
            {
                KeyVaultManager keyVaultManager = new KeyVaultManager();
                var secret = keyVaultManager.GetSecretAsync("Neo4JInstanceName").Result;
                Assert.IsNotNull(secret);
            }
            catch (Exception ex)
            {
                Assert.Fail($"GetSecretAsync threw an exception: {ex.Message}");
            }
        }
    }
}