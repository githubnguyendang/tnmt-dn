using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;
using System;

namespace tnmt_qn.Service
{
    public interface ITCQ_ThongTinService
    {
        public Task<List<TCQ_ThongTinDto>> GetAllAsync(TCQ_FilterDto filterDto);
        public Task<List<TCQ_ThongTinDto>> GetByLicensingAuthoritiesAsync(TCQ_FilterDto filterDto);
        public Task<TCQ_ThongTinDto> GetByIdAsync(int Id);
        public Task<int> SaveAsync(TCQ_ThongTinDto dto);
        public Task<bool> DeleteAsync(int Id);
    }

    public class TCQ_ThongTinService : ITCQ_ThongTinService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly ILogChangeService _logChangeService;

        // Constructor to initialize the service with required dependencies
        public TCQ_ThongTinService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager, ILogChangeService logChangeService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
            _logChangeService = logChangeService;
        }

        // Method to get all TCQ_ThongTin entities
        public async Task<List<TCQ_ThongTinDto>> GetAllAsync(TCQ_FilterDto filterDto)
        {
            var query = _context!.TCQ_ThongTin!
                .Where(u => u.DaXoa == false)
                .Include(u => u.GP_TCQ!).ThenInclude(gp_tcq => gp_tcq.GP_ThongTin)
                .Include(u => u.GP_TCQ!).ThenInclude(gp_tcq => gp_tcq.GP_ThongTin).ThenInclude(gp => gp.CongTrinh)
                .OrderByDescending(x => x.NgayKy)
                .AsQueryable();

            if (filterDto.StartYear > 0)
            {
                query = query.Where(x => x.NgayKy!.Value.Year >= filterDto.StartYear);
            }

            if (filterDto.EndYear > 0)
            {
                query = query.Where(x => x.NgayKy!.Value.Year <= filterDto.EndYear);
            }

            var tiencp = await query.ToListAsync();

            var tiencqDto = _mapper.Map<List<TCQ_ThongTinDto>>(tiencp);
            return tiencqDto;
        }

        // Method to get TCQ_ThongTin entities by licensing authorities
        public async Task<List<TCQ_ThongTinDto>> GetByLicensingAuthoritiesAsync(TCQ_FilterDto filterDto)
        {
            var query = _context!.TCQ_ThongTin!
                .Where(u => u.DaXoa == false)
                .Include(tcq => tcq.GP_TCQ)
                .OrderByDescending(x => x.NgayKy)
                .AsQueryable();

            if (filterDto.coquan_cp == "bo-cap")
            {
                query = query.Where(u => u.CoQuanCP == "BTNMT");
            }
            else if (filterDto.coquan_cp == "tinh-cap")
            {
                query = query.Where(u => u.CoQuanCP == "UBNDT");
            }

            if (filterDto.StartYear > 0)
            {
                query = query.Where(x => x.NgayKy!.Value.Year >= filterDto.StartYear);
            }

            if (filterDto.EndYear > 0)
            {
                query = query.Where(x => x.NgayKy!.Value.Year <= filterDto.EndYear);
            }

            var items = await query.ToListAsync();

            var listItems = _mapper.Map<List<TCQ_ThongTinDto>>(items);

            return listItems;
        }

        // Method to get TCQ_ThongTin entity by Id
        public async Task<TCQ_ThongTinDto> GetByIdAsync(int Id)
        {
            var item = await _context.TCQ_ThongTin!.FindAsync(Id);

            var dto = _mapper.Map<TCQ_ThongTinDto>(item);
            return dto;
        }

        // Method to save or update a TCQ_ThongTin entity
        public async Task<int> SaveAsync(TCQ_ThongTinDto dto)
        {
            int id = 0;
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            TCQ_ThongTin? item = null;

            string action = "CREATE";

            var existingItem = await _context.TCQ_ThongTin!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            var oldItem = _mapper.Map<TCQ_ThongTinDto>(existingItem);

            if (existingItem == null || dto.Id == 0)
            {
                item = _mapper.Map<TCQ_ThongTin>(dto);
                item.DaXoa = false;
                item.ThoiGianTao = DateTime.Now;
                item.TaiKhoanTao = currentUser?.UserName;
                _context.TCQ_ThongTin!.Add(item);
            }
            else
            {
                item = existingItem;
                action = "UPDATE";
                _mapper.Map(dto, item);
                item.DaXoa = false;
                item.ThoiGianSua = DateTime.Now;
                item.TaiKhoanSua = currentUser?.UserName;
                _context.TCQ_ThongTin!.Update(item);
            }

            var res = await _context.SaveChangesAsync();

            if (res != 0)
            {
                await _logChangeService.LogChangeAsync(
                    "TCQ_ThongTin",
                    action,
                    action == "CREATE" ? null : oldItem,
                    item,
                    currentUser?.UserName
                );

                id = (int)(res > 0 ? item.Id : 0);
            }

            return id;
        }

        // Method to delete a TCQ_ThongTin entity
        public async Task<bool> DeleteAsync(int Id)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            var existingItem = await _context.TCQ_ThongTin!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.TCQ_ThongTin!.Update(existingItem);
            var res = await _context.SaveChangesAsync();

            if (res != 0)
            {
                await _logChangeService.LogChangeAsync(
                    "TCQ_ThongTin",
                    "DELETE",
                    existingItem,
                    null,
                    currentUser?.UserName
                );
            }

            return true;
        }
    }
}
