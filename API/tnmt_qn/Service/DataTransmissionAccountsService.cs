using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class DataTransmissionAccountsService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public DataTransmissionAccountsService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to retrieve a list of CT_ThongTin entities based on specified filters
        public async Task<List<DataTransmissionAccountsDto>> GetAllAsync()
        {

            var query = _context.DataTransmissionAccounts!
                .OrderBy(x => x.Id)
                .AsQueryable();

            var stations = await query.ToListAsync();

            // Map the result to DTOs
            var stationDtos = _mapper.Map<List<DataTransmissionAccountsDto>>(stations);

            // Return the list of DTOs
            return stationDtos;
        }

        // Method to retrieve a single CT_ThongTin entity by Id
        public async Task<List<DataTransmissionAccountsDto>> GetByConstructionCode(string Username)
        {
            var query = _context.DataTransmissionAccounts!
                .Where(ct => ct.Username == Username)
                .OrderByDescending(x => x.Id)
                .Take(11);

            var PreData = await query.ToListAsync();

            if (PreData == null)
            {
                // Handle the case where the record is not found
                return null;
            }

            var PreDataDto = _mapper.Map<List<DataTransmissionAccountsDto>>(PreData);

            return PreDataDto;
        }

        // Method to save or update a CT_ThongTin entity
        public async Task<int> SaveAsync(List<DataTransmissionAccountsDto> dtos)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            DataTransmissionAccounts item = null; // Declare item variable

            foreach (var d in dtos)
            {
                // Retrieve an existing item based on Id or if dto.Id is 0
                var existingItem = await _context.DataTransmissionAccounts!.FirstOrDefaultAsync(e => e.Id == d.Id);

                if (existingItem == null || d.Id == 0)
                {
                    // If the item doesn't exist or dto.Id is 0, create a new item
                    item = _mapper.Map<DataTransmissionAccounts>(d);
                    item.Status = true;
                    _context.DataTransmissionAccounts!.Add(item);

                }
                else
                {
                    // If the item exists, update it with values from the dto
                    item = existingItem;
                    _mapper.Map(d, item);
                    _context.DataTransmissionAccounts!.Update(item);
                }

            }

            // Save changes to the database
            var res = await _context.SaveChangesAsync();

            // Return the id
            return res;
        }

        // Method to delete a CT_ThongTin entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.DataTransmissionAccounts!.FirstOrDefaultAsync(d => d.Id == Id);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            _context.DataTransmissionAccounts!.Remove(existingItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}
