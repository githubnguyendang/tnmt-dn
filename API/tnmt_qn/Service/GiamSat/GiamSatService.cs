using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class GiamSatService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly IHttpContextAccessor _httpContext;

        // Constructor to initialize the service with required dependencies
        public GiamSatService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _httpContext = httpContext;
        }

        // Method to retrieve and map all data for monitoring
        public async Task<List<GS_SoLieuDto>> GetAllAsync(string? MaCT, string? TenCT, int? IdLoaiCT)
        {
            // Initial query to retrieve construction information
            var query = _context.CT_ThongTin!
                .Where(ct => ct.DaXoa == false)
                .Include(ct => ct.LoaiCT)
                .Include(ct => ct.ThongSo)
                .OrderBy(x => x.IdLoaiCT)
                .AsQueryable();
            // Apply additional filters based on parameters
            if (!string.IsNullOrEmpty(MaCT))
            {
                query = query.Where(ct => ct.MaCT!.Contains(MaCT));
            }
            if (!string.IsNullOrEmpty(TenCT))
            {
                query = query.Where(ct => ct.TenCT!.Contains(TenCT));
            }

            if (IdLoaiCT > 0)
            {
                query = query.Where(ct => IdLoaiCT == 1 || IdLoaiCT == 2 || IdLoaiCT == 3 || IdLoaiCT == 24 ? ct.LoaiCT!.IdCha == IdLoaiCT : ct.LoaiCT!.Id == IdLoaiCT);
            }
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (currentUser != null)
            {
                if (await _userManager.IsInRoleAsync(currentUser!, "Construction"))
                {
                    query = query.Where(ct => ct.TaiKhoan!.ToLower() == currentUser!.UserName!.ToLower());
                }

                if (await _userManager.IsInRoleAsync(currentUser!, "District"))
                {
                    query = query.Where(ct => ct.CT_ViTri!.Any(x => x.IdHuyen == currentUser!.IdHuyen));
                }
            }
            var congtrinh = await query.ToListAsync();

            // Map the construction information to DTOs
            var congTrinhDtos = _mapper.Map<List<GS_SoLieuDto>>(congtrinh);

            // Lấy dữ liệu giám sát mới nhất cho từng loại StationCode của mỗi công trình
            foreach (var item in congTrinhDtos)
            {
                // Lấy dữ liệu mới nhất cho từng StationCode
                var solieu = await _context.StoragePreData!
                    .Where(x => x.ConstructionCode == item.MaCT)
                    .GroupBy(x => x.StationCode)
                    .Select(g => g.OrderByDescending(x => x.Time).FirstOrDefault())
                    .ToListAsync();

                // Gán dữ liệu mới nhất vào các thuộc tính trong DTO dựa trên StationCode
                foreach (var sl in solieu)
                {
                    if (sl == null) continue;

                    item.ThoiGian = sl.Time; // Lấy thời gian mới nhất cho mỗi StationCode

                    switch (sl.StationCode!.ToLower())
                    {
                        case "muathuongluu":
                            item.MUATHUONGLUU = sl.Value;
                            break;
                        case "quatran":
                            item.QXaTranTT = sl.Value;
                            break;
                        case "nhamay":
                            item.QXaMaxTT = sl.Value;
                            break;
                        case "dctt":
                            item.DCTTTT = sl.Value;
                            break;
                        case "haluu":
                            item.HHaLuuTT = sl.Value;
                            break;
                        case "dungtich":
                            item.DungTichTT = sl.Value;
                            break;
                        case "thuongluu":
                            item.HThuongLuuTT = sl.Value;
                            break;
                        case "nhietdo":
                            item.NhietDo = sl.Value;
                            break;
                        case "ph":
                            item.PH = sl.Value;
                            break;
                        case "bod":
                            item.BOD = sl.Value;
                            break;
                        case "cod":
                            item.COD = sl.Value;
                            break;
                        case "do":
                            item.DO = sl.Value;
                            break;
                        case "tss":
                            item.TSS = sl.Value;
                            break;
                        case "nh4":
                            item.NH4 = sl.Value;
                            break;
                        case "giengkhoan":
                            item.GIENGKHOAN = sl.Value;
                            break;
                        case "giengquantrac":
                            item.GIENGQUANTRAC = sl.Value;
                            break;
                        case "qkhaithac":
                            item.QKhaiThac = sl.Value;
                            break;
                    }
                }
            }


            // Return the list of mapped DTOs
            return congTrinhDtos;
        }

        public async Task<List<StoragePreDataDto>> GetAllDetailsAsync(string? ConstructionCode, DateTime? StartDate, DateTime? EndDate)

        {
            var query = _context.StoragePreData
                         .Where(x => x.Status == true)  // Only get records with Status == true
                         .OrderByDescending(t => t.Id)
                         .AsQueryable(); ; // Order by Id in descending order

            if (!string.IsNullOrEmpty(ConstructionCode))
            {
                string keyword = ConstructionCode.ToLower();
                query = query.Where(ct => ct.ConstructionCode!.ToLower().Contains(keyword));
                // query = query.Where(x => x.ConstructionCode.ToLower().Contains(keyword)); // Filter by ConstructionCode
            }

            if (StartDate.HasValue && EndDate.HasValue)
            {
                query = query.Where(x => x.Time >= StartDate && x.Time <= EndDate)  // Filter by date range
;
            }

            var dataList = await query.ToListAsync();
            var result = dataList
             .GroupBy(x => x.Time)
             .Select(group => new StoragePreDataDto
             {
                 Time = group.Key,
                 Data = group!.ToDictionary(item => item!.StationCode, item => item!.Value)
             })
             .ToList();

            return result;
        }

    }
}

