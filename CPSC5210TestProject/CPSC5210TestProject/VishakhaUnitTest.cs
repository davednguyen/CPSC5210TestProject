using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPSC5210TestProject
{
    [TestClass]
    public class VishakhaUnitTest
    {
        [Test()]
        public void TestPdfDocumentToBeNotNull()
        {
            PdfDocument document = new PdfDocument();
            Assert.NotNull(document);
        }

        [Test()]
        public void TestPageCountMatchesAddedPages()
        {
            PdfDocument document = new PdfDocument();
            document.AddPage();
            document.AddPage();
            Assert.True(2 == document.PageCount);

        }
        [Test()]
        public void TestTitleMatches()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";
            Assert.Equals(document.Info.Title,"Created with PDFsharp");
        }
    }
}
