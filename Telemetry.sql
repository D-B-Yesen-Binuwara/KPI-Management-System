-- ==========================================
-- TELEMETRY TABLE
-- ==========================================
CREATE TABLE [dbo].[Telemetry]
(
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Designation] NVARCHAR(100) NOT NULL,
    [Year] INT NOT NULL,
    [Month] INT NOT NULL,
    [Percentage] DECIMAL(5,2) NOT NULL,

    CONSTRAINT [PK_Telemetry]
        PRIMARY KEY ([Id]),

    CONSTRAINT [UQ_Telemetry_Designation_Year_Month]
        UNIQUE ([Designation], [Year], [Month])
);
GO


-- ==========================================
-- POWER AND AC TABLE
-- ==========================================
CREATE TABLE [dbo].[PowerAndAC]
(
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Designation] NVARCHAR(100) NOT NULL,
    [Year] INT NOT NULL,
    [Month] INT NOT NULL,
    [Scheduled] INT NOT NULL,
    [Attended] INT NOT NULL,
    [Cumulative_Sched] INT NOT NULL,
    [Cumulative_Achieved] INT NOT NULL,

    CONSTRAINT [PK_PowerAndAC]
        PRIMARY KEY ([Id]),

    CONSTRAINT [UQ_PowerAndAC_Designation_Year_Month]
        UNIQUE ([Designation], [Year], [Month])
);
GO


/*
in other kpi page
[NW KPI Monitoring](http://localhost:4200/platform/other-kpi)

when a platform admin fills out the filter component. the metrices fields are shown to imput values [this is the general behaviour of all pages in platform admin]

under the "Telemetry Network Availability" - the metric table related should be - Telemetry [check telemetry.sql file]
and under - O&M of Power & Aircondition. table should be - PowerAndAC [check telemetry.sql]

*/