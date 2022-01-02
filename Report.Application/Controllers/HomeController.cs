using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.Business.Model;
using Report.Business.Service;
using System.Web.Http.Results;

namespace Report.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService _service;
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IService service, IConfiguration configuration)
        {
            _logger = logger;
            _service = service;
            _config = configuration;
        }

        [HttpPost(Name = "GetReport")]
        public HttpResponseMessage Index(CommonRequest apiRequest)
        {
            if (!string.IsNullOrEmpty(apiRequest.ReportType))
                return _service.Generate(apiRequest, _config);
            else
                return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
        }
    }
}
