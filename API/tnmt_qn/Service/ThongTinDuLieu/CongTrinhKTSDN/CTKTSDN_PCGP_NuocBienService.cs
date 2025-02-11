using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class CTKTSDN_PCGP_NuocBienService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public CTKTSDN_PCGP_NuocBienService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<CTKTSDN_PCGP_NuocBienDto>> GetAllCTKTSDN_PCGP_NuocBienAsync()
        {
            var items = await _context.CTKTSDN_PCGP_NuocBien!.Where(d => d.DaXoa == false)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var ttdlDto = _mapper.Map<List<CTKTSDN_PCGP_NuocBienDto>>(items);

            return ttdlDto;
        }
        public async Task<bool> SaveAsync(CTKTSDN_PCGP_NuocBienDto dto)
        {

            var existingItem = await _context.CTKTSDN_PCGP_NuocBien!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<CTKTSDN_PCGP_NuocBien>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.CTKTSDN_PCGP_NuocBien!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.CTKTSDN_PCGP_NuocBien!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.CTKTSDN_PCGP_NuocBien!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.CTKTSDN_PCGP_NuocBien!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.CTKTSDN_PCGP_NuocBien!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
