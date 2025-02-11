using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class TangChuaNuocService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public TangChuaNuocService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<TangChuaNuocDto>> GetAllAsync()
        {
            var items = await _context.TangChuaNuoc!.Where(b => b.DaXoa == false).OrderBy(b => b.TenTCN).ToListAsync();
            return _mapper.Map<List<TangChuaNuocDto>>(items);
        }

        public async Task<TangChuaNuocDto?> GetByIdAsync(int Id)
        {
            var item = await _context.TangChuaNuoc!.FindAsync(Id);
            return _mapper.Map<TangChuaNuocDto>(item);
        }


        public async Task<bool> SaveAsync(TangChuaNuocDto model)
        {
            var existingItem = await _context.TangChuaNuoc!.FirstOrDefaultAsync(d => d.Id == model.Id && d.DaXoa == false);

            if (existingItem == null || model.Id == 0)
            {
                var newItem = _mapper.Map<TangChuaNuoc>(model);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.TangChuaNuoc!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.TangChuaNuoc!.FirstOrDefaultAsync(d => d.Id == model.Id && d.DaXoa == false);

                updateItem = _mapper.Map(model, updateItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.TangChuaNuoc!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.TangChuaNuoc!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.TangChuaNuoc!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}