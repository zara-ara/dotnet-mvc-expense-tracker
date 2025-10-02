using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using nyobaa.Models;

namespace nyobaa.Controllers
{
    public class BudgetController : Controller
    {
        private static List<Budget> _budgetList = new List<Budget>();
        private static List<Kategori> _kategoriList = new List<Kategori>
        {
            new Kategori { Id = 1, Nama = "Transport" },
            new Kategori { Id = 2, Nama = "Makanan" },
            new Kategori { Id = 3, Nama = "Belanja" }
        };

        public IActionResult Index()
        {
            return View(_budgetList);
        }

        public IActionResult Create()
        {
            ViewBag.Kategori = new SelectList(_kategoriList, "Id", "Nama");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Budget budget)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Kategori = new SelectList(_kategoriList, "Id", "Nama", budget.KategoriId);
                return View(budget);
            }

            budget.Id = _budgetList.Count + 1;
            budget.Kategori = _kategoriList.FirstOrDefault(k => k.Id == budget.KategoriId);
            _budgetList.Add(budget);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var budget = _budgetList.FirstOrDefault(x => x.Id == id);
            if (budget == null) return NotFound();

            ViewBag.Kategori = new SelectList(_kategoriList, "Id", "Nama", budget.KategoriId);
            return View(budget);
        }

        [HttpPost]
        public IActionResult Edit(Budget budget)
        {
            var existing = _budgetList.FirstOrDefault(x => x.Id == budget.Id);
            if (existing == null) return NotFound();

            existing.KategoriId = budget.KategoriId;
            existing.Kategori = _kategoriList.FirstOrDefault(k => k.Id == budget.KategoriId);
            existing.Nama = budget.Nama;
            existing.Deskripsi = budget.Deskripsi;
            existing.TotalBudget = budget.TotalBudget;
            existing.StartDate = budget.StartDate;
            existing.EndDate = budget.EndDate;
            existing.IsRepeat = budget.IsRepeat;
            existing.Status = budget.Status;

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var budget = _budgetList.FirstOrDefault(x => x.Id == id);
            if (budget == null) return NotFound();

            return View(budget);
        }

        public IActionResult Delete(int id)
        {
            var budget = _budgetList.FirstOrDefault(x => x.Id == id);
            if (budget == null) return NotFound();

            return View(budget);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var budget = _budgetList.FirstOrDefault(x => x.Id == id);
            if (budget != null)
            {
                _budgetList.Remove(budget);
            }
            return RedirectToAction("Index");
        }
    }
}
