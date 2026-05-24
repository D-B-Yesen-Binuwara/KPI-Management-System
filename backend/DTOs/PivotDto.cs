/*
 * File: BbAnwDto.cs
 * Data Transfer Object representing a BB&ANW KPI record along with its
 * associated node metrics for API responses.
 */

using backend.Services;
using System.Collections.Generic;

namespace backend.DTOs
{
    // =========================================================
    // BB&ANW KPI DTO
    // Used to transfer BB&ANW KPI data between backend and frontend
    // =========================================================

    public class PivotDto
    {
        public string Month { get; set; }
        public Dictionary<string, PlatformDetailDto> Data { get; set; }
    }

}