using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class GP_LoaiService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public GP_LoaiService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to retrieve all GP_Loai entities
        public async Task<List<GP_LoaiDto>> GetAllAsync()
        {
            // Retrieve non-deleted items and order them by TenLoaiGP
            var items = await _context.GP_Loai!.Where(x => x.DaXoa == false).OrderBy(x => x.TenLoaiGP).ToListAsync();

            // Map the entities to DTOs and return the result
            return _mapper.Map<List<GP_LoaiDto>>(items);
        }

        // Method to retrieve a specific GP_Loai entity by Id
        public async Task<GP_LoaiDto?> GetGP_LoaiByIdAsync(int Id)
        {
            // Find the GP_Loai entity by Id
            var item = await _context.GP_Loai!.FindAsync(Id);

            // Map the entity to a DTO and return the result
            return _mapper.Map<GP_LoaiDto>(item);
        }

        // Method to save or update a GP_Loai entity
        public async Task<bool> SaveAsync(GP_LoaiDto dto)
        {
            var existingItem = await _context.GP_Loai!.FirstOrDefaultAsync(d => d.Id == dto.Id);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            GP_Loai? item = null;
            if (existingItem == null || dto.Id == 0)
            {
                // If the item doesn't exist or dto.Id is 0, create a new item
                item = _mapper.Map<GP_Loai>(dto);
                item.DaXoa = false;
                item.ThoiGianTao = DateTime.Now;
                item.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.GP_Loai!.Add(item);
            }
            else
            {
                // If the item exists, update it with values from the dto
                item = existingItem;
                item = _mapper.Map(dto, item);
                item.DaXoa = false;
                item.ThoiGianSua = DateTime.Now;
                item.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
                _context.GP_Loai!.Update(item);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful save or update
            return true;
        }

        // Method to delete a GP_Loai entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.GP_Loai!.FirstOrDefaultAsync(d => d.Id == Id);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            existingItem.ThoiGianSua = DateTime.Now;
            existingItem.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
            existingItem!.DaXoa = true; // Mark the item as deleted
            _context.GP_Loai!.Update(existingItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}
