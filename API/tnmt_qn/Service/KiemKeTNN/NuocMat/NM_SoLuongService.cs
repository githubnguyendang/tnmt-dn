using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class NM_SoLuongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NM_SoLuongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        //Song Suoi
        public async Task<List<KKTNN_NuocMat_SoLuong_SongSuoiDto>> GetAllSongSuoiAsync()
        {
            var items = await _context.KKTNN_NuocMat_SoLuong_SongSuoi!.Where(d => d.DaXoa == false)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var soLuongNuocMatDto = _mapper.Map<List<KKTNN_NuocMat_SoLuong_SongSuoiDto>>(items);
            //foreach (var dto in soLuongNuocMatDto)
            //{
            //    if (!string.IsNullOrEmpty(dto.Song!.IdXaDauSong.ToString()))
            //    {
            //        var ds = await _context.DonViHC!.FirstOrDefaultAsync(dv => dv.IdXa == dto.Song!.IdXaDauSong.ToString());
            //        if (ds != null)
            //        {
            //            dto.Song.DauSong = new DauCuoiSongDto
            //            {
            //                X = dto.Song.XDauSong,
            //                Y = dto.Song.YDauSong,
            //                Xa = ds!.TenXa,
            //                Huyen = ds!.TenHuyen
            //            };
            //        }
            //        var cs = await _context.DonViHC!.FirstOrDefaultAsync(dv => dv.IdXa == dto.Song!.IdXaCuoiSong.ToString());
            //        if (cs != null)
            //        {
            //            dto.Song.CuoiSong = new DauCuoiSongDto
            //            {
            //                X = dto.Song.XCuoiSong,
            //                Y = dto.Song.YCuoiSong,
            //                Xa = cs!.TenXa,
            //                Huyen = cs!.TenHuyen
            //            };
            //        }
            //    }
            //}
            return soLuongNuocMatDto;


        }
        public async Task<bool> SaveSongSuoiAsync(KKTNN_NuocMat_SoLuong_SongSuoiDto dto)
        {

            var existingItem = await _context.KKTNN_NuocMat_SoLuong_SongSuoi!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<KKTNN_NuocMat_SoLuong_SongSuoi>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.KKTNN_NuocMat_SoLuong_SongSuoi!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.KKTNN_NuocMat_SoLuong_SongSuoi!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.KKTNN_NuocMat_SoLuong_SongSuoi!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteSongSuoiAsync(int Id)
        {
            var existingItem = await _context.KKTNN_NuocMat_SoLuong_SongSuoi!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.KKTNN_NuocMat_SoLuong_SongSuoi!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }

        //Ao Ho
        public async Task<List<KKTNN_NuocMat_SoLuong_AoHoDamPhaDto>> GetAllAoHoDamPhaAsync()
        {
            var items = await _context.KKTNN_NuocMat_SoLuong_AoHoDamPha!.Where(x => x.DaXoa == false).OrderBy(x => x.Id).ToListAsync();
            return _mapper.Map<List<KKTNN_NuocMat_SoLuong_AoHoDamPhaDto>>(items);


        }
        public async Task<bool> SaveAoHoDamPhaAsync(KKTNN_NuocMat_SoLuong_AoHoDamPhaDto dto)
        {

            var existingItem = await _context.KKTNN_NuocMat_SoLuong_AoHoDamPha!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<KKTNN_NuocMat_SoLuong_AoHoDamPha>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.KKTNN_NuocMat_SoLuong_AoHoDamPha!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.KKTNN_NuocMat_SoLuong_AoHoDamPha!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.KKTNN_NuocMat_SoLuong_AoHoDamPha!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAoHoDamPhaAsync(int Id)
        {
            var existingItem = await _context.KKTNN_NuocMat_SoLuong_AoHoDamPha!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.KKTNN_NuocMat_SoLuong_AoHoDamPha!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
