using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauMuoiChinService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiChinService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauMuoiChinDto>> GetAllBieuMauMuoiChinAsync()
        {
            var items = await _context.BieuMauSoMuoiChin!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauMuoiChinDto>>(items);
        }

        public async Task<bool> SaveBieuMauMuoiChinAsync(BieuMauMuoiChinDto dto)
        {
            var exitsItem = await _context!.BieuMauSoMuoiChin!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoMuoiChin>(dto);

                _context.BieuMauSoMuoiChin!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoMuoiChin!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoMuoiChin!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauMuoiChinAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoMuoiChin!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoMuoiChin?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

