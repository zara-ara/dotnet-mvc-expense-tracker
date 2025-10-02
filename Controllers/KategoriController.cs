using Microsoft.AspNetCore.Mvc;
using nyobaa.Models;
using System.Collections.Generic;
using System.Linq;

namespace nyobaa.Controllers
{
    public class KategoriController : Controller
    {
        // sementara pakai static list (dummy)
        private static List<Kategori> data = new List<Kategori>
        {
            new Kategori { Id = 1, Tipe="Income", Nama="Gaji", Deskripsi="Pendapatan bulanan", Status="Active"},
            new Kategori { Id = 2, Tipe="Expense", Nama="Makan", Deskripsi="Biaya makan", Status="Active"}
        };

        public IActionResult Index()
        {
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var kategori = data.FirstOrDefault(x => x.Id == id);
            return View(kategori);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kategori model)
        {
            model.Id = data.Max(x => x.Id) + 1;
            data.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var kategori = data.FirstOrDefault(x => x.Id == id);
            return View(kategori);
        }

        [HttpPost]
        public IActionResult Edit(Kategori model)
        {
            var kategori = data.FirstOrDefault(x => x.Id == model.Id);
            if (kategori != null)
            {
                kategori.Tipe = model.Tipe;
                kategori.Nama = model.Nama;
                kategori.Deskripsi = model.Deskripsi;
                kategori.Status = model.Status;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var kategori = data.FirstOrDefault(x => x.Id == id);
            return View(kategori);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var kategori = data.FirstOrDefault(x => x.Id == id);
            if (kategori != null)
            {
                data.Remove(kategori);
            }
            return RedirectToAction("Index");
        }
    }
}
