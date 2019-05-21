using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;
using System.IO;
using Spire.Pdf.Graphics;
using System.Drawing;
using Spire.Pdf.General.Find;
using Spire.Pdf.Graphics.Fonts;

namespace spire
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneratePDF();
            ReadSamplePDF();
            
            //PdfDocument doc = new PdfDocument("TxtToPDf.pdf");
            //PdfUsedFont[] fonts = doc.UsedFonts;


            ReplaceDataInPDF();
        }

        private static void ReplaceDataInPDF()
        {
            PdfDocument doc = new PdfDocument("sample.pdf");
            PdfPageBase page = doc.Pages[0];
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("text", "TEXT");
            FindAndReplace(doc, dictionary);
            doc.SaveToFile("result.pdf");
        }

        public static void FindAndReplace(PdfDocument documents, Dictionary<string, string> dictionary)
        {
            PdfTextFind[] result = null;
            foreach (var word in dictionary)
            {
                foreach (PdfPageBase page in documents.Pages)
                {
                    result = page.FindText(word.Key).Finds;
                    foreach (PdfTextFind find in result)
                    {
                        //replace word in pdf                   
                        find.ApplyRecoverString(word.Value, System.Drawing.Color.White, true);
                    }
                }
            }
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
            format.LineSpacing = 40f;

            var brush = PdfBrushes.Black;
            float y = 20;
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
