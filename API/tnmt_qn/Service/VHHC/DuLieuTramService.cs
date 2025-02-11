using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Net.WebSockets;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DuLieuTramService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public DuLieuTramService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<DuLieuTramDto>> GetAllDuLieuTramAsync()
        {
            var items = _context.Tram_ThongTin!
                .Include(x => x.DuLieuTram)
                .AsQueryable();

            var dltDto = _mapper.Map<List<DuLieuTramDto>>(await items.Where(x => x.DuLieuTram != null).ToListAsync());

            return dltDto;
        }
        //DataMua1H
        public async Task<List<DuLieuTramDto>> GetRainDataByStationIdFor1HourAsync(int IdTram, DateTime StartTime, DateTime EndTime)
        {
            var items = _context.DuLieuTram!
                 .Where(x => x.IdTram == IdTram).OrderByDescending(x => x.ThoiGian!.Value.Hour == 1).Take(31)
                 .AsQueryable();

            if (StartTime != default(DateTime) && EndTime != default(DateTime))
            {
                items = items.Where(x => x.ThoiGian >= StartTime && x.ThoiGian <= EndTime);
            }

            var dltDto = _mapper.Map<List<DuLieuTramDto>>(await items.ToListAsync());

            return dltDto;
        }
        //DataMua6H
        public async Task<List<DuLieuTramDto>> GetRainDataByStationIdFor6HourAsync(int IdTram, DateTime StartTime, DateTime EndTime)
        {
            var items = _context.DuLieuTram!
                 .Where(x => x.IdTram == IdTram).OrderByDescending(x => x.ThoiGian!.Value.Hour == 6).Take(31)
                 .AsQueryable();

            if (StartTime != default(DateTime) && EndTime != default(DateTime))
            {
                items = items.Where(x => x.ThoiGian >= StartTime && x.ThoiGian <= EndTime);
            }

            var dltDto = _mapper.Map<List<DuLieuTramDto>>(await items.ToListAsync());

            return dltDto;
        }
        //DataMua12H
        public async Task<List<DuLieuTramDto>> GetRainDataByStationIdFor12HourAsync(int IdTram, DateTime StartTime, DateTime EndTime)
        {
            var items = _context.DuLieuTram!
                 .Where(x => x.IdTram == IdTram).OrderByDescending(x => x.ThoiGian!.Value.Hour == 12).Take(31)
                 .AsQueryable();

            if (StartTime != default(DateTime) && EndTime != default(DateTime))
            {
                items = items.Where(x => x.ThoiGian >= StartTime && x.ThoiGian <= EndTime);
            }

            var dltDto = _mapper.Map<List<DuLieuTramDto>>(await items.ToListAsync());

            return dltDto;
        }
        //DataMua24H
        public async Task<List<DuLieuTramDto>> GetRainDataByStationIdFor24HourAsync(int IdTram, DateTime StartTime, DateTime EndTime)
        {
            var items = _context.DuLieuTram!
                 .Where(x => x.IdTram == IdTram).OrderByDescending(x => x.ThoiGian!.Value.Hour == 0).Take(31)
                 .AsQueryable();

            if (StartTime != default(DateTime) && EndTime != default(DateTime))
            {
                items = items.Where(x => x.ThoiGian >= StartTime && x.ThoiGian <= EndTime);
            }

            var dltDto = _mapper.Map<List<DuLieuTramDto>>(await items.ToListAsync());

            return dltDto;
        }
        //ChartMua1H
        public async Task<List<ApexChartSeriesTramDto>> YeuToKhiTuong1HourAsync(int IdTram)
        {
            var items = await _context.DuLieuTram!.Where(x => x.IdTram == IdTram).OrderByDescending(x => x.ThoiGian!.Value.Hour == 1).Take(31).OrderByDescending(x => x.ThoiGian!.Value.Hour == 1)
                .AsQueryable().ToListAsync();

            var seriesList = new List<ApexChartSeriesTramDto>();

            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Lượng mưa",
                data = items.Select(x => x.LuongMua ?? 0.0).ToList() 
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Nhiệt độ",
                data = items.Select(x => x.NhietDo ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Độ ẩm",
                data = items.Select(x => x.DoAm ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Tốc độ gió",
                data = items.Select(x => x.TocDoGio ?? 0.0).ToList()
            });
            return seriesList;
        }
        //ChartMua6H
        public async Task<List<ApexChartSeriesTramDto>> YeuToKhiTuong6HourAsync(int IdTram)
        {
            var items = await _context.DuLieuTram!.Where(x => x.IdTram == IdTram).OrderByDescending(x => x.ThoiGian!.Value.Hour == 6).Take(31).OrderByDescending(x => x.ThoiGian!.Value.Hour == 6)
                .AsQueryable().ToListAsync();

            var seriesList = new List<ApexChartSeriesTramDto>();

            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Lượng mưa",
                data = items.Select(x => x.LuongMua ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Nhiệt độ",
                data = items.Select(x => x.NhietDo ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Độ ẩm",
                data = items.Select(x => x.DoAm ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Tốc độ gió",
                data = items.Select(x => x.TocDoGio ?? 0.0).ToList()
            });
            return seriesList;
        }
        //ChartMua12H
        public async Task<List<ApexChartSeriesTramDto>> YeuToKhiTuong12HourAsync(int IdTram)
        {
            var items = await _context.DuLieuTram!.Where(x => x.IdTram == IdTram).OrderByDescending(x => x.ThoiGian!.Value.Hour == 12).Take(31).OrderByDescending(x => x.ThoiGian!.Value.Hour == 12)
                .AsQueryable().ToListAsync();

            var seriesList = new List<ApexChartSeriesTramDto>();

            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Lượng mưa",
                data = items.Select(x => x.LuongMua ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Nhiệt độ",
                data = items.Select(x => x.NhietDo ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Độ ẩm",
                data = items.Select(x => x.DoAm ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Tốc độ gió",
                data = items.Select(x => x.TocDoGio ?? 0.0).ToList()
            });
            return seriesList;
        }
        //ChartMua24H
        public async Task<List<ApexChartSeriesTramDto>> YeuToKhiTuong24HourAsync(int IdTram)
        {
            var items = await _context.DuLieuTram!.Where(x => x.IdTram == IdTram).OrderByDescending(x => x.ThoiGian!.Value.Hour == 0).Take(31).OrderByDescending(x => x.ThoiGian!.Value.Hour == 0)
                .AsQueryable().ToListAsync();

            var seriesList = new List<ApexChartSeriesTramDto>();

            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Lượng mưa",
                data = items.Select(x => x.LuongMua ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Nhiệt độ",
                data = items.Select(x => x.NhietDo ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Độ ẩm",
                data = items.Select(x => x.DoAm ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Tốc độ gió",
                data = items.Select(x => x.TocDoGio ?? 0.0).ToList()
            });
            return seriesList;
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DuLieuTram!.FirstOrDefaultAsync(d => d.Id == Id);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.DuLieuTram!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
