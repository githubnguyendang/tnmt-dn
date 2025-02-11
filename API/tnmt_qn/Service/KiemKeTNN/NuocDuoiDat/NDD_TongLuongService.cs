using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;
using static tnmt_qn.Dto.KKTNN_NuocDuoiDat_TongLuongDto;

namespace tnmt_qn.Service
{
    public class NDD_TongLuongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NDD_TongLuongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<KKTNN_NuocDuoiDat_TongLuongDto>> GetAllAsync()
        {
            var items = await _context.KKTNN_NuocDuoiDat_TongLuong!.Where(d => d.DaXoa == false)
                .Include(d => d.TangChuaNuoc)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var tongLuongNDDDto = _mapper.Map<List<KKTNN_NuocDuoiDat_TongLuongDto>>(items);
            foreach (var dto in tongLuongNDDDto)
            {
                if (!string.IsNullOrEmpty(dto.NuocNgot_IdXa.ToString()))
                {
                    //var ds = await _context.DonViHC!.FirstOrDefaultAsync(dv => dv.IdXa == dto!.NuocNgot_IdXa.ToString());
                    //if (ds != null)
                    //{
                    //    dto.NuocNgot = new NuocManNuocNgotDto
                    //    {
                    //        Xa = ds!.TenXa,
                    //        Huyen = ds!.TenHuyen
                    //    };
                    //}
                    //var cs = await _context.DonViHC!.FirstOrDefaultAsync(dv => dv.IdXa == dto!.NuocMan_IdXa.ToString());
                    //if (cs != null)
                    //{
                    //    dto.NuocMan = new NuocManNuocNgotDto
                    //    {
                    //        Xa = cs!.TenXa,
                    //        Huyen = cs!.TenHuyen
                    //    };
                    //}
                }
            }
            return tongLuongNDDDto;

        }

        //public async Task<bool> SaveAsync(KKTNN_NuocDuoiDat_TongLuongDto dto)
        //{

        //    var existingItem = await _context.KKTNN_NuocDuoiDat_TongLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

        //    if (existingItem == null || dto.Id == 0)
        //    {
        //        var newItem = _mapper.Map<KKTNN_NuocDuoiDat_TongLuong>(dto);
        //        newItem.DaXoa = false;
        //        _context.KKTNN_NuocDuoiDat_TongLuong!.Add(newItem);
        //    }
        //    else
        //    {
        //        var updateItem = await _context.KKTNN_NuocDuoiDat_TongLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id);

        //        updateItem = _mapper.Map(dto, updateItem);

        //        _context.KKTNN_NuocDuoiDat_TongLuong!.Update(updateItem);
        //    }

        //    var res = await _context.SaveChangesAsync();

        //    return true;
        //}


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.KKTNN_NuocDuoiDat_TongLuong!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.KKTNN_NuocDuoiDat_TongLuong!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
