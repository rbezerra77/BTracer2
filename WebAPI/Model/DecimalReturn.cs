using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class DecimalReturn
    {
        public Decimal Value { get; set; }
        public String Message { get; set; }
        [Required]
        public Boolean Success { get; set; }
    }
}