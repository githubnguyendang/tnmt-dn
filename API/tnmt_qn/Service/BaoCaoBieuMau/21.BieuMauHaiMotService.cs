using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauHaiMotService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauHaiMotService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauHaiMotDto>> GetAllBieuMauHaiMotAsync()
        {
            var items = await _context.BieuMauSoHaiMot!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauHaiMotDto>>(items);
        }

        public async Task<bool> SaveBieuMauHaiMotAsync(BieuMauHaiMotDto dto)
        {
            var exitsItem = await _context!.BieuMauSoHaiMot!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoHaiMot>(dto);

                _context.BieuMauSoHaiMot!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoHaiMot!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoHaiMot!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauHaiMotAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoHaiMot!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoHaiMot?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

