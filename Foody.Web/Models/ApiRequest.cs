using System.ComponentModel;
using static Foody.Web.ApiConstants;

namespace Foody.Web.Models
{
    public class ApiRequest
    {
        [DefaultValue(ApiType.GET)]
        public ApiType ApiType { get; set; } //= ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
