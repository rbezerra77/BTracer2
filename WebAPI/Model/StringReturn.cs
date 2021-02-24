using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class StringReturn
    {
        public String Value { get; set; }
        public String Message { get; set; }
        [Required]
        public Boolean Success { get; set; }
    }
}