using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauMuoiTamService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiTamService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauMuoiTamDto>> GetAllBieuMauMuoiTamAsync()
        {
            var items = await _context.BieuMauSoMuoiTam!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauMuoiTamDto>>(items);
        }

        public async Task<bool> SaveBieuMauMuoiTamAsync(BieuMauMuoiTamDto dto)
        {
            var exitsItem = await _context!.BieuMauSoMuoiTam!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoMuoiTam>(dto);

                _context.BieuMauSoMuoiTam!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoMuoiTam!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoMuoiTam!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauMuoiTamAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoMuoiTam!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoMuoiTam?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

