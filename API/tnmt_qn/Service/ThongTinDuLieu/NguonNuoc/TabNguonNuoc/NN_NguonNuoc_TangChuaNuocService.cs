using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class NN_NguonNuoc_TangChuaNuocService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NN_NguonNuoc_TangChuaNuocService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<NN_NguonNuoc_TangChuaNuocDto>> GetAllNguonNuocTangChuaNuocAsync()
        {
            var items = await _context.NN_NguonNuoc_TangChuaNuoc!.Where(d => d.DaXoa == false)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var ttdlDto = _mapper.Map<List<NN_NguonNuoc_TangChuaNuocDto>>(items);

            return ttdlDto;
        }
        public async Task<bool> SaveAsync(NN_NguonNuoc_TangChuaNuocDto dto)
        {

            var existingItem = await _context.NN_NguonNuoc_TangChuaNuoc!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<NN_NguonNuoc_TangChuaNuoc>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.NN_NguonNuoc_TangChuaNuoc!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.NN_NguonNuoc_TangChuaNuoc!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.NN_NguonNuoc_TangChuaNuoc!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.NN_NguonNuoc_TangChuaNuoc!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.NN_NguonNuoc_TangChuaNuoc!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
