using GaraMan.GaraDbContext;
using GaraMan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GaraMan.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Timkiemthongtin385()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            return RedirectToAction("Danhsachtimkiem385", new { searchTerm });
        }

        // Xử lý tìm kiếm và hiển thị danh sách kết quả
        public async Task<IActionResult> Danhsachtimkiem385(string searchTerm)
        {
            var viewModel = new SearchViewModel
            {
                SearchTerm = searchTerm,
                DichvuResults = await _context.Dichvus
                    .Where(d => d.Name.Contains(searchTerm))
                    .ToListAsync(),
                PhutungResults = await _context.Phutungs
                    .Where(p => p.Name.Contains(searchTerm))
                    .ToListAsync()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Thongtinchitiet385(string id, bool isDichvu)
        {
            var viewModel = new DetailViewModel { IsDichvu = isDichvu };

            if (isDichvu)
            {
                viewModel.Dichvu = await _context.Dichvus.FindAsync(id);
                if (viewModel.Dichvu == null) return NotFound();
            }
            else
            {
                viewModel.Phutung = await _context.Phutungs.FindAsync(id);
                if (viewModel.Phutung == null) return NotFound();
            }

            return View(viewModel);
        }
    }
}
