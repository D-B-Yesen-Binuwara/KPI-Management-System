/*
 * File: EnterpriseKpiMetric.cs
 * Entity model representing area-level metrics for Enterprise KPI.
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("EnterpriseKpiMetrics")]
    public class EnterpriseKpiMetric
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EnterpriseKpiId { get; set; }

        [Required]
        [MaxLength(255)]
        public string KpiName { get; set; } = string.Empty;

        [Required]
        public string AreaCode { get; set; } = null!;

        public decimal? KpiValue { get; set; }

        public byte Month { get; set; }

        public short Year { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(EnterpriseKpiId))]
        public EnterpriseKpi? EnterpriseKpi { get; set; }
    }
}