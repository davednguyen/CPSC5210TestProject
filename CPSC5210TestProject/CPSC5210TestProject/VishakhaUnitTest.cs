using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfSharp;
using PdfSharp.Pdf;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;

namespace CPSC5210TestProject
{
    [TestClass]
    public class VishakhaUnitTest
    {
        [TestMethod]
        public void TestPdfDocumentToBeNotNull()
        {
            PdfDocument document = new PdfDocument();
            Assert.IsNotNull(document);
        }

        [TestMethod]
        public void TestPageCountMatchesAddedPages()
        {
            PdfDocument document = new PdfDocument();
            document.AddPage();
            document.AddPage();
            Assert.IsTrue(2 == document.PageCount);

        }
        [TestMethod]
        public void TestTitleMatches()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";
            Assert.AreEqual(document.Info.Title, "Created with PDFsharp");
        }

        //[TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEmptySaveThrowsException()
        {
            PdfDocument document = new PdfDocument();
            document.Save("C:\\Users\\User\\test.pdf");
        }

        [TestMethod]
        public void TestGetCustomValues()
        {
            PdfDocument document = new PdfDocument();
            document.CustomValues.ToString();
        }

        [TestMethod]
        public void TestSetCustomValues()
        {
            PdfDocument document = new PdfDocument();
            document.CustomValues = null;
        }

        [TestMethod]
        public void TestGetEmptyFullPath()
        {
            PdfDocument document = new PdfDocument();
            Assert.AreEqual(String.Empty, document.FullPath);
        }

        [TestMethod]
        public void TestGetFileFullPath()
        {
            PdfDocument document = PdfReader.Open("..\\..\\..\\blank.pdf");
            StringAssert.Contains(document.FullPath, ":\\");
            StringAssert.EndsWith(document.FullPath, "\\blank.pdf");
        }

        [TestMethod]
        public void TestGetLanguage()
        {
            PdfDocument document = new PdfDocument();
            Assert.AreEqual(String.Empty, document.Language);
        }

        [TestMethod]
        public void TestSetLanguage()
        {
            PdfDocument document = new PdfDocument();
            document.Language = "French";
            Assert.AreEqual("French", document.Language);
        }

        [TestMethod]
        public void TestGetOutLines()
        {
            PdfDocument document = new PdfDocument();
            Assert.IsInstanceOfType(document.Outlines, typeof(PdfSharp.Pdf.PdfOutlineCollection));
        }

        [TestMethod]
        public void TestGetPageMode()
        {
            PdfDocument document = new PdfDocument();
            Assert.IsInstanceOfType(document.PageMode, typeof(PdfSharp.Pdf.PdfPageMode));
        }

          [TestMethod]
        public void TestPageTag()
        {
            PdfDocument document = new PdfDocument();
            document.Tag = "CustomStringObject";
            Assert.AreEqual("CustomStringObject", document.Tag);
        }

        [TestMethod]
        public void TestGetViewerPreferences()
        {
            PdfDocument document = new PdfDocument();
            Assert.IsInstanceOfType(document.ViewerPreferences, typeof(PdfSharp.Pdf.PdfViewerPreferences));
        }

        [TestMethod]
        public void TestGetFileSize()
        {
            PdfDocument document = new PdfDocument();
            Assert.AreEqual(0, document.FileSize);
        }

        [TestMethod]
        public void TestGetPageLayout()
        {
            PdfDocument document = new PdfDocument();
            //document.PageLayout=null;
            //Assert.AreEqual(0, document.FileSize);
            Assert.IsInstanceOfType(document.PageLayout, typeof(PdfSharp.Pdf.PdfPageLayout));
        }

        [TestMethod]
        public void TestGetSecurityHandler()
        {
            PdfDocument document = new PdfDocument();
            Assert.IsInstanceOfType(document.SecurityHandler, typeof(PdfSharp.Pdf.Security.PdfStandardSecurityHandler));
        }

    }
}
