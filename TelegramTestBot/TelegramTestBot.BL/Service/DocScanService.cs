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

                        //If the page unsearchable then save the page as high-res image
                        PdfDrawOptions options = PdfDrawOptions.Create();
                        options.BackgroundColor = new PdfRgbColor(255, 255, 255);
                        options.HorizontalResolution = 300;
                        options.VerticalResolution = 300;

                        string pageImage = $"page_{i}.png";
                        page.Save(pageImage,options);

                        //Perform OCR
                        using (Pix img = Pix.LoadFromFile(pageImage))
                        {
                            using (Page recognizedPage = engine.Process(img))
                            {
                                string recognizedText = recognizedPage.GetText();
                                documentText.Append(recognizedText);
                            }
                        }

                        File.Delete(pageImage);

                    }
                }
            }
            using (var writer = new StreamWriter("res.txt"))
                writer.Write(documentText.ToString());
        }

    }
}
