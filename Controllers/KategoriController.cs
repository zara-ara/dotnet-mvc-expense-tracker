using Microsoft.AspNetCore.Mvc;
using YourApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace YourApp.Controllers
{
    public class KategoriController : Controller
    {
        // Simulasi database (dummy data)
        private static List<Kategori> _kategoris = new List<Kategori>
        {
            new Kategori { Id = 1, Tipe = "Income", Nama = "Gaji", Deskripsi = "Pendapatan bulanan", Status = "Active" },
            new Kategori { Id = 2, Tipe = "Expense", Nama = "Makan", Deskripsi = "Biaya makan", Status = "Active" }
        };

        // GET: Kategori
        public IActionResult Index()
        {
            return View(_kategoris);
        }

        // GET: Kategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategori/Create
        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {
            kategori.Id = _kategoris.Max(x => x.Id) + 1;
            _kategoris.Add(kategori);
            return RedirectToAction("Index");
        }

        // GET: Kategori/Edit/5
        public IActionResult Edit(int id)
        {
            var kategori = _kategoris.FirstOrDefault(x => x.Id == id);
            if (kategori == null) return NotFound();
            return View(kategori);
        }

        // POST: Kategori/Edit/5
        [HttpPost]
        public IActionResult Edit(Kategori kategori)
        {
            var data = _kategoris.FirstOrDefault(x => x.Id == kategori.Id);
            if (data != null)
            {
                data.Tipe = kategori.Tipe;
                data.Nama = kategori.Nama;
                data.Deskripsi = kategori.Deskripsi;
                data.Status = kategori.Status;
            }
            return RedirectToAction("Index");
        }

        // GET: Kategori/Details/5
        public IActionResult Details(int id)
        {
            var kategori = _kategoris.FirstOrDefault(x => x.Id == id);
            if (kategori == null) return NotFound();
            return View(kategori);
        }

        // GET: Kategori/Delete/5
        public IActionResult Delete(int id)
        {
            var kategori = _kategoris.FirstOrDefault(x => x.Id == id);
            if (kategori == null) return NotFound();
            return View(kategori);
        }

        // POST: Kategori/DeleteConfirmed
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var kategori = _kategoris.FirstOrDefault(x => x.Id == id);
            if (kategori != null) _kategoris.Remove(kategori);
            return RedirectToAction("Index");
        }
    }
}
