using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OganiClone.Models;
using System.Diagnostics;
using X.PagedList;

namespace OganiClone.Controllers
{
    public class HomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageIndex = page == null || page < 0 ? 1 : page.Value;

            var dsDanhMuc = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(dsDanhMuc, pageIndex, pageSize);

            return View(list);
        }

        public IActionResult SanPhamTheoLoai(string maloai, int? page)
        {
            int pageSize = 8;
            int pageIndex = page == null || page < 0 ? 1 : page.Value;

            var sdSanPham = db.TDanhMucSps.Where(x => x.MaLoai == maloai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(sdSanPham, pageIndex, pageSize);

            ViewBag.maloai = maloai;

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
