using Microsoft.Extensions.Configuration;
using Report.Business.Factory;
using Report.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Service
{
    public class Service : IService
    {
        private readonly Resolver _resolver;

        public Service(Resolver resolver)
        {
            _resolver = resolver;
        }
        
        public HttpResponseMessage Generate(CommonRequest apiRequest, IConfiguration configuration)
        {
           return _resolver.Invoke(apiRequest.ReportType.ToUpper()).Download(apiRequest,configuration);
        }
    }
}
