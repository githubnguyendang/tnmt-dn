using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DuBaoKhaNangTiepNhanNuocHoService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public DuBaoKhaNangTiepNhanNuocHoService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }
        public async Task<List<DuBaoKhaNangTiepNhanNuocHoDto>> GetAllAsync()
        {
            var query = await _context.DuBaoKhaNangTiepNhanNuocHo!
                .Where(gp => gp.DaXoa == false)
                .Include(x => x.CT_ThongTin)
                .Include(x => x.ThongSoCLNDuBao)
                .AsQueryable().ToListAsync();

            // Apply filters based on input parameters

            var listItems = _mapper.Map<List<DuBaoKhaNangTiepNhanNuocHoDto>>(query);

            return listItems;
        }
        public async Task<DuBaoKhaNangTiepNhanNuocHoDto> CalculateDuBaoAsync(DuBaoKhaNangTiepNhanNuocHoDto dto)
        {
            // Retrieve the data from the ThongSoCLNDuBao table based on the provided IdMucPL
            var thongSoCLNDuBao = await _context.ThongSoCLNDuBao!
                .FirstOrDefaultAsync(t => t.Id == dto.IdMucPL);

            if (thongSoCLNDuBao == null)
            {
                throw new Exception("ThongSoCLNDuBao not found for the given IdMucPL.");
            }

            // Ensure VH is provided in the dto
            if (dto.VH == null)
            {
                throw new Exception("VH value is required for calculation.");
            }

            // Initialize entity outside of conditional blocks
            DuBaoKhaNangTiepNhanNuocHo entity;

            // Check if an entity with the same Id already exists in the database
            var existingEntity = await _context.DuBaoKhaNangTiepNhanNuocHo!.FirstOrDefaultAsync(d => d.Id == dto.Id);

            if (existingEntity == null)
            {
                // Create a new entity
                entity = _mapper.Map<DuBaoKhaNangTiepNhanNuocHo>(dto);
                entity.DaXoa = false;
                entity.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";

                _context.DuBaoKhaNangTiepNhanNuocHo!.Add(entity);
            }
            else
            {
                // Update the existing entity
                entity = _mapper.Map(dto, existingEntity);
                entity.ThoiGianSua = DateTime.Now;
                entity.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";

                _context.DuBaoKhaNangTiepNhanNuocHo!.Update(entity);
            }

            // Perform calculations directly on the entity's fields
            entity.MtnBOD = (thongSoCLNDuBao.BOD - entity.CnnBOD) * (entity.VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * (entity.FS ?? 0);
            entity.MtnCOD = (thongSoCLNDuBao.COD - entity.CnnCOD) * (entity.VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * (entity.FS ?? 0);
            entity.MtnTSS = (thongSoCLNDuBao.TSS - entity.CnnTSS) * (entity.VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * (entity.FS ?? 0);
            entity.MtnAmoni = (thongSoCLNDuBao.Amoni - entity.CnnAmoni) * (entity.VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * (entity.FS ?? 0);
            entity.MtnTongP = (thongSoCLNDuBao.TongP - entity.CnnTongP) * (entity.VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * (entity.FS ?? 0);
            entity.MtnTongN = (thongSoCLNDuBao.TongN - entity.CnnTongN) * (entity.VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * (entity.FS ?? 0);
            entity.MtnColiform = (thongSoCLNDuBao.TongColiform - entity.CnnColiform) * (entity.VH * Math.Pow(10, 6) ?? 0) * Math.Pow(10, -3) * (entity.FS ?? 0);

            await _context.SaveChangesAsync();

            // Return the dto with updated values
            return _mapper.Map<DuBaoKhaNangTiepNhanNuocHoDto>(entity);
        }


    }
}

