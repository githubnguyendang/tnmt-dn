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
    public class NDD_ChatLuongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NDD_ChatLuongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<KKTNN_NuocDuoiDat_ChatLuongDto>> GetAllAsync()
        {
            var items = await _context.KKTNN_NuocDuoiDat_ChatLuong!.Where(x => x.DaXoa == false).OrderBy(x => x.Id).ToListAsync();
            var chatLuongNDDDto = _mapper.Map<List<KKTNN_NuocDuoiDat_ChatLuongDto>>(items);
            //foreach (var dto in chatLuongNDDDto)
            //{
            //    if (!string.IsNullOrEmpty(dto.IdXa.ToString()))
            //    {
            //        dto.donvi_hanhchinh = _mapper.Map<ViTriDto>(await _context.DonViHC!
            //            .FirstOrDefaultAsync(dv => dv.IdXa == dto.IdXa.ToString()));
            //    }
            //}
            return chatLuongNDDDto;


        }
        //public async Task<bool> SaveAsync(KKTNN_NuocDuoiDat_ChatLuongDto dto)
        //{

        //    var existingItem = await _context.KKTNN_NuocDuoiDat_ChatLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

        //    if (existingItem == null || dto.Id == 0)
        //    {
        //        var newItem = _mapper.Map<KKTNN_NuocDuoiDat_ChatLuong>(dto);
        //        newItem.DaXoa = false;
        //        _context.KKTNN_NuocDuoiDat_ChatLuong!.Add(newItem);
        //    }
        //    else
        //    {
        //        var updateItem = await _context.KKTNN_NuocDuoiDat_ChatLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id);

        //        updateItem = _mapper.Map(dto, updateItem);
        //        _context.KKTNN_NuocDuoiDat_ChatLuong!.Update(updateItem);
        //    }

        //    var res = await _context.SaveChangesAsync();

        //    return true;
        //}


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.KKTNN_NuocDuoiDat_ChatLuong!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.KKTNN_NuocDuoiDat_ChatLuong!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
