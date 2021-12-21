using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Model
{
    public class CommonRequest
    {
        [Required]
        public string ?AppName { get; set; }
        [Required]
        public string ?UserName { get; set; }
        [Required]
        public string ?TransactionId { get; set; }
        public string ReportType { get; set; } = "pdf";

    }

    public class CommonResponse
    {
        [JsonProperty(Order = 0)]
        public string? Code { get; set; }
        [JsonProperty(Order = 1)]
        public string? Message { get; set; }
        [JsonProperty(Order = 2)]
        public object? Data { get; set; }
        [JsonProperty(Order = 3)]
        public List<Error>? Errors { get; set; }
    }

    public class Error
    {
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
