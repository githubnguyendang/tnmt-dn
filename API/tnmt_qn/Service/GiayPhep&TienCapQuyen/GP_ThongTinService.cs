using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{

    public interface IGP_ThongTinService
    {
        public Task<List<GP_ThongTinDto>> GetAllAsync(GPFilterFormDto filterDto);
        public Task<GP_ThongTinDto> GetByIdAsync(int Id);
        public Task<CountFolowLicensingAuthoritiesDto> CountFolowLicensingAuthoritiesAsync();
        public Task<CountFolowConstructionTypesDto> CountFolowConstructionTypesAsync();
        public Task<LicenseStatisticsDto> LicenseStatisticsAsync(GPFilterFormDto filterDto);
        public Task<int> SaveAsync(GP_ThongTinDto dto);
        public Task<bool> DeleteAsync(int Id);
        public Task<List<GP_ThongTinDto>> GetHistoryByConstructionIdAsync(int congTrinhId);
        public Task<List<GP_ThongTinDto>> GetHistoryByBusinessIdAsync(int businessId);
    }
    public class GP_ThongTinService : IGP_ThongTinService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly ILogChangeService _logChangeService;
        private readonly ICT_ThongTinService _ctThongTinService;
        private readonly IToChucCaNhanService _tccnService;
        private readonly ITCQ_ThongTinService _tcqService;
        private readonly IGP_TCQService _gpTCQService;

        public GP_ThongTinService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager, ILogChangeService logChangeService, ICT_ThongTinService ctThongTinService, IToChucCaNhanService tccnService, ITCQ_ThongTinService tcqService, IGP_TCQService gpTCQService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
            _logChangeService = logChangeService;
            _ctThongTinService = ctThongTinService;
            _tccnService = tccnService;
            _tcqService = tcqService;
            _gpTCQService = gpTCQService;
        }
        public async Task<List<GP_ThongTinDto>> GetAllAsync(GPFilterFormDto filterDto)
        {
            var query = _context.GP_ThongTin!
                .Where(gp => gp.DaXoa == false)
                .Include(gp => gp.LoaiGP)
                .Include(gp => gp.ToChuc_CaNhan)
                .Include(gp => gp.ThanhTraKiemTra)
                .Include(gp => gp.GP_TCQ!).ThenInclude(gp => gp.TCQ_ThongTin)
                .Include(gp => gp.CongTrinh)
                .Include(gp => gp.giayphep_cu)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.HangMuc!)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.HangMuc!).ThenInclude(hm => hm!.ThongSo)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.ThongSo)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.LoaiCT)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.LuuVuc)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.LuuLuongTheoMucDich!).ThenInclude(lld => lld.MucDichKT)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.CT_ViTri!).ThenInclude(vt => vt.Xa!).ThenInclude(x => x.Huyen)
                .OrderByDescending(x => x.NgayKy)
                .AsQueryable();

            // Apply filters based on input parameters
            if (!string.IsNullOrEmpty(filterDto.so_gp))
            {
                query = query.Where(x => x.SoGP!.Contains(filterDto.so_gp));
            }

            if (!string.IsNullOrEmpty(filterDto.cong_trinh))
            {
                query = query.Where(x => x.CongTrinh!.TenCT!.ToLower().Contains(filterDto.cong_trinh!.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterDto.coquan_cp))
            {
                query = query.Where(x => x.CoQuanCapPhep!.Contains(filterDto.coquan_cp));
            }

            if (filterDto.loaihinh_cp > 0)
            {
                query = query.Where(x => x.IdLoaiGP == filterDto.loaihinh_cp);
            }

            if (filterDto.tochuc_canhan > 0)
            {
                query = query.Where(x => x.IdTCCN == filterDto.tochuc_canhan);
            }

            if (filterDto.loai_ct > 0)
            {
                if (filterDto.loai_ct == 7 || filterDto.loai_ct == 10)
                {
                    query = query.Where(gp => gp.CongTrinh!.LoaiCT!.Id == 7 || gp.CongTrinh!.LoaiCT!.Id == 10);
                }
                else
                {
                    query = query.Where(gp => filterDto.loai_ct == 1 || filterDto.loai_ct == 2 || filterDto.loai_ct == 3 || filterDto.loai_ct == 24 ? gp.CongTrinh!.LoaiCT!.IdCha == filterDto.loai_ct : gp.CongTrinh!.LoaiCT!.Id == filterDto.loai_ct);
                }
            }

            if (filterDto.huyen > 0)
            {
                query = query.Where(gp => gp.CongTrinh!.CT_ViTri!.Any(v => v.Xa!.Huyen!.IdHuyen.Contains(filterDto.huyen.ToString()!)));
            }

            if (filterDto.xa > 0)
            {
                query = query.Where(gp => gp.CongTrinh!.CT_ViTri!.Any(v => v.Xa!.IdXa.Contains(filterDto.huyen.ToString()!)));
            }

            if (filterDto.tang_chuanuoc > 0)
            {
                query = query.Where(gp => gp.CongTrinh!.IdTangChuaNuoc == filterDto.tang_chuanuoc);
            }

            if (filterDto.tieuvung_qh > 0)
            {
                query = query.Where(gp => gp.CongTrinh!.IdTieuLuuVuc == filterDto.tieuvung_qh);
            }

            if (filterDto.tu_nam > 0)
            {
                query = query.Where(x => x.NgayKy!.Value.Year >= filterDto.tu_nam);
            }

            if (filterDto.den_nam > 0)
            {
                query = query.Where(x => x.NgayKy!.Value.Year <= filterDto.den_nam);
            }

            if (!string.IsNullOrEmpty(filterDto.hieuluc_gp))
            {
                switch (filterDto.hieuluc_gp.ToLower())
                {
                    case "sap-het-hieu-luc":
                        query = query
                            .Where(x => x.NgayHetHieuLuc.HasValue &&
                                        x.NgayHetHieuLuc >= DateTime.Today &&
                                        x.NgayHetHieuLuc < DateTime.Today.AddDays(160) &&
                                        x.DaBiThuHoi == false);
                        break;
                    case "het-hieu-luc":
                        query = query
                            .Where(x => x.NgayHetHieuLuc.HasValue &&
                                        x.NgayHetHieuLuc < DateTime.Today &&
                                        x.DaBiThuHoi == false);
                        break;
                    case "con-hieu-luc":
                        query = query
                            .Where(x => x.NgayHetHieuLuc.HasValue &&
                                        x.NgayHetHieuLuc > DateTime.Today.AddDays(160) &&
                                        x.DaBiThuHoi == false);
                        break;
                    case "da-bi-thu-hoi":
                        query = query.Where(x => x.DaBiThuHoi == true);
                        break;
                    default: break;
                }
            }

            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (currentUser != null)
            {
                if (await _userManager.IsInRoleAsync(currentUser!, "Construction"))
                {
                    query = query.Where(x => x.CongTrinh!.TaiKhoan!.ToLower() == currentUser!.UserName!.ToLower());
                }

                if (await _userManager.IsInRoleAsync(currentUser!, "District"))
                {
                    query = query.Where(x => x.CongTrinh!.CT_ViTri!.Any(v => v.Xa!.Huyen!.IdHuyen == currentUser!.IdHuyen));
                }
            }

            var giayphep = await query.ToListAsync();

            var giayPhepDtos = _mapper.Map<List<GP_ThongTinDto>>(giayphep);

            // Directly assign the history to LichSuCapPhep
            foreach (var item in giayPhepDtos)
            {
                if (item.IdCT.HasValue)
                {
                    item.LichSuCapPhep = await GetHistoryByConstructionIdAsync(item.IdCT.Value);
                }
                if (item.IdTCCN.HasValue)
                {
                    item.GiayPhepCuaToChuc = await GetHistoryByBusinessIdAsync(item.IdTCCN.Value);
                }
            }

            return giayPhepDtos;
        }

        // Method to get GP_ThongTin entity by Id
        public async Task<GP_ThongTinDto> GetByIdAsync(int Id)
        {
            // Query to get GP_ThongTin entity by Id
            var query = _context.GP_ThongTin!
                .Where(gp => gp.DaXoa == false)
                .Include(gp => gp.LoaiGP)
                .Include(gp => gp.ToChuc_CaNhan)
                .Include(gp => gp.ThanhTraKiemTra)
                .Include(gp => gp.GP_TCQ!).ThenInclude(gp => gp.TCQ_ThongTin)
                .Include(gp => gp.CongTrinh)
                .Include(gp => gp.giayphep_cu)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.HangMuc!)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.HangMuc!).ThenInclude(hm => hm!.ThongSo)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.ThongSo)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.LoaiCT)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.LuuVuc)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.LuuLuongTheoMucDich!).ThenInclude(lld => lld.MucDichKT)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.CT_ViTri!).ThenInclude(vt => vt.Xa!).ThenInclude(x => x.Huyen)
                .AsQueryable();

            var giayphep = await query.FirstOrDefaultAsync();

            var giayPhepDto = _mapper.Map<GP_ThongTinDto>(giayphep);

            return giayPhepDto;
        }


        // Method to count the number of GP_ThongTin entities based on licensing authorities
        public async Task<CountFolowLicensingAuthoritiesDto> CountFolowLicensingAuthoritiesAsync()
        {
            // Count total, Btnmt, and Ubndt entities
            var totalCount = await _context.GP_ThongTin!
                .Where(gp => gp.DaXoa == false)
                .CountAsync();

            var btnmtCount = await _context.GP_ThongTin!
                .Where(gp => gp.DaXoa == false && gp.CoQuanCapPhep!.ToLower() == "btnmt")
                .CountAsync();

            var ubndtCount = await _context.GP_ThongTin!
                .Where(gp => gp.DaXoa == false && gp.CoQuanCapPhep!.ToLower() == "ubndt")
                .CountAsync();

            return new CountFolowLicensingAuthoritiesDto
            {
                Total = totalCount,
                Btnmt = btnmtCount,
                Ubndt = ubndtCount
            };
        }

        // Method to count the number of GP_ThongTin entities based on construction types
        public async Task<CountFolowConstructionTypesDto> CountFolowConstructionTypesAsync()
        {
            var today = DateTime.Today;

            var query = _context.GP_ThongTin!
                .Where(gp => gp.DaXoa == false)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.LoaiCT)
                .AsQueryable();

            // Count entities for different construction types
            var ktsd_nm = query.Where(gp => gp.CongTrinh!.LoaiCT!.IdCha == 1);
            var ktsd_ndd = query.Where(gp => gp.CongTrinh!.LoaiCT!.Id == 7 || gp.CongTrinh!.LoaiCT!.Id == 10);
            var thamdo_ndd = query.Where(gp => gp.CongTrinh!.LoaiCT!.Id == 8);
            var hnk_ndd = query.Where(gp => gp.CongTrinh!.LoaiCT!.Id == 9);
            var xathai = query.Where(gp => gp.CongTrinh!.LoaiCT!.IdCha == 3);

            return new CountFolowConstructionTypesDto
            {
                ktsd_nm = new CountFolowConsTypesData
                {
                    total = await ktsd_nm.CountAsync(),
                    con_hieuluc = await ktsd_nm.CountAsync(gp => gp.DaBiThuHoi == false && gp.NgayHetHieuLuc >= today),
                    bo_cap = await ktsd_nm.CountAsync(gp => gp.CoQuanCapPhep!.ToLower() == "btnmt"),
                    tinh_cap = await ktsd_nm.CountAsync(gp => gp.CoQuanCapPhep!.ToLower() == "ubndt"),
                },
                ktsd_ndd = new CountFolowConsTypesData
                {
                    total = await ktsd_ndd.CountAsync(),
                    con_hieuluc = await ktsd_ndd.CountAsync(gp => gp.DaBiThuHoi == false && gp.NgayHetHieuLuc >= today),
                    bo_cap = await ktsd_ndd.CountAsync(gp => gp.CoQuanCapPhep!.ToLower() == "btnmt"),
                    tinh_cap = await ktsd_ndd.CountAsync(gp => gp.CoQuanCapPhep!.ToLower() == "ubndt"),
                },
                thamdo_ndd = new CountFolowConsTypesData
                {
                    total = await thamdo_ndd.CountAsync(),
                    con_hieuluc = await thamdo_ndd.CountAsync(gp => gp.DaBiThuHoi == false && gp.NgayHetHieuLuc >= today),
                    bo_cap = await thamdo_ndd.CountAsync(gp => gp.CoQuanCapPhep!.ToLower() == "btnmt"),
                    tinh_cap = await thamdo_ndd.CountAsync(gp => gp.CoQuanCapPhep!.ToLower() == "ubndt"),
                },
                hnk_ndd = new CountFolowConsTypesData
                {
                    total = await hnk_ndd.CountAsync(),
                    con_hieuluc = await hnk_ndd.CountAsync(gp => gp.DaBiThuHoi == false && gp.NgayHetHieuLuc >= today),
                    bo_cap = await hnk_ndd.CountAsync(gp => gp.CoQuanCapPhep!.ToLower() == "btnmt"),
                    tinh_cap = await hnk_ndd.CountAsync(gp => gp.CoQuanCapPhep!.ToLower() == "ubndt"),
                },
                xathai = new CountFolowConsTypesData
                {
                    total = await xathai.CountAsync(),
                    con_hieuluc = await xathai.CountAsync(gp => gp.DaBiThuHoi == false && gp.NgayHetHieuLuc >= today),
                    bo_cap = await xathai.CountAsync(gp => gp.CoQuanCapPhep!.ToLower() == "btnmt"),
                    tinh_cap = await xathai.CountAsync(gp => gp.CoQuanCapPhep!.ToLower() == "ubndt"),
                },
            };
        }

        // Method to get license statistics based on filter criteria
        public async Task<LicenseStatisticsDto> LicenseStatisticsAsync(GPFilterFormDto filterDto)
        {
            var query = _context.GP_ThongTin!
                .Where(gp => gp.DaXoa == false && gp.NgayKy != null)
                .Include(gp => gp.CongTrinh).ThenInclude(ct => ct!.LoaiCT)
                .AsQueryable();

            // Apply filters based on input parameters
            if (!string.IsNullOrEmpty(filterDto.so_gp))
            {
                query = query.Where(x => x.SoGP!.Contains(filterDto.so_gp));
            }

            if (!string.IsNullOrEmpty(filterDto.cong_trinh))
            {
                query = query.Where(x => x.CongTrinh!.TenCT!.ToLower().Contains(filterDto.cong_trinh.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterDto.coquan_cp))
            {
                query = query.Where(x => x.CoQuanCapPhep!.Contains(filterDto.coquan_cp));
            }

            if (filterDto.loaihinh_cp > 0)
            {
                query = query.Where(x => x.IdLoaiGP == filterDto.loaihinh_cp);
            }

            if (filterDto.tochuc_canhan > 0)
            {
                query = query.Where(x => x.IdTCCN == filterDto.tochuc_canhan);
            }

            if (filterDto.loai_ct > 0)
            {
                query = query.Where(gp => filterDto.loai_ct == 1 || filterDto.loai_ct == 2 || filterDto.loai_ct == 3 || filterDto.loai_ct == 24 ? gp.CongTrinh!.LoaiCT!.IdCha == filterDto.loai_ct : gp.CongTrinh!.LoaiCT!.Id == filterDto.loai_ct);
            }

            if (filterDto.huyen > 0)
            {
                query = query.Where(gp => gp.CongTrinh!.CT_ViTri!.Any(v => v.Xa!.Huyen!.IdHuyen.Contains(filterDto.huyen.ToString()!)));
            }

            if (filterDto.xa > 0)
            {
                query = query.Where(gp => gp.CongTrinh!.CT_ViTri!.Any(v => v.Xa!.IdXa.Contains(filterDto.xa.ToString()!)));
            }

            if (filterDto.tang_chuanuoc > 0)
            {
                query = query.Where(gp => gp.CongTrinh!.IdTangChuaNuoc == filterDto.tang_chuanuoc);
            }

            if (filterDto.tieuvung_qh > 0)
            {
                query = query.Where(gp => gp.CongTrinh!.IdTieuLuuVuc == filterDto.tieuvung_qh);
            }

            if (filterDto.tu_nam > 0)
            {
                query = query.Where(x => x.NgayKy!.Value.Year >= filterDto.tu_nam);
            }

            if (filterDto.den_nam > 0)
            {
                query = query.Where(x => x.NgayKy!.Value.Year <= filterDto.den_nam);
            }

            if (!string.IsNullOrEmpty(filterDto.hieuluc_gp))
            {
                switch (filterDto.hieuluc_gp.ToLower())
                {
                    case "sap-het-hieu-luc":
                        query = query
                            .Where(x => x.NgayHetHieuLuc.HasValue &&
                                        x.NgayHetHieuLuc >= DateTime.Today &&
                                        x.NgayHetHieuLuc < DateTime.Today.AddDays(160) &&
                                        x.DaBiThuHoi == false);
                        break;
                    case "het-hieu-luc":
                        query = query
                            .Where(x => x.NgayHetHieuLuc.HasValue &&
                                        x.NgayHetHieuLuc < DateTime.Today &&
                                        x.DaBiThuHoi == false);
                        break;
                    case "con-hieu-luc":
                        query = query
                            .Where(x => x.NgayHetHieuLuc.HasValue &&
                                        x.NgayHetHieuLuc > DateTime.Today.AddDays(160) &&
                                        x.DaBiThuHoi == false);
                        break;
                    case "da-bi-thu-hoi":
                        query = query.Where(x => x.DaBiThuHoi == true);
                        break;
                    default: break;
                }
            }

            var categoryQueries = new List<(string, Func<IQueryable<GP_ThongTin>, IQueryable<GP_ThongTin>>)>
{
                ("Khai thác sử dụng nước mặt", q => q.Where(gp => gp.CongTrinh!.LoaiCT!.IdCha == 1)),
                ("Khai thác sử dụng nước dưới đất", q => q.Where(gp => gp.CongTrinh!.LoaiCT!.Id == 7)),
                ("Thăm dò nước dưới đất", q => q.Where(gp => gp.CongTrinh!.LoaiCT!.Id == 8)),
                ("Hành nghề khoan", q => q.Where(gp => gp.CongTrinh!.LoaiCT!.Id == 9)),
                ("Xả thải vào nguồn nước", q => q.Where(gp => gp.CongTrinh!.LoaiCT!.IdCha == 3))
            };

            var distinctYears = Enumerable.Range((int)filterDto.tu_nam!, (int)(filterDto.den_nam! - filterDto.tu_nam! + 1)).ToArray();

            var color = new string[]
            {
            "rgb(106, 179, 230)",
            "rgb(0, 61, 126)",
            "rgb(125, 95, 58)",
            "rgb(0, 178, 151)",
            "rgb(244, 153, 23)"
            };

            var seriesList = new List<ApexChartSeriesDto>();

            foreach (var (categoryName, categoryQuery) in categoryQueries)
            {
                var categoryCounts = new int[distinctYears.Length];

                for (int j = 0; j < distinctYears.Length; j++)
                {
                    categoryCounts[j] = await categoryQuery(query)
                        .CountAsync(gp => gp.NgayKy!.Value.Year == distinctYears[j]);
                }

                seriesList.Add(new ApexChartSeriesDto
                {
                    name = categoryName,
                    data = categoryCounts.ToList() // Convert the array to a list
                });
            }

            return new LicenseStatisticsDto
            {
                color = color,
                year = distinctYears,
                series = seriesList
            };
        }

        // Method to save or update a GP_ThongTin entity
        public async Task<int> SaveAsync(GP_ThongTinDto dto)
        {
            // Save the related CT_ThongTin
            var ctDto = _mapper.Map<CT_ThongTinDto>(dto.congtrinh);
            int idCT = await _ctThongTinService.SaveAsync(ctDto);

            // Save the related ToChuc_CaNhan
            var tccnDto = _mapper.Map<ToChuc_CaNhanDto>(dto.tochuc_canhan);
            int idTCCN = await _tccnService.SaveAsync(tccnDto);

            // Map TCQ_ThongTinDto to TCQ_ThongTin entities
            var tcqDtos = dto.tiencq; // List of TCQ_ThongTinDto from the input
            var tcqEntities = new List<TCQ_ThongTin>();

            int id = 0;
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            GP_ThongTin? item = null;

            string action = "CREATE";

            var existingItem = await _context.GP_ThongTin!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            var oldItem = _mapper.Map<GP_ThongTinDto>(existingItem);

            if (existingItem == null || dto.Id == 0)
            {
                item = _mapper.Map<GP_ThongTin>(dto);
                item.IdCT = idCT;
                item.IdTCCN = idTCCN;
                item.DaXoa = false;
                item.ThoiGianTao = DateTime.Now;
                item.TaiKhoanTao = currentUser != null ? currentUser.UserName : null;

                _context.GP_ThongTin!.Add(item);
            }
            else
            {
                action = "UPDATE";
                item = existingItem;
                _mapper.Map(dto, item);
                item.IdCT = idCT;
                item.IdTCCN = idTCCN;
                item.DaXoa = false;
                item.ThoiGianSua = DateTime.Now;
                item.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
                _context.GP_ThongTin!.Update(item);
            }

            var res = await _context.SaveChangesAsync();

            if (res != 0)
            {
                foreach (var tcqDto in tcqDtos!)
                {
                    var tcqEntity = _mapper.Map<TCQ_ThongTinDto>(tcqDto);

                    var gp_tcqDto = new GP_TCQDto
                    {
                        IdTCQ = await _tcqService.SaveAsync(tcqEntity),
                        IdGP = item.Id
                    };

                    await _gpTCQService.SaveAsync(gp_tcqDto);
                }

                await _logChangeService.LogChangeAsync(
                    "GP_ThongTin",
                    action,
                    action == "CREATE" ? null : oldItem,
                    item,
                    currentUser?.UserName
                );

                id = (int)(res > 0 ? item.Id : 0);
            }

            return id;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.GP_ThongTin!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; }
            existingItem.ThoiGianSua = DateTime.Now;
            existingItem.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
            existingItem!.DaXoa = true;
            _context.GP_ThongTin!.Update(existingItem);
            var res = await _context.SaveChangesAsync();

            if (res != 0)
            {
                await _logChangeService.LogChangeAsync(
                    "GP_ThongTin",
                    "DELETE",
                    existingItem,
                    null,
                    currentUser?.UserName
                );
            }

            return true;
        }

        public async Task<List<GP_ThongTinDto>> GetHistoryByConstructionIdAsync(int congTrinhId)
        {
            var history = await _context.GP_ThongTin!
                .Where(gp => gp.IdCT == congTrinhId && gp.DaXoa == false)
                .Include(gp => gp.LoaiGP)
                .Include(gp => gp.ToChuc_CaNhan)
                .Include(gp => gp.CongTrinh)
                .OrderByDescending(gp => gp.NgayKy)
                .ToListAsync();

            return _mapper.Map<List<GP_ThongTinDto>>(history);
        }

        public async Task<List<GP_ThongTinDto>> GetHistoryByBusinessIdAsync(int businessId)
        {
            var history = await _context.GP_ThongTin!
                .Where(gp => gp.IdTCCN == businessId && gp.DaXoa == false)
                .Include(gp => gp.LoaiGP)
                .Include(gp => gp.ToChuc_CaNhan)
                .Include(gp => gp.CongTrinh)
                .OrderByDescending(gp => gp.NgayKy)
                .ToListAsync();

            return _mapper.Map<List<GP_ThongTinDto>>(history);
        }
    }
}
