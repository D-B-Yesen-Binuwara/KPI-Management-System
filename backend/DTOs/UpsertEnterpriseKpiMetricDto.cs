namespace backend.DTOs
{
    public class UpsertEnterpriseKpiMetricDto
    {
        public int EnterpriseKpiId { get; set; }
        public string AreaCode { get; set; } = string.Empty;
        public decimal? KpiValue { get; set; }
        public byte Month { get; set; }
        public short Year { get; set; }
    }
}