using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tnmt_qn.Data
{
    public class GS_TaiKhoanTruyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? CameraLink { get; set; }
        public string? FTPAddress { get; set; }
        public string? Protocol { get; set; }
        public int? Port { get; set; }
        public string? WorkingDirectory { get; set; }
        public string? DataType { get; set; }
        public string? CreatedUser { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? ModifiedUser { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool? Status { get; set; }
    }
}
