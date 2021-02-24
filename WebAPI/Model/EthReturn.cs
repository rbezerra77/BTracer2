using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class EthReturn
    {
        public String TxHash { get; set; }
        public String Message { get; set; }
        [Required]
        public Boolean Success { get; set; }
    }
}