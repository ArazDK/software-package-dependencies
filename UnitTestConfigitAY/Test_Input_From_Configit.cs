using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigitAYLogic;

namespace UnitTestConfigitAY
{
    [TestClass]
    public class Test_Input_From_Configit
    {
        [TestMethod]
        public void TestFile000()
        {
            SoftwarePackageBL bl = new SoftwarePackageBL();
            bl.Packages = new System.Collections.Generic.List<ISoftwarePackage>();
            bl.Packages.Add(new SoftwarePackage() { PackageName = "P1", PackageVersion = "42" });

            bl.Dependencies = new System.Collections.Generic.List<SoftwarePackageDependencie>();
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "P1",
                PackageVersion = "42",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "P2",
                    PackageVersion = "Beta-1"
                }
            });

            Assert.IsTrue(bl.Check());
        }

        [TestMethod]
        public void TestFile001()
        {
            SoftwarePackageBL bl = new SoftwarePackageBL();
            bl.Packages = new System.Collections.Generic.List<ISoftwarePackage>();
            bl.Packages.Add(new SoftwarePackage() { PackageName = "A", PackageVersion = "1" });
         
            bl.Dependencies = new System.Collections.Generic.List<SoftwarePackageDependencie>();
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "A",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "B",
                    PackageVersion = "2"
                }
            });
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "A",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "B",
                    PackageVersion = "1"
                }
            });

            Assert.IsFalse(bl.Check());
        }
        [TestMethod]
        public void TestFile002()
        {
            SoftwarePackageBL bl = new SoftwarePackageBL();
            bl.Packages = new System.Collections.Generic.List<ISoftwarePackage>();
            bl.Packages.Add(new SoftwarePackage() { PackageName = "B", PackageVersion = "2" });

            bl.Dependencies = new System.Collections.Generic.List<SoftwarePackageDependencie>();
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "B",
                PackageVersion = "2",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "A",
                    PackageVersion = "1",
                    DependOn = new SoftwarePackageDependencie()
                    {
                        PackageName = "C",
                        PackageVersion = "1"
                    }
                }
            });
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "C",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "A",
                    PackageVersion = "2"
                }
            });

            Assert.IsFalse(bl.Check());
        }
        [TestMethod]
        public void TestFile003()
        {
            SoftwarePackageBL bl = new SoftwarePackageBL();
            bl.Packages = new System.Collections.Generic.List<ISoftwarePackage>();
            bl.Packages.Add(new SoftwarePackage() { PackageName = "B", PackageVersion = "1" });

            bl.Dependencies = new System.Collections.Generic.List<SoftwarePackageDependencie>();
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "B",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "B",
                    PackageVersion = "1"
                }
            });
          
            Assert.IsTrue(bl.Check());
        }
        [TestMethod]
        public void TestFile004()
        {
            SoftwarePackageBL bl = new SoftwarePackageBL();
            bl.Packages = new System.Collections.Generic.List<ISoftwarePackage>();
            bl.Packages.Add(new SoftwarePackage() { PackageName = "A", PackageVersion = "2" });
            bl.Packages.Add(new SoftwarePackage() { PackageName = "B", PackageVersion = "2" });

            bl.Dependencies = new System.Collections.Generic.List<SoftwarePackageDependencie>();
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "A",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "B",
                    PackageVersion = "1",

                }
            });
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "A",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "B",
                    PackageVersion = "2"
                }
            });
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "A",
                PackageVersion = "2",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "C",
                    PackageVersion = "3"
                }
            });

            Assert.IsTrue(bl.Check());
        }
        [TestMethod]
        public void TestFile005()
        {
            SoftwarePackageBL bl = new SoftwarePackageBL();
            bl.Packages = new System.Collections.Generic.List<ISoftwarePackage>();
            bl.Packages.Add(new SoftwarePackage() { PackageName = "A", PackageVersion = "2" });
            bl.Packages.Add(new SoftwarePackage() { PackageName = "B", PackageVersion = "2" });

            bl.Dependencies = new System.Collections.Generic.List<SoftwarePackageDependencie>();
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "A",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "B",
                    PackageVersion = "1",
                   
                }
            });
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "A",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "B",
                    PackageVersion = "2"
                }
            });
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "A",
                PackageVersion = "2",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "C",
                    PackageVersion = "3"
                }
            });

            Assert.IsTrue(bl.Check());
        }
        [TestMethod]
        public void TestFile006()
        {
            SoftwarePackageBL bl = new SoftwarePackageBL();
            bl.Packages = new System.Collections.Generic.List<ISoftwarePackage>();
            bl.Packages.Add(new SoftwarePackage() { PackageName = "B", PackageVersion = "2" });

            bl.Dependencies = new System.Collections.Generic.List<SoftwarePackageDependencie>();
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "A",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "B",
                    PackageVersion = "2"
                }
            });
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "B",
                PackageVersion = "2",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "A",
                    PackageVersion = "1"
                }
            });

            Assert.IsTrue(bl.Check());
        }
        [TestMethod]
        public void TestFile007()
        {
            SoftwarePackageBL bl = new SoftwarePackageBL();
            bl.Packages = new System.Collections.Generic.List<ISoftwarePackage>();
            bl.Packages.Add(new SoftwarePackage() { PackageName = "A", PackageVersion = "1" });
            bl.Packages.Add(new SoftwarePackage() { PackageName = "C", PackageVersion = "2" });

            bl.Dependencies = new System.Collections.Generic.List<SoftwarePackageDependencie>();
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "A",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "B",
                    PackageVersion = "1",
                    
                }
            });
            bl.Dependencies.Add(new SoftwarePackageDependencie()
            {
                PackageName = "C",
                PackageVersion = "1",
                DependOn = new SoftwarePackageDependencie()
                {
                    PackageName = "B",
                    PackageVersion = "2",
                    
                }
            });

            Assert.IsFalse(bl.Check());
        }
        [TestMethod]
        public void TestFile008()
        {
            SoftwarePackageBL bl = new SoftwarePackageBL();
            bl.Packages = new System.Collections.Generic.List<ISoftwarePackage>();
            bl.Packages.Add(new SoftwarePackage() { PackageName = "A", PackageVersion = "1" });

           
            Assert.IsTrue(bl.Check());
        }

    }
}
