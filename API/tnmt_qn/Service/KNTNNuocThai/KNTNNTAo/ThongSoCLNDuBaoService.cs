using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class ThongSoCLNDuBaoService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ThongSoCLNDuBaoService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ThongSoCLNDuBaoDto>> GetAllThongSoCLNDuBaoAsync()
        {
            var items = await _context.ThongSoCLNDuBao!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<ThongSoCLNDuBaoDto>>(items);
        }

        public async Task<bool> SaveThongSoCLNDuBaoAsync(ThongSoCLNDuBaoDto dto)
        {
            var exitsItem = await _context!.ThongSoCLNDuBao!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<ThongSoCLNDuBao>(dto);

                _context.ThongSoCLNDuBao!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.ThongSoCLNDuBao!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.ThongSoCLNDuBao!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteThongSoCLNDuBaoAsync(int Id)
        {
            var exitsItem = await _context!.ThongSoCLNDuBao!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.ThongSoCLNDuBao?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

