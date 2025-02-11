using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauHaiHaiService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauHaiHaiService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauHaiHaiDto>> GetAllBieuMauHaiHaiAsync()
        {
            var items = await _context.BieuMauSoHaiHai!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauHaiHaiDto>>(items);
        }

        public async Task<bool> SaveBieuMauHaiHaiAsync(BieuMauHaiHaiDto dto)
        {
            var exitsItem = await _context!.BieuMauSoHaiHai!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoHaiHai>(dto);

                _context.BieuMauSoHaiHai!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoHaiHai!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoHaiHai!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauHaiHaiAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoHaiHai!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoHaiHai?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

