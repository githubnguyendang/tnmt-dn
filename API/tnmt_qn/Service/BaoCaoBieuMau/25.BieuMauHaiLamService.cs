using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauHaiLamService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauHaiLamService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauHaiLamDto>> GetAllBieuMauHaiLamAsync()
        {
            var items = await _context.BieuMauSoHaiLam!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauHaiLamDto>>(items);
        }

        public async Task<bool> SaveBieuMauHaiLamAsync(BieuMauHaiLamDto dto)
        {
            var exitsItem = await _context!.BieuMauSoHaiLam!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoHaiLam>(dto);

                _context.BieuMauSoHaiLam!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoHaiLam!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoHaiLam!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauHaiLamAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoHaiLam!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoHaiLam?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

