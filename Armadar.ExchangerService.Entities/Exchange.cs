using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Armadar.ExchangerService.Entities
{
    public class Exchange
    {
        public long Id { get; set; }
        [Column(TypeName ="varchar(3)")]
        public string from { get; set; }
        [Column(TypeName = "varchar(3)")]
        public string to { get; set; }
        [Column(TypeName = "varchar(1)")]
        public string operation { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal rate { get; set; }
        public DateTime dateRate { get; set; }
        [NotMapped]
        public decimal amount { get; set; }
        [NotMapped]
        public decimal value { get; set; }
        public bool isActive { get; set; }
    }
}