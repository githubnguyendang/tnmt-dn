using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class ThongSoCLNSongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ThongSoCLNSongService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ThongSoCLNSongDto>> GetAllThongSoCLNSongAsync()
        {
            var items = await _context.ThongSoCLNSong!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<ThongSoCLNSongDto>>(items);
        }

        public async Task<bool> SaveThongSoCLNSongAsync(ThongSoCLNSongDto dto)
        {
            var exitsItem = await _context!.ThongSoCLNSong!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<ThongSoCLNSong>(dto);

                _context.ThongSoCLNSong!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.ThongSoCLNSong!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.ThongSoCLNSong!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteThongSoCLNSongAsync(int Id)
        {
            var exitsItem = await _context!.ThongSoCLNSong!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.ThongSoCLNSong?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

