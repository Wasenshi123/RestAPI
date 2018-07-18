using System;
using System.ComponentModel.DataAnnotations;

namespace Wasenshi.CreditCard.Libs.Models
{
    public class Card
    {
        [Required]
        [MaxLength(16), MinLength(15)]
        public string Number { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}