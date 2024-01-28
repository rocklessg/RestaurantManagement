﻿using System.ComponentModel;

namespace Foody.Web.Models
{
    public class ResponseDto
    {
        [DefaultValue(true)]
        public bool IsSuccess { get; set; } //= true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
