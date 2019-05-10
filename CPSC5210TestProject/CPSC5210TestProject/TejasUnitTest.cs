using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;

namespace CPSC5210TestProject
{
    [TestClass]
    public class TejasUnitTest
    {
        private object document;

        public TejasUnitTest()
        {

        }
        [TestMethod]
        public void TestCreateDocument()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";
        }

        [TestMethod]
        public void TestAddPageToDocument()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
        }
        [TestMethod]

        public void TestGetXgraphicsPage()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
        }

        [TestMethod]
        public void TestCreateFontStyle()
        {
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
        }

        [TestMethod]
        public void TestDrawTextWithFont()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 30, XFontStyle.Italic);
            gfx.DrawString("Hello, World!", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.Center);
        }

        [TestMethod]
        public void TestSaveDocument()
        {
            PdfDocument document = new PdfDocument();
            const string filename = "PracticeDocument.pdf";
            document.Save(filename);
            //Process.start(filename);
        }

       
    }
}
