using System;
using System.ComponentModel.DataAnnotations;

namespace Wasenshi.CreditCard.Libs.Models
{
    public class Card
    {
        [Required]
        public string Number { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}