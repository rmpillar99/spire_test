using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;
using System.IO;
using Spire.Pdf.Graphics;
using System.Drawing;

namespace spire
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneratePDF();
            ReadSamplePDF();
        }

        private static void ReadSamplePDF()
        {
            var document = new PdfDocument();
            document.LoadFromFile("sample.pdf");

            var content = new StringBuilder();
        
            foreach (PdfPageBase page in document.Pages)
            {
                content.Append(page.ExtractText());
            }

            var fileName = "TextFromPDF.txt";
            File.WriteAllText(fileName, content.ToString());
        }

        private static void GeneratePDF()
        {
            var text = File.ReadAllText("TestDocument.txt");

            var doc = new PdfDocument();
            var section = doc.Sections.Add();
            var page = section.Pages.Add();

            var font = new PdfFont(PdfFontFamily.Helvetica, 11);

            var format = new PdfStringFormat();
            format.LineSpacing = 20f;

            var brush = PdfBrushes.Black;
            float y = 0;
            var textLayout = new PdfTextLayout();
            textLayout.Break = PdfLayoutBreakType.FitPage;
            textLayout.Layout = PdfLayoutType.Paginate;

            var textWidget = new PdfTextWidget(text, font, brush);
            var bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
            textWidget.StringFormat = format;
            textWidget.Draw(page, bounds, textLayout);

            doc.SaveToFile("TxtToPDf.pdf", FileFormat.PDF);
        }
    }
}
