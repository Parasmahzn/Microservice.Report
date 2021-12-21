using Microsoft.Extensions.Configuration;
using Report.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Factory.Instance
{
    public class Excel : IReportFactory
    {
        public HttpResponseMessage Download(CommonRequest downloadData, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(downloadData.AppName);
            return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
        }

    }
}
