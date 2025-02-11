using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class CT_HangMucService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public CT_HangMucService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to save or update a CT_HangMuc entity
        public async Task<int> SaveAsync(CT_HangMucDto dto)
        {
            int id = 0; // Initialize the id variable
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            CT_HangMuc? item = null; // Declare item variable

            // Retrieve an existing item based on Id or if dto.Id is 0
            var existingItem = await _context.CT_HangMuc!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                // If the item doesn't exist or dto.Id is 0, create a new item
                item = _mapper.Map<CT_HangMuc>(dto);
                item.DaXoa = false;
                item.ThoiGianTao = DateTime.Now;
                item.TaiKhoanTao = currentUser != null ? currentUser.UserName : null;
                _context.CT_HangMuc!.Add(item);
            }
            else
            {
                // If the item exists, update it with values from the dto
                item = existingItem;
                _mapper.Map(dto, item);
                item.DaXoa = false;
                item.ThoiGianSua = DateTime.Now;
                item.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
                _context.CT_HangMuc!.Update(item);
            }

            // Save changes to the database
            var res = await _context.SaveChangesAsync();

            // Simplified assignment of id based on the result of SaveChanges
            id = (int)(res > 0 ? item.Id : 0);

            // Return the id
            return id;
        }

        // Method to delete a CT_HangMuc entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.CT_HangMuc!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            existingItem!.DaXoa = true; // Mark the item as deleted
            existingItem.ThoiGianSua = DateTime.Now;
            existingItem.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
            _context.CT_HangMuc!.Update(existingItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}
