using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfSharp;
using PdfSharp.Pdf;
using System.IO;

namespace CPSC5210TestProject
{
    /// <summary>
    /// Summary description for DavidMainUnitTest
    /// </summary>
    [TestClass]
    public class DavidMainUnitTest
    {
        public DavidMainUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCreatePDFDocumentTest()
        {
            PdfDocument document = new PdfDocument();
            Assert.IsNotNull(document);
        }

        [TestMethod]
        public void TestCreateEmptyPageForAPDFDocument()
        {
            // Create an empty page
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            Assert.IsNotNull(page);
        }

        [TestMethod]
        public void CheckCreatePDFDocumentWithName()
        {
            PdfDocument testDocument = new PdfDocument("TestFile");
            Assert.IsNotNull(testDocument);
        }

        [TestMethod]
        public void CheckCreatePDFDocumentWithStream()
        {
            Stream outputStream=null;
            PdfDocument testDocument = new PdfDocument(outputStream);
            Assert.IsNotNull(testDocument);
        }
    }
}
