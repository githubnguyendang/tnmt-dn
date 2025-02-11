namespace tnmt_qn.Dto
{
    public class SongDto
    {
        public int? Id { get; set; }
        public int? IdLuuVuc { get; set; }
        public string? TenSong { get; set; }
        public string? MaSong { get; set; }
        public double? XDauSong { get; set; }
        public double? YDauSong { get; set; }
        public int? IdXaDauSong { get; set; }
        public int? IdHuyenDauSong { get; set; }
        public double? XCuoiSong { get; set; }
        public double? YCuoiSong { get; set; }
        public int? IdXaCuoiSong { get; set; }
        public int? IdHuyenCuoiSong { get; set; }
        public double? Qtt { get; set; }
        public string? ChuGiai { get; set; }
        public bool? DaXoa { get; set; }

        public LuuVucSongDto? luuvuc_song { get; set; }
        public DauCuoiSongDto? DauSong { get; set; }
        public DauCuoiSongDto? CuoiSong { get; set; }
    }

    public class DauCuoiSongDto
    {
        public double? X { get; set; }
        public double? Y { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
    }
}
