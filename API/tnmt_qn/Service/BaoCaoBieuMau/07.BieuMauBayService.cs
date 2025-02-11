using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauBayService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauBayService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauBayDto>> GetAllBieuMauBayAsync()
        {
            var items = await _context.BieuMauSoBay!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauBayDto>>(items);
        }

        public async Task<bool> SaveBieuMauBayAsync(BieuMauBayDto dto)
        {
            var exitsItem = await _context!.BieuMauSoBay!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoBay>(dto);

                _context.BieuMauSoBay!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoBay!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoBay!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauBayAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoBay!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoBay?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

