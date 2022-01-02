using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
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
            string sql = "select * from Products";
            var dbResp = DapperDAO.ExecuteQuery<ProductModel>(sql, downloadData.AppName, configuration);

            string path = System.IO.Directory.GetCurrentDirectory();

            var templateContent = File.ReadAllText(path + "/Views/Index.cshtml");

            //var htmlContent = Razor.Parse(templateContent, dbResp);

            var result = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            Byte[] bytes;
            using (var ms = new MemoryStream())
            {
                using (var doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 20, 10))
                {
                    using var writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();
                    try
                    {
                        var html = templateContent;

                        using var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html));

                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, System.Text.Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    finally
                    {
                        doc.Close();
                    }
                }
                bytes = ms.ToArray();
            }

            result.Content = new ByteArrayContent(bytes);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = downloadData.AppName + DateTime.Now.ToString() + ".pdf"
            };

            return result;

        }
    }
}
