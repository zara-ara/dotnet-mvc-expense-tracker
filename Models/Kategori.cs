using System.ComponentModel.DataAnnotations;

namespace nyobaa.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required]
        public string Tipe { get; set; } // Income / Expense

        [Required]
        public string Nama { get; set; }

        public string Deskripsi { get; set; }

        [Required]
        public string Status { get; set; } // Active / Not Active
    }
}
