namespace backend.DTOs
{
    public class PlatformRecordDto
    {


        public string Month { get; set; } = string.Empty;
        public Dictionary<string, PlatformDetailDto> Data { get; set; } = new();


    }
}
