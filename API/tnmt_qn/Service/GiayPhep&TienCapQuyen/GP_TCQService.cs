using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public interface IGP_TCQService
    {
        public Task<bool> SaveAsync(GP_TCQDto dto);
        public Task<bool> DeleteAsync(GP_TCQDto dto);
    }
    public class GP_TCQService : IGP_TCQService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly ILogChangeService _logChangeService;

        // Constructor to initialize the service with required dependencies
        public GP_TCQService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager, ILogChangeService logChangeService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
            _logChangeService = logChangeService;
        }

        // Method to save a GP_TCQ entity
        public async Task<bool> SaveAsync(GP_TCQDto dto)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            // Retrieve an existing item based on IdTCQ and IdGP
            var existingItem = await _context.GP_TCQ!.FirstOrDefaultAsync(d => d.IdTCQ == dto.IdTCQ && d.IdGP == dto.IdGP);

            if (existingItem == null)
            {
                // If the item doesn't exist, create a new item
                var newItem = _mapper.Map<GP_TCQ>(dto);
                _context.GP_TCQ!.Add(newItem);

                // Save changes to the database
                var res = await _context.SaveChangesAsync();

                if (res != 0)
                {
                    await _logChangeService.LogChangeAsync(
                    "GP_TCQ",
                    "CREATE",
                    _mapper.Map<ToChuc_CaNhanDto>(existingItem),
                    newItem,
                    currentUser?.UserName);
                }
            }

            // Return true to indicate successful save
            return true;
        }

        // Method to delete a GP_TCQ entity
        public async Task<bool> DeleteAsync(GP_TCQDto dto)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            // Retrieve an existing item based on IdTCQ and IdGP
            var existingItem = await _context.GP_TCQ!.FirstOrDefaultAsync(d => d.IdTCQ == dto.IdTCQ && d.IdGP == dto.IdGP);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            // Remove the existing item
            _context.GP_TCQ!.Remove(existingItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            var res = await _context.SaveChangesAsync();

            if (res != 0)
            {
                await _logChangeService.LogChangeAsync(
                "GP_TCQ",
                "DELETE",
                _mapper.Map<ToChuc_CaNhanDto>(existingItem),
                null,
                currentUser?.UserName
            );
            }
            return true;
        }
    }
}
