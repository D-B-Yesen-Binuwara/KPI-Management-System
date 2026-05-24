/*
 * File: MultiTableService.cs
 * Implements data fetching from SOAP UI endpoints for multiple platform types.
 * Provides fallback mock data when endpoints are unavailable.
 */

using backend.Data;
using backend.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Services
{
    // =========================================================
    // MULTI-TABLE SERVICE
    // Fetches MSAN, VPN, and SLBN data from configured SOAP UI endpoints
    // =========================================================
    public class MultiTableService : IMultiTableService
    {
        // HTTP client for making requests to SOAP UI endpoints
        private readonly HttpClient _httpClient;

        // Configuration for endpoint URLs and settings
        private readonly IConfiguration _configuration;


        private readonly AppDbContext _context;

        public MultiTableService(HttpClient httpClient, IConfiguration configuration, AppDbContext context)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _context = context;
        }


        

        // Fetches MSAN (Metro Software Area Network) platform data
        public async Task<List<PlatformRecordDto>> FetchMsanDataAsync()
        {
            return await GetDataFromDatabaseAsync("Msan");
        }

        // Fetches VPN (Virtual Private Network) platform data
        public async Task<List<PlatformRecordDto>> FetchVpnDataAsync()
        {
            return await GetDataFromDatabaseAsync("Vpn");
        }

        // Fetches SLBN (Service Level Backbone Network) platform data
        public async Task<List<PlatformRecordDto>> FetchSlbnDataAsync()
        {
            return await GetDataFromDatabaseAsync("Slbn");
        }

        // Fetches Tower (Service Level Backbone Network) platform data
        public async Task<List<PlatformRecordDto>> FetchTowerDataAsync()
        {
            return await GetDataFromDatabaseAsync("Tower");
        }

        /// <summary>
        /// Fetches data from configured SOAP UI endpoint for the specified platform type.
        /// Endpoint URLs should be configured in appsettings.json under the SoapUi section.
        /// Example: "SoapUi:MsanEndpoint": "http://localhost:8080/endpoint"
        /// Falls back to mock data if endpoint is unavailable or request fails.
        /// </summary>






        /// <summary>
        /// Parses SOAP UI HTTP response into platform record format.
        /// Currently returns mock data.
        /// TODO: Implement actual parsing based on real SOAP UI response format once available.
        /// </summary>


        private async Task<List<PlatformRecordDto>> GetDataFromDatabaseAsync(string platformType)
        {
            IEnumerable<object> data;

            if (platformType == "Msan")
            {
                data = await _context.MsanMtcData
                    .Select(x => new
                    {
                        x.Designation,
                        x.Month,
                        x.Scheduled,
                        x.Attended
                    }).ToListAsync();
            }
            else if (platformType == "Vpn")
            {
                data = await _context.IpnwMtcData
                    .Select(x => new
                    {
                        x.Designation,
                        x.Month,
                        x.Scheduled,
                        x.Attended
                    }).ToListAsync();
            }
            else if (platformType == "Slbn")
            {
                data = await _context.SlbnMtcData
                    .Select(x => new
                    {
                        x.Designation,
                        x.Month,
                        x.Scheduled,
                        x.Attended
                    }).ToListAsync();
            }
            else if (platformType == "Tower") {
                data = await _context.TowerMtcData
                   .Select(x => new
                   {
                       x.Designation,
                       x.Month,
                       x.Scheduled,
                       x.Attended
                   }).ToListAsync();

            } else
            {
                return new List<PlatformRecordDto>();
            }

            // ✅ Now all have SAME SHAPE

            var result = data
    .GroupBy(x => ((dynamic)x).Month)
    .Select(g => new PlatformRecordDto
    {
        Month = g.Key,
        Details = new List<PlatformDetailDto>(), // optional if not used
        Data = g.ToDictionary(
            x => ((dynamic)x).Designation.Trim(),
            x =>
            {
                var item = (dynamic)x;

                int scheduled = item.Scheduled ?? 0;
                int attended = item.Attended ?? 0;

                string percentage = (scheduled > 0 && scheduled == attended)
                    ? "100.00%"
                    : (scheduled > 0
                        ? (attended * 100.0 / scheduled).ToString("0.00") + "%"
                        : "0%");

                return new PlatformDetailDto
                {
                    Column2 = scheduled.ToString(),   // Distribution
                    Column3 = attended.ToString()              // Achievement
                };
            })
    }).ToList();

            return result;
        }

    }
}
