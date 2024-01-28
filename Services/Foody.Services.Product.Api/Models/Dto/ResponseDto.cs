using System.ComponentModel;

namespace Foody.Services.ProductApi.Models.Dto
{
    public class ResponseDto
    {
        [DefaultValue("true")]
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
