using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauMuoiBaService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiBaService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BieuMauMuoiBaDto>> GetAllAsync(int nam)
        {
            var items = _context.CLN_NuocMat!.Where(d => d.DaXoa == false && d.ThoiGianQuanTrac == nam)
                .Select(cln => new BieuMauMuoiBaDto
                {
                    Id = cln.Id,
                    ViTriQuanTrac = cln.ViTriQuanTrac,
                    LuuVucSong = cln.LuuVucSong,
                    SongSuoiHoChua = cln.SongSuoiHoChua,
                    BOD5LonNhat = new[] { cln.BOD5Dot1, cln.BOD5Dot2, cln.BOD5Dot3 }.Max(),
                    BOD5NhoNhat = new[] { cln.BOD5Dot1, cln.BOD5Dot2, cln.BOD5Dot3 }.Min(),
                    BOD5TrungBinh = Math.Round((double)new[] { cln.BOD5Dot1, cln.BOD5Dot2, cln.BOD5Dot3 }.Average()!, 2),
                    CODLonNhat = new[] { cln.CODDot1, cln.CODDot2, cln.CODDot3 }.Max(),
                    CODNhoNhat = new[] { cln.CODDot1, cln.CODDot2, cln.CODDot3 }.Min(),
                    CODTrungBinh = Math.Round((double)new[] { cln.CODDot1, cln.CODDot2, cln.CODDot3 }.Average()!, 2),
                    DOLonNhat = new[] { cln.DODot1, cln.DODot2, cln.DODot3 }.Max(),
                    DONhoNhat = new[] { cln.DODot1, cln.DODot2, cln.DODot3 }.Min(),
                    DOTrungBinh = Math.Round((double)new[] { cln.DODot1, cln.DODot2, cln.DODot3 }.Average()!, 2),
                })
                .OrderBy(d => d.Id)
                .AsQueryable();

            var ttdlDto = _mapper.Map<List<BieuMauMuoiBaDto>>(await items.ToListAsync());

            return ttdlDto;
        }
    }
}

