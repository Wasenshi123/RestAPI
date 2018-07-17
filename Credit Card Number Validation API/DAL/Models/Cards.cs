namespace DAL
{
    using System.ComponentModel.DataAnnotations;

    public partial class Cards
    {
        [Key]
        [MaxLength(16), MinLength(15)]
        public string CardNumber { get; set; }
    }
}
