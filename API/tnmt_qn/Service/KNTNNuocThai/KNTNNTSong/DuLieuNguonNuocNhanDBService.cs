using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DuLieuNguonNuocNhanDBService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public DuLieuNguonNuocNhanDBService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }
        public async Task<List<DuLieuNguonNuocNhanDBDto>> GetAllAsync()
        {
            var query = await _context.DuLieuNguonNuocNhanDB!
                .Where(gp => gp.DaXoa == false)
                  .Include(x => x.PhanDoanSong)
                .Include(x => x.ThongSoCLNDuBao)
                .AsQueryable().ToListAsync();

            // Apply filters based on input parameters

            var listItems = _mapper.Map<List<DuLieuNguonNuocNhanDBDto>>(query);

            return listItems;
        }
        public async Task<DuLieuNguonNuocNhanDBDto> CalculateDuBaoAsync(DuLieuNguonNuocNhanDBDto dto)
        {
            // Retrieve the data from the ThongSoCLNDuBao table based on the provided IdMucPL
            var thongSoCLNDuBao = await _context.ThongSoCLNDuBao!
                .FirstOrDefaultAsync(t => t.Id == dto.IdMucPL);

            if (thongSoCLNDuBao == null)
            {
                throw new Exception("ThongSoCLNDuBao not found for the given IdMucPL.");
            }


            // Initialize entity outside of conditional blocks
            DuLieuNguonNuocNhanDB entity;

            // Check if an entity with the same Id already exists in the database
            var existingEntity = await _context.DuLieuNguonNuocNhanDB!.FirstOrDefaultAsync(d => d.Id == dto.Id);

            if (existingEntity == null)
            {
                // Create a new entity
                entity = _mapper.Map<DuLieuNguonNuocNhanDB>(dto);
                entity.DaXoa = false;
                entity.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";

                _context.DuLieuNguonNuocNhanDB!.Add(entity);
            }
            else
            {
                // Update the existing entity
                entity = _mapper.Map(dto, existingEntity);
                entity.ThoiGianSua = DateTime.Now;
                entity.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";

                _context.DuLieuNguonNuocNhanDB!.Update(entity);
            }

            // Perform calculations directly on the entity's fields
            entity.LtdBODDB = Math.Round((entity.LuuLuongDongChayDB ?? 0) * (thongSoCLNDuBao.BOD ?? 0) * 86.4, 2);
            entity.LtdCODDB = Math.Round((entity.LuuLuongDongChayDB ?? 0) * (thongSoCLNDuBao.COD ?? 0) * 86.4, 2);
            entity.LtdTSSDB = Math.Round((entity.LuuLuongDongChayDB ?? 0) * (thongSoCLNDuBao.TSS ?? 0) * 86.4, 2);
            entity.LtdAmoniDB = Math.Round((entity.LuuLuongDongChayDB ?? 0) * (thongSoCLNDuBao.Amoni ?? 0) * 86.4, 2);
            entity.LtdTongPDB = Math.Round((entity.LuuLuongDongChayDB ?? 0) * (thongSoCLNDuBao.TongP ?? 0) * 86.4, 2);
            entity.LtdTongNDB = Math.Round((entity.LuuLuongDongChayDB ?? 0) * (thongSoCLNDuBao.TongN ?? 0) * 86.4, 2);
            entity.LtdColiformDB =  Math.Round((entity.LuuLuongDongChayDB ?? 0) * (thongSoCLNDuBao.TongColiform ?? 0) * 86.4, 2);

            await _context.SaveChangesAsync();

            // Return the dto with updated values
            return _mapper.Map<DuLieuNguonNuocNhanDBDto>(entity);
        }


    }
}

