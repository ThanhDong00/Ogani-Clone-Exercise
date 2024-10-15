using OganiClone.Models;
using Microsoft.AspNetCore.Mvc;
using OganiClone.Repository;

namespace OganiClone.ViewComponents
{
    public class LoaiSpMenuViewComponent: ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSpRepository;

        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpMenuRepository)
        {
            _loaiSpRepository = loaiSpMenuRepository;
        }
        public IViewComponentResult Invoke()
        {
            var dsLoaiSp = _loaiSpRepository.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(dsLoaiSp);
        }
    }
}
