using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauHaiBaService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauHaiBaService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauHaiBaDto>> GetAllBieuMauHaiBaAsync()
        {
            var items = await _context.BieuMauSoHaiBa!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauHaiBaDto>>(items);
        }

        public async Task<bool> SaveBieuMauHaiBaAsync(BieuMauHaiBaDto dto)
        {
            var exitsItem = await _context!.BieuMauSoHaiBa!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoHaiBa>(dto);

                _context.BieuMauSoHaiBa!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoHaiBa!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoHaiBa!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauHaiBaAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoHaiBa!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoHaiBa?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

