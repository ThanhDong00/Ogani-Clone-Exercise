using OganiClone.Models;

namespace OganiClone.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSp GetLoaiSp(string maLoaiSp);
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(string maLoaiSp);

        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
