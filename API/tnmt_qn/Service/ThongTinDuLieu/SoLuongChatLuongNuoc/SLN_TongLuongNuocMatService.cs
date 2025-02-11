using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class SLN_TongLuongNuocMatService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public SLN_TongLuongNuocMatService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<SLN_TongLuongNuocMatDto>> GetAllSLN_TongLuongNuocMatAsync()
        {
            var items = await _context.SLN_TongLuongNuocMat!.Where(d => d.DaXoa == false)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var ttdlDto = _mapper.Map<List<SLN_TongLuongNuocMatDto>>(items);

            return ttdlDto;
        }
        public async Task<bool> SaveAsync(SLN_TongLuongNuocMatDto dto)
        {

            var existingItem = await _context.SLN_TongLuongNuocMat!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<SLN_TongLuongNuocMat>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.SLN_TongLuongNuocMat!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.SLN_TongLuongNuocMat!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.SLN_TongLuongNuocMat!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.SLN_TongLuongNuocMat!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.SLN_TongLuongNuocMat!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
