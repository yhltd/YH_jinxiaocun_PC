
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/25/2021 17:39:40
-- Generated from EDMX file: E:\yhltd129\工作\YH_jinxiaocun_PC\Web\scheduling\model\Scheduling.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [scheduling];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[module_info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[module_info];
GO
IF OBJECT_ID(N'[dbo].[module_type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[module_type];
GO
IF OBJECT_ID(N'[dbo].[user_info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_info];
GO
IF OBJECT_ID(N'[dbo].[holiday_config]', 'U') IS NOT NULL
    DROP TABLE [dbo].[holiday_config];
GO
IF OBJECT_ID(N'[dbo].[time_config]', 'U') IS NOT NULL
    DROP TABLE [dbo].[time_config];
GO
IF OBJECT_ID(N'[dbo].[bom_info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[bom_info];
GO
IF OBJECT_ID(N'[dbo].[order_bom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[order_bom];
GO
IF OBJECT_ID(N'[dbo].[order_info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[order_info];
GO
IF OBJECT_ID(N'[dbo].[work_detail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[work_detail];
GO
IF OBJECT_ID(N'[dbo].[work_module]', 'U') IS NOT NULL
    DROP TABLE [dbo].[work_module];
GO
IF OBJECT_ID(N'[dbo].[department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[department];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'module_info'
CREATE TABLE [dbo].[module_info] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type_id] int  NOT NULL,
    [name] varchar(255)  NOT NULL,
    [num] float  NULL,
    [parent_id] int  NULL,
    [company] varchar(255)  NOT NULL
);
GO

-- Creating table 'module_type'
CREATE TABLE [dbo].[module_type] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(255)  NOT NULL,
    [company] varchar(255)  NULL
);
GO

-- Creating table 'user_info'
CREATE TABLE [dbo].[user_info] (
    [id] int IDENTITY(1,1) NOT NULL,
    [user_code] varchar(255)  NOT NULL,
    [password] varchar(255)  NOT NULL,
    [company] varchar(255)  NOT NULL,
    [department_name] nvarchar(max)  NULL
);
GO

-- Creating table 'holiday_config'
CREATE TABLE [dbo].[holiday_config] (
    [id] int IDENTITY(1,1) NOT NULL,
    [day_or_reset] datetime  NOT NULL,
    [company] varchar(255)  NOT NULL
);
GO

-- Creating table 'time_config'
CREATE TABLE [dbo].[time_config] (
    [id] int IDENTITY(1,1) NOT NULL,
    [week] int  NULL,
    [morning_start] varchar(8)  NULL,
    [morning_end] varchar(8)  NULL,
    [noon_start] varchar(8)  NULL,
    [noon_end] varchar(8)  NULL,
    [night_start] varchar(8)  NULL,
    [night_end] varchar(8)  NULL,
    [company] varchar(50)  NULL
);
GO

-- Creating table 'bom_info'
CREATE TABLE [dbo].[bom_info] (
    [id] int IDENTITY(1,1) NOT NULL,
    [code] varchar(255)  NOT NULL,
    [name] varchar(255)  NOT NULL,
    [norms] varchar(255)  NULL,
    [comment] varchar(255)  NULL,
    [unit] varchar(255)  NULL,
    [size] float  NULL,
    [company] varchar(255)  NULL,
    [type] varchar(255)  NOT NULL
);
GO

-- Creating table 'order_bom'
CREATE TABLE [dbo].[order_bom] (
    [id] int IDENTITY(1,1) NOT NULL,
    [order_id] int  NOT NULL,
    [bom_id] int  NOT NULL,
    [use_num] int  NOT NULL
);
GO

-- Creating table 'order_info'
CREATE TABLE [dbo].[order_info] (
    [id] int IDENTITY(1,1) NOT NULL,
    [code] varchar(255)  NOT NULL,
    [product_name] varchar(255)  NOT NULL,
    [norms] varchar(255)  NULL,
    [order_id] varchar(255)  NOT NULL,
    [set_date] datetime  NULL,
    [set_num] int  NOT NULL,
    [company] varchar(255)  NULL
);
GO

-- Creating table 'work_detail'
CREATE TABLE [dbo].[work_detail] (
    [id] int IDENTITY(1,1) NOT NULL,
    [order_id] int  NOT NULL,
    [work_num] int  NOT NULL,
    [work_start_date] datetime  NOT NULL,
    [company] varchar(255)  NOT NULL,
    [row_num] int  NULL,
    [is_insert] int  NULL
);
GO

-- Creating table 'work_module'
CREATE TABLE [dbo].[work_module] (
    [id] int IDENTITY(1,1) NOT NULL,
    [work_id] int  NOT NULL,
    [module_id] int  NOT NULL
);
GO

-- Creating table 'department'
CREATE TABLE [dbo].[department] (
    [id] int IDENTITY(1,1) NOT NULL,
    [department_name] varchar(255)  NULL,
    [add] nvarchar(max)  NULL,
    [del] nvarchar(max)  NULL,
    [upd] nvarchar(max)  NULL,
    [sel] nvarchar(max)  NULL,
    [view_name] varchar(255)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'module_info'
ALTER TABLE [dbo].[module_info]
ADD CONSTRAINT [PK_module_info]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'module_type'
ALTER TABLE [dbo].[module_type]
ADD CONSTRAINT [PK_module_type]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [user_code], [password], [company] in table 'user_info'
ALTER TABLE [dbo].[user_info]
ADD CONSTRAINT [PK_user_info]
    PRIMARY KEY CLUSTERED ([id], [user_code], [password], [company] ASC);
GO

-- Creating primary key on [id] in table 'holiday_config'
ALTER TABLE [dbo].[holiday_config]
ADD CONSTRAINT [PK_holiday_config]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'time_config'
ALTER TABLE [dbo].[time_config]
ADD CONSTRAINT [PK_time_config]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'bom_info'
ALTER TABLE [dbo].[bom_info]
ADD CONSTRAINT [PK_bom_info]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'order_bom'
ALTER TABLE [dbo].[order_bom]
ADD CONSTRAINT [PK_order_bom]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'order_info'
ALTER TABLE [dbo].[order_info]
ADD CONSTRAINT [PK_order_info]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'work_detail'
ALTER TABLE [dbo].[work_detail]
ADD CONSTRAINT [PK_work_detail]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'work_module'
ALTER TABLE [dbo].[work_module]
ADD CONSTRAINT [PK_work_module]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'department'
ALTER TABLE [dbo].[department]
ADD CONSTRAINT [PK_department]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------