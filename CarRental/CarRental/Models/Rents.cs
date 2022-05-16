using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Rents
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RentBegin { get; set; }

        public string RentEnd { get; set; }

        public string PayMethod { get; set; }

    }
}
