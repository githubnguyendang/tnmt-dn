namespace tnmt_qn.Data
{
    public class ChangeHistory
    {
        public int Id { get; set; }
        public string? EntityName { get; set; }
        public string? Action { get; set; }
        public string? OldValues { get; set; }
        public string? NewValues { get; set; }
        public DateTime ChangeTime { get; set; }
        public string? ChangedBy { get; set; }
    }

}
