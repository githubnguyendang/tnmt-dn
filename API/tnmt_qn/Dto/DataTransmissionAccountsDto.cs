namespace tnmt_qn.Dto
{
    public class DataTransmissionAccountsDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? CameraLink { get; set; }
        public string? FTPAddress { get; set; }
        public string? Protocol { get; set; }
        public int? Port { get; set; }
        public string? WorkingDirectory { get; set; }
        public string? DataType { get; set; }
    }
}
