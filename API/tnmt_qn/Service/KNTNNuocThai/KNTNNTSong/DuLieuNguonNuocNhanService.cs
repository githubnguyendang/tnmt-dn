using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DuLieuNguonNuocNhanService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public DuLieuNguonNuocNhanService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<DuLieuNguonNuocNhanDto>> GetAllAsync(string? phanDoan)
        {
            // Start building the query for DuLieuNguonNuocNhan
            var query = _context.DuLieuNguonNuocNhan!
                .Where(gp => gp.DaXoa == false)
                .Include(x => x.PhanDoanSong)
                .AsQueryable();

            // Check if phanDoan filter is provided
            if (!string.IsNullOrEmpty(phanDoan))
            {
                // Add filter to query based on phanDoan
                query = query.Where(gp => gp.PhanDoanSong != null && gp.PhanDoanSong.PhanDoan!.Contains(phanDoan));
            }

            // Execute the query and map the results
            var items = await query.ToListAsync();
            var listItems = _mapper.Map<List<DuLieuNguonNuocNhanDto>>(items);

            return listItems;
        }

        public async Task<DuLieuNguonNuocNhanDto> GetByIdAsync(int Id)
        {
            var item = await _context.DuLieuNguonNuocNhan!.FindAsync(Id);
            return _mapper.Map<DuLieuNguonNuocNhanDto>(item);
        }


        public async Task<bool> SaveAsync(DuLieuNguonNuocNhanDto dto)
        {
            var existingItem = await _context.DuLieuNguonNuocNhan!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<DuLieuNguonNuocNhan>(dto);
                newItem.DaXoa = false;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocNhan!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.DuLieuNguonNuocNhan!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.DaXoa = false;
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocNhan!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DuLieuNguonNuocNhan!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.DuLieuNguonNuocNhan!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
