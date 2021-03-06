using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Extensions.Configuration;
using Report.Business.Model;
using ReportRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Factory.Instance
{
    public class Pdf : IReportFactory
    {
        public HttpResponseMessage Download(CommonRequest downloadData, IConfiguration configuration)
        {
            //string sql = "select * from Products";
            //var dbResp = DapperDAO.ExecuteQuery<ProductModel>(sql, downloadData.AppName, configuration);

            //string path = System.IO.Directory.GetCurrentDirectory();

            //var templateContent = File.ReadAllText(path + "/Views/Index.cshtml");

            //var htmlContent = Razor.Parse(templateContent, dbResp);

            var result = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            Byte[] bytes;

            using (var stream = new MemoryStream())
            {
                try
                {
                    var writer = new PdfWriter(stream);
                    var pdf = new PdfDocument(writer);
                    using (var document = new Document(pdf, iText.Kernel.Geom.PageSize.A4, true))
                    {
                        document.SetLeftMargin(50);
                        document.Add(getTableCells());
                    }
                    bytes = stream.ToArray();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            result.Content = new ByteArrayContent(bytes);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = downloadData.AppName + DateTime.Now.ToString() + ".pdf"
            };

            return result;
        }
        private Table getTableCells()
        {
            float[] colsWidth = { 5, 5, 5, 5 };
            string nepaliFont =  System.IO.Directory.GetCurrentDirectory()+ "\\wwwroot\\font\\PreetiNormal.otf";
            PdfFont npFont = PdfFontFactory.CreateFont(nepaliFont);
            PdfFont standard = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            Table tableman = new Table(UnitValue.CreatePercentArray(colsWidth));

            Cell cellman = new Cell(1, 4)
            .Add(new Paragraph("Header"))
            .SetFont(standard)
            .SetFontSize(13)
            .SetFontColor(DeviceGray.WHITE)
            .SetBackgroundColor(DeviceGray.BLACK)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetBorder(new SolidBorder(ColorConstants.GRAY, 2));
            // Add Header cell.
            tableman.AddHeaderCell(cellman);

            Cell cellman1 = new Cell(1, 1)
                        .Add(new Paragraph("cell1"))
                        .SetFont(standard)
                        .SetFontSize(13)
                        .SetFontColor(DeviceGray.BLACK)
                        .SetBackgroundColor(new DeviceGray(0.75f))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorder(new SolidBorder(ColorConstants.GRAY, 2));
            // Add cell 1.
            tableman.AddHeaderCell(cellman1);

            Cell cellman2 = new Cell(1, 1)
                        .Add(new Paragraph("cell2"))
                        .SetFont(standard)
                        .SetFontSize(13)
                        .SetFontColor(DeviceGray.BLACK)
                        .SetBackgroundColor(new DeviceGray(0.75f))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorder(new SolidBorder(ColorConstants.GRAY, 2));
            // Add cell 2.
            tableman.AddHeaderCell(cellman2);

            Cell cellman3 = new Cell(1, 1)
                        .Add(new Paragraph("cell3"))
                        .SetFont(standard)
                        .SetFontSize(13)
                        .SetFontColor(DeviceGray.BLACK)
                        .SetBackgroundColor(new DeviceGray(0.75f))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorder(new SolidBorder(ColorConstants.GRAY, 2));
            // Add cell 3.
            tableman.AddHeaderCell(cellman3);

            Cell cellman4 = new Cell(1, 1)
                        .Add(new Paragraph("cell4"))
                        .SetFont(standard)
                        .SetFontSize(13)
                        .SetFontColor(DeviceGray.BLACK)
                        .SetBackgroundColor(new DeviceGray(0.75f))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetBorder(new SolidBorder(ColorConstants.GRAY, 2));
            // Add cell 4.
            tableman.AddHeaderCell(cellman4);
            tableman.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Hello")));
            tableman.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("I")));
            tableman.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("paras")).SetFont(npFont).SetFontSize(13));
            tableman.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("पारस")).SetFont(npFont).SetFontSize(13));
            return tableman;
        }
    }
}
