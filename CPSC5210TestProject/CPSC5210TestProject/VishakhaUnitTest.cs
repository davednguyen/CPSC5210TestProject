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
            Assert.Equals(document.Info.Title,"Created with PDFsharp");
        }
    }
}
