using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enclave.Models;

namespace ModelTests
{
    [TestClass]
    public class EnclaveTests
    {
        [TestMethod]
        public void PhaseTest()
        {
            var enclave = Enclave.Models.Enclave.Get("super");

        }
    }
}
