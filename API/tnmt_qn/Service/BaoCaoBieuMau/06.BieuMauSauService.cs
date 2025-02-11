using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauSauService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauSauService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauSauDto>> GetAllBieuMauSauAsync()
        {
            var items = await _context.BieuMauSoSau!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauSauDto>>(items);
        }

        public async Task<bool> SaveBieuMauSauAsync(BieuMauSauDto dto)
        {
            var exitsItem = await _context!.BieuMauSoSau!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoSau>(dto);

                _context.BieuMauSoSau!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoSau!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoSau!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauSauAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoSau!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoSau?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

