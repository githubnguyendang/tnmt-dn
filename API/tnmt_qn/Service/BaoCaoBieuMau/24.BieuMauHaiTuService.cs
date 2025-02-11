using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauHaiTuService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauHaiTuService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauHaiTuDto>> GetAllBieuMauHaiTuAsync()
        {
            var items = await _context.BieuMauSoHaiTu!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauHaiTuDto>>(items);
        }

        public async Task<bool> SaveBieuMauHaiTuAsync(BieuMauHaiTuDto dto)
        {
            var exitsItem = await _context!.BieuMauSoHaiTu!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoHaiTu>(dto);

                _context.BieuMauSoHaiTu!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoHaiTu!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoHaiTu!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauHaiTuAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoHaiTu!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoHaiTu?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

