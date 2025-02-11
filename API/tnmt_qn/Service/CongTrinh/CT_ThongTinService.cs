using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public interface ICT_ThongTinService
    {
        public Task<List<CT_ThongTinDto>> GetAllAsync(string? TenCT, int? IdLoaiCT, int? IdHuyen, int? IdXa, int? IdSong, int? IdLuuVuc, int? IdTieuLuuVuc, int? IdTangChuaNuoc, string? NguonNuocKT);
        public Task<CT_ThongTinDto?> GetByIdAsync(int Id);
        public Task<int> SaveAsync(CT_ThongTinDto dto);
        public Task<bool> DeleteAsync(int Id);

    }
    public class CT_ThongTinService : ICT_ThongTinService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly ILogChangeService _logChangeService;

        // Constructor to initialize the service with required dependencies
        public CT_ThongTinService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager, ILogChangeService logChangeService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
            _logChangeService = logChangeService;
        }

        // Method to retrieve a list of CT_ThongTin entities based on specified filters
        public async Task<List<CT_ThongTinDto>> GetAllAsync(string? TenCT, int? IdLoaiCT, int? IdHuyen, int? IdXa, int? IdSong, int? IdLuuVuc, int? IdTieuLuuVuc, int? IdTangChuaNuoc, string? NguonNuocKT)
        {
            _context.Database.SetCommandTimeout(120);

            var query = _context.CT_ThongTin!
                .Where(ct => ct.DaXoa == false)
                .Include(ct => ct.LoaiCT)
                .Include(ct => ct.TangChuaNuoc)
                .Include(ct => ct.HangMuc!).ThenInclude(hm => hm.ThongSo)
                .Include(ct => ct.ThongSo)
                .Include(ct => ct.LuuVuc)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Xa)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Huyen)
                .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.ToChuc_CaNhan)
                 .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.GP_TCQ!).ThenInclude(tcq => tcq.TCQ_ThongTin)
                .Include(ct => ct.LuuLuongTheoMucDich!).ThenInclude(lld => lld.MucDichKT)
                .OrderBy(x => x.IdLoaiCT)
                .AsQueryable();

            // Apply filters based on input parameters
            if (!string.IsNullOrEmpty(TenCT))
            {
                query = query.Where(ct => ct.TenCT!.Contains(TenCT));
            }

            if (IdLoaiCT > 0)
            {
                query = query.Where(ct => IdLoaiCT == 1 || IdLoaiCT == 2 || IdLoaiCT == 3 || IdLoaiCT == 24 ? ct.LoaiCT!.IdCha == IdLoaiCT : ct.LoaiCT!.Id == IdLoaiCT);
            }

            if (IdXa > 0)
            {
                query = query.Where(ct => ct.CT_ViTri!.Any(x => x.IdXa!.Contains(IdXa.ToString()!)));
            }

            if (IdHuyen > 0)
            {
                query = query.Where(ct => ct.CT_ViTri!.Any(x => x.IdHuyen!.Contains(IdHuyen.ToString()!)));
            }

            if (IdSong > 0)
            {
                query = query.Where(ct => ct.IdSong == IdSong);
            }

            if (IdLuuVuc > 0)
            {
                query = query.Where(ct => ct.IdLuuVuc == IdLuuVuc);
            }

            if (IdTieuLuuVuc > 0)
            {
                query = query.Where(ct => ct.IdTieuLuuVuc == IdTieuLuuVuc);
            }

            if (IdTangChuaNuoc > 0)
            {
                query = query.Where(ct => ct.IdTangChuaNuoc == IdTangChuaNuoc);
            }

            if (!string.IsNullOrEmpty(NguonNuocKT))
            {
                query = query.Where(ct => ct.NguonNuocKT!.Contains(NguonNuocKT));
            }

            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (currentUser != null)
            {
                if (await _userManager.IsInRoleAsync(currentUser!, "Construction"))
                {
                    query = query.Where(ct => ct.TaiKhoan!.ToLower() == currentUser!.UserName!.ToLower());
                }

                if (await _userManager.IsInRoleAsync(currentUser!, "District"))
                {
                    query = query.Where(ct => ct.CT_ViTri!.Any(x => x.IdHuyen == currentUser!.IdHuyen));
                }
            }

            var congtrinh = await query.ToListAsync();

            // Map the result to DTOs
            var congTrinhDtos = _mapper.Map<List<CT_ThongTinDto>>(congtrinh);


            // Return the list of DTOs
            return congTrinhDtos;
        }

        // Method to retrieve a single CT_ThongTin entity by Id
        public async Task<CT_ThongTinDto?> GetByIdAsync(int Id)
        {
            var query = _context.CT_ThongTin!
                .Where(ct => ct.DaXoa == false)
                .Include(ct => ct.LoaiCT)
                .Include(ct => ct.TangChuaNuoc)
                .Include(ct => ct.HangMuc!).ThenInclude(hm => hm.ThongSo)
                .Include(ct => ct.ThongSo)
                .Include(ct => ct.LuuVuc)
                .Include(ct => ct.CT_ViTri)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Xa)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Huyen)
                .Include(ct => ct.GiayPhep)
                .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.ToChuc_CaNhan)
                .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.GP_TCQ)
                .Include(ct => ct.LuuLuongTheoMucDich!).ThenInclude(lld => lld.MucDichKT)
                .OrderBy(x => x.IdLoaiCT)
                .AsQueryable();

            var congTrinh = await query.SingleOrDefaultAsync(ct => ct.Id == Id);

            if (congTrinh == null)
            {
                // Handle the case where the record is not found
                return null;
            }

            var congTrinhDto = _mapper.Map<CT_ThongTinDto>(congTrinh);

            return congTrinhDto;
        }

        // Method to save or update a CT_ThongTin entity
        public async Task<int> SaveAsync(CT_ThongTinDto dto)
        {
            int id = 0;
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            CT_ThongTin? item = null;

            while (true)
            {
                try
                {
                    var existingItem = await _context.CT_ThongTin!
                        .AsNoTracking()
                        .Include(ct => ct.HangMuc)
                        .Include(ct => ct.ThongSo)
                        .Include(ct => ct.CT_ViTri)
                        .FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                    if (existingItem != null)
                    {
                        item = _mapper.Map<CT_ThongTin>(dto);
                        item.Id = existingItem.Id;
                        item.ThoiGianSua = DateTime.Now;
                        item.TaiKhoanSua = currentUser?.UserName;

                        // Attach the entity manually before updating
                        _context.Attach(item);
                        _context.CT_ThongTin!.Update(item);
                    }
                    else
                    {
                        item = _mapper.Map<CT_ThongTin>(dto);
                        item.DaXoa = false;
                        item.ThoiGianTao = DateTime.Now;
                        item.TaiKhoanTao = currentUser?.UserName;

                        _context.CT_ThongTin!.Add(item);
                    }

                    var res = await _context.SaveChangesAsync();

                    if (res != 0)
                    {
                        await _logChangeService.LogChangeAsync(
                            "CT_ThongTin",
                            existingItem == null ? "CREATE" : "UPDATE",
                            existingItem == null ? null : _mapper.Map<CT_ThongTinDto>(existingItem),
                            item,
                            currentUser?.UserName
                        );

                        id = item.Id;
                    }

                    break; // Exit the loop if successful
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // Reload the entity and retry
                    var entry = ex.Entries.Single();
                    var databaseEntity = await entry.GetDatabaseValuesAsync();
                    if (databaseEntity == null)
                    {
                        // The entity was deleted by another user
                        throw new InvalidOperationException("The entity you are trying to update has been deleted.");
                    }

                    // Update the original values to the current values in the database
                    entry.OriginalValues.SetValues(databaseEntity);
                }
            }

            return id;
        }



        // Method to delete a CT_ThongTin entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.CT_ThongTin!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            var oldItem = _mapper.Map<CT_ThongTinDto>(existingItem);
            existingItem!.DaXoa = true; // Mark the item as deleted
            existingItem.ThoiGianSua = DateTime.Now;
            existingItem.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
            _context.CT_ThongTin!.Update(existingItem);

            // Log the creation (DELETE)
            await _logChangeService.LogChangeAsync(
                "CT_ThongTin",
                "DELETE",
                null,
                oldItem,
                currentUser != null ? currentUser.UserName : null
            );

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}
