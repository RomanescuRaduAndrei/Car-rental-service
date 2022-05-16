using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Cars
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }

        public int An { get; set; }

        public string Firma { get; set; }

        public string Imagine { get; set; }

        public int HorsePower { get; set; }

        public string Traction { get; set; }

        public string Transmission { get; set; }

        public string FuelType { get; set; }

        public int Weight { get; set; }



    }
}
