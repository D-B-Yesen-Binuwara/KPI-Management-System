using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace backend.Models
{
    [Table("slbnmtcdata", Schema = "dbo")]
    public class SlbnMtcData
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("designation")]
        public string? Designation { get; set; }

        [Column("year")]
        public short? Year { get; set; }

        [Column("month", TypeName = "varchar(10)")]
        public string? Month { get; set; }

        [Column("scheduled")]
        public int? Scheduled { get; set; }

        [Column("attended")]
        public int? Attended { get; set; }

        [Column("cumulative_count")]
        public int? CumulativeCount { get; set; }
    }
}
