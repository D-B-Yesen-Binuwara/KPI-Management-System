/*
 * File: OtherKpiMetric.cs
 * Entity model representing area-level metrics for Other Operator KPI.
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("OtherKpiMetrics")]
    public class OtherKpiMetric
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OtherKpiId { get; set; }

        [Required]
        public string AreaCode { get; set; } = null!;

        public decimal? KpiValue { get; set; }

        public byte Month { get; set; }

        public short Year { get; set; }

        [ForeignKey(nameof(OtherKpiId))]
        public OtherKpi? OtherKpi { get; set; }
    }
}