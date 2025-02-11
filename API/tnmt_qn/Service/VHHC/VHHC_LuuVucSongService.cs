using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class VHHC_LuuVucSongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public VHHC_LuuVucSongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        
        //Lấy dữ liệu từ trong csdl (lấy từ cột Id => cột DaXoa)
        public async Task<List<VHHC_LuuVucSongDto>> GetAllVHHC_LuuVucSongAsync()
        {
            var items = await _context.VHHC_LuuVucSong!.Where(d => d.DaXoa == false)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var vhhcDto = _mapper.Map<List<VHHC_LuuVucSongDto>>(items);

            return vhhcDto;
        }

        //Lưu dữ liệu vào csdl (lấy từ cột Id => cột DaXoa)
        public async Task<bool> SaveAsync(VHHC_LuuVucSongDto dto)
        {

            var existingItem = await _context.VHHC_LuuVucSong!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<VHHC_LuuVucSong>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.VHHC_LuuVucSong!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.VHHC_LuuVucSong!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.VHHC_LuuVucSong!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }

        //Xoá dữ liệu trong csdl (lấy từ cột Id => cột DaXoa)
        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.VHHC_LuuVucSong!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.VHHC_LuuVucSong!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
