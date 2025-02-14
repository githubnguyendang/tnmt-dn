using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using tnmt_qn.Data;
using tnmt_qn.Service;
using tnmt_qn.Service.BaoCaoBieuMau;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Register the DatabaseContext with the dependency injection container
services.AddDbContext<DatabaseContext>();

services.AddAutoMapper(typeof(Program));

services.AddScoped<IAuthService, AuthService>();
services.AddScoped<UserService>();
services.AddScoped<RoleService>();
services.AddScoped<DashboardService>();
services.AddScoped<RoleDashboardService>();
services.AddScoped<UserDashboardService>();
services.AddScoped<PermissionService>();

//Other Service
services.AddScoped<TestService, TestService>();
//LogChange
services.AddScoped<ILogChangeService, LogChangeService>();

services.AddScoped<ICT_ThongTinService, CT_ThongTinService>();
services.AddScoped<CT_ThongSoService>();
services.AddScoped<CT_LoaiService>();
services.AddScoped<CT_HangMucService>();
services.AddScoped<LuuLuongTheoMucDichService>();
services.AddScoped<MucDichKTService>();

services.AddScoped<IGP_ThongTinService, GP_ThongTinService>();
services.AddScoped<GP_LoaiService>();
services.AddScoped<IGP_TCQService, GP_TCQService>();
services.AddScoped<ITCQ_ThongTinService, TCQ_ThongTinService>();

services.AddScoped<TangChuaNuocService>();
services.AddScoped<IToChucCaNhanService, ToChucCaNhanService>();

services.AddScoped<IThanhTraKiemTraService, ThanhTraKiemTraService>();

services.AddScoped<SongService>();
services.AddScoped<LuuVucSongService>();
services.AddScoped<TieuVungLuuVucService>();
services.AddScoped<DonViHCService>();
services.AddScoped<DonViDoService>();

services.AddScoped<BieuMauMotService>();
services.AddScoped<BieuMauHaiService>();
services.AddScoped<BieuMauBaService>();
services.AddScoped<BieuMauBonService>();
services.AddScoped<BieuMauNamService>();
services.AddScoped<BieuMauSauService>();
services.AddScoped<BieuMauBayService>();
services.AddScoped<BieuMauTamService>();
services.AddScoped<BieuMauChinService>();
services.AddScoped<BieuMauMuoiService>();
services.AddScoped<BieuMauMuoiMotService>();
services.AddScoped<BieuMauMuoiHaiService>();
services.AddScoped<BieuMauMuoiBaService>();
services.AddScoped<BieuMauMuoiBonService>();
services.AddScoped<BieuMauMuoiLamService>();
services.AddScoped<BieuMauMuoiSauService>();
services.AddScoped<BieuMauMuoiBayService>();
services.AddScoped<BieuMauMuoiTamService>();
services.AddScoped<BieuMauMuoiChinService>();
services.AddScoped<BieuMauHaiMuoiService>();
services.AddScoped<BieuMauHaiMotService>();
services.AddScoped<BieuMauHaiHaiService>();
services.AddScoped<BieuMauHaiBaService>();
services.AddScoped<BieuMauHaiTuService>();
services.AddScoped<BieuMauHaiLamService>();
services.AddScoped<GiamSatService>();

//khannangtiepnhannuocthai
services.AddScoped<ThongSoCLNSongService>();
services.AddScoped<ThongSoCLNAoService>();
services.AddScoped<DoanSongService>();
services.AddScoped<DuLieuNguonNuocNhanService>();
services.AddScoped<DuLieuNguonNuocThaiDiemService>();
services.AddScoped<DuLieuNguonNuocThaiSinhHoatService>();
services.AddScoped<DuLieuNguonNuocThaiTrauBoService>();
services.AddScoped<DuLieuNguonNuocThaiLonService>();
services.AddScoped<DuLieuNguonNuocThaiGiaCamService>();
services.AddScoped<DuLieuNguonNuocThaiTrongLuaService>();
services.AddScoped<DuLieuNguonNuocThaiTrongCayService>();
services.AddScoped<DuLieuNguonNuocThaiTrongRungService>();
services.AddScoped<DuLieuNguonNuocThaiThuySanService>();
services.AddScoped<PhanDoanSongService>();
services.AddScoped<ThongTinAoHoService>();
services.AddScoped<KhaNangTiepNhanNuocHoService>();
services.AddScoped<NguonThaiDiemService>();
services.AddScoped<DiemQuanTracService>();
services.AddScoped<ThongSoDiemQuanTracService>();
services.AddScoped<DuBaoKhaNangTiepNhanNuocHoService>();
services.AddScoped<ThongSoCLNDuBaoService>();

