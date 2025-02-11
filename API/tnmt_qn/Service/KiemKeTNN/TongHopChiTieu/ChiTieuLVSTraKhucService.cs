using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class ChiTieuLVSTraKhucService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ChiTieuLVSTraKhucService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ChiTieuLVSTraKhucDto>> GetAllChiTieuLVSTraKhucAsync()
        {
            var items = await _context.ChiTieuLVSTraKhuc!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<ChiTieuLVSTraKhucDto>>(items);
        }

        public async Task<bool> SaveChiTieuLVSTraKhucAsync(ChiTieuLVSTraKhucDto dto)
        {
            var exitsItem = await _context!.ChiTieuLVSTraKhuc!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<ChiTieuLVSTraKhuc>(dto);

                _context.ChiTieuLVSTraKhuc!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.ChiTieuLVSTraKhuc!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.ChiTieuLVSTraKhuc!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteChiTieuLVSTraKhucAsync(int Id)
        {
            var exitsItem = await _context!.ChiTieuLVSTraKhuc!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.ChiTieuLVSTraKhuc?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

