using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauHaiService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauHaiService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauHaiDto>> GetAllBieuMauHaiAsync()
        {
            var items = await _context.BieuMauSoHai!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauHaiDto>>(items);
        }

        public async Task<bool> SaveBieuMauHaiAsync(BieuMauHaiDto dto)
        {
            var exitsItem = await _context!.BieuMauSoHai!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoHai>(dto);

                _context.BieuMauSoHai!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoHai!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoHai!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauHaiAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoHai!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoHai?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

