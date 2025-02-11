using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System;

namespace tnmt_qn.Service
{
    public interface IToChucCaNhanService
    {
        public Task<List<ToChuc_CaNhanDto>> GetAllAsync();
        public Task<ToChuc_CaNhanDto?> GetByIdAsync(int Id);
        public Task<int> SaveAsync(ToChuc_CaNhanDto dto);
        public Task<bool> DeleteAsync(int Id);
    }
    public class ToChucCaNhanService : IToChucCaNhanService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly ILogChangeService _logChangeService;

        public ToChucCaNhanService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager, ILogChangeService logChangeService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
            _logChangeService = logChangeService;
        }

        public async Task<List<ToChuc_CaNhanDto>> GetAllAsync()
        {
            var items = await _context.ToChuc_CaNhan!.Where(x => x.DaXoa == false).OrderBy(x => x.TenTCCN).ToListAsync();
            return _mapper.Map<List<ToChuc_CaNhanDto>>(items);
        }

        public async Task<ToChuc_CaNhanDto?> GetByIdAsync(int Id)
        {
            var item = await _context.ToChuc_CaNhan!.FindAsync(Id);
            return _mapper.Map<ToChuc_CaNhanDto>(item);
        }

        public async Task<int> SaveAsync(ToChuc_CaNhanDto dto)
        {
            int id = 0;
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            ToChuc_CaNhan? item = null;

            string action = "CREATE";

            var existingItem = await _context.ToChuc_CaNhan!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            var oldItem = _mapper.Map<ToChuc_CaNhanDto>(existingItem);

            if (existingItem == null || dto.Id == 0)
            {
                item = _mapper.Map<ToChuc_CaNhan>(dto);
                item.DaXoa = false;
                item.ThoiGianTao = DateTime.Now;
                item.TaiKhoanTao = currentUser?.UserName;
                _context.ToChuc_CaNhan!.Add(item);
            }
            else
            {
                item = existingItem;
                action = "UPDATE";
                _mapper.Map(dto, item);
                item.DaXoa = false;
                item.ThoiGianSua = DateTime.Now;
                item.TaiKhoanSua = currentUser?.UserName;
                _context.ToChuc_CaNhan!.Update(item);
            }

            var res = await _context.SaveChangesAsync();

            if (res != 0)
            {
                await _logChangeService.LogChangeAsync(
                    "ToChuc_CaNhan",
                    action,
                    action == "CREATE" ? null : oldItem,
                    item,
                    currentUser?.UserName
                );

                id = (int)(res > 0 ? item.Id : 0);
            }

            return id;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.ToChuc_CaNhan!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.ToChuc_CaNhan!.Update(existingItem);
            var res = await _context.SaveChangesAsync();


            if (res != 0)
            {
                await _logChangeService.LogChangeAsync(
                    "ToChuc_CaNhan",
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
