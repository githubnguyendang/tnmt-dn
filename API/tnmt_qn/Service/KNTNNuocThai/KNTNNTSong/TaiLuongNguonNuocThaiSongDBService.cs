using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace tnmt_qn.Service
{
    public class TaiLuongNuocThaiSongDBService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public TaiLuongNuocThaiSongDBService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<TaiLuongNuocThaiSongDBDto>> GetDataCaculatePolutantAsync()
        {

            var itemsQuery = _context.TaiLuongNuocThaiSongDB!
                .Include(x => x.DuLieuNguonNuocNhanDB)
                .Include(p => p.DuLieuNguonNuocThaiDiemDB)
                .Include(p => p.DuLieuNguonNuocThaiSinhHoatDB)
                .Include(p => p.DuLieuNguonNuocThaiGiaCamDB)
                .Include(p => p.DuLieuNguonNuocThaiLonDB)
                .Include(p => p.DuLieuNguonNuocThaiTrauBoDB)
                .Include(p => p.DuLieuNguonNuocThaiTrongCayDB)
                .Include(p => p.DuLieuNguonNuocThaiTrongLuaDB)
                .Include(p => p.DuLieuNguonNuocThaiTrongRungDB)
                .Include(p => p.DuLieuNguonNuocThaiThuySanDB)
                .AsQueryable();


        

            var items = await itemsQuery.ToListAsync();


            var pdsDtos = _mapper.Map<List<TaiLuongNuocThaiSongDBDto>>(items);


            foreach (var dto in pdsDtos)
            {
                // Reset unnecessary properties to null
               
                dto.DuLieuNguonNuocThaiDiemDB = null;
                dto.DuLieuNguonNuocThaiSinhHoatDB = null;
                dto.DuLieuNguonNuocThaiGiaCamDB = null;
                dto.DuLieuNguonNuocThaiLonDB = null;
                dto.DuLieuNguonNuocThaiTrauBoDB = null;
                dto.DuLieuNguonNuocThaiTrongCayDB = null;
                dto.DuLieuNguonNuocThaiTrongLuaDB = null;
                dto.DuLieuNguonNuocThaiTrongRungDB = null;
                dto.DuLieuNguonNuocThaiThuySanDB = null;
            }

            return pdsDtos;
        }
     

    }
}
