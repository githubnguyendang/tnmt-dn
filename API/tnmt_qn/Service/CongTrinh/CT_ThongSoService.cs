using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using System.Security.Claims;

namespace tnmt_qn.Service
{
    public class CT_ThongSoService
    {
        //private readonly DatabaseContext _context;
        //private readonly IMapper _mapper;
        //private readonly IHttpContextAccessor _httpContext;
        //private readonly UserManager<AspNetUsers> _userManager;

        //// Constructor to initialize the service with required dependencies
        //public CT_ThongSoService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //    _httpContext = httpContext;
        //    _userManager = userManager;
        //}

        //// Method to save or update a CT_ThongSo entity
        //public async Task<bool> SaveAsync(CT_ThongSoDto dto)
        //{
        //    var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

        //    // Retrieve an existing item based on Id or if dto.Id is 0
        //    var existingItem = await _context.CT_ThongSo!
        //        .FirstOrDefaultAsync(d => (dto.IdCT != null && dto.IdCT > 0 && d.IdCT == dto.IdCT) ||
        //                                    (dto.IdHangMucCT != null && dto.IdHangMucCT > 0 && d.IdHangMucCT == dto.IdHangMucCT) &&
        //                                    d.DaXoa == false);

        //    CT_ThongSo item;

        //    if (existingItem == null)
        //    {
        //        // If the item doesn't exist or dto.Id is 0, create a new item
        //        item = _mapper.Map<CT_ThongSo>(dto);
        //        item.IdCT = item.IdCT == 0 ? null : item.IdCT;
        //        item.IdHangMucCT = item.IdHangMucCT == 0 ? null : item.IdHangMucCT;
        //        item.DaXoa = false;
        //        item.ThoiGianTao = DateTime.Now;
        //        item.TaiKhoanTao = currentUser?.UserName;
        //        _context.CT_ThongSo!.Add(item);
        //    }
        //    else
        //    {
        //        // If the item exists, update it with values from the dto, excluding the key property
        //        item = _mapper.Map(dto, existingItem);
        //        item.IdCT = item.IdCT == 0 ? null : item.IdCT;
        //        item.IdHangMucCT = item.IdHangMucCT == 0 ? null : item.IdHangMucCT;
        //        item.DaXoa = false;
        //        item.ThoiGianSua = DateTime.Now;
        //        item.TaiKhoanSua = currentUser?.UserName;
        //        _context.CT_ThongSo!.Update(item);
        //    }

        //    // Save changes to the database
        //    await _context.SaveChangesAsync();

        //    return true;
        //}


        //// Method to delete a CT_ThongSo entity
        //public async Task<bool> DeleteAsync(int Id)
        //{
        //    // Retrieve an existing item based on Id
        //    var existingItem = await _context.CT_ThongSo!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);
        //    var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

        //    if (existingItem == null) { return false; } // If the item doesn't exist, return false

        //    existingItem!.DaXoa = true; // Mark the item as deleted
        //    existingItem.ThoiGianSua = DateTime.Now;
        //    existingItem.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
        //    _context.CT_ThongSo!.Update(existingItem);

        //    // Save changes to the database
        //    await _context.SaveChangesAsync();

        //    // Return true to indicate successful deletion
        //    return true;
        //}
    }
}
