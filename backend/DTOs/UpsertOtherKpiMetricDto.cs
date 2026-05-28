namespace backend.DTOs
{
    public class UpsertOtherKpiMetricDto
    {
        public int OtherKpiId { get; set; }
        public string AreaCode { get; set; } = string.Empty;
        public decimal? KpiValue { get; set; }
        public byte Month { get; set; }
        public short Year { get; set; }
    }
}