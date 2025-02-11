using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class ThongSoCLNAoService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ThongSoCLNAoService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ThongSoCLNAoDto>> GetAllThongSoCLNAoAsync()
        {
            var items = await _context.ThongSoCLNAo!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<ThongSoCLNAoDto>>(items);
        }

        public async Task<bool> SaveThongSoCLNAoAsync(ThongSoCLNAoDto dto)
        {
            var exitsItem = await _context!.ThongSoCLNAo!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<ThongSoCLNAo>(dto);

                _context.ThongSoCLNAo!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.ThongSoCLNAo!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.ThongSoCLNAo!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteThongSoCLNAoAsync(int Id)
        {
            var exitsItem = await _context!.ThongSoCLNAo!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.ThongSoCLNAo?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

