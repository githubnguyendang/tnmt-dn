using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauMuoiLamService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiLamService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauMuoiLamDto>> GetAllBieuMauMuoiLamAsync()
        {
            var items = await _context.BieuMauMuoiLam!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauMuoiLamDto>>(items);
        }

        public async Task<bool> SaveBieuMauMuoiLamAsync(BieuMauMuoiLamDto dto)
        {
            var exitsItem = await _context!.BieuMauMuoiLam!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoMuoiLam>(dto);

                _context.BieuMauMuoiLam!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauMuoiLam!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauMuoiLam!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauMuoiLamAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauMuoiLam!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauMuoiLam?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

