using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Remetee_Challenge.Core.Entities
{
    public class Quote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; internal set; }
        public string Key { get; set; }
        public double valor { get; set; }
        
        public long CurrencyLayerId { get; set; }
        public CurrencyLayer CurrencyLayer { get; set; }
    }
}
