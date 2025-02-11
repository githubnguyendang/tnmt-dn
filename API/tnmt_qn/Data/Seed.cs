using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace tnmt_qn.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(DatabaseContext context, UserManager<AspNetUsers> userManager, RoleManager<AspNetRoles> roleManager)
        {
            // Ensure the database is created and apply migrations
            context.Database.EnsureCreated();

            // Check if there is any data in the database
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations == null || !pendingMigrations.Any())
            {
                await SeedRolesAsync(roleManager);
                await SeedUsersAsync(userManager);
                await SeedFunctionsAsync(context);
                //await SeedCT_LoaiAsync(context);
                //await SeedMucDichKTAsync(context);
                await SeedGP_LoaiAsync(context);
                await SeedDonViDoAsync(context);
                //await SeedTangChuaNuocAsync(context);

            }
        }

        private static async Task SeedRolesAsync(RoleManager<AspNetRoles> roleManager)
        {
            if (!await roleManager.Roles.AnyAsync())
            {
                await roleManager.CreateAsync(new AspNetRoles { Name = "Administrator", IsDeleted = false });
                await roleManager.CreateAsync(new AspNetRoles { Name = "Default", IsDefault = true, IsDeleted = false });
            }
        }

        private static async Task SeedUsersAsync(UserManager<AspNetUsers> userManager)
        {
            if (!await userManager.Users.AnyAsync())
            {
                var admin = new AspNetUsers { UserName = "admin", IsDeleted = false };
                await userManager.CreateAsync(admin, "quantri@175");
                await userManager.AddToRoleAsync(admin, "Administrator");
            }
        }

        private static async Task SeedFunctionsAsync(DatabaseContext context)
        {
            if (!await context.Functions!.AnyAsync())
            {
                context.Functions!.AddRange(
                    new Functions { PermitName = "View", PermitCode = "VIEW" },
                    new Functions { PermitName = "Create", PermitCode = "CREATE" },
                    new Functions { PermitName = "Edit", PermitCode = "EDIT" },
                    new Functions { PermitName = "Delete", PermitCode = "DELETE" });

                await context.SaveChangesAsync();
            }
        }

        //private static async Task SeedCT_LoaiAsync(DatabaseContext context)
        //{
        //    if (!await context.CT_Loai!.AnyAsync())
        //    {
        //        context.CT_Loai!.AddRange(
        //            new CT_Loai { IdCha = 0, TenLoaiCT = "NƯỚC MẶT", MaLoaiCT = "nuocmat", DaXoa = false },
        //            new CT_Loai { IdCha = 0, TenLoaiCT = "NƯỚC DƯỚI ĐẤT", MaLoaiCT = "nuocduoidat", DaXoa = false },
        //            new CT_Loai { IdCha = 0, TenLoaiCT = "XẢ THẢI VÀO NGUỒN NƯỚC", MaLoaiCT = "xathai", DaXoa = false },
        //            new CT_Loai { IdCha = 1, TenLoaiCT = "Thủy điện", MaLoaiCT = "thuydien", DaXoa = false },
        //            new CT_Loai { IdCha = 1, TenLoaiCT = "Hồ chứa", MaLoaiCT = "hochua", DaXoa = false },
        //            new CT_Loai { IdCha = 1, TenLoaiCT = "Trạm bơm", MaLoaiCT = "trambom", DaXoa = false },
        //            new CT_Loai { IdCha = 2, TenLoaiCT = "Khai thác", MaLoaiCT = "khaithac", DaXoa = false },
        //            new CT_Loai { IdCha = 2, TenLoaiCT = "Thăm dò", MaLoaiCT = "thamdo", DaXoa = false },
        //            new CT_Loai { IdCha = 2, TenLoaiCT = "Hành nghề khoan", MaLoaiCT = "hanhnghekhoan", DaXoa = false },
        //            new CT_Loai { IdCha = 1, TenLoaiCT = "Trạm cấp nước", MaLoaiCT = "tramcapnuoc", DaXoa = false },
        //            new CT_Loai { IdCha = 1, TenLoaiCT = "Đập / Hệ thống thuỷ lợi", MaLoaiCT = "dap_httl", DaXoa = false },
        //            new CT_Loai { IdCha = 1, TenLoaiCT = "Cống lấy nước", MaLoaiCT = "cong", DaXoa = false },
        //            new CT_Loai { IdCha = 1, TenLoaiCT = "Nhà máy nước", MaLoaiCT = "nhamaynuoc", DaXoa = false },
        //            new CT_Loai { IdCha = 1, TenLoaiCT = "Công trình khác", MaLoaiCT = "congtrinhkhac_nm", DaXoa = false },
        //            new CT_Loai { IdCha = 2, TenLoaiCT = "Công trình khác", MaLoaiCT = "congtrinhkhac_ndd", DaXoa = false },
        //            new CT_Loai { IdCha = 3, TenLoaiCT = "Khu / cụm CN tập chung", MaLoaiCT = "kh_cumcn_taptrung", DaXoa = false },
        //            new CT_Loai { IdCha = 3, TenLoaiCT = "SX tiểu thủ CN", MaLoaiCT = "sx_tieuthu_cn", DaXoa = false },
        //            new CT_Loai { IdCha = 3, TenLoaiCT = "SX KD dịch vụ", MaLoaiCT = "sx_kd_dichvu", DaXoa = false },
        //            new CT_Loai { IdCha = 3, TenLoaiCT = "CS bệnh viện", MaLoaiCT = "cs_benhvien", DaXoa = false },
        //            new CT_Loai { IdCha = 3, TenLoaiCT = "Khu dân cư / Làng nghề", MaLoaiCT = "khudancu_langnghe", DaXoa = false },
        //            new CT_Loai { IdCha = 3, TenLoaiCT = "Chăn nuôi / NTTS", MaLoaiCT = "channuoi_ntts", DaXoa = false },
        //            new CT_Loai { IdCha = 3, TenLoaiCT = "Công trình khác", MaLoaiCT = "congtrinhkhac_xt", DaXoa = false },
        //            new CT_Loai { IdCha = 2, TenLoaiCT = "Trám lấp giếng", MaLoaiCT = "tramlapgieng    ", DaXoa = false },
        //            new CT_Loai { IdCha = 0, TenLoaiCT = "NƯỚC BIỂN", MaLoaiCT = "nuocbien", DaXoa = false },
        //            new CT_Loai { IdCha = 24, TenLoaiCT = "Khai thác", MaLoaiCT = "khaithac_nuocbien", DaXoa = false });

        //        await context.SaveChangesAsync();
        //    }
        //}

        //private static async Task SeedTangChuaNuocAsync(DatabaseContext context)
        //{
        //    if (!await context.TangChuaNuoc!.AnyAsync())
        //    {
        //        context.TangChuaNuoc!.AddRange(
        //            new TangChuaNuoc { TenTCN = "Mạch lộ tầng chứa nước Holocen", KyHieuTCN = "qh", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Mạch lộ tầng chứa nước Pleistocen", KyHieuTCN = "qp", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng cát, cuội, sỏi alQiv Holocen", KyHieuTCN = "qh", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng Holocen", KyHieuTCN = "qh", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Khe nứt Holocen", KyHieuTCN = "qh", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng chứa nước đá gốc granit nứt nẻ", KyHieuTCN = "NULL", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng chứa nước lỗ hổng Holocen", KyHieuTCN = "qh", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng chứa nước Holocen", KyHieuTCN = "NULL", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng chứa nước khe nứt", KyHieuTCN = "Bq", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng chứa nước Pleistocen", KyHieuTCN = "NULL", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Phun trào Bazan", KyHieuTCN = "bQ2", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Pleistocen", KyHieuTCN = "qp", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Pleistocen", KyHieuTCN = "NULL", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Khe nứt - lỗ hổng", KyHieuTCN = "Bqp", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Phun trào Bazan", KyHieuTCN = "bQ1", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Khe nứt các thành tạo bazan tuổi Miocen sơm hệ tầng Đại Nga", KyHieuTCN = "n", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Các thành tạo cát kết, bột kết tuổi Jura sớm hệ tầng Bình Sơn", KyHieuTCN = "j", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng chứa nước lỗ hổng các thành tạo bồi tích biến Holocen trung", KyHieuTCN = "qh", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng chứa nước lỗ hổng Pleistocen", KyHieuTCN = "qp", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng chứa nước lỗ hổng các thành tạo bồi tích sông (aQ23 và aQ13 ), tuổi Holocen (qh) và Pleistocen (qp)", KyHieuTCN = "NULL", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng chứa nước lỗ hổng các thành tạo bồi tích thềm sông (aQ), tuổi Đệ tứ không phân chia (q)", KyHieuTCN = "NULL", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Khe nứt Mesoproterozoi", KyHieuTCN = "mp", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Khe nứt - lỗ hổng bazan", KyHieuTCN = "bQ", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Khe nứt thành tạo phun trào bazan Pliocen- Pleistocen dưới B(N2-Q1), bazan Plicocen BN2đn", KyHieuTCN = "NULL", DaXoa = false },
        //            new TangChuaNuoc { TenTCN = "Tầng chứa nước Pleistocen thượng", KyHieuTCN = "qp", DaXoa = false }
        //            );

        //        await context.SaveChangesAsync();
        //    }
        //}

        //private static async Task SeedMucDichKTAsync(DatabaseContext context)
        //{
        //    if (!await context.MucDichKT!.AnyAsync())
        //    {
        //        context.MucDichKT!.AddRange(
        //            new MucDichKT { MucDich = "Khai thác nước dùng cho sản xuất thủy điện", DaXoa = false },
        //            new MucDichKT { MucDich = "Khai thác nước dùng cho kinh doanh, dịch vụ", DaXoa = false },
        //            new MucDichKT { MucDich = "Khai thác nước dùng cho sản xuất phi nông nghiệp", DaXoa = false },
        //            new MucDichKT { MucDich = "Khai thác nước dưới đất dùng cho tưới", DaXoa = false },
        //            new MucDichKT { MucDich = "Khai thác nước dưới đất dùng cho nuôi trồng thủy sản, chăn nuôi gia súc", DaXoa = false });

        //        await context.SaveChangesAsync();
        //    }
        //}

        private static async Task SeedGP_LoaiAsync(DatabaseContext context)
        {
            if (!await context.GP_Loai!.AnyAsync())
            {
                context.GP_Loai!.AddRange(
                    new GP_Loai { TenLoaiGP = "Cấp mới giấy phép", MaLoaiGP = "cap-moi", DaXoa = false },
                    new GP_Loai { TenLoaiGP = "Cấp lại giấy phép", MaLoaiGP = "cap-lai", DaXoa = false },
                    new GP_Loai { TenLoaiGP = "Gia hạn giấy phép", MaLoaiGP = "gia-han", DaXoa = false },
                    new GP_Loai { TenLoaiGP = "Điều chỉnh giấy phép", MaLoaiGP = "dieu-chinh", DaXoa = false },
                    new GP_Loai { TenLoaiGP = "Thu hồi giấy phép", MaLoaiGP = "thu-hoi", DaXoa = false });

                await context.SaveChangesAsync();
            }
        }
        private static async Task SeedDonViDoAsync(DatabaseContext context)
        {
            if (!await context.DonViDo!.AnyAsync())
            {
                context.DonViDo!.AddRange(
                    new DonViDo { Ten = "Độ C" },
                    new DonViDo { Ten = "Pt/Co" },
                    new DonViDo { Ten = "mg/l" },
                    new DonViDo { Ten = "Vi khuẩn/100ml" },
                    new DonViDo { Ten = "Bq/l" },
                    new DonViDo { Ten = "mm" },
                    new DonViDo { Ten = "m" },
                    new DonViDo { Ten = "m3/s" },
                    new DonViDo { Ten = "m3/ngày đêm" },
                    new DonViDo { Ten = "MPN hoặc CFU/100ml" },
                    new DonViDo { Ten = "MPN/100ml" },
                    new DonViDo { Ten = "pgTEQ /l" },
                    new DonViDo { Ten = "ug/l" },
                    new DonViDo { Ten = "µg/l" },
                    new DonViDo { Ten = "Không có đơn vị đo" }
                    );
                await context.SaveChangesAsync();
            }
        }
    }
}