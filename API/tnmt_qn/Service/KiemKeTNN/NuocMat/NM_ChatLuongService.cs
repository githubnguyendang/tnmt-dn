using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class NM_ChatLuongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NM_ChatLuongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<KKTNN_NuocMat_ChatLuongDto>> GetAllAsync()
        {
            var items = await _context.KKTNN_NuocMat_ChatLuong!.Where(x => x.DaXoa == false).OrderBy(x => x.Id).ToListAsync();
            return _mapper.Map<List<KKTNN_NuocMat_ChatLuongDto>>(items);
        }


        public async Task<bool> SaveAsync(KKTNN_NuocMat_ChatLuongDto dto)
        {

            var existingItem = await _context.KKTNN_NuocMat_ChatLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<KKTNN_NuocMat_ChatLuong>(dto);
                newItem.DaXoa = false;
                _context.KKTNN_NuocMat_ChatLuong!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.KKTNN_NuocMat_ChatLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.KKTNN_NuocMat_ChatLuong!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.KKTNN_NuocMat_ChatLuong!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.KKTNN_NuocMat_ChatLuong!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
