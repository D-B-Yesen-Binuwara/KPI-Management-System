/*
 * File: IMultiTableService.cs
 * Service interface and DTOs for fetching multi-table platform data from SOAP UI endpoints.
 * Supports MSAN, VPN, and SLBN data retrieval.
 */

using backend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    // =========================================================
    // MULTI-TABLE SERVICE INTERFACE
    // Defines contract for fetching platform data from SOAP UI
    // =========================================================
    public interface IMultiTableService
    {
        // Fetches MSAN (Metro Software Area Network) platform data
        Task<List<PlatformRecordDto>> FetchMsanDataAsync();

        // Fetches VPN (Virtual Private Network) platform data
        Task<List<PlatformRecordDto>> FetchVpnDataAsync();

        // Fetches SLBN (Service Level Backbone Network) platform data
        Task<List<PlatformRecordDto>> FetchSlbnDataAsync();

        Task<List<PlatformRecordDto>> FetchTowerDataAsync();
    }

    // =========================================================
    // PLATFORM RECORD DTO
    // Represents monthly platform data with details
    // =========================================================
    public class PlatformRecordDto
    {
        // Month identifier for the data
        public string Month { get; set; } = string.Empty;

        // Collection of platform details for the month
        public List<PlatformDetailDto> Details { get; set; } = new();
        public Dictionary<dynamic, PlatformDetailDto>? Data { get; internal set; }
    }

    // =========================================================
    // PLATFORM DETAIL DTO
    // Represents individual platform detail columns
    // =========================================================
   
}
