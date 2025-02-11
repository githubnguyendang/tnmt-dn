using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class VHHC_HoChua_ThongSoKTService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public VHHC_HoChua_ThongSoKTService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<VHHC_HoChua_ThongSoKTDto>> GetAllVHHC_HoChua_ThongSoKTAsync()
        {
            var items = await _context.VHHC_HoChua_ThongSoKT!.Where(d => d.DaXoa == false )
                .Include(ct => ct.CT_ThongTin)
                .Include(ct => ct.CT_ThongTin).ThenInclude(ct => ct.ThongSo)
                .AsQueryable().ToListAsync();

            var vhhcDto = _mapper.Map<List<VHHC_HoChua_ThongSoKTDto>>(items);

            return vhhcDto;
        }

        //public async Task<List<DuLieuNguonNuocNhanDto>> GetAllAsync()
        //{
        //    var query = _context.DuLieuNguonNuocNhan!
        //        .Where(gp => gp.DaXoa == false)
        //        .Include(x => x.PhanDoanSong)
        //        .AsQueryable();

        //    // Apply filters based on input parameters
        //    var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

        //    var listItems = _mapper.Map<List<DuLieuNguonNuocNhanDto>>(query);

        //    return listItems;
        //}
        public async Task<bool> SaveAsync(VHHC_HoChua_ThongSoKTDto dto)
        {

            var existingItem = await _context.VHHC_HoChua_ThongSoKT!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<VHHC_HoChua_ThongSoKT>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.VHHC_HoChua_ThongSoKT!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.VHHC_HoChua_ThongSoKT!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.VHHC_HoChua_ThongSoKT!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.VHHC_HoChua_ThongSoKT!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.VHHC_HoChua_ThongSoKT!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
