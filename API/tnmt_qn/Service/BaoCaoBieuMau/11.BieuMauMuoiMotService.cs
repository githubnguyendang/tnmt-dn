using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Collections.Generic;
using System.Linq;

namespace tnmt_qn.Service
{
    public class BieuMauMuoiMotService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiMotService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauMuoiMotDto>> GetAllAsync()
        {
            var ids = new HashSet<int?> { 4, 5, 6, 7, 10, 11, 12, 13, 14, 15 };

            var items = await _context.LuuVucSong!
                 .Where(lvs => lvs.Id > 0)
                 .Select(lvs => new BieuMauMuoiMotDto
                 {
                     Id = lvs.Id,
                     LuuVucSong = lvs.TenLVS,
                     TongSoCongTrinh = lvs.CongTrinh!.Where(ct => ids.Contains(ct.IdLoaiCT) && ct.DaXoa == false).Count(),
                     CongTrinhHoChua = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 5 && ct.DaXoa == false).Count(),
                     CongTrinhDapDang = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 11 && ct.DaXoa == false).Count(),
                     CongTrinhCong = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 12 && ct.DaXoa == false).Count(),
                     CongTrinhTramBom = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 6 && ct.DaXoa == false).Count(),
                     CongTrinhKhacNuocMat = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 14 || ct.IdLoaiCT == 13 || ct.IdLoaiCT == 4 && ct.DaXoa == false).Count(),
                     CongTrinhGieng = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 7 || ct.IdLoaiCT == 10 && ct.DaXoa == false).Count(),
                     CongTrinhKhacNDD = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 15 && ct.DaXoa == false).Count(),
                 })
                 .ToListAsync();

            // Calculate total for summary row
            var total = new BieuMauMuoiMotDto
            {
                Id = -1,
                LuuVucSong = "Tổng",
                TongSoCongTrinh = items.Sum(item => item.TongSoCongTrinh),
                CongTrinhHoChua = items.Sum(item => item.CongTrinhHoChua),
                CongTrinhDapDang = items.Sum(item => item.CongTrinhDapDang),
                CongTrinhCong = items.Sum(item => item.CongTrinhCong),
                CongTrinhTramBom = items.Sum(item => item.CongTrinhTramBom),
                CongTrinhKhacNuocMat = items.Sum(item => item.CongTrinhKhacNuocMat),
                CongTrinhGieng = items.Sum(item => item.CongTrinhGieng),
                CongTrinhKhacNDD = items.Sum(item => item.CongTrinhKhacNDD)
            };

            // Adding the total DTO to the items list
            items.Add(total);

            // Order items by Id, with total as the last item added manually
            return items.OrderBy(item => item.Id).ToList();
        }

    }
}

