using Microsoft.Extensions.Configuration;
using Report.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Service
{
    public interface IService
    {
        HttpResponseMessage Generate(CommonRequest apiRequest, IConfiguration configuration);
    }
}
