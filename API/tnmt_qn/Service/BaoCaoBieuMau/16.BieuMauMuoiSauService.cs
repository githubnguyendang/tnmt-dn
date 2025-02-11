using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauMuoiSauService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiSauService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauMuoiSauDto>> GetAllBieuMauMuoiSauAsync()
        {
            var items = await _context.BieuMauSoMuoiSau!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauMuoiSauDto>>(items);
        }

        public async Task<bool> SaveBieuMauMuoiSauAsync(BieuMauMuoiSauDto dto)
        {
            var exitsItem = await _context!.BieuMauSoMuoiSau!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoMuoiSau>(dto);

                _context.BieuMauSoMuoiSau!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoMuoiSau!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoMuoiSau!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauMuoiSauAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoMuoiSau!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoMuoiSau?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

