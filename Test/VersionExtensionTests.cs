using Extensio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{    
    [TestClass]
    public class VersionExtensionTests
    {
        [TestCategory("Unit"), TestMethod]
        public void ToVersionTest()
        {
            var v = new Version(DateTime.Now.Year, 1, 1);
            var versionString = v.ToString();
            Assert.AreEqual(v, versionString.ToVersion(), "Good ToVersion Failed");
            versionString = string.Format("{0}.1.1", DateTime.Now.Year);
            Assert.AreEqual(v, versionString.ToVersion(), "Good ToVersion Failed");
            versionString = string.Empty;
            Assert.AreNotEqual(v, versionString.ToVersion(), "Bad ToVersion Failed");
            versionString = "some.old.scrap";
            Assert.AreNotEqual(v, versionString.ToVersion(), "Bad ToVersion Failed");
        }

        [TestCategory("Unit"), TestMethod]
        public void IsVersionEqualTest()
        {
            var v = new Version(DateTime.Now.Year, 1, 1);
            var versionString = v.ToString();
            Assert.IsTrue(v.IsVersionEqual(versionString.ToVersion()), "True Equals Failed");
            versionString = string.Format("{0}.1.1", DateTime.Now.Year);
            Assert.IsTrue(v.IsVersionEqual(versionString.ToVersion()), "True Equals Failed");
            versionString = null;
            Assert.IsFalse(v.IsVersionEqual(versionString.ToVersion()), "False Equals Failed");
            versionString = string.Empty;
            Assert.IsFalse(v.IsVersionEqual(versionString.ToVersion()), "False Equals Failed");
            versionString = "some.old.scrap";
            Assert.IsFalse(v.IsVersionEqual(versionString.ToVersion()), "False Equals Failed");
        }

        [TestCategory("Unit"), TestMethod]
        public void IsVersionHigherTest()
        {
            var v = new Version(DateTime.Now.Year, 1, 1);
            var versionString = v.ToString();
            Assert.IsFalse(v.IsVersionHigher(versionString.ToVersion()), "False Higher Failed");
            versionString = string.Format("{0}.1.2", DateTime.Now.Year);
            Assert.IsTrue(v.IsVersionHigher(versionString.ToVersion()), "True Higher Failed");
            versionString = string.Format("{0}.2.1", DateTime.Now.Year);
            Assert.IsTrue(v.IsVersionHigher(versionString.ToVersion()), "True Higher Failed");
            versionString = string.Format("{0}.1.1", DateTime.Now.Year + 1);
            Assert.IsTrue(v.IsVersionHigher(versionString.ToVersion()), "True Higher Failed");
            versionString = string.Format("{0}.2.2", DateTime.Now.Year + 1);
            Assert.IsTrue(v.IsVersionHigher(versionString.ToVersion()), "True Higher Failed");
            versionString = string.Format("{0}.1.0", DateTime.Now.Year);
            Assert.IsFalse(v.IsVersionHigher(versionString.ToVersion()), "False Higher Failed");
            versionString = string.Format("{0}.0.1", DateTime.Now.Year);
            Assert.IsFalse(v.IsVersionHigher(versionString.ToVersion()), "False Higher Failed");
            versionString = string.Format("{0}.1.1", DateTime.Now.Year - 1);
            Assert.IsFalse(v.IsVersionHigher(versionString.ToVersion()), "False Higher Failed");
            versionString = string.Format("{0}.0.0", DateTime.Now.Year - 1);
            Assert.IsFalse(v.IsVersionHigher(versionString.ToVersion()), "False Higher Failed");
        }

        [TestCategory("Unit"), TestMethod]
        public void IsVersionLowerTest()
        {
            var v = new Version(DateTime.Now.Year, 1, 1);
            var versionString = v.ToString();
            Assert.IsFalse(v.IsVersionLower(versionString.ToVersion()), "False Lower Failed");
            versionString = string.Format("{0}.1.0", DateTime.Now.Year);
            Assert.IsTrue(v.IsVersionLower(versionString.ToVersion()), "True Lower Failed");
            versionString = string.Format("{0}.0.1", DateTime.Now.Year);
            Assert.IsTrue(v.IsVersionLower(versionString.ToVersion()), "True Lower Failed");
            versionString = string.Format("{0}.1.1", DateTime.Now.Year - 1);
            Assert.IsTrue(v.IsVersionLower(versionString.ToVersion()), "True Lower Failed");
            versionString = string.Format("{0}.0.0", DateTime.Now.Year - 1);
            Assert.IsTrue(v.IsVersionLower(versionString.ToVersion()), "True Lower Failed");
            versionString = string.Format("{0}.1.2", DateTime.Now.Year);
            Assert.IsFalse(v.IsVersionLower(versionString.ToVersion()), "False Lower Failed");
            versionString = string.Format("{0}.2.1", DateTime.Now.Year);
            Assert.IsFalse(v.IsVersionLower(versionString.ToVersion()), "False Lower Failed");
            versionString = string.Format("{0}.1.1", DateTime.Now.Year + 1);
            Assert.IsFalse(v.IsVersionLower(versionString.ToVersion()), "False Lower Failed");
            versionString = string.Format("{0}.2.2", DateTime.Now.Year + 1);
            Assert.IsFalse(v.IsVersionLower(versionString.ToVersion()), "False Lower Failed");
        }


    }
}
