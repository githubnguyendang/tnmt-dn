using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauChinService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauChinService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauChinDto>> GetAllBieuMauChinAsync()
        {
            var items = await _context.BieuMauSoChin!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauChinDto>>(items);
        }

        public async Task<bool> SaveBieuMauChinAsync(BieuMauChinDto dto)
        {
            var exitsItem = await _context!.BieuMauSoChin!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoChin>(dto);

                _context.BieuMauSoChin!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoChin!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoChin!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauChinAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoChin!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoChin?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

