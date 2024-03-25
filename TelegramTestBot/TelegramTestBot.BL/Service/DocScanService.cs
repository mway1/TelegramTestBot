using System;
using System.IO;
using System.Text;
using BitMiracle.Docotic.Pdf;
using Tesseract;


namespace TelegramTestBot.BL.Service
{
    public static class DocScanService
    {
        public static void Main() 
        {
            var documentText = new StringBuilder();
            using (var pdf = new PdfDocument("Test.pdf"))
            {
                using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
                {
                    for (int i = 0; i < pdf.PageCount; i++)
                    {
                        if (documentText.Length > 0)
                            documentText.Append("\r\n\r\n");

                        PdfPage page = pdf.Pages[i];
                        string searchableText = page.GetText();

                        //Check if the page contains searchable text
                        //We don't need to perform OCR in that case
                        if (!string.IsNullOrEmpty(searchableText.Trim()))
                        {
                            documentText.Append(searchableText);
                            continue;
                        }



                    }
                }
            }
        }

    }
}
