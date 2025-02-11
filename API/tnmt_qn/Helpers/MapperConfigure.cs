using AutoMapper;
using tnmt_qn.Data;
using tnmt_qn.Dto;

namespace tnmt_qn.Helpers
{
    public class MapperConfigure : Profile
    {
        public MapperConfigure()
        {

            //-------------Authenticatiion--------------------

            //Users
            CreateMap<AspNetUsers, UserDto>().ReverseMap();

            //Users Info
            CreateMap<AspNetUsers, UserInfoDto>().ForMember(dest => dest.Dashboards, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Dashboards);
                }).ReverseMap();

            //Roles
            CreateMap<AspNetRoles, RoleDto>()
                .ForMember(dest => dest.Dashboards, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Dashboards);
                }).ReverseMap();

            //Dashboards
            CreateMap<Dashboards, DashboardDto>()
                .ForMember(dest => dest.Functions, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Functions);
                }).ReverseMap();
            //Test
            CreateMap<Test, TestDto>().ReverseMap();
            //Permissions
            CreateMap<Permissions, PermissionDto>().ReverseMap();

            //Dashboard for Roles and Users
            CreateMap<UserDashboards, UserDashboardDto>().ReverseMap();
            CreateMap<RoleDashboards, RoleDashboardDto>().ReverseMap();

            //functions
            CreateMap<Functions, FunctionDto>().ReverseMap();

            //-------------Other mapper--------------------

            CreateMap<CT_Loai, CT_LoaiDto>().ReverseMap();
            CreateMap<CT_HangMuc, CT_HangMucDto>().ReverseMap();
            CreateMap<CT_ThongSo, CT_ThongSoDto>().ReverseMap();

            //Get data
            CreateMap<CT_ThongTin, CT_ThongTinDto>()
            .ForMember(dest => dest.loaiCT, opt => opt.MapFrom(src => src.LoaiCT))
            .ForMember(dest => dest.hangmuc, opt => opt.MapFrom(src => src.HangMuc!.Where(hm => hm.DaXoa == false)))
            .ForMember(dest => dest.thongso, opt => opt.MapFrom(src => src.ThongSo))
            .ForMember(dest => dest.ThanhTraKiemTra, opt => opt.MapFrom(src => src.ThanhTraKiemTra))
            .ForMember(dest => dest.luuvuc, opt => opt.MapFrom(src => src.LuuVuc))
            .ForMember(dest => dest.giayphep, opt => opt.MapFrom(src => src.GiayPhep!.Where(gp => gp.DaXoa == false)))
            .ForMember(dest => dest.vitri, opt => opt.MapFrom(src => src.CT_ViTri))
            .ForMember(dest => dest.huyen, opt => opt.MapFrom(src => src.CT_ViTri!
            .Where(v => v.Huyen != null)
            .Select(v => v.Huyen).GroupBy(h => h!.IdHuyen).Select(g => g.First()).ToList()))
            .ForMember(dest => dest.xa, opt => opt.MapFrom(src => src.CT_ViTri!
            .Select(v => v.Xa).ToList()))
            .ForMember(dest => dest.luuluong_theomd, opt => opt.MapFrom(src => src.LuuLuongTheoMucDich != null ? src.LuuLuongTheoMucDich!.Where(x => x.DaXoa == false).Select(lld => new LuuLuongTheoMucDichDto()
            {
                Id = lld.Id,
                IdCT = lld.IdCT,
                IdMucDich = lld.IdMucDich,
                MucDich = lld.MucDichKT!.MucDich,
                LuuLuong = lld.LuuLuong,
                DonViDo = lld.DonViDo,
                GhiChu = lld.GhiChu,
            }).ToList() : new List<LuuLuongTheoMucDichDto>()))
            .ForMember(dest => dest.mucdich_kt, opt => opt.MapFrom(src => src.LuuLuongTheoMucDich != null ? src.LuuLuongTheoMucDich!
            .Where(l => l.MucDichKT != null && l.DaXoa == false)
            .GroupBy(l => l.MucDichKT!.Id)
            .Select(g => new MucDichKTDto
            {
                Id = g.Key,
                MucDich = g.First().MucDichKT!.MucDich,
                LuuLuong = new LuuLuongTheoMucDichDto
                {
                    Id = g.First().Id,
                    IdMucDich = g.First().IdMucDich,
                    IdCT = g.First().IdCT,
                    LuuLuong = g.Sum(ll => ll.MucDichKT!.LuuLuongTheoMucDich!.Where(llmd => llmd.CT_ThongTin!.Id == src.Id && llmd.DaXoa == false).Sum(llmd => llmd.LuuLuong ?? 0)),
                    DonViDo = g.First().MucDichKT!.LuuLuongTheoMucDich!.Where(lld => lld.DaXoa == false).First().DonViDo
                }
            }).ToList() : new List<MucDichKTDto>()))
            .AfterMap((src, dest) =>
            {
                if (dest.mucdich_kt != null)
                {
                    var hasM3NgayDem = dest.mucdich_kt.Any(mk => mk.LuuLuong?.DonViDo == "m3/ngày đêm");
                    var hasM3S = dest.mucdich_kt.Any(mk => mk.LuuLuong?.DonViDo == "m3/s");

                    if (hasM3NgayDem && hasM3S)
                    {
                        dest.mucdich_kt.ForEach(mk =>
                        {
                            if (mk.LuuLuong != null && mk.LuuLuong.DonViDo == "m3/ngày đêm")
                            {
                                mk.LuuLuong.LuuLuong = mk.LuuLuong.LuuLuong!.Value / 86400;
                                mk.LuuLuong.DonViDo = "m3/s";
                            }
                        });

                        dest.TongLuuLuong = dest.mucdich_kt
                            .Where(mk => mk.LuuLuong != null && mk.LuuLuong.LuuLuong.HasValue)
                            .Sum(mk => mk.LuuLuong!.LuuLuong!.Value);

                        dest.TongLuuLuong = Math.Round((double)dest.TongLuuLuong, 3);

                        dest.DonViTinhLuuLuong = "m3/s";
                    }
                    else
                    {
                        // Nếu chỉ có một loại đơn vị đo
                        dest.TongLuuLuong = dest.mucdich_kt
                            .Where(mk => mk.LuuLuong != null && mk.LuuLuong.LuuLuong.HasValue)
                            .Sum(mk => mk.LuuLuong!.LuuLuong!.Value);

                        dest.TongLuuLuong = Math.Round((double)dest.TongLuuLuong, 3);

                        // Đơn vị đo được giữ nguyên dựa trên loại duy nhất tồn tại
                        dest.DonViTinhLuuLuong = "m3/ngày đêm";
                    }
                }
                else
                {
                    dest.TongLuuLuong = 0;
                    dest.DonViTinhLuuLuong = "";
                }

                if (dest.TongLuuLuong == null || dest.TongLuuLuong == 0)
                {
                    dest.DonViTinhLuuLuong = "";
                }
            });


            //Mapper to save CT_ThongTin
            CreateMap<CT_ThongTinDto, CT_ThongTin>()
                .ForMember(dest => dest.HangMuc, opt => opt.MapFrom(src => src.hangmuc))
                .ForMember(dest => dest.ThongSo, opt => opt.MapFrom(src => src.thongso))
                .ForMember(dest => dest.CT_ViTri, opt => opt.MapFrom(src => src.vitri))
                .ForMember(dest => dest.LuuLuongTheoMucDich, opt => opt.MapFrom(src => src.luuluong_theomd))
                .ForMember(dest => dest.GiayPhep, opt => opt.Ignore())
                .ForMember(dest => dest.ThanhTraKiemTra, opt => opt.Ignore());

            CreateMap<MucDichKT, MucDichKTDto>();
            CreateMap<LuuLuongTheoMucDich, LuuLuongTheoMucDichDto>();
            CreateMap<LuuLuongTheoMucDichDto, LuuLuongTheoMucDich>()
                .ForMember(dest => dest.CT_ThongTin, opt => opt.Ignore())
                .ForMember(dest => dest.MucDichKT, opt => opt.Ignore());

            CreateMap<CT_ViTriDto, CT_ViTri>()
                .ForMember(dest => dest.Huyen, opt => opt.Ignore())
                .ForMember(dest => dest.Xa, opt => opt.Ignore());

            CreateMap<CT_ViTri, CT_ViTriDto>()
                .ForMember(dest => dest.TenHuyen, opt => opt.MapFrom(src => src.Huyen!.TenHuyen))
                .ForMember(dest => dest.TenXa, opt => opt.MapFrom(src => src.Xa!.TenXa));


            CreateMap<Huyen, HuyenDto>().ReverseMap();
            CreateMap<Xa, XaDto>().ReverseMap();

            CreateMap<GP_Loai, GP_LoaiDto>().ReverseMap();
            CreateMap<GP_ThongTin, GP_ThongTinDto>()
                        .ForMember(dest => dest.tochuc_canhan, opt => opt.MapFrom(src => src.ToChuc_CaNhan))
                        .ForMember(dest => dest.loaiGP, opt => opt.MapFrom(src => src.LoaiGP))
                        .ForMember(dest => dest.congtrinh, opt => opt.MapFrom(src => src.CongTrinh))
                        .ForMember(dest => dest.giayphep_cu, opt => opt.MapFrom(src => src.giayphep_cu))
                        .ForMember(dest => dest.ThanhTraKiemTra, opt => opt.MapFrom(src => src.ThanhTraKiemTra))
                        .ForMember(dest => dest.tiencq, opt => opt.MapFrom(src => src.GP_TCQ!.Select(tcq => tcq.TCQ_ThongTin).ToList()));

            CreateMap<GP_ThongTinDto, GP_ThongTin>()
                 .ForMember(dest => dest.ToChuc_CaNhan, opt => opt.Ignore())
                 .ForMember(dest => dest.LoaiGP, opt => opt.Ignore())
                 .ForMember(dest => dest.CongTrinh, opt => opt.Ignore())
                 .ForMember(dest => dest.ThanhTraKiemTra, opt => opt.MapFrom(src => src.ThanhTraKiemTra))
                 .ForMember(dest => dest.GP_TCQ, opt => opt.MapFrom(src => src.gp_tcq));

            CreateMap<GP_TCQ, GP_TCQDto>().ReverseMap();

            CreateMap<TCQ_ThongTin, TCQ_ThongTinDto>()
                        .ForMember(dest => dest.giayphep, opt => opt.MapFrom(src => src.GP_TCQ!.Select(gp => gp.GP_ThongTin).ToList()));

            CreateMap<TCQ_ThongTinDto, TCQ_ThongTin>();


            CreateMap<ToChuc_CaNhan, ToChuc_CaNhanDto>().ReverseMap();
            CreateMap<ThanhTraKiemTra, ThanhTraKiemTraDto>()
                .ForMember(dest => dest.GP, otp => otp.MapFrom(src => src.GiayPhep))
                .ForMember(dest => dest.CT, otp => otp.MapFrom(src => src.CongTrinh))
                .ForMember(dest => dest.TCCN, otp => otp.MapFrom(src => src.ToChuc_CaNhan));
            CreateMap<ThanhTraKiemTraDto, ThanhTraKiemTra>()
                .ForMember(dest => dest.CongTrinh, opt => opt.Ignore())
                .ForMember(dest => dest.GiayPhep, opt => opt.Ignore())
                .ForMember(dest => dest.ToChuc_CaNhan, opt => opt.Ignore());

            //baocaobieumau
            CreateMap<BieuMauSoMot, BieuMauMotDto>().ReverseMap();
            CreateMap<BieuMauSoHai, BieuMauHaiDto>().ReverseMap();
            CreateMap<BieuMauSoBa, BieuMauBaDto>().ReverseMap();
            CreateMap<BieuMauSoBon, BieuMauBonDto>().ReverseMap();
            CreateMap<BieuMauSoNam, BieuMauNamDto>().ReverseMap();
            CreateMap<BieuMauSoSau, BieuMauSauDto>().ReverseMap();
            CreateMap<BieuMauSoBay, BieuMauBayDto>().ReverseMap();
            CreateMap<BieuMauSoTam, BieuMauTamDto>().ReverseMap();
            CreateMap<BieuMauSoChin, BieuMauChinDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiSau, BieuMauMuoiSauDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiBay, BieuMauMuoiBayDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiTam, BieuMauMuoiTamDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiChin, BieuMauMuoiChinDto>().ReverseMap();
            CreateMap<BieuMauSoHaiMot, BieuMauHaiMotDto>().ReverseMap();
            CreateMap<BieuMauSoHaiHai, BieuMauHaiHaiDto>().ReverseMap();
            CreateMap<BieuMauSoHaiBa, BieuMauHaiBaDto>().ReverseMap();
            CreateMap<BieuMauSoHaiTu, BieuMauHaiTuDto>().ReverseMap();
            CreateMap<BieuMauSoHaiLam, BieuMauHaiLamDto>().ReverseMap();

            //KNTiepNhanNuocThai
            CreateMap<ThongSoCLNSong, ThongSoCLNSongDto>().ReverseMap();
            CreateMap<NguonThaiDiem, NguonThaiDiemDto>().ReverseMap();
            CreateMap<ThongSoCLNAo, ThongSoCLNAoDto>().ReverseMap();
            CreateMap<DoanSong, DoanSongDto>()
                        .ForMember(dest => dest.ThongSoLtd, opt => opt.MapFrom(src => src.ThongSoLtd))
                        .ReverseMap();
            CreateMap<ThongSoLtd, ThongSoLtdDto>().ReverseMap();
            CreateMap<DuLieuNguonNuocNhan, DuLieuNguonNuocNhanDto>()
                        .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiDiem, DuLieuNguonNuocThaiDiemDto>()
                        .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiSinhHoat, DuLieuNguonNuocThaiSinhHoatDto>()
                       .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrauBo, DuLieuNguonNuocThaiTrauBoDto>()
                      .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiLon, DuLieuNguonNuocThaiLonDto>()
                     .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiGiaCam, DuLieuNguonNuocThaiGiaCamDto>()
                    .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrongLua, DuLieuNguonNuocThaiTrongLuaDto>()
                    .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrongCay, DuLieuNguonNuocThaiTrongCayDto>()
                    .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrongRung, DuLieuNguonNuocThaiTrongRungDto>()
           .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiThuySan, DuLieuNguonNuocThaiThuySanDto>()
            .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();

            //dubaokntnsong
            CreateMap<DuLieuNguonNuocNhanDB, DuLieuNguonNuocNhanDBDto>()
                        .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiDiemDB, DuLieuNguonNuocThaiDiemDBDto>()
                        .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiSinhHoatDB, DuLieuNguonNuocThaiSinhHoatDBDto>()
                       .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrauBoDB, DuLieuNguonNuocThaiTrauBoDBDto>()
                      .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiLonDB, DuLieuNguonNuocThaiLonDBDto>()
                     .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiGiaCamDB, DuLieuNguonNuocThaiGiaCamDBDto>()
                    .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrongLuaDB, DuLieuNguonNuocThaiTrongLuaDBDto>()
                    .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrongCayDB, DuLieuNguonNuocThaiTrongCayDBDto>()
                    .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrongRungDB, DuLieuNguonNuocThaiTrongRungDBDto>()
           .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiThuySanDB, DuLieuNguonNuocThaiThuySanDBDto>()
            .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();


            CreateMap<TaiLuongNuocThaiSongDB, TaiLuongNuocThaiSongDBDto>()
           .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong))
                .ForMember(dest => dest.LtBodDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemBODDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatBODDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamBODDB
                + src.DuLieuNguonNuocThaiLonDB!.LtLonBODDB + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoBODDB
                + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayBODDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaBODDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungBODDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanBODDB))

                .ForMember(dest => dest.LtCodDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemCODDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatCODDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamCODDB + src.DuLieuNguonNuocThaiLonDB!.LtLonCODDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoCODDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayCODDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaCODDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungCODDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanCODDB))

                .ForMember(dest => dest.LtAmoniDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemAmoniDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatAmoniDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamAmoniDB + src.DuLieuNguonNuocThaiLonDB!.LtLonAmoniDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoAmoniDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayAmoniDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaAmoniDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungAmoniDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanAmoniDB))

                .ForMember(dest => dest.LtTongNDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemTongNDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatTongNDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamTongNDB + src.DuLieuNguonNuocThaiLonDB!.LtLonTongNDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoTongNDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayTongNDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaTongNDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungTongNDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanTongNDB))

                .ForMember(dest => dest.LtTongPDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemTongPDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatTongPDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamTongPDB + src.DuLieuNguonNuocThaiLonDB!.LtLonTongPDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoTongPDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayTongPDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaTongPDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungTongPDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanTongPDB))

                .ForMember(dest => dest.LtTSSDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemTSSDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatTSSDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamTSSDB + src.DuLieuNguonNuocThaiLonDB!.LtLonTSSDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoTSSDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayTSSDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaTSSDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungTSSDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanTSSDB))

                .ForMember(dest => dest.LtColiformDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemColiformDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatColiformDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamColiformDB + src.DuLieuNguonNuocThaiLonDB!.LtLonColiformDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoColiformDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayColiformDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaColiformDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungColiformDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanColiformDB))

                //ltd
                .ForMember(dest => dest.LtnBodDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdBODDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnBODDB : 0) - dest.LtBodDB) * (src.PhanDoanSong != null ? src.PhanDoanSong.HeSoFS : 0))))
                .ForMember(dest => dest.LtnCodDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdCODDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnCODDB : 0) - dest.LtCodDB) * (src.PhanDoanSong != null ? src.PhanDoanSong.HeSoFS : 0))))
                .ForMember(dest => dest.LtnAmoniDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdAmoniDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnAmoniDB : 0) - dest.LtAmoniDB) * (src.PhanDoanSong != null ? src.PhanDoanSong.HeSoFS : 0))))
                .ForMember(dest => dest.LtnTongNDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdTongNDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnTongNDB : 0) - dest.LtTongNDB) * (src.PhanDoanSong != null ? src.PhanDoanSong.HeSoFS : 0))))
                .ForMember(dest => dest.LtnTongPDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdTongPDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnTongPDB : 0) - dest.LtTongPDB) * (src.PhanDoanSong != null ? src.PhanDoanSong.HeSoFS : 0))))
                .ForMember(dest => dest.LtnTSSDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdTSSDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnTSSDB : 0) - dest.LtTSSDB) * (src.PhanDoanSong != null ? src.PhanDoanSong.HeSoFS : 0))))
                .ForMember(dest => dest.LtnColiformDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdColiformDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnColiformDB : 0) - dest.LtColiformDB) * (src.PhanDoanSong != null ? src.PhanDoanSong.HeSoFS : 0))))
               .ReverseMap();

            CreateMap<PhanDoanSong, PhanDoanSongDto>()
                .ForMember(dest => dest.DuLieuNguonNuocNhan, opt => opt.MapFrom(src => src.DuLieuNguonNuocNhan))
                 .ForMember(dest => dest.DuLieuNguonNuocNhanDB, opt => opt.MapFrom(src => src.DuLieuNguonNuocNhanDB))
                .ForMember(dest => dest.DuLieuNguonNuocThaiDiem, opt => opt.MapFrom(src => src.DuLieuNguonNuocThaiDiem))
                .ForMember(dest => dest.DuLieuNguonNuocThaiSinhHoat, opt => opt.MapFrom(src => src.DuLieuNguonNuocThaiSinhHoat))

                //bod
                .ForMember(dest => dest.LtBod, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiem != null ? src.DuLieuNguonNuocThaiDiem.LtdiemBOD : 0)
                + src.DuLieuNguonNuocThaiSinhHoat!.LtSinhHoatBOD + src.DuLieuNguonNuocThaiGiaCam!.LtGiaCamBOD
                + src.DuLieuNguonNuocThaiLon!.LtLonBOD + src.DuLieuNguonNuocThaiTrauBo!.LtTrauBoBOD
                + src.DuLieuNguonNuocThaiTrongCay!.LtTrongCayBOD + src.DuLieuNguonNuocThaiTrongLua!.LtTrongLuaBOD
                + src.DuLieuNguonNuocThaiTrongRung!.LtTrongRungBOD + src.DuLieuNguonNuocThaiThuySan!.LtThuySanBOD))

                .ForMember(dest => dest.LtCod, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiem != null ? src.DuLieuNguonNuocThaiDiem.LtdiemCOD : 0)
                + src.DuLieuNguonNuocThaiSinhHoat!.LtSinhHoatCOD + src.DuLieuNguonNuocThaiGiaCam!.LtGiaCamCOD + src.DuLieuNguonNuocThaiLon!.LtLonCOD
                + src.DuLieuNguonNuocThaiTrauBo!.LtTrauBoCOD + src.DuLieuNguonNuocThaiTrongCay!.LtTrongCayCOD + src.DuLieuNguonNuocThaiTrongLua!.LtTrongLuaCOD
                + src.DuLieuNguonNuocThaiTrongRung!.LtTrongRungCOD + src.DuLieuNguonNuocThaiThuySan!.LtThuySanCOD))

                .ForMember(dest => dest.LtAmoni, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiem != null ? src.DuLieuNguonNuocThaiDiem.LtdiemAmoni : 0)
                + src.DuLieuNguonNuocThaiSinhHoat!.LtSinhHoatAmoni + src.DuLieuNguonNuocThaiGiaCam!.LtGiaCamAmoni + src.DuLieuNguonNuocThaiLon!.LtLonAmoni
                + src.DuLieuNguonNuocThaiTrauBo!.LtTrauBoAmoni + src.DuLieuNguonNuocThaiTrongCay!.LtTrongCayAmoni + src.DuLieuNguonNuocThaiTrongLua!.LtTrongLuaAmoni
                + src.DuLieuNguonNuocThaiTrongRung!.LtTrongRungAmoni + src.DuLieuNguonNuocThaiThuySan!.LtThuySanAmoni))

                .ForMember(dest => dest.LtTongN, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiem != null ? src.DuLieuNguonNuocThaiDiem.LtdiemTongN : 0)
                + src.DuLieuNguonNuocThaiSinhHoat!.LtSinhHoatTongN + src.DuLieuNguonNuocThaiGiaCam!.LtGiaCamTongN + src.DuLieuNguonNuocThaiLon!.LtLonTongN
                + src.DuLieuNguonNuocThaiTrauBo!.LtTrauBoTongN + src.DuLieuNguonNuocThaiTrongCay!.LtTrongCayTongN + src.DuLieuNguonNuocThaiTrongLua!.LtTrongLuaTongN
                + src.DuLieuNguonNuocThaiTrongRung!.LtTrongRungTongN + src.DuLieuNguonNuocThaiThuySan!.LtThuySanTongN))

                .ForMember(dest => dest.LtTongP, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiem != null ? src.DuLieuNguonNuocThaiDiem.LtdiemTongP : 0)
                + src.DuLieuNguonNuocThaiSinhHoat!.LtSinhHoatTongP + src.DuLieuNguonNuocThaiGiaCam!.LtGiaCamTongP + src.DuLieuNguonNuocThaiLon!.LtLonTongP
                + src.DuLieuNguonNuocThaiTrauBo!.LtTrauBoTongP + src.DuLieuNguonNuocThaiTrongCay!.LtTrongCayTongP + src.DuLieuNguonNuocThaiTrongLua!.LtTrongLuaTongP
                + src.DuLieuNguonNuocThaiTrongRung!.LtTrongRungTongP + src.DuLieuNguonNuocThaiThuySan!.LtThuySanTongP))

                .ForMember(dest => dest.LtTSS, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiem != null ? src.DuLieuNguonNuocThaiDiem.LtdiemTSS : 0)
                + src.DuLieuNguonNuocThaiSinhHoat!.LtSinhHoatTSS + src.DuLieuNguonNuocThaiGiaCam!.LtGiaCamTSS + src.DuLieuNguonNuocThaiLon!.LtLonTSS
                + src.DuLieuNguonNuocThaiTrauBo!.LtTrauBoTSS + src.DuLieuNguonNuocThaiTrongCay!.LtTrongCayTSS + src.DuLieuNguonNuocThaiTrongLua!.LtTrongLuaTSS
                + src.DuLieuNguonNuocThaiTrongRung!.LtTrongRungTSS + src.DuLieuNguonNuocThaiThuySan!.LtThuySanTSS))

                .ForMember(dest => dest.LtColiform, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiem != null ? src.DuLieuNguonNuocThaiDiem.LtdiemColiform : 0)
                + src.DuLieuNguonNuocThaiSinhHoat!.LtSinhHoatColiform + src.DuLieuNguonNuocThaiGiaCam!.LtGiaCamColiform + src.DuLieuNguonNuocThaiLon!.LtLonColiform
                + src.DuLieuNguonNuocThaiTrauBo!.LtTrauBoColiform + src.DuLieuNguonNuocThaiTrongCay!.LtTrongCayColiform + src.DuLieuNguonNuocThaiTrongLua!.LtTrongLuaColiform
                + src.DuLieuNguonNuocThaiTrongRung!.LtTrongRungColiform + src.DuLieuNguonNuocThaiThuySan!.LtThuySanColiform))

                //ltd
                .ForMember(dest => dest.LtnBod, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LtdBOD : 0) - (src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LnnBOD : 0) - dest.LtBod) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnCod, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LtdCOD : 0) - (src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LnnCOD : 0) - dest.LtCod) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnAmoni, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LtdAmoni : 0) - (src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LnnAmoni : 0) - dest.LtAmoni) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnTongN, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LtdTongN : 0) - (src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LnnTongN : 0) - dest.LtTongN) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnTongP, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LtdTongP : 0) - (src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LnnTongP : 0) - dest.LtTongP) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnTSS, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LtdTSS : 0) - (src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LnnTSS : 0) - dest.LtTSS) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnColiform, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LtdColiform : 0) - (src.DuLieuNguonNuocNhan != null ? src.DuLieuNguonNuocNhan.LnnColiform : 0) - dest.LtColiform) * dest.HeSoFS)))

                //dubao
                //bod
                .ForMember(dest => dest.LtBodDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemBODDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatBODDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamBODDB
                + src.DuLieuNguonNuocThaiLonDB!.LtLonBODDB + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoBODDB
                + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayBODDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaBODDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungBODDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanBODDB))

                .ForMember(dest => dest.LtCodDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemCODDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatCODDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamCODDB + src.DuLieuNguonNuocThaiLonDB!.LtLonCODDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoCODDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayCODDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaCODDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungCODDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanCODDB))

                .ForMember(dest => dest.LtAmoniDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemAmoniDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatAmoniDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamAmoniDB + src.DuLieuNguonNuocThaiLonDB!.LtLonAmoniDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoAmoniDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayAmoniDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaAmoniDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungAmoniDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanAmoniDB))

                .ForMember(dest => dest.LtTongNDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemTongNDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatTongNDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamTongNDB + src.DuLieuNguonNuocThaiLonDB!.LtLonTongNDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoTongNDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayTongNDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaTongNDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungTongNDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanTongNDB))

                .ForMember(dest => dest.LtTongPDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemTongPDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatTongPDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamTongPDB + src.DuLieuNguonNuocThaiLonDB!.LtLonTongPDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoTongPDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayTongPDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaTongPDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungTongPDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanTongPDB))

                .ForMember(dest => dest.LtTSSDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemTSSDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatTSSDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamTSSDB + src.DuLieuNguonNuocThaiLonDB!.LtLonTSSDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoTSSDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayTSSDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaTSSDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungTSSDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanTSSDB))

                .ForMember(dest => dest.LtColiformDB, opt => opt.MapFrom(src => (src.DuLieuNguonNuocThaiDiemDB != null ? src.DuLieuNguonNuocThaiDiemDB.LtdiemColiformDB : 0)
                + src.DuLieuNguonNuocThaiSinhHoatDB!.LtSinhHoatColiformDB + src.DuLieuNguonNuocThaiGiaCamDB!.LtGiaCamColiformDB + src.DuLieuNguonNuocThaiLonDB!.LtLonColiformDB
                + src.DuLieuNguonNuocThaiTrauBoDB!.LtTrauBoColiformDB + src.DuLieuNguonNuocThaiTrongCayDB!.LtTrongCayColiformDB + src.DuLieuNguonNuocThaiTrongLuaDB!.LtTrongLuaColiformDB
                + src.DuLieuNguonNuocThaiTrongRungDB!.LtTrongRungColiformDB + src.DuLieuNguonNuocThaiThuySanDB!.LtThuySanColiformDB))

                //ltd
                .ForMember(dest => dest.LtnBodDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdBODDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnBODDB : 0) - dest.LtBodDB) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnCodDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdCODDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnCODDB : 0) - dest.LtCodDB) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnAmoniDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdAmoniDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnAmoniDB : 0) - dest.LtAmoniDB) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnTongNDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdTongNDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnTongNDB : 0) - dest.LtTongNDB) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnTongPDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdTongPDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnTongPDB : 0) - dest.LtTongPDB) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnTSSDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdTSSDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnTSSDB : 0) - dest.LtTSSDB) * dest.HeSoFS)))
                .ForMember(dest => dest.LtnColiformDB, opt => opt.MapFrom((src, dest) => (((src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LtdColiformDB : 0) - (src.DuLieuNguonNuocNhanDB != null ? src.DuLieuNguonNuocNhanDB.LnnColiformDB : 0) - dest.LtColiformDB) * dest.HeSoFS)))

            .ReverseMap();

            //mtn

            CreateMap<ThongTinAoHo, ThongTinAoHoDto>().ReverseMap();

            //KNTNNuocThaiHo
            CreateMap<KhaNangTiepNhanNuocHo, KhaNangTiepNhanNuocHoDto>().ReverseMap();
            //dubaokhanangtiepnhanaoho
            CreateMap<ThongSoCLNDuBao, ThongSoCLNDuBaoDto>().ReverseMap();
            CreateMap<DuBaoKhaNangTiepNhanNuocHo, DuBaoKhaNangTiepNhanNuocHoDto>().ReverseMap();


            //diem quan trac
            CreateMap<DiemQuanTrac, DiemQuanTracDto>().ReverseMap();

            CreateMap<ThongSoDiemQuanTrac, ThongSoDiemQuanTracDto>()
                       .ForMember(dest => dest.DiemQuanTrac, opt => opt.MapFrom(src => src.DiemQuanTrac)).ReverseMap();
            //KiemKeTaiNguyenNuoc
            //tong hop chi tieu
            CreateMap<ChiTieuLVSTraKhuc, ChiTieuLVSTraKhucDto>().ReverseMap();
            CreateMap<Tram_ThongTin, Tram_ThongTinDto>()
                        .ForMember(dest => dest.tongluong_nuocmua, opt => opt.MapFrom(src => src.KKTNN_NuocMua_TongLuong))
                        .ForMember(dest => dest.huyen, opt => opt.MapFrom(src => src.Huyen))
                        .ForMember(dest => dest.xa, opt => opt.MapFrom(src => src.Xa))
                        .ReverseMap();
            CreateMap<KKTNN_NuocMua_TongLuong, KKTNN_NuocMua_TongLuongDto>().ReverseMap();
            CreateMap<KKTNN_NuocMat_SoLuong_SongSuoi, KKTNN_NuocMat_SoLuong_SongSuoiDto>().ReverseMap();

            CreateMap<KKTNN_NuocMat_SoLuong_AoHoDamPha, KKTNN_NuocMat_SoLuong_AoHoDamPhaDto>().ReverseMap();

            CreateMap<CT_ThongTin, KKTNN_NuocMat_KhaiThacSuDungDto>()
                 .ForMember(dest => dest.ten_ct, opt => opt.MapFrom(src => src.TenCT))
                 .ForMember(dest => dest.loai_ct, opt => opt.MapFrom(src => src.LoaiCT!.TenLoaiCT))
                 .ForMember(dest => dest.nguonnuoc_kt, opt => opt.MapFrom(src => src.NguonNuocKT))
                 .ForMember(dest => dest.dungtich_ho, opt => opt.MapFrom(src => src.ThongSo!.DungTichToanBo))
                 .ForMember(dest => dest.congsuat, opt => opt.MapFrom(src => src.ThongSo!.CongSuatLM))
                 .ForMember(dest => dest.lv_song, opt => opt.MapFrom(src => src.LuuVuc!.TenLVS))
                 .ForMember(dest => dest.huyen, opt => opt.MapFrom(src => src.CT_ViTri!.Where(v => v.Huyen != null)
                    .Select(v => v.Huyen).GroupBy(h => h!.IdHuyen).Select(g => g.First()).ToList()))
                 .ForMember(dest => dest.xa, opt => opt.MapFrom(src => src.CT_ViTri!.Select(v => v.Xa).ToList()))
                 .ForMember(dest => dest.mucdich_kt, opt => opt.MapFrom(src => src.LuuLuongTheoMucDich != null
                     ? string.Join(", ", src.LuuLuongTheoMucDich
                         .Where(l => l.MucDichKT != null && l.DaXoa == false)
                         .Select(l => l.MucDichKT!.MucDich)
                         .Distinct())
                     : string.Empty))
                 .ForMember(dest => dest.q_kt_tuoi, opt => opt.MapFrom(src => src.LuuLuongTheoMucDich!
                     .Where(lld => lld.IdCT == src.Id && lld.MucDichKT!.MucDich!.ToLower().Contains("tưới") && lld.DaXoa == false)
                     .ToList()
                     .Sum(x => x.DonViDo == "m3/ngày đêm" ? x.LuuLuong ?? 0 * 86400 : x.LuuLuong ?? 0)))
                 .ForMember(dest => dest.q_kt_kddv_sx_phi_nn, opt => opt.MapFrom(src => src.LuuLuongTheoMucDich!
                     .Where(lld => lld.IdCT == src.Id &&
                        lld.MucDichKT!.MucDich!.ToLower().Contains("kinh doanh, dịch vụ") ||
                        lld.MucDichKT!.MucDich!.ToLower().Contains("sản xuất") && lld.DaXoa == false)
                     .ToList()
                     .Sum(x => x.DonViDo == "m3/ngày đêm" ? x.LuuLuong ?? 0 * 86400 : x.LuuLuong ?? 0)))
                 .ForMember(dest => dest.mucdich_khac, opt => opt.MapFrom(src => src.LuuLuongTheoMucDich!
                     .Where(lld => lld.IdCT == src.Id &&
                         !lld.MucDichKT!.MucDich!.ToLower().Contains("kinh doanh, dịch vụ") ||
                         !lld.MucDichKT!.MucDich!.ToLower().Contains("sản xuất") ||
                         !lld.MucDichKT!.MucDich!.ToLower().Contains("tưới") &&
                         lld.DaXoa == false)
                     .ToList()
                     .Sum(x => x.DonViDo == "m3/ngày đêm" ? x.LuuLuong ?? 0 * 86400 : x.LuuLuong ?? 0)))
                 .ReverseMap();




            CreateMap<CT_ThongTin, GS_SoLieuDto>()
                        .ForMember(dest => dest.loaiCT, opt => opt.MapFrom(src => src.LoaiCT))
                         .ForMember(dest => dest.thongso, opt => opt.MapFrom(src => src.ThongSo))
                        .ReverseMap();

            CreateMap<KKTNN_NuocMat_TongLuong, KKTNN_NuocMat_TongLuongDto>()
                        .ForMember(dest => dest.LuuVucSong, opt => opt.MapFrom(src => src.LuuVucSong))
                        //.ForMember(dest => dest.donvi_hanhchinh, opt => opt.MapFrom((src, dest) => dest.donvi_hanhchinh))
                        .ReverseMap();

            CreateMap<KKTNN_NuocMat_ChatLuong, KKTNN_NuocMat_ChatLuongDto>().ReverseMap();
            CreateMap<KKTNN_NuocDuoiDat_SoLuong, KKTNN_NuocDuoiDat_SoLuongDto>()
                       .ForMember(dest => dest.TangChuaNuoc, opt => opt.MapFrom(src => src.TangChuaNuoc))
                       .ReverseMap();
            CreateMap<KKTNN_NuocDuoiDat_TongLuong, KKTNN_NuocDuoiDat_TongLuongDto>()
                      .ForMember(dest => dest.TangChuaNuoc, opt => opt.MapFrom(src => src.TangChuaNuoc))
                      .ReverseMap();
            CreateMap<LuuVucSong, KKTNN_NuocDuoiDat_ChatLuongDto>()
                       .ForMember(dest => dest.donvi_hanhchinh, opt => opt.MapFrom((src, dest) => dest.donvi_hanhchinh))
                       .ReverseMap();
            //Song
            CreateMap<Song, SongDto>().ReverseMap();

            //LuuVucSong
            CreateMap<LuuVucSong, LuuVucSongDto>().ReverseMap();

            //TangChuaNuoc
            CreateMap<TangChuaNuoc, TangChuaNuocDto>().ReverseMap();

            //ThongTinDuLieu
            CreateMap<NN_LuuVucSong, NN_LuuVucSongDto>().ReverseMap();
            CreateMap<NN_NguonNuoc_SongSuoi, NN_NguonNuoc_SongSuoiDto>().ReverseMap();
            CreateMap<NN_NguonNuoc_AoHoDamPha, NN_NguonNuoc_AoHoDamPhaDto>().ReverseMap();
            CreateMap<NN_NguonNuoc_TangChuaNuoc, NN_NguonNuoc_TangChuaNuocDto>().ReverseMap();
            CreateMap<NN_AoHoDamPhaKhongDuocSanLap, NN_AoHoDamPhaKhongDuocSanLapDto>().ReverseMap();
            CreateMap<NN_HanhLangBaoVeNN_SongSuoi, NN_HanhLangBaoVeNN_SongSuoiDto>().ReverseMap();
            CreateMap<NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3, NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3Dto>().ReverseMap();
            CreateMap<NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3, NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Dto>().ReverseMap();
            CreateMap<NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTao, NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoDto>().ReverseMap();
            CreateMap<NN_CNNN_SongSuoi, NN_CNNN_SongSuoiDto>().ReverseMap();
            CreateMap<NN_CNNN_Ho, NN_CNNN_HoDto>().ReverseMap();
            CreateMap<NN_CNNN_TangChuaNuoc, NN_CNNN_TangChuaNuocDto>().ReverseMap();
            CreateMap<NN_DCTT_SongSuoi, NN_DCTT_SongSuoiDto>().ReverseMap();
            CreateMap<NN_DCTT_HaDuHoChua, NN_DCTT_HaDuHoChuaDto>().ReverseMap();
            CreateMap<NN_NguongKhaiThacNDD, NN_NguongKhaiThacNDDDto>().ReverseMap();
            CreateMap<NN_VungCamHanCheKTNDD, NN_VungCamHanCheKTNDDDto>().ReverseMap();
            CreateMap<NN_MatCatSongSuoi, NN_MatCatSongSuoiDto>().ReverseMap();

            CreateMap<SLN_TongLuongNuocMat, SLN_TongLuongNuocMatDto>().ReverseMap();
            CreateMap<CLN_NuocMat, CLN_NuocMatDto>().ReverseMap();
            CreateMap<CLN_NDD, CLN_NDDDto>().ReverseMap();

            CreateMap<SLDTKTSDN_NuocMat, SLDTKTSDN_NuocMatDto>().ReverseMap();
            CreateMap<SLDTKTSDN_NDD, SLDTKTSDN_NDDDto>().ReverseMap();
            CreateMap<SLDTKTSDN_XaThai, SLDTKTSDN_XaThaiDto>().ReverseMap();

            CreateMap<CTKTSDN_PCGP_NDD, CTKTSDN_PCGP_NDDDto>().ReverseMap();
            CreateMap<CTKTSDN_PCGP_NuocBien, CTKTSDN_PCGP_NuocBienDto>().ReverseMap();
            CreateMap<CTKTSDN_PCGP_NuocMat, CTKTSDN_PCGP_NuocMatDto>().ReverseMap();
            CreateMap<CTKTSDN_PDK_NDD, CTKTSDN_PDK_NDDDto>().ReverseMap();
            CreateMap<CTKTSDN_PDK_NuocBien, CTKTSDN_PDK_NuocBienDto>().ReverseMap();
            CreateMap<CTKTSDN_PDK_NuocMat, CTKTSDN_PDK_NuocMatDto>().ReverseMap();
            CreateMap<CTKTSDN_KTNDDCuaHoGD, CTKTSDN_KTNDDCuaHoGDDto>().ReverseMap();

            CreateMap<HSKTT_NuocMat, HSKTT_NuocMatDto>().ReverseMap();
            CreateMap<HSKTT_NDD, HSKTT_NDDDto>().ReverseMap();

            CreateMap<DanhMucNN_LienTinh, DanhMucNN_LienTinhDto>().ReverseMap();
            CreateMap<DanhMucNN_NoiTinh_AoHo, DanhMucNN_NoiTinh_AoHoDto>().ReverseMap();
            CreateMap<DanhMucNN_NoiTinh_SongSuoi, DanhMucNN_NoiTinh_SongSuoiDto>().ReverseMap();

            CreateMap<CLN_NuocMat, CLN_NuocMatDto>().ReverseMap();

            //VanHanhHoChua
            CreateMap<VHHC_LuuVucSong, VHHC_LuuVucSongDto>().ReverseMap();
            CreateMap<VHHC_HoChua_ThongSoKT, VHHC_HoChua_ThongSoKTDto>()
                .ForMember(dest => dest.CT_ThongTin, opt => opt.MapFrom((src) => src.CT_ThongTin))
                .ReverseMap();
            CreateMap<MuaHienTai, MuaHienTaiDto>().ReverseMap();
            CreateMap<HTTT, HTTTDto>().ReverseMap();


            //demo
            CreateMap<Demo, DemoDto>().ReverseMap();

            //TramQuangNgai
            CreateMap<Tram_ThongTin, DuLieuTramDto>()
                       .ForMember(dest => dest.TenTram, opt => opt.MapFrom(src => src.TenTram))
                       .ForMember(dest => dest.X, opt => opt.MapFrom(src => src.X))
                       .ForMember(dest => dest.Y, opt => opt.MapFrom(src => src.Y))
                       .ForMember(dest => dest.ThoiGian, opt => opt.MapFrom(src => src.DuLieuTram!.Max(d => d.ThoiGian)))
                       .ForMember(dest => dest.LuongMua, opt => opt.MapFrom(src => src.DuLieuTram!.Max(d => d.LuongMua)))
                       .ForMember(dest => dest.NhietDo, opt => opt.MapFrom(src => src.DuLieuTram!.Max(d => d.NhietDo)))
                       .ForMember(dest => dest.DoAm, opt => opt.MapFrom(src => src.DuLieuTram!.Max(d => d.DoAm)))
                       .ForMember(dest => dest.HuongGio, opt => opt.MapFrom(src => src.DuLieuTram!.Max(d => d.HuongGio)))
                       .ForMember(dest => dest.TocDoGio, opt => opt.MapFrom(src => src.DuLieuTram!.Max(d => d.TocDoGio)))
                       .ReverseMap();
            CreateMap<DuLieuTram, DuLieuTramDto>().ReverseMap();

            //truyendulieuquantrac
            CreateMap<StoragePreData, StoragePreDataDto>().ReverseMap();
            CreateMap<DataTransmissionAccounts, DataTransmissionAccountsDto>().ReverseMap();

            //CreateMap<CT_ThongTin, GS_SoLieuDto>()
            //            .ForMember(dest => dest.loaiCT, opt => opt.MapFrom(src => src.LoaiCT))
            //             .ForMember(dest => dest.thongso, opt => opt.MapFrom(src => src.ThongSo))
            //            .ReverseMap();

            //vanhanhhochua
            CreateMap<DuLieuLuuVucLHC, DuLieuLuuVucLHCDto>().ReverseMap();
        }
    }
}
