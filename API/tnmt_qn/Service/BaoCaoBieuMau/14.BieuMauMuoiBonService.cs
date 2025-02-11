using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Service
{
    public class BieuMauMuoiBonService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiBonService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BieuMauMuoiBonDto>?> GetAllAsync(int? nam)
        {
            var items = _context.CLN_NDD!.Where(d => d.DaXoa == false && d.ThoiGianQuanTrac == nam)
                .Select(cln => new BieuMauMuoiBonDto
                {
                    Id = cln.Id,
                    ThoiGianQuanTrac = cln.ThoiGianQuanTrac,
                    LuuVucSong = cln.LuuVucSong,
                    TangChuaNuoc = cln.TangChuaNuoc,
                    ViTriQuanTrac = cln.ViTriQuanTrac,
                    PHlonNhat = new[] { cln.PhDot1 , cln.PhDot2 , cln.PhDot3  }.Max(),
                    PHNhoNhat = new[] { cln.PhDot1, cln.PhDot2, cln.PhDot3 }.Min(),
                    PHTrungBinh = Math.Round((double)new[] { cln.PhDot1 , cln.PhDot2 , cln.PhDot3  }.Average()!, 2),
                    ColiformlonNhat = new[] { cln.ColiformDot1 , cln.ColiformDot2 , cln.ColiformDot3  }.Max(),
                    ColiformNhoNhat = new[] { cln.ColiformDot1 , cln.ColiformDot2 , cln.ColiformDot3  }.Min(),
                    ColiformTrungBinh = Math.Round((double)new[] { cln.ColiformDot1 , cln.ColiformDot2 , cln.ColiformDot3  }.Average()!, 2),
                    NitratelonNhat = new[] { cln.NitrateDot1 , cln.NitrateDot2 , cln.NitrateDot3  }.Max(),
                    NitrateNhoNhat = new[] { cln.NitrateDot1 , cln.NitrateDot2 , cln.NitrateDot3  }.Min(),
                    NitrateTrungBinh = Math.Round((double)new[] { cln.NitrateDot1 , cln.NitrateDot2 , cln.NitrateDot3  }.Average()!, 2),
                    AmonilonNhat = new[] { cln.AmoniDot1 , cln.AmoniDot2 , cln.AmoniDot3  }.Max(),
                    AmoniNhoNhat = new[] { cln.AmoniDot1 , cln.AmoniDot2 , cln.AmoniDot3  }.Min(),
                    AmoniTrungBinh = Math.Round((double)new[] { cln.AmoniDot1 , cln.AmoniDot2 , cln.AmoniDot3  }.Average()!, 3),
                    TDSlonNhat = new[] { cln.TDSDot1 , cln.TDSDot2 , cln.TDSDot3  }.Max(),
                    TDSNhoNhat = new[] { cln.TDSDot1 , cln.TDSDot2 , cln.TDSDot3  }.Min(),
                    TDSTrungBinh = Math.Round((double)new[] { cln.TDSDot1 , cln.TDSDot2 , cln.TDSDot3  }.Average()!, 2),
                    DoCungLonNhat = cln.DoCungDot1 == null && cln.DoCungDot2 == null && cln.DoCungDot3 == null ? null 
                    : new[] { cln.DoCungDot1, cln.DoCungDot2, cln.DoCungDot3 }.Max(),
                    DoCungNhoNhat = cln.DoCungDot1 == null && cln.DoCungDot2 == null && cln.DoCungDot3 == null ? null
                    : new[] { cln.DoCungDot1, cln.DoCungDot2, cln.DoCungDot3 }.Min(),
                    DoCungTrungBinh = cln.DoCungDot1 == null && cln.DoCungDot2 == null && cln.DoCungDot3 == null ? null
                    : Math.Round((double)new[] { cln.DoCungDot1, cln.DoCungDot2, cln.DoCungDot3 }.Average()!, 2),
                    ArsenicLonNhat = cln.ArsenicDot1 == null && cln.ArsenicDot2 == null && cln.ArsenicDot3 == null ? null 
                    : new[] { cln.ArsenicDot1, cln.ArsenicDot2, cln.ArsenicDot3 }.Max(),
                    ArsenicNhoNhat = cln.ArsenicDot1 == null && cln.ArsenicDot2 == null && cln.ArsenicDot3 == null ? null 
                    : new[] { cln.ArsenicDot1, cln.ArsenicDot2, cln.ArsenicDot3 }.Min(),
                    ArsenicTrungBinh = cln.ArsenicDot1 == null && cln.ArsenicDot2 == null && cln.ArsenicDot3 == null ? null 
                    : Math.Round((double)new[] { cln.ArsenicDot1, cln.ArsenicDot2, cln.ArsenicDot3 }.Average()!, 4),
                    ChlorideLonNhat = new[] { cln.ChlorideDot1 , cln.ChlorideDot2 , cln.ChlorideDot3  }.Max(),
                    ChlorideNhoNhat = new[] { cln.ChlorideDot1 , cln.ChlorideDot2 , cln.ChlorideDot3  }.Min(),
                    ChlorideTrungBinh = Math.Round((double)new[] { cln.ChlorideDot1 , cln.ChlorideDot2 , cln.ChlorideDot3  }.Average()!, 2),

                })
                .OrderBy(d => d.Id)
                .AsQueryable();

            var ttdlDto = _mapper.Map<List<BieuMauMuoiBonDto>>(await items.ToListAsync());

            return ttdlDto;
        }


    }
}

