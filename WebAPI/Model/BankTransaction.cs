using System;
using System.Numerics;

namespace WebAPI.Model
{
    public class BankTransaction
    {
        public String PartnerId { get; set; }
        public String TransDescription { get; set; }
        public String TransType { get; set; }
        public Decimal TransValue { get; set; }
        public DateTime TransDateTime  { get; set; }
    }
}