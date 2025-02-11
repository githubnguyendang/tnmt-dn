using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauMuoiBayService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiBayService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauMuoiBayDto>> GetAllBieuMauMuoiBayAsync()
        {
            var items = await _context.BieuMauSoMuoiBay!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauMuoiBayDto>>(items);
        }

        public async Task<bool> SaveBieuMauMuoiBayAsync(BieuMauMuoiBayDto dto)
        {
            var exitsItem = await _context!.BieuMauSoMuoiBay!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoMuoiBay>(dto);

                _context.BieuMauSoMuoiBay!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoMuoiBay!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoMuoiBay!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauMuoiBayAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoMuoiBay!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoMuoiBay?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

