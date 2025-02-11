using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class NM_TongLuongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NM_TongLuongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<KKTNN_NuocMat_TongLuongDto>> GetAllAsync(int? nam_bao_cao)
        {
            var items = await _context.KKTNN_NuocMat_TongLuong!.Where(d => d.DaXoa == false && d.Nam == nam_bao_cao)
                .Include(d => d.LuuVucSong)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var soLuongNuocMatDto = _mapper.Map<List<KKTNN_NuocMat_TongLuongDto>>(items);
            foreach (var dto in soLuongNuocMatDto)
            {
                dto.vitri = _mapper.Map<ViTriDto>(await _context.Xa!
                        .FirstOrDefaultAsync(dv => dv.IdXa == dto.LuuVucSong!.IdXa.ToString()));
            }
            return soLuongNuocMatDto;
        }
            public async Task<bool> SaveAsync(KKTNN_NuocMat_TongLuongDto dto)
        {

            var existingItem = await _context.KKTNN_NuocMat_TongLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<KKTNN_NuocMat_TongLuong>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.KKTNN_NuocMat_TongLuong!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.KKTNN_NuocMat_TongLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.KKTNN_NuocMat_TongLuong!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.KKTNN_NuocMat_TongLuong!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.KKTNN_NuocMat_TongLuong!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
