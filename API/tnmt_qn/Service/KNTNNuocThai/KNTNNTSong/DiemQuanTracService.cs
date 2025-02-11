using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class DiemQuanTracService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public DiemQuanTracService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to retrieve all DiemQuanTrac entities
        public async Task<List<DiemQuanTracDto>> GetAllAsync()
        {
            // Retrieve non-deleted items and order them by Id
            var items = await _context.DiemQuanTrac!.Where(x => x.DaXoa == false).OrderBy(x => x.Id).ToListAsync();

            // Map the entities to DTOs and return the result
            return _mapper.Map<List<DiemQuanTracDto>>(items);
        }

        // Method to retrieve a specific DiemQuanTrac entity by Id
        public async Task<DiemQuanTracDto?> GetByIdAsync(int Id)
        {
            // Find the DiemQuanTrac entity by Id
            var item = await _context.DiemQuanTrac!.FindAsync(Id);

            // Map the entity to a DTO and return the result
            return _mapper.Map<DiemQuanTracDto>(item);
        }

        // Method to save or update a DiemQuanTrac entity
        public async Task<bool> SaveAsync(DiemQuanTracDto dto)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            // Retrieve an existing item based on Id or if dto.Id is 0
            var existingItem = await _context.DiemQuanTrac!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                // If the item doesn't exist or dto.Id is 0, create a new item
                var newItem = _mapper.Map<DiemQuanTrac>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = currentUser != null ? currentUser.UserName : null;
                _context.DiemQuanTrac!.Add(newItem);
            }
            else
            {
                // If the item exists, update it with values from the dto
                var updateItem = await _context.DiemQuanTrac!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);
                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.DaXoa = false;
                updateItem.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
                _context.DiemQuanTrac!.Update(updateItem);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful save or update
            return true;
        }

        // Method to delete a DiemQuanTrac entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.DiemQuanTrac!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            existingItem!.DaXoa = true; // Mark the item as deleted
            existingItem.ThoiGianSua = DateTime.Now;
            existingItem.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
            _context.DiemQuanTrac!.Update(existingItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}
