using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace tnmt_qn.Service
{
    public class NMua_TongLuongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NMua_TongLuongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public List<Tram_ThongTinDto> GetAll(string? nam_bao_cao)
        {
            var items = _context.Tram_ThongTin!.Where(x => x.DaXoa == false)
                .Include(d => d.KKTNN_NuocMua_TongLuong)
                .Include(d => d.Huyen)
                .Include(d => d.Xa)
                .OrderBy(d => d.Id)
                .AsQueryable();

            var tramDto = _mapper.Map<List<Tram_ThongTinDto>>(items);
            foreach (var dto in tramDto)
            {
                dto.tongluong_nuocmua = dto.tongluong_nuocmua!.Where(x => x.Daxoa == false && x.Nam == nam_bao_cao).ToList();

            }

            // Exclude items where KKTNN_NuocMua_TongLuong is an empty list
            tramDto = tramDto.Where(dto => dto.tongluong_nuocmua != null && dto.tongluong_nuocmua.Any()).ToList();

            return tramDto;
        }
        public async Task<bool> SaveAsync(KKTNN_NuocMua_TongLuongDto dto)
        {

            var existingItem = await _context.KKTNN_NuocMua_TongLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<KKTNN_NuocMua_TongLuong>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.KKTNN_NuocMua_TongLuong!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.KKTNN_NuocMua_TongLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.KKTNN_NuocMua_TongLuong!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.KKTNN_NuocMua_TongLuong!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.KKTNN_NuocMua_TongLuong!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
