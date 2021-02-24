using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class EthReturnFull
    {
        public String TxHashB { get; set; }
        public String TxHashC { get; set; }
        public String TxHashD { get; set; }
        public String TxHashE { get; set; }
        public String Message { get; set; }
        [Required]
        public Boolean Success { get; set; }
    }
}