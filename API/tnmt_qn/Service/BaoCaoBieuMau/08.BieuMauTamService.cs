using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauTamService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauTamService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauTamDto>> GetAllBieuMauTamAsync()
        {
            var items = await _context.BieuMauSoTam!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauTamDto>>(items);
        }

        public async Task<bool> SaveBieuMauTamAsync(BieuMauTamDto dto)
        {
            var exitsItem = await _context!.BieuMauSoTam!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoTam>(dto);

                _context.BieuMauSoTam!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoTam!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoTam!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauTamAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoTam!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoTam?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