//dubao
services.AddScoped<DuLieuNguonNuocNhanDBService>();
services.AddScoped<DuLieuNguonNuocNhanDBService>();
services.AddScoped<DuLieuNguonNuocThaiDiemDBService>();
services.AddScoped<DuLieuNguonNuocThaiSinhHoatDBService>();
services.AddScoped<DuLieuNguonNuocThaiTrauBoDBService>();
services.AddScoped<DuLieuNguonNuocThaiLonDBService>();
services.AddScoped<DuLieuNguonNuocThaiGiaCamDBService>();
services.AddScoped<DuLieuNguonNuocThaiTrongLuaDBService>();
services.AddScoped<DuLieuNguonNuocThaiTrongCayDBService>();
services.AddScoped<DuLieuNguonNuocThaiTrongRungDBService>();
services.AddScoped<DuLieuNguonNuocThaiThuySanDBService>();
services.AddScoped<TaiLuongNuocThaiSongDBService>();
//kiem ke
services.AddScoped<NMua_TongLuongService>();
//tong hop chi tieu
services.AddScoped<ChiTieuLVSTraKhucService>();
services.AddScoped<Tram_ThongTinService>();
services.AddScoped<NM_SoLuongService>();
services.AddScoped<NM_TongLuongService>();
services.AddScoped<NM_KhaiThacSuDungService>();
services.AddScoped<NM_ChatLuongService>();
services.AddScoped<NDD_SoLuongService>();
services.AddScoped<NDD_TongLuongService>();
services.AddScoped<NDD_ChatLuongService>();

//thongtindulieu
services.AddScoped<NN_LuuVucSongService>();
services.AddScoped<NN_NguonNuoc_SongSuoiService>();
services.AddScoped<NN_NguonNuoc_AoHoDamPhaService>();
services.AddScoped<NN_NguonNuoc_TangChuaNuocService>();
services.AddScoped<NN_AoHoDamPhaKhongDuocSanLapService>();
services.AddScoped<NN_HanhLangBaoVeNN_SongSuoiService>();
services.AddScoped<NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3Service>();
services.AddScoped<NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Service>();
services.AddScoped<NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoService>();
services.AddScoped<NN_CNNN_SongSuoiService>();
services.AddScoped<NN_CNNN_HoService>();
services.AddScoped<NN_CNNN_TangChuaNuocService>();
services.AddScoped<NN_DCTT_SongSuoiService>();
services.AddScoped<NN_DCTT_HaDuHoChuaService>();
services.AddScoped<NN_NguongKhaiThacNDDService>();
services.AddScoped<NN_VungCamHanCheKTNDDService>();
services.AddScoped<NN_MatCatSongSuoiService>();

services.AddScoped<SLN_TongLuongNuocMatService>();
services.AddScoped<CLN_NuocMatService>();
services.AddScoped<CLN_NDDService>();

services.AddScoped<SLDTKTSDN_NuocMatService>();
services.AddScoped<SLDTKTSDN_NDDService>();
services.AddScoped<SLDTKTSDN_XaThaiService>();

services.AddScoped<CTKTSDN_PCGP_NDDService>();
services.AddScoped<CTKTSDN_PCGP_NuocBienService>();
services.AddScoped<CTKTSDN_PCGP_NuocMatService>();
services.AddScoped<CTKTSDN_PDK_NDDService>();
services.AddScoped<CTKTSDN_PDK_NuocBienService>();
services.AddScoped<CTKTSDN_PDK_NuocMatService>();
services.AddScoped<CTKTSDN_KTNDDCuaHoGDService>();

services.AddScoped<HSKTT_NDDService>();
services.AddScoped<HSKTT_NuocMatService>();

services.AddScoped<DanhMucNN_LienTinhService>();
services.AddScoped<DanhMucNN_NoiTinh_AoHoService>();
services.AddScoped<DanhMucNN_NoiTinh_SongSuoiService>();

services.AddScoped<CLN_NuocMatService>();



// van hanh ho chua
services.AddScoped<VHHC_LuuVucSongService>();
services.AddScoped<VHHC_HoChua_ThongSoKTService>();
services.AddScoped<MuaHienTaiService>();
services.AddScoped<DuLieuLuuVucLHCService>();


//demo
services.AddScoped<DemoService>();

//TramQuangNgai
services.AddScoped<DuLieuTramService>();
services.AddScoped<HTTTService>();

//truyendulieu
services.AddScoped<StoragePreDataService>();
services.AddScoped<DataTransmissionAccountsService>();


//AI Forecast
services.AddScoped<ForecaseDakdrinhInflowService>(sp =>
    {
        var configuration = sp.GetRequiredService<IConfiguration>();
        var modelPath = Path.Combine(Directory.GetCurrentDirectory(), configuration.GetValue<string>("OnnxModelPath") + "");
        return new ForecaseDakdrinhInflowService(modelPath);
    });

services.AddIdentity<AspNetUsers, AspNetRoles>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 1; // Set the minimum password length to 1 or any other value you prefer
})
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

services.AddControllers();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WRDakNong API", Version = "v1" });
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme. Example: \"{token}\"",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = JwtBearerDefaults.AuthenticationScheme
        }
    };
    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] { } }
    });
});

// Add JWT authentication
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""));

services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = key
    };
});

// Add CORS policy
services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000", "https://tnmt-dn.vercel.app", "https://tainguyenmoitruongquangngai.vn/")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WRDakNong API");
    });
}

//Add CORS policy
app.UseCors();

app.UseSwagger();

//app.UseHttpsRedirection();

//app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AspNetUsers>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AspNetRoles>>();

        await dbContext.Database.MigrateAsync();
        await SeedData.InitializeAsync(dbContext, userManager, roleManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during database seeding: {ex.Message}");
    }
}

app.Run();
