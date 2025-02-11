using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;
using static tnmt_qn.Dto.PhanDoanSongDto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace tnmt_qn.Service
{
    public class PhanDoanSongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public PhanDoanSongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<PhanDoanSongDto>> GetAllAsync(string? phanDoan)
        {
            var itemsQuery = _context.PhanDoanSong!.Where(ct => ct.DaXoa == false).AsQueryable();

            if (!string.IsNullOrEmpty(phanDoan))
            {
                itemsQuery = itemsQuery.Where(ct => ct.PhanDoan != null && ct.PhanDoan.Contains(phanDoan));
            }
            var items = await itemsQuery.ToListAsync();
            return _mapper.Map<List<PhanDoanSongDto>>(items);
        }

        public async Task<List<PhanDoanSongDto>> GetDataCaculatePolutantNormalAsync(string? phanDoan)
        {
            var itemsQuery = _context.PhanDoanSong!
                .Where(ct => ct.DaXoa == false)
                .Include(x => x.DuLieuNguonNuocNhan)
                .Include(p => p.DuLieuNguonNuocThaiDiem)
                .Include(p => p.DuLieuNguonNuocThaiSinhHoat)
                .Include(p => p.DuLieuNguonNuocThaiGiaCam)
                .Include(p => p.DuLieuNguonNuocThaiLon)
                .Include(p => p.DuLieuNguonNuocThaiTrauBo)
                .Include(p => p.DuLieuNguonNuocThaiTrongCay)
                .Include(p => p.DuLieuNguonNuocThaiTrongLua)
                .Include(p => p.DuLieuNguonNuocThaiTrongRung)
                .Include(p => p.DuLieuNguonNuocThaiThuySan)
                .AsQueryable();

            if (!string.IsNullOrEmpty(phanDoan))
            {
                itemsQuery = itemsQuery.Where(ct => ct.PhanDoan != null && ct.PhanDoan.Contains(phanDoan));
            }

            var items = await itemsQuery.ToListAsync();
            var pdsDtos = _mapper.Map<List<PhanDoanSongDto>>(items);

            // Reset DB-specific properties to null
            foreach (var dto in pdsDtos)
            {
                dto.DuLieuNguonNuocThaiDiemDB = null;
                dto.DuLieuNguonNuocThaiSinhHoatDB = null;
                dto.DuLieuNguonNuocThaiGiaCamDB = null;
                dto.DuLieuNguonNuocThaiLonDB = null;
                dto.DuLieuNguonNuocThaiTrauBoDB = null;
                dto.DuLieuNguonNuocThaiTrongCayDB = null;
                dto.DuLieuNguonNuocThaiTrongLuaDB = null;
                dto.DuLieuNguonNuocThaiTrongRungDB = null;
                dto.DuLieuNguonNuocThaiThuySanDB = null;
            }

            return pdsDtos;
        }

        // Method for fetching and calculating pollutants for DB data
        public async Task<List<PhanDoanSongDto>> GetDataCaculatePolutantDBAsync(string? phanDoan)
        {
            var itemsQuery = _context.PhanDoanSong!
                .Where(ct => ct.DaXoa == false)
                .Include(x => x.DuLieuNguonNuocNhanDB)
                .Include(p => p.DuLieuNguonNuocThaiDiemDB)
                .Include(p => p.DuLieuNguonNuocThaiSinhHoatDB)
                .Include(p => p.DuLieuNguonNuocThaiGiaCamDB)
                .Include(p => p.DuLieuNguonNuocThaiLonDB)
                .Include(p => p.DuLieuNguonNuocThaiTrauBoDB)
                .Include(p => p.DuLieuNguonNuocThaiTrongCayDB)
                .Include(p => p.DuLieuNguonNuocThaiTrongLuaDB)
                .Include(p => p.DuLieuNguonNuocThaiTrongRungDB)
                .Include(p => p.DuLieuNguonNuocThaiThuySanDB)
                .Where(p => p.DuLieuNguonNuocNhanDB != null)
                .AsQueryable();

            if (!string.IsNullOrEmpty(phanDoan))
            {
                itemsQuery = itemsQuery.Where(ct => ct.PhanDoan != null && ct.PhanDoan.Contains(phanDoan));
            }

            var items = await itemsQuery.ToListAsync();
            var pdsDtos = _mapper.Map<List<PhanDoanSongDto>>(items);

            // Reset normal data-specific properties to null
            foreach (var dto in pdsDtos)
            {
                dto.DuLieuNguonNuocThaiDiem = null;
                dto.DuLieuNguonNuocThaiSinhHoat = null;
                dto.DuLieuNguonNuocThaiGiaCam = null;
                dto.DuLieuNguonNuocThaiLon = null;
                dto.DuLieuNguonNuocThaiTrauBo = null;
                dto.DuLieuNguonNuocThaiTrongCay = null;
                dto.DuLieuNguonNuocThaiTrongLua = null;
                dto.DuLieuNguonNuocThaiTrongRung = null;
                dto.DuLieuNguonNuocThaiThuySan = null;
            }

            return pdsDtos;
        }
        public async Task<PhanDoanSongDto?> GetByIdAsync(int Id)
        {
            var item = await _context.PhanDoanSong!.FindAsync(Id);
            return _mapper.Map<PhanDoanSongDto>(item);
        }


        public async Task<bool> SaveAsync(PhanDoanSongDto dto)
        {
            var existingItem = await _context.PhanDoanSong!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null)
            {
                var newItem = _mapper.Map<PhanDoanSong>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.PhanDoanSong!.Add(newItem);
            }
            else
            {
                existingItem = _mapper.Map(dto, existingItem);
                existingItem!.DaXoa = false;
                existingItem!.ThoiGianSua = DateTime.Now;
                existingItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.PhanDoanSong!.Update(existingItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.PhanDoanSong!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.PhanDoanSong!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
