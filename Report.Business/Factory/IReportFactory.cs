using Microsoft.Extensions.Configuration;
using Report.Business.Model;

namespace Report.Business.Factory
{
    public interface IReportFactory
    {
        HttpResponseMessage Download(CommonRequest downloadData, IConfiguration configuration);
    }
}
