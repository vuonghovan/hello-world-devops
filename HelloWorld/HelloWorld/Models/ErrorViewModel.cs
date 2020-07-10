using System;
using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class CreateViewModel
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
    }
}
