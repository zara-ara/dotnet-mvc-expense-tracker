namespace YourApp.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Tipe { get; set; }      // Income / Expense
        public string Nama { get; set; }
        public string Deskripsi { get; set; }
        public string Status { get; set; }    // Active / Not Active
    }
}
