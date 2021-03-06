IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PlannerID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_PlannerID]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LastUpdatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_LastUpdatedBy]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_CustomerID]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_CreatedBy]
GO
/****** Object:  UserDefinedFunction [dbo].[DelimitedSplit8K]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DelimitedSplit8K]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[DelimitedSplit8K]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project]') AND type in (N'U'))
DROP TABLE [dbo].[Project]
GO
/****** Object:  Table [dbo].[Position_Longdesc]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position_Longdesc]') AND type in (N'U'))
DROP TABLE [dbo].[Position_Longdesc]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position]') AND type in (N'U'))
DROP TABLE [dbo].[Position]
GO
/****** Object:  Table [dbo].[Planner]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Planner]') AND type in (N'U'))
DROP TABLE [dbo].[Planner]
GO
/****** Object:  Table [dbo].[Map]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Map]') AND type in (N'U'))
DROP TABLE [dbo].[Map]
GO
/****** Object:  Table [dbo].[LvSectionDetails]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LvSectionDetails]') AND type in (N'U'))
DROP TABLE [dbo].[LvSectionDetails]
GO
/****** Object:  Table [dbo].[LVSection]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LVSection]') AND type in (N'U'))
DROP TABLE [dbo].[LVSection]
GO
/****** Object:  Table [dbo].[LVRaster]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LVRaster]') AND type in (N'U'))
DROP TABLE [dbo].[LVRaster]
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lookup]') AND type in (N'U'))
DROP TABLE [dbo].[Lookup]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
DROP TABLE [dbo].[Customer]
GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SplitString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[SplitString]
GO
/****** Object:  UserDefinedFunction [dbo].[PrepareOZ]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrepareOZ]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[PrepareOZ]
GO
/****** Object:  UserDefinedFunction [dbo].[Cal_MultiValue]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cal_MultiValue]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Cal_MultiValue]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_Project]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_Project]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_Project]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_LongDescription]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_LongDescription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_LongDescription]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_BulkProcess_ActionB]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_BulkProcess_ActionB]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_BulkProcess_ActionB]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_BulkProcess_ActionA]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_BulkProcess_ActionA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_BulkProcess_ActionA]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Project]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Project]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Project]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Position]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Position]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Position]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_LVSection]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_LVSection]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_LVSection]
GO
/****** Object:  StoredProcedure [dbo].[P_Import]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Import]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Import]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_TMLFile]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_TMLFile]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_TMLFile]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectList]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ProjectList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ProjectList]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectDetails]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ProjectDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ProjectDetails]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionOZ]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionOZ]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionOZ]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionList]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionList]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionKZ]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionKZ]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionKZ]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionForTML]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionForTML]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionForTML]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVSectionForImport]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVSectionForImport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_LVSectionForImport]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVSection]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVSection]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_LVSection]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVRaster]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVRaster]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_LVRaster]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LongDescription]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LongDescription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_LongDescription]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_DocuwareLinks]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_DocuwareLinks]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_DocuwareLinks]
GO
/****** Object:  StoredProcedure [dbo].[P_Del_Project]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Del_Project]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Del_Project]
GO
/****** Object:  StoredProcedure [dbo].[P_Del_Position]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Del_Position]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Del_Position]
GO
/****** Object:  UserDefinedTableType [dbo].[Project_Import]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Project_Import' AND ss.name = N'dbo')
DROP TYPE [dbo].[Project_Import]
GO
/****** Object:  UserDefinedTableType [dbo].[Positions]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Positions' AND ss.name = N'dbo')
DROP TYPE [dbo].[Positions]
GO
/****** Object:  UserDefinedTableType [dbo].[Position_OZ_List]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Position_OZ_List' AND ss.name = N'dbo')
DROP TYPE [dbo].[Position_OZ_List]
GO
/****** Object:  UserDefinedTableType [dbo].[Import]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Import' AND ss.name = N'dbo')
DROP TYPE [dbo].[Import]
GO
/****** Object:  UserDefinedTableType [dbo].[Bulk_Process_ActionB]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Bulk_Process_ActionB' AND ss.name = N'dbo')
DROP TYPE [dbo].[Bulk_Process_ActionB]
GO
/****** Object:  UserDefinedTableType [dbo].[Bulk_Process_ActionA]    Script Date: 2/3/2017 2:28:19 PM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Bulk_Process_ActionA' AND ss.name = N'dbo')
DROP TYPE [dbo].[Bulk_Process_ActionA]
GO
/****** Object:  UserDefinedTableType [dbo].[Bulk_Process_ActionA]    Script Date: 2/3/2017 2:28:19 PM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Bulk_Process_ActionA' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Bulk_Process_ActionA] AS TABLE(
	[ID] [int] NULL,
	[MA_selbstkostenMulti] [decimal](10, 3) NULL,
	[MO_selbstkostenMulti] [decimal](10, 3) NULL,
	[MA_verkaufspreis_Multi] [decimal](10, 3) NULL,
	[MO_verkaufspreisMulti] [decimal](10, 3) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Bulk_Process_ActionB]    Script Date: 2/3/2017 2:28:20 PM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Bulk_Process_ActionB' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Bulk_Process_ActionB] AS TABLE(
	[ID] [int] NULL,
	[Menge] [nvarchar](10) NULL,
	[PreisText] [nvarchar](200) NULL,
	[MA] [nvarchar](10) NULL,
	[MO] [nvarchar](10) NULL,
	[Fabricate] [nvarchar](100) NULL,
	[Type] [nvarchar](50) NULL,
	[LiefrantMA] [nvarchar](50) NULL,
	[WG] [nvarchar](10) NULL,
	[WA] [nvarchar](10) NULL,
	[WI] [nvarchar](10) NULL,
	[LVSection] [nvarchar](10) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Import]    Script Date: 2/3/2017 2:28:20 PM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Import' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Import] AS TABLE(
	[PositionID] [int] NULL,
	[Art] [nvarchar](10) NULL,
	[OZ] [nvarchar](10) NULL,
	[Menge] [int] NULL,
	[Einheit] [nvarchar](10) NULL,
	[Kurztext] [nvarchar](max) NULL,
	[KurztextTA] [nvarchar](10) NULL,
	[Langtext] [nvarchar](max) NULL,
	[LangtextTA] [nvarchar](10) NULL,
	[LangtextTB] [nvarchar](10) NULL,
	[EP] [decimal](10, 2) NULL,
	[GB] [decimal](10, 2) NULL,
	[Nachlass] [nvarchar](10) NULL,
	[SB] [nvarchar](10) NULL,
	[SummePsch] [nvarchar](10) NULL,
	[Bedarf] [nvarchar](10) NULL,
	[StPos] [nvarchar](10) NULL,
	[ZZGruppeNr] [nvarchar](10) NULL,
	[ZZLfdNr] [nvarchar](10) NULL,
	[BezugBeschr] [nvarchar](10) NULL,
	[BezugOZ] [nvarchar](10) NULL,
	[LeitBeschr] [nvarchar](10) NULL,
	[ZuschlArt] [nvarchar](10) NULL,
	[Nr] [nvarchar](10) NULL,
	[Bez] [nvarchar](10) NULL,
	[Entf] [nvarchar](10) NULL,
	[EPAufgl] [nvarchar](10) NULL,
	[Bezuschl] [nvarchar](10) NULL,
	[StLNr] [nvarchar](10) NULL,
	[SPos] [nvarchar](10) NULL,
	[NachtrNr] [nvarchar](10) NULL,
	[NachtrStatus] [nvarchar](10) NULL,
	[BezugAusfNr] [nvarchar](10) NULL,
	[MeAng] [nvarchar](10) NULL,
	[PrAng] [nvarchar](10) NULL,
	[FrMenge] [nvarchar](10) NULL,
	[VaMenge] [nvarchar](10) NULL,
	[ReMenge] [nvarchar](10) NULL,
	[Beauftragt] [nvarchar](10) NULL,
	[BedarfAuftr] [nvarchar](10) NULL,
	[EP110] [nvarchar](10) NULL,
	[EPAnteil1] [nvarchar](10) NULL,
	[EPAnteil2] [nvarchar](10) NULL,
	[EPAnteil3] [nvarchar](10) NULL,
	[EPAnteil4] [nvarchar](10) NULL,
	[EPAnteil5] [nvarchar](10) NULL,
	[EPAnteil6] [nvarchar](10) NULL,
	[EFBLohn] [nvarchar](10) NULL,
	[EFBStoffe] [nvarchar](10) NULL,
	[EFBGeraete] [nvarchar](10) NULL,
	[EFBSoKo] [nvarchar](10) NULL,
	[EFBNU] [nvarchar](10) NULL,
	[EFBZeit] [nvarchar](10) NULL,
	[USt] [nvarchar](10) NULL,
	[BruttoSumme] [nvarchar](10) NULL,
	[EPVon] [nvarchar](10) NULL,
	[EPMittel] [nvarchar](10) NULL,
	[EPBis] [nvarchar](10) NULL,
	[EPLohnVon] [nvarchar](10) NULL,
	[EPLohnMittel] [nvarchar](10) NULL,
	[EPLohnBis] [nvarchar](10) NULL,
	[Zeitwert] [nvarchar](10) NULL,
	[PreisInfo] [nvarchar](10) NULL,
	[Zeitansatz] [nvarchar](10) NULL,
	[TLKNr] [nvarchar](10) NULL,
	[FreieOZ] [nvarchar](10) NULL,
	[ZBV1] [nvarchar](10) NULL,
	[ZBV2] [nvarchar](10) NULL,
	[ZBV3] [nvarchar](10) NULL,
	[Parent_OZ] [int] NULL,
	[LVPos_Id] [int] NULL,
	[LVPos_Id_0] [int] NULL,
	[LV_Id] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Position_OZ_List]    Script Date: 2/3/2017 2:28:24 PM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Position_OZ_List' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Position_OZ_List] AS TABLE(
	[_FronPos] [int] NULL,
	[_ToPos] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Positions]    Script Date: 2/3/2017 2:28:24 PM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Positions' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Positions] AS TABLE(
	[FromOZ] [nvarchar](50) NULL,
	[ToOZ] [nvarchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Project_Import]    Script Date: 2/3/2017 2:28:24 PM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Project_Import' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Project_Import] AS TABLE(
	[Art] [nvarchar](10) NULL,
	[OZ] [nvarchar](50) NULL,
	[Menge] [int] NULL,
	[Einheit] [nvarchar](10) NULL,
	[Kurztext] [nvarchar](max) NULL,
	[Langtext] [nvarchar](max) NULL,
	[EP] [decimal](10, 2) NULL,
	[GB] [decimal](10, 2) NULL,
	[Nachlass] [nvarchar](10) NULL,
	[ParentOz] [nvarchar](50) NULL,
	[Title] [nvarchar](100) NULL
)
GO
/****** Object:  StoredProcedure [dbo].[P_Del_Position]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Del_Position]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEdure [dbo].[P_Del_Position]
@PositionID INT
AS
BEGIN

DELETE FROM Position_Longdesc WHERE PositionID = @PositionID

DELETE FROM Position WHERE PositionID = @PositionID

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Del_Project]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Del_Project]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Del_Project]
@ProjectID INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			DELETE FROM PROJECT WHERE ProjectID = @ProjectID
		COMMIT TRAN
	END TRY
	
	BEGIN CATCH
        IF(@@TRANCOUNT > 0)
			ROLLBACK TRAN
	END CATCH

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_DocuwareLinks]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_DocuwareLinks]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Get_DocuwareLinks]
@PositionID INT
AS
BEGIN
SELECT  
PositionID,
DocuwareLink1,
DocuwareLink2,
DocuwareLink3
FROM  Position WHERE PositionID = @PositionID
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LongDescription]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LongDescription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_LongDescription]
@PositionID INT
AS
BEGIN
IF EXISTS(SELECT 1 FROM Position_Longdesc WHERE positionID = @PositionID)
SELECT Longdiscription FROM Position_Longdesc WHERE positionID = @PositionID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVRaster]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVRaster]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Get_LVRaster]

AS
BEGIN
    SELECT *FROM LVRaster
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVSection]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVSection]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Get_LVSection]
@LVSectionName NVARCHAR(10),
@ProjectID int
AS
BEGIN
select  
REPLICATE(''0'',3 - DATALENGTH(cast(ISNULL(max(LD.SNO),0) + 1 as varchar))) + cast(ISNULL(max(LD.SNO),0) + 1 as varchar) 
AS LVSectionID
from LVSectionDetails LD inner join
LVSection L on LD.LVsectionID = L.LVSectionID
where L.LVSectionName = @LVSectionName and L.ProjectID = @ProjectID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVSectionForImport]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVSectionForImport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_LVSectionForImport]
@ProjectID INT
AS
BEGIN
SELECT DISTINCT(LVSection) FROM Position WHERE ProjectID = @ProjectID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionForTML]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionForTML]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_PositionForTML]  
@ProjectID INT,  
@LVSection NVARCHAR(50) = NULL  
AS  
BEGIN  
DECLARE @Count INT = 0,@Raster NVARCHAR(100)  
CREATE TABLE #Postions(PositionID INT)  
CREATE TABLE #TEMP(PositionID INT)  
IF (@LVSection IS NULL OR @LVSection = ''ALL'')  
BEGIN  
INSERT INTO #Postions  
SELECT PositionID FROM position WHERE projectID = @ProjectID and Parent_OZ is null  
SELECT @Count = ISNULL(count(PositionID),0) FROM #Postions  
SELECT @Raster = LV_Raster FROM Project WHERE ProjectID = @ProjectID  
WHILE(@Count > 0)  
 BEGIN  
  SELECT   
  P.PositionID,P.Parent_OZ,CASE WHEN PositionKZ = '''' THEN ''NG'' ELSE PositionKZ END AS Art,  
  dbo.PrepareOZ(@Raster,Position_OZ) AS OZ,  
  isnull(Menge,0) AS Menge,ISNULL(ME,'''') AS Einheit,isnull(ShortDescription,'''') AS Kurztext,'''' AS KurztextTA,  
  ISNULL(P1.Longdiscription,'''') AS Langtext,  
    '''' AS LangtextTA,'''' AS LangtextTB,ISNULL(MA_verkaufspreis,0) + ISNULL(MO_verkaufspreis,0) AS EP,  
    (ISNULL(MA_verkaufspreis,0) + ISNULL(MO_verkaufspreis,0)) * ISNULL(Menge,0) AS GB,  
    ISNULL(LVSection,'''') AS Nachlass,'''' AS SB,'''' AS SummePsch,  
    '''' AS Bedarf,'''' AS StPos,'''' AS ZZGruppeNr,'''' AS ZZLfdNr,'''' AS BezugBeschr,'''' AS BezugOZ,'''' AS LeitBeschr,  
    '''' AS ZuschlArt,'''' AS Nr,'''' AS Bez,'''' AS Entf,'''' AS EPAufgl,'''' AS Bezuschl,'''' AS StLNr,'''' AS SPos,  
    '''' AS NachtrNr,'''' AS NachtrStatus,'''' AS BezugAusfNr,'''' AS MeAng,'''' AS PrAng,'''' AS FrMenge,'''' AS VaMenge,  
    '''' AS ReMenge,'''' AS Beauftragt,'''' AS BedarfAuftr,'''' AS EP110,'''' AS EPAnteil1,'''' AS EPAnteil2,  
    '''' AS EPAnteil3,'''' AS EPAnteil4,'''' AS EPAnteil5,'''' AS EPAnteil6,'''' AS EFBLohn,'''' AS EFBStoffe,  
    '''' AS EFBGeraete,'''' AS EFBSoKo,'''' AS EFBNU,'''' AS EFBZeit,'''' AS USt,'''' AS BruttoSumme,'''' AS EPVon,  
    '''' AS EPMittel,'''' AS EPBis,'''' AS EPLohnVon,'''' AS EPLohnMittel,'''' AS EPLohnBis,'''' AS Zeitwert,  
    '''' AS PreisInfo,'''' AS Zeitansatz,'''' AS TLKNr,Position_OZ AS FreieOZ,'''' AS ZBV1,'''' AS ZBV2,'''' AS ZBV3   
    FROM Position P   
    LEFT JOIN Position_Longdesc P1   
     ON P.PositionID = P1.positionID   
    INNER JOIN #Postions P2   
    ON P.PositionID = P2.PositionID  
    WHERE ProjectID = @ProjectID   
    AND (PositionKZ = ''N'' OR PositionKZ = ''NG'' OR PositionKZ = '''' OR PositionKZ = ''E'' OR PositionKZ = ''A'' OR PositionKZ = ''M'')   
    AND DetailKZ = 0  
    AND ISNULL(LVStatus,'''') != ''A''  
    ORDER BY   
     cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 1) AS INT)  
     ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 2) AS INT)  
     ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 3) AS INT)  
     ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 4) AS INT)  
     ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 5) AS INT) 
   
    INSERT INTO #TEMP  
     SELECT P.PositionID FROM Position P INNER JOIN #Postions P1 ON P.Parent_OZ = P1.PositionID  
     DELETE FROM #Postions  
     INSERT INTO #Postions  
     SELECT PositionID FROM #TEMP  
     DELETE FROM #TEMP  
     SELECT @Count = ISNULL(COUNT(PositionID),0) from #Postions  
  END  
  
END  
  
ELSE  
  
BEGIN  
  
INSERT INTO #Postions  
  
SELECT PositionID FROM position WHERE projectID = @ProjectID and Parent_OZ is null  
  
SELECT @Count = ISNULL(count(PositionID),0) FROM #Postions  
  
SELECT @Raster = LV_Raster FROM Project WHERE ProjectID = @ProjectID  
  
WHILE(@Count > 0)  
  
 BEGIN  
  
  SELECT   
  
  P.PositionID,P.Parent_OZ,CASE WHEN PositionKZ = '''' THEN ''NG'' ELSE PositionKZ END AS Art,  
  
  dbo.PrepareOZ(@Raster,Position_OZ) AS OZ,  
  
  isnull(Menge,0) AS Menge,ISNULL(ME,'''') AS Einheit,isnull(ShortDescription,'''') AS Kurztext,'''' AS KurztextTA,  
  
  ISNULL(P1.Longdiscription,'''') AS Langtext,  
  
    '''' AS LangtextTA,'''' AS LangtextTB,ISNULL(MA_verkaufspreis,0) + ISNULL(MO_verkaufspreis,0) AS EP,  
  
    (ISNULL(MA_verkaufspreis,0) + ISNULL(MO_verkaufspreis,0)) * ISNULL(Menge,0) AS GB,  
  
    ISNULL(LVSection,'''') AS Nachlass,'''' AS SB,'''' AS SummePsch,  
  
    '''' AS Bedarf,'''' AS StPos,'''' AS ZZGruppeNr,'''' AS ZZLfdNr,'''' AS BezugBeschr,'''' AS BezugOZ,'''' AS LeitBeschr,  
  
    '''' AS ZuschlArt,'''' AS Nr,'''' AS Bez,'''' AS Entf,'''' AS EPAufgl,'''' AS Bezuschl,'''' AS StLNr,'''' AS SPos,  
  
    '''' AS NachtrNr,'''' AS NachtrStatus,'''' AS BezugAusfNr,'''' AS MeAng,'''' AS PrAng,'''' AS FrMenge,'''' AS VaMenge,  
  
    '''' AS ReMenge,'''' AS Beauftragt,'''' AS BedarfAuftr,'''' AS EP110,'''' AS EPAnteil1,'''' AS EPAnteil2,  
  
    '''' AS EPAnteil3,'''' AS EPAnteil4,'''' AS EPAnteil5,'''' AS EPAnteil6,'''' AS EFBLohn,'''' AS EFBStoffe,  
  
    '''' AS EFBGeraete,'''' AS EFBSoKo,'''' AS EFBNU,'''' AS EFBZeit,'''' AS USt,'''' AS BruttoSumme,'''' AS EPVon,  
  
    '''' AS EPMittel,'''' AS EPBis,'''' AS EPLohnVon,'''' AS EPLohnMittel,'''' AS EPLohnBis,'''' AS Zeitwert,  
  
    '''' AS PreisInfo,'''' AS Zeitansatz,'''' AS TLKNr,Position_OZ AS FreieOZ,'''' AS ZBV1,'''' AS ZBV2,'''' AS ZBV3   
  
    FROM Position P   
  
    LEFT JOIN Position_Longdesc P1   
  
     ON P.PositionID = P1.positionID   
  
    INNER JOIN #Postions P2   
  
    ON P.PositionID = P2.PositionID  
  
    WHERE ProjectID = @ProjectID   
  
    AND (PositionKZ = ''N'' OR PositionKZ = ''NG'' OR PositionKZ = '''' OR PositionKZ = ''E'' OR PositionKZ = ''A'' OR PositionKZ = ''M'')   
  
    AND DetailKZ = 0 AND LVSection = @LVSection AND ISNULL(LVStatus,'''') != ''A''
  
    ORDER BY   
  
     cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 1) AS INT)  
  
     ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 2) AS INT)  
  
     ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 3) AS INT)  
  
     ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 4) AS INT)  
  
     ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 5) AS INT)  
  
    INSERT INTO #TEMP  
  
    SELECT P.PositionID FROM Position P INNER JOIN #Postions P1 ON P.Parent_OZ = P1.PositionID  
  
    DELETE FROM #Postions  
  
    INSERT INTO #Postions  
  
    SELECT PositionID FROM #TEMP  
  
    DELETE FROM #TEMP  
  
    SELECT @Count = ISNULL(COUNT(PositionID),0) from #Postions  
  
 END  
  
END  
  
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionKZ]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionKZ]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_PositionKZ]
AS
BEGIN

SELECT LookupID,Value 
FROM Lookup WHERE MapID = 1

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionList]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[P_Get_PositionList]

@projectID INT = 1

AS

BEGIN	

create table  #temp

(

[PositionID] int,

[Identity_Column] int identity(1,1) not null

)

insert into #temp

select [PositionID] FROM Position 

          WHERE ProjectID= @projectID ORDER BY 

		    cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 1) as int)

	  ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 2) as int)

	  ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 3) as int)

	  ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 4) as int)

	  ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 5) as int)

		

		 SELECT  

	   p.[PositionID],[ProjectID],[Position_OZ],[Parent_OZ],[Title],[GetTitle],[ShortDescription],[PositionKZ]

      ,[LVSection],[WG],[WA],[WI],
	  Menge,[ME],[Fabricate],[LiefrantMA],[Type]

      ,[LVStatus],[ProposalNo],[surchargefrom],[surchargeto],[surchargePercentage],[surchargePercentage_MO]

	  ,[DetailKZ],[LVStatus_GAEB],[LVStatus_OTTO],[GetTitle]

	  ,CAST(MA_verkaufspreis + MO_verkaufspreis AS DECIMAL(10,3)) AS EP

	  ,cast(((MA_verkaufspreis + MO_verkaufspreis) * Menge) as decimal(10,3))AS GB

	  ,Identity_Column,validitydate,MA,MO,minutes,Faktor,MA_listprice,MO_listprice

	  ,MA_Multi1,MA_multi2,MA_multi3,MA_multi4,MA_multi5

	  ,MA_einkaufspreis,MA_selbstkosten,MA_selbstkostenMulti,MA_verkaufspreis,MA_verkaufspreis_Multi,

		MO_multi1,MO_multi2,MO_multi3,MO_multi4,MO_multi5,

		MO_Einkaufspreis,MO_selbstkostenMulti,MO_selbstkosten,MO_verkaufspreisMulti,MO_verkaufspreis,std_satz,

		PreisText,MA_einkaufspreis_lck,MA_selbstkosten_lck,MA_verkaufspreis_lck,

		MO_Einkaufspreis_lck,MO_selbstkosten_lck,MO_verkaufspreis_lck,A,B,L,DocuwareLink1,DocuwareLink2,DocuwareLink3,GrandTotalME,GrandTotalMO,FinalGB

	  FROM Position p inner join #temp t ON t.PositionID=p.PositionID

	  order by t.Identity_Column

	  DROP TABLE #temp 	  

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionOZ]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionOZ]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Get_PositionOZ]  
@Position_OZ_Table As [dbo].[Positions] Readonly,  
@projectID INT,  
@Position_Type varchar(50),  
@WG INT,  
@WA INT
AS  
BEGIN  
CREATE  TABLE #tempPosition(PositionID INT,PositionOZ NVARCHAR(50), [Indetity_Column] int identity(1,1))
INSERT INTO #tempPosition(PositionID,PositionOZ)
SELECT PositionID,Position_OZ FROM Position WHERE PositionKZ = ''N'' AND
ProjectID= @projectID ORDER BY 
		    cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 1) as int)
	  ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 2) as int)
	  ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 3) as int)
	  ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 4) as int)
	  ,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 5) as int)
 DECLARE @tempRowCount INT
		  DECLARE @count INT,@FromOZ nvarchar(50) = null,@ToOZ nvarchar(50) = null, @fromID int = 0,@toID int = 0
		  CREATE TABLE #temp
(
[id] INT IDENTITY(1,1),
[Position_From] NVARCHAR(50),
[Position_To] NVARCHAR(50)
)
IF(@Position_Type =''Parent Position'')  
	BEGIN
		INSERT INTO #temp select * from @Position_OZ_Table
		SET @tempRowCount=(SELECT COUNT(*) FROM #temp)
		SET @count=1
		CREATE TABLE #TempParents(PositionID INT)
		CREATE TABLE #TempChilds(PositionID INT,PositionOZ nvarchar(100),[Indetity_Column] int identity(1,1))
		CREATE TABLE #TempResultP(PositionID INT)
		WHILE(@tempRowCount>=@count)
			BEGIN
				SELECT @FromOZ=[Position_From]+''.'', @ToOZ=[Position_To]+''.'' from #temp where id=@count
              
				INSERT INTO #TempChilds(PositionID,PositionOZ)
				SELECT PositionID,Position_OZ FROM Position WHERE ProjectID = @projectID and PositionKZ =''NG''
				ORDER BY 
					cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 1) as int)
					,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 2) as int)
					,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 3) as int)
					,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 4) as int)
					,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 5) as int)

					select @fromID = [Indetity_Column] from #TempChilds where PositionOZ = @FromOZ
					select @toID = [Indetity_Column] from #TempChilds where PositionOZ = @ToOZ

					INSERT INTO #TempParents(PositionID)
					SELECT PositionID FROM #TempChilds WHERE [Indetity_Column] >= @fromID AND  [Indetity_Column] <= @toID

					DELETE FROM #TempChilds
					INSERT INTO #TempChilds(PositionID)
					SELECT  PositionID FROM #TempParents

				declare @Countresult int = 0
				select @Countresult = ISNULL(COUNT(*),0) FROM #TempParents where PositionID in (select Parent_OZ from Position where ProjectID = @projectID)     
				
				WHILE(@Countresult > 0)
					BEGIN
						INSERT INTO #TempResultP
						SELECT P.PositionID FROM Position P INNER JOIN #TempChilds T
						ON P.Parent_OZ = T.PositionID AND P.PositionKZ = ''NG''

						INSERT INTO #TempParents(PositionID)
						SELECT PositionID FROM #TempResultP S where not exists(select 1 from #TempParents T where s.PositionID = t.PositionID)

  						DELETE FROM #TempChilds
		
						INSERT INTO #TempChilds(PositionID)
						SELECT PositionID FROM #TempResultP

						select @Countresult = ISNULL(COUNT(*),0) FROM #TempChilds where PositionID in (select Parent_OZ from Position where ProjectID = @projectID)
		
						DELETE FROM #TempResultP
					END		
				SET @count=@count+1
			END	
	SELECT * FROM Position P INNER JOIN (SELECT DISTINCT(Positionid) FROM #TempParents) T ON P.Parent_OZ = t.PositionID
	WHERE PositionKZ = ''N''
	ORDER BY 
						cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 1) as int)
		,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 2) as int)
		,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 3) as int)
		,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 4) as int)
		,cast((SELECT item FROM dbo.DelimitedSplit8K(position_Oz, ''.'')WHERE ItemNumber = 5) as int)	
				  
		DROP TABLE #TempParents
		DROP TABLE #TempChilds 
		DROP TABLE #TempResultP
	END				
  IF(@Position_Type =''LV Position'')  
  BEGIN  
			INSERT INTO #temp select * from @Position_OZ_Table
			SET @tempRowCount=(SELECT COUNT(*) FROM #temp)
			SET @count=1
			DECLARE @RasterCount int = 0,@Raster NVARCHAR(50),@OZCount int = 0
			SELECT @Raster  = LV_raster from Project where ProjectID = @ProjectID
			select @RasterCount = Count(*) from splitstring(@Raster,''.'')
			
		CREATE TABLE #Tempresult(PositionID INT,ID int)
           IF(@tempRowCount>0)
			 BEGIN
             WHILE(@tempRowCount>=@count)
             BEGIN
                      SELECT @FromOZ=[Position_From], @ToOZ=[Position_To] from #temp where id=@count
					
					SELECT @OZCount = Count(*) FROM SPLITSTRING(@FromOZ,''.'')
					IF(@RasterCount = @OZCount)
					BEGIN
						SELECT @fromID = ISNULL(Indetity_Column,0) FROM #tempPosition where PositionOZ = @FromOZ
					 END
					 ELSE
					 BEGIN
						SELECT @fromID = isnull(Indetity_Column,0) FROM #tempPosition where PositionOZ = @FromOZ + ''.''
					 END
					 
					 IF(@fromID = 0)
					 BEGIN
						SELECT @FromOZ + '' POSITION DOES NOT EXISTS UNDER SELECTED PROJECT'' AS Error
						RETURN	
					 END
					 
					 SELECT @OZCount = Count(*) FROM SPLITSTRING(@ToOZ,''.'')
					IF(@RasterCount = @OZCount)
					BEGIN
						SELECT @toID = isnull(Indetity_Column,0) FROM #tempPosition where PositionOZ = @ToOZ
					 END
					 ELSE
					 BEGIN
						SELECT @toID = isnull(Indetity_Column,0) FROM #tempPosition where PositionOZ = @ToOZ + ''.''
					 END
					 
					 IF(@toID = 0)
					 BEGIN
						SELECT @ToOZ + '' POSITION DOES NOT EXISTS UNDER SELECTED PROJECT'' AS Error
						RETURN
					 END
					 
					 INSERT INTO #Tempresult(PositionID,ID)
					 SELECT PositionID,Indetity_Column FROM #tempPosition WHERE Indetity_Column >= @fromID AND Indetity_Column <= @toID
					 set @fromID = 0
					 set @toID = 0
					 SET @count=@count+1
           END
		   SELECT DISTINCT * FROM #Tempresult t INNER JOIN Position p on t.PositionID = p.PositionID order by t.ID
         END
  END  
  IF(@Position_Type =''WG/WA'')  
  BEGIN  
IF(@WG!='''') 
    BEGIN  
        SELECT * FROM #tempPosition T inner join Position P on T.PositionID = P.PositionID
        WHERE WG=@WG and WA=@WA ORDER BY T.Indetity_Column
    END  
    ELSE  
     BEGIN  
        SELECT * FROM #tempPosition T inner join Position P on T.PositionID = P.PositionID
        WHERE WG=@WG ORDER BY T.Indetity_Column
     END  
  END  
   DROP TABLE #temp      
  
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectDetails]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ProjectDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_ProjectDetails]
@ProjectID INT
AS
BEGIN
SELECT 
P.ProjectID,
P.Location,
P.ProjectNumber,
P.ComissionNumber,
P.CustomerID,
P.CustomerNumber,
P.CustomerName ,
P.ProjectDescription,
P.PlannerID,
P.PlannerName,
P.LV_Raster,
P.LV_Sprung,
P.Intern_X,
P.Intern_S,
P.Vat,
P.Submit_Location,
P.Submit_Date,
P.Submit_Time,
P.Estimated_LV,
ISNULL(PO.Actual_LV,0) AS Actual_LV,
P.Round_Off,
P.Remarks,
P.Planned_Duration,
P.Project_Discount,
P.Lock_LVHierarchy,
ISNULL(P.ProjectStartDate,getdate()) AS ProjectStartDate,
ISNULL(P.ProjectEndDate,getdate()) AS ProjectEndDate,
CASE WHEN PO.Actual_LV > 0 THEN ''true'' ELSE ''false'' END AS IsDisable
FROM Project P LEFT JOIN 
(SELECT ProjectID,COUNT(PositionID) AS Actual_LV FROM Position 
WHERE ProjectID = @ProjectID GROUP BY ProjectID)
PO ON P.ProjectID = PO.ProjectID
WHERE P.ProjectID = @ProjectID

SELECT 
LVSectionID,
LVSectionName
FROM LVSection WHERE ProjectID = @ProjectID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectList]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ProjectList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_ProjectList] 
@UserID INT = 1,
@iScOMMISION BIT = 0
AS
BEGIN
DECLARE @SqlQuery NVARCHAR(MAX)
DECLARE @WhereClause NVARCHAR(MAX) = ''''
SET @SqlQuery = ''SELECT
P.ProjectID,
P.ProjectNumber,
P.ComissionNumber,
P.CustomerName,
P.ProjectDescription,
P.PlannerName,
''''Created User'''' AS  Created_By,
P.Created_Date
FROM Project P''
IF (@iScOMMISION = 1)
	SET @WhereClause = '' WHERE P.ComissionNumber IS NOT NULL''
SET @SqlQuery = @SqlQuery + @WhereClause
EXECUTE sp_executesql @SqlQuery
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_TMLFile]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_TMLFile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_TMLFile]
@ProjectID INT
AS
BEGIN
SELECT ''1.1'' AS [Version],''11'' AS VersMon,''2016'' AS VersJahr,CONVERT(VARCHAR(20),GETDATE(),101) AS Datum,
		CONVERT(VARCHAR(5), GETDATE(),108) AS Uhrzeit,''OTTOPRO'' AS ProgSystem,''OTTOPRO'' AS ProgName,''''  AS Zertifikat,
		''ANSI'' AS Zeichensatz,''81'' AS DP,'''' AS TextFormat,'''' AS NachlassBasis,'''' AS IA_State,
		'''' AS IA_Format,'''' AS IA_DP,'''' AS IA_Kurztext,'''' AS IA_Langtext,'''' AS TreeCheckBox,
		'''' AS AufmassMenge,'''' AS BerechnungsMenge,'''' AS Berechnungszuordnungen,
		'''' AS [View],'''' AS BillOfQuantitiesType, '''' AS AufmassMenge

SELECT '''' AS Name1,'''' AS Name2, '''' AS Name3,'''' AS Name4,'''' AS Strasse,'''' AS PLZ,
		'''' AS Ort,'''' AS LandBez,'''' AS ILN,'''' AS AnsprPartner,'''' AS Telefon,
		'''' AS Fax,'''' AS	Email,'''' AS UStIdent,'''' AS DVNr, '''' AS VergNr,	
		'''' AS DebitorNr ,'''' AS ArtStaat,'''' AS NameStaat

SELECT ''Otto Luft‐ u. Klimatechnik'' AS Name1,''GmbH &amp; Co. KG'' AS Name2,'''' AS Name3,'''' AS Name4,
		''Edertalstraße 22'' AS Strasse,''AS'' AS PLZ,''Bad Berleburg'' AS Ort,''Deutschland'' AS LandBez,
		'''' AS ILN,'''' AS AnsprPartner,''02755‐89‐0'' AS Telefon,''02755‐89‐190'' AS Fax,'''' AS Email,
		'''' AS UStIdent,'''' AS DVNr,'''' AS VergNr,'''' AS KreditorNr,'''' AS BieterNr,'''' AS ArtStaat,
		'''' AS NameStaat,'''' AS ArtBranche,'''' AS ArtBevBew,'''' AS ArtNU,'''' AS BGBez,'''' AS BGDatum,'''' AS BGNr

SELECT  ProjectNumber AS Name,ProjectDescription AS Bez,'''' AS Beschreib,''EUR'' AS Wae,
		''Euro'' AS WaeBez,isnull(ComissionNumber,'''') AS KostenNr,'''' AS Lokalit,'''' AS LokalNr,
		'''' AS LBKE FROM Project WHERE ProjectID = @ProjectID

SELECT	'''' AS Art,'''' AS SonderArt,'''' AS Wae,'''' AS WaeBez,'''' AS AngebDatum,'''' AS AngebUhrzeit,
		'''' AS ErDatum,'''' AS ErUhrzeit,'''' AS ZusEnde,'''' AS AbgabeOrt,'''' AS AusfBeginn,
		'''' AS AusfEnde,'''' AS AuftrNr,'''' AS AuftrDatum,'''' AS AbnahmeArt,'''' AS AbnahmeDatum,
		'''' AS GwlDauer,'''' AS GwlEinheit,'''' AS GwlEnde,'''' AS AusfProz,'''' AS GwlProz

SELECT  '''' AS NoCalcInPrj,'''' AS DistributeUPComp,'''' AS KalkTyp,'''' AS ZuschlTyp,'''' AS RoundingMethod,
		'''' AS RoundingAccuracy,'''' AS EFBLohn,'''' AS EFBStoffe,'''' AS EFBGeraete,'''' AS EFBSoKo,'''' AS EFBNU,
		'''' AS EFBLohnUmlage,'''' AS EFBStoffeUmlage,'''' AS EFBGeraeteUmlage,'''' AS EFBSoKoUmlage,'''' AS EFBNUUmlage,
		'''' AS EFBMittellohn,'''' AS EFBMittellohnMethod,'''' AS EFBLohnZusKo,'''' AS EFBLohnNebenKo,'''' AS EFBKalkLohn,
		'''' AS EFBGemeinkosten,'''' AS EFBVerrechnungslohn,'''' AS KalkKostenart1,'''' AS KalkKostenart2,'''' AS KalkKostenart3,
		'''' AS KalkKostenart4,'''' AS KalkKostenart5,'''' AS KalkKostenart6,'''' AS KalkMittellohnH,'''' AS KalkMittellohnM,
		'''' AS KalkWagnis,'''' AS KalkLohnIndex,'''' AS KalkMaterialIndex,'''' AS KalkRoherl,'''' AS KalkDeckung,'''' AS KalkSE,
		'''' AS KalkSV,'''' AS KoGroups

SELECT	'''' AS AbrArt,'''' AS AufmassInfo,'''' AS AuftrDatum,'''' AS AuftrNr,'''' AS BuchDatum,
		'''' AS BuchNrAG,'''' AS InstHaltAuftr,'''' AS Kostenstelle,'''' AS KTr,'''' AS Leistungzr,
		'''' AS LeistungzrBis,'''' AS Mandant,'''' AS ReAG,'''' AS ReArt,'''' AS ReBez,'''' AS ReDatum,
		'''' AS ReNr,'''' AS RePruef,'''' AS ReTyp,'''' AS ReZahl,'''' AS Sicherheitseinbehalt,'''' AS SkProz,
		'''' AS SkTage,'''' AS USt,'''' AS Wae,'''' AS WaeBez,'''' AS ZahlZiel 

SELECT	'''' AS AnfrArt,'''' AS AnfrNrKunde,'''' AS AngebNrLief,'''' AS BestNr,'''' AS ABNr,'''' AS ErDatum,
		'''' AS LiefArt,'''' AS LiefDatum,'''' AS LiefUhrzeit,'''' AS LiefWoche,'''' AS PrBindDatum,
		'''' AS VersArt,'''' AS Wae,'''' AS WaeBez,'''' AS BestZusText,'''' AS AbgabeDatum,'''' AS AbgabeWoche

DECLARE @Raster NVARCHAR(50),@Count INT =0
DECLARE @TEMP TABLE(LVGliedTyp1 NVARCHAR(10),LVGliedBez1 NVARCHAR(10),LVGliedLen1 INT,
					LVGliedTyp2 NVARCHAR(10),LVGliedBez2 NVARCHAR(10),LVGliedLen2 INT,
					LVGliedTyp3 NVARCHAR(10),LVGliedBez3 NVARCHAR(10),LVGliedLen3 INT,
					LVGliedTyp4 NVARCHAR(10),LVGliedBez4 NVARCHAR(10),LVGliedLen4 INT,
					LVGliedTyp5 NVARCHAR(10),LVGliedBez5 NVARCHAR(10),LVGliedLen5 INT,
					LVGliedTyp6 NVARCHAR(10),LVGliedBez6 NVARCHAR(10),LVGliedLen6 INT,
					LVGliedTyp7 NVARCHAR(10),LVGliedBez7 NVARCHAR(10),LVGliedLen7 INT)
SELECT @Raster = LV_Raster FROM Project WHERE ProjectID = @ProjectID
SELECT @Count = COUNT(*) from SplitString(@Raster,''.'')
IF(@Count > 5)
BEGIN
INSERT INTO @TEMP(LVGliedTyp1,LVGliedBez1,LVGliedLen1,
					LVGliedTyp2,LVGliedBez2,LVGliedLen2,
					LVGliedTyp3,LVGliedBez3,LVGliedLen3,
					LVGliedTyp4,LVGliedBez4,LVGliedLen4,
					LVGliedTyp5,LVGliedBez5,LVGliedLen5,
					LVGliedTyp6,LVGliedBez6,LVGliedLen6)
Values(''LVStufe'',''Titel'',2,
		''LVStufe'',''Titel'',2,
		''LVStufe'',''Titel'',2,
		''LVStufe'',''Titel'',2,
		''Position'',''Position'',4,
		''Index'',''Index'',1) 
END
ELSE IF(@Count > 4)
BEGIN
INSERT INTO @TEMP(LVGliedTyp1,LVGliedBez1,LVGliedLen1,
					LVGliedTyp2,LVGliedBez2,LVGliedLen2,
					LVGliedTyp3,LVGliedBez3,LVGliedLen3,
					LVGliedTyp4,LVGliedBez4,LVGliedLen4,
					LVGliedTyp5,LVGliedBez5,LVGliedLen5)
Values(''LVStufe'',''Titel'',2,
		''LVStufe'',''Titel'',2,
		''LVStufe'',''Titel'',2,
		''Position'',''Position'',4,
		''Index'',''Index'',1) 
END
ELSE IF(@Count > 3)
BEGIN
INSERT INTO @TEMP(LVGliedTyp1,LVGliedBez1,LVGliedLen1,
					LVGliedTyp2,LVGliedBez2,LVGliedLen2,
					LVGliedTyp3,LVGliedBez3,LVGliedLen3,
					LVGliedTyp4,LVGliedBez4,LVGliedLen4)
Values(''LVStufe'',''Titel'',2,
		''LVStufe'',''Titel'',2,
		''Position'',''Position'',4,
		''Index'',''Index'',1) 
END
ELSE IF(@Count > 2)
BEGIN
INSERT INTO @TEMP(LVGliedTyp1,LVGliedBez1,LVGliedLen1,
					LVGliedTyp2,LVGliedBez2,LVGliedLen2,
					LVGliedTyp3,LVGliedBez3,LVGliedLen3)
Values(''LVStufe'',''Titel'',2,
		''Position'',''Position'',4,
		''Index'',''Index'',1) 
END
SELECT	ProjectNumber AS LVName,ProjectDescription AS LVBez,CONVERT(VARCHAR(20),GETDATE(),101) AS Datum,'''' AS KurzLang,'''' AS AnzEPAnteile,'''' AS BezEPAnteil1,
		'''' AS BezEPAnteil2,'''' AS BezEPAnteil3,'''' AS BezEPAnteil4,'''' AS BezEPAnteil5,'''' AS BezEPAnteil6,
		'''' AS BezZeit,'''' AS AusfZeit,'''' AS KZPreis,'''' AS Summe,'''' AS Nachlass,'''' AS SB,'''' AS SummePsch,
		'''' AS USt,'''' AS BruttoSumme,'''' AS Skonto,'''' AS SkontoTage,'''' AS PosAnz,
		
		ISNULL(LVGliedTyp1,'''') AS LVGliedTyp1,ISNULL(LVGliedBez1,'''') AS LVGliedBez1,
		
		case when LVGliedLen1 = 0 then '''' 
		when LVGliedLen1 is null then '''' 
		else LVGliedLen1 end AS LVGliedLen1,
		
		ISNULL(LVGliedTyp2,'''') AS LVGliedTyp2,ISNULL(LVGliedBez2,'''') AS LVGliedBez2,
		
		case when LVGliedLen2 = 0 then '''' 
		when LVGliedLen2 is null then '''' 
		else LVGliedLen2 end AS LVGliedLen2,
		
		ISNULL(LVGliedTyp3,'''') AS LVGliedTyp3,ISNULL(LVGliedBez3,'''') AS LVGliedBez3,

		case when LVGliedLen3 = 0 then '''' 
		when LVGliedLen3 is null then ''''
		else LVGliedLen3 end AS LVGliedLen3,
		
		ISNULL(LVGliedTyp4,'''') AS LVGliedTyp4,ISNULL(LVGliedBez4,'''') AS LVGliedBez4,

		case when LVGliedLen4 = 0 then '''' 
		when LVGliedLen4 is null then ''''
		else LVGliedLen4 end AS LVGliedLen4,
		
		ISNULL(LVGliedTyp5,'''') AS LVGliedTyp5,ISNULL(LVGliedBez5,'''') AS LVGliedBez5,
		
		case when LVGliedLen5 = 0 then '''' 
		when LVGliedLen5 is null then ''''
		else LVGliedLen5 end AS LVGliedLen5,

		ISNULL(LVGliedTyp6,'''') AS LVGliedTyp6,ISNULL(LVGliedBez6,'''') AS LVGliedBez6,
		
		case when LVGliedLen6 = 0 then '''' 
		when LVGliedLen6 is null then ''''
		else LVGliedLen6 end AS LVGliedLen6,

		ISNULL(LVGliedTyp7,'''') AS LVGliedTyp7,ISNULL(LVGliedBez7,'''') AS LVGliedBez7,
		
		case when LVGliedLen7 = 0 then '''' 
		when LVGliedLen7 is null then ''''
		else LVGliedLen7 End AS LVGliedLen7

		from Project,@TEMP where ProjectID = @ProjectID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Import]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Import]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Import]    
@ProjectID INT,    
@dtImport AS Project_Import READONLY,    
@Raster nvarchar(50)    
AS    
BEGIN    
 DECLARE @ERaster nvarchar(50) = NULL    
 SELECT @ERaster = LV_Raster from Project where ProjectID = @ProjectID    
 IF(@ERaster IS NULL OR @ERaster = '''')    
  BEGIN    
   IF NOT EXISTS(SELECT 1 FROM LVRaster WHERE LVRasterName = @Raster)    
   BEGIN    
    INSERT INTO LVRaster(LVRasterName) VALUES (@Raster)    
   END    
   UPDATE Project SET LV_Raster = @Raster WHERE ProjectID = @ProjectID    
  END    
 ELSE IF(@Raster != @ERaster)    
  BEGIN    
   SELECT ''Selected file raster is incompatible with selected project raster''    
   return    
  END    
  IF EXISTS(SELECT 1 FROM @dtImport WHERE ParentOz NOT IN(SELECT OZ FROM @dtImport) AND ParentOz != '''')    
  BEGIN    
   IF EXISTS(SELECT 1 FROM @dtImport WHERE ParentOz NOT IN(SELECT Position_OZ FROM Position WHERE ProjectID = @ProjectID) AND ParentOz != '''')    
   BEGIN    
    SELECT ''Selected positions titles are not matching''    
    return    
   END    
  END    
 DECLARE @dt AS TABLE(PositionOZ nvarchar(50))    
 DECLARE @Count INT = 0    
 INSERT INTO @dt    
 SELECT Position_OZ FROM Position WHERE Position_OZ IN (SELECT OZ FROM @dtImport) AND ProjectID = @ProjectID    
 SELECT @Count = COUNT(*) FROM @dt    
 IF(@Count = 0)    
  BEGIN    
       
   INSERT INTO Position(ProjectID,Position_OZ,ShortDescription,PositionKZ,Menge,DetailKZ,ME,LVSection,Title)    
   SELECT @ProjectID,OZ,Kurztext,Art,Menge,0,Einheit,Nachlass,Title
   FROM @dtImport WHERE OZ != '''' AND Art = ''NG''    
       
    INSERT INTO Position(ProjectID,Position_OZ,ShortDescription,PositionKZ,Menge,DetailKZ,ME,
							LVSection,MA_Multi1,MA_multi2,MA_multi3,MA_multi4,MO_multi1,MO_multi2,MO_multi3,MO_multi4,    
							MA_selbstkostenMulti,MA_verkaufspreis_Multi,MO_selbstkostenMulti,MO_verkaufspreisMulti,MA,MO,
							MA_einkaufspreis_lck,MA_selbstkosten_lck,MA_verkaufspreis_lck,MO_Einkaufspreis_lck,  
							MO_selbstkosten_lck,MO_verkaufspreis_lck,Faktor,Title)    
   SELECT @ProjectID,OZ,Kurztext,Art,Menge,0,Einheit,Nachlass,1,1,1,1,1,1,1,1,1,1,1,1,''X'',''X'',0,0,0,0,0,0,1,Title
   FROM @dtImport WHERE OZ != '''' AND Art != ''NG''    
       
   UPDATE    
    Position    
   SET    
    Position.Parent_OZ = P1.ParentID
   FROM    
   (    
   SELECT I.OZ,P.PositionID  AS ParentID
   FROM @dtImport I     
   INNER JOIN Position P     
   ON I.ParentOZ = P.Position_OZ AND P.ProjectID = @ProjectID    
   ) AS P1    
   WHERE Position.Position_OZ = P1.OZ AND Position.ProjectID = @ProjectID    
       
   INSERT INTO Position_Longdesc(positionID,Longdiscription)    
   SELECT P.PositionID,D.Langtext FROM @dtImport D INNER JOIN Position P     
   ON D.OZ = P.Position_OZ WHERE P.ProjectID = @ProjectID    
       
   SELECT @ProjectID    
  END    
 ELSE    
  BEGIN    
   DECLARE @EPositionOZ NVARCHAR(50)    
   SELECT TOP(1) @EPositionOZ = PositionOZ FROM @dt    
   SELECT @EPositionOZ + '' Position is already exists under selected project''    
  END    
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_LVSection]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_LVSection]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_LVSection]
@LVSection nvarchar(20),
@ProjectID int
As
begin

declare @LVSectionID int = 0
IF NOT EXISTS(SELECT 1 FROM LVSection WHERE LVSectionName = @LVSection AND ProjectID = @ProjectID)
				BEGIN
					INSERT INTO LVSection(LVSectionName,ProjectID)
					VALUES (@LVSection,@ProjectID)
					
					IF(LEFT(@LVSection,3) = ''NTM'')
						BEGIN
							SELECT @LVSectionID = LVSectionID FROM LVSection 
							WHERE LVSectionName = ''NTM'' AND ProjectID = @ProjectID
						END
					ELSE
						BEGIN
							SELECT @LVSectionID = LVSectionID FROM LVSection 
							WHERE LVSectionName = ''NT'' AND ProjectID = @ProjectID
						END
					INSERT INTO LvSectionDetails(LVSectionID,SNO)
					VALUES(@LVSectionID,RIGHT(@LVSection,3))
				END

end' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Position]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Position]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Position]	
@XMLPositions XML,
@LongDescription NVARCHAR(MAX) = NULL
AS
BEGIN
       SET NOCOUNT ON;
       BEGIN TRY
              BEGIN TRAN
			    --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @positionId INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			    EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLPositions 
				print ''test''
			  SELECT * INTO #Temp from (SELECT 
			  ab.PositionID,
              ab.ProjectID,ab.PositionOZ,ab.ParentOZ,ab.Title,ab.ShortDescription,ab.LongDescription,ab.PositionKZ
              ,ab.LVSection,ab.WG,ab.WA,ab.WI,ab.Menge,ab.ME,ab.Fabricate,ab.LiefrantMA, ab.[Type],ab.LVStatus
              ,ab.UserID 
              ,p.PositionID AS ParentPositonID,ab.DetailKZ
			  ,ISNULL(p.GetTitle,'''') + ''~'' + ISNULL(ab.Title,'''') as GetTitle,
			  ab.SurchargePer,ab.SurchargeFrom,ab.SurchargeTO,ab.surchargePercentageMO,
			  ab.ValidityDate,ab.KalkMenge,ab.MECost,ab.MA,ab.MO,ab.Dim1,ab.Dim2,ab.Dim3,
			  ab.Mins,ab.Faktor,  ab.LPMA,ab.LPMO,
			  ab.Multi1MA,ab.Multi1MO,ab.Multi2MA,ab.Multi2MO,ab.Multi3MA,ab.Multi3MO,ab.Multi4MA,ab.Multi4MO,ab.Multi5MA,ab.Multi5MO,
			  ab.EinkaufspreisMA,ab.EinkaufspreisMO,ab.SelbstkostenMultiMA,ab.SelbstkostenMultiMO,ab.SelbstkostenValueMA,ab.SelbstkostenValueMO,
			  ab.VerkaufspreisMultiMA,ab.VerkaufspreisMultiMO,ab.VerkaufspreisValueMA,ab.VerkaufspreisValueMO,AB.StdSatz,ab.PreisText,
			  ab.EinkaufspreisLockMA,ab.EinkaufspreisLockMO,ab.SelbstkostenLockMA,ab.SelbstkostenLockMO,ab.VerkaufspreisLockMA,ab.VerkaufspreisLockMO,
			  ab.DocuwareLink1,ab.DocuwareLink2,ab.DocuwareLink3,ab.GrandTotalME,ab.GrandTotalMO,ab.FinalGB,ab.EP
              FROM OPENXML (@XmlDocumentHandle, ''/Nouns/Position'',2)  
                              WITH (
                              PositionID INT,  ProjectID INT,PositionOZ NVARCHAR(100),ParentOZ NVARCHAR(100),Title NVARCHAR(100),ShortDescription NVARCHAR(1000),
                              LongDescription VARBINARY(MAX),PositionKZ NVARCHAR(10),DetailKZ NVARCHAR(10),LVSection NVARCHAR(10), WG INT,WA INT,WI INT,
                              Menge DECIMAL(10,3),ME NVARCHAR(50),  Fabricate NVARCHAR(100),LiefrantMA NVARCHAR(50), [Type] NVARCHAR(50),  LVStatus NVARCHAR(50),UserID NVARCHAR(10),SurchargePer DECIMAL(10,3),
							 SurchargeFrom NVARCHAR(20),SurchargeTO NVARCHAR(20),surchargePercentageMO DECIMAL(10,3),ValidityDate DateTime,KalkMenge INT,MECost DECIMAL(10,3),
							  MA NVARCHAR(10),MO NVARCHAR(10),Dim1 INT,Dim2 INT,Dim3 INT,Mins DECIMAL(10,3),Faktor DECIMAL(10,3),LPMA DECIMAL(10,3),LPMO DECIMAL(10,3),  
                              Multi1MA DECIMAL(10,3),Multi1MO DECIMAL(10,3),Multi2MA DECIMAL(10,3),Multi2MO DECIMAL(10,3),Multi3MA DECIMAL(10,3),Multi3MO DECIMAL(10,3),
							 Multi4MA DECIMAL(10,3),Multi4MO DECIMAL(10,3),Multi5MA DECIMAL(10,3),Multi5MO DECIMAL(10,3),EinkaufspreisMA DECIMAL(10,3),
							 EinkaufspreisMO DECIMAL(10,3),SelbstkostenMultiMA DECIMAL(10,3),SelbstkostenMultiMO DECIMAL(10,3),SelbstkostenValueMA DECIMAL(10,3),
							 SelbstkostenValueMO DECIMAL(10,3),VerkaufspreisMultiMA DECIMAL(10,3),VerkaufspreisMultiMO DECIMAL(10,3),VerkaufspreisValueMA DECIMAL(10,3),
							 VerkaufspreisValueMO DECIMAL(10,3),StdSatz DECIMAL(10,3),PreisText NVARCHAR(MAX),
							 EinkaufspreisLockMA BIT,EinkaufspreisLockMO BIT,SelbstkostenLockMA BIT,SelbstkostenLockMO BIT,VerkaufspreisLockMA BIT,VerkaufspreisLockMO BIT,
							 DocuwareLink1 NVARCHAR(MAX),DocuwareLink2 NVARCHAR(MAX),DocuwareLink3 NVARCHAR(MAX),GrandTotalME DECIMAL(10,3),GrandTotalMO DECIMAL(10,3),FinalGB DECIMAL(10,3),EP DECIMAL(10,3)
							 )
                              AB LEFT JOIN 
							  Position P
							  ON AB.ParentOZ = P.Position_OZ and ab.ProjectID=p.ProjectID
							 ) as t 
            
			
             DECLARE @PositionOZ NVARCHAR(500), @ParentOZ INT = NULL,@Count int
			 SELECT @PositionOZ = PositionOZ, @ParentOZ = ParentPositonID FROM #Temp
			 SELECT @Count = COUNT(1) from SplitString(@PositionOZ,''.'') 
			 IF	(@Count > 2)
				 BEGIN
					IF (@ParentOZ IS NULL)
					BEGIN
						SELECT ''Title or SubTitle does not exist''
						return;
					END
				 END
			DECLARE @LVSection NVARCHAR(100),@ProjectID INT,@LVSectionID int
			SELECT @LVSection = LVSection,@ProjectID = ProjectID FROM #Temp
			
			IF NOT EXISTS(SELECT 1 FROM LVSection WHERE LVSectionName = @LVSection AND ProjectID = @ProjectID)
				BEGIN
					INSERT INTO LVSection(LVSectionName,ProjectID)
					VALUES (@LVSection,@ProjectID)
					
					IF(LEFT(@LVSection,3) = ''NTM'')
						BEGIN
							SELECT @LVSectionID = LVSectionID FROM LVSection 
							WHERE LVSectionName = ''NTM'' AND ProjectID = @ProjectID
						END
					ELSE
						BEGIN
							SELECT @LVSectionID = LVSectionID FROM LVSection 
							WHERE LVSectionName = ''NT'' AND ProjectID = @ProjectID
						END
					INSERT INTO LvSectionDetails(LVSectionID,SNO)
					VALUES(@LVSectionID,RIGHT(@LVSection,3))
				END
			DECLARE @PositionKZ NVARCHAR(10)
			SELECT TOP(1) @PositionKZ = PositionKZ FROM #Temp
			IF(@PositionKZ = ''NG'' OR @PositionKZ = ''ZS'' or @PositionKZ = ''Z'')
				BEGIN
					MERGE Position AS T
					  USING #temp as  SRC ON T.PositionID = SRC.PositionID
					  WHEN NOT MATCHED THEN
					  INSERT
						 (
								   ProjectID,Position_OZ,Parent_OZ,Title,ShortDescription,PositionKZ,DetailKZ,
								   LVSection,LVStatus,Created_By,Fabricate,LiefrantMA, GetTitle,
	             					 surchargePercentage,surchargefrom,surchargeto,surchargePercentage_MO,PreisText,
								  DocuwareLink1,DocuwareLink2,DocuwareLink3
								   )
					  VALUES
							 (
								   SRC.ProjectID,SRC.PositionOZ,SRC.ParentPositonID,SRC.Title,SRC.ShortDescription,SRC.PositionKZ,SRC.DetailKZ,
								   SRC.LVSection,SRC.LVStatus,SRC.UserID,SRC.Fabricate,SRC.LiefrantMA, SRC.GetTitle,
									SRC.SurchargePer,SRC.SurchargeFrom,SRC.SurchargeTO,SRC.surchargePercentageMO,
									SRC.PreisText,								 
									 SRC.DocuwareLink1,SRC.DocuwareLink2,SRC.DocuwareLink3
								   )
					  WHEN MATCHED THEN
					  UPDATE SET 
					  T.ProjectID = SRC.ProjectID,
					  T.Position_OZ = SRC.PositionOZ,
					  T.Parent_OZ = SRC.ParentPositonID,
					  T.Title = SRC.Title,
					  T.GetTitle = SRC.GetTitle,
					  T.ShortDescription = SRC.ShortDescription,
					  T.PositionKZ = SRC.PositionKZ,
					  T.Fabricate = SRC.Fabricate,
					  T.LiefrantMA = SRC.LiefrantMA,
					 T.DetailKZ = SRC.DetailKZ,
					  T.LVSection = SRC.LVSection,
					  T.LVStatus = SRC.LVStatus,
					  T.LastUpdated_By = SRC.UserID,
					  T.surchargePercentage = SRC.SurchargePer,
					  T.surchargefrom =	SRC.SurchargeFrom,
					  T.surchargeto = SRC.SurchargeTO,
					  T.surchargePercentage_MO = SRC.surchargePercentageMO,
					  T.PreisText = SRC.PreisText,
					  T.DocuwareLink1 = SRC.DocuwareLink1,
					  T.DocuwareLink2 = SRC.DocuwareLink2,
					  T.DocuwareLink3 = SRC.DocuwareLink3,
					  T.GrandTotalME = SRC.GrandTotalME,
					  T.GrandTotalMO = SRC.GrandTotalMO,
					  T.FinalGB = SRC.FinalGB,
					  T.EP=SRC.EP
					  OUTPUT
							 INSERTED.PositionID into @Output;
				END
			ELSE
			BEGIN
             MERGE Position AS T
              USING #temp as  SRC ON T.PositionID = SRC.PositionID
              WHEN NOT MATCHED THEN
              INSERT
                 (
                           ProjectID,Position_OZ,Parent_OZ,Title,ShortDescription,PositionKZ,DetailKZ,
                           LVSection,WG,WA,WI,Menge,ME,[Type],LVStatus,Created_By,Fabricate,LiefrantMA, GetTitle,
	             			 surchargePercentage,surchargefrom,surchargeto,surchargePercentage_MO,
						   validitydate,MA,MO,minutes,Faktor,
						   MA_listprice,MO_listprice,
						   MA_Multi1,MA_multi2,MA_multi3,MA_multi4,MA_multi5,
						   MA_einkaufspreis,MA_selbstkosten,MA_selbstkostenMulti,MA_verkaufspreis,MA_verkaufspreis_Multi,
						   MO_multi1,MO_multi2,MO_multi3,MO_multi4,MO_multi5,
						   MO_Einkaufspreis,MO_selbstkostenMulti,MO_selbstkosten,MO_verkaufspreisMulti,MO_verkaufspreis,std_satz,
						   PreisText,MA_einkaufspreis_lck,MA_selbstkosten_lck,MA_verkaufspreis_lck,
						   MO_Einkaufspreis_lck,MO_selbstkosten_lck,MO_verkaufspreis_lck,A,B,L,DocuwareLink1,DocuwareLink2,DocuwareLink3,GrandTotalME,GrandTotalMO,FinalGB,EP
						   )
              VALUES
                     (
                           SRC.ProjectID,SRC.PositionOZ,SRC.ParentPositonID,SRC.Title,SRC.ShortDescription,SRC.PositionKZ,SRC.DetailKZ,
                           SRC.LVSection,SRC.WG,SRC.WA,SRC.WI,SRC.Menge,SRC.ME,SRC.[Type],SRC.LVStatus,SRC.UserID,SRC.Fabricate,SRC.LiefrantMA, SRC.GetTitle,
							SRC.SurchargePer,SRC.SurchargeFrom,SRC.SurchargeTO,SRC.surchargePercentageMO,
							SRC.ValidityDate,SRC.MA,SRC.MO,SRC.Mins,SRC.Faktor,
							  SRC.LPMA,SRC.LPMO,  
                              SRC.Multi1MA,SRC.Multi2MA,SRC.Multi3MA,SRC.Multi4MA,SRC.Multi5MA,
                             SRC.EinkaufspreisMA,SRC.SelbstkostenValueMA,SRC.SelbstkostenMultiMA,SRC.VerkaufspreisValueMA,SRC.VerkaufspreisMultiMA,
							 SRC.Multi1MO,SRC.Multi2MO,SRC.Multi3MO,SRC.Multi4MO,SRC.Multi5MO,
							 SRC.EinkaufspreisMO,SRC.SelbstkostenMultiMO,SRC.SelbstkostenValueMO,SRC.VerkaufspreisMultiMO,SRC.VerkaufspreisValueMO,SRC.StdSatz,SRC.PreisText,
							 SRC.EinkaufspreisLockMA,SRC.SelbstkostenLockMA,SRC.VerkaufspreisLockMA,SRC.EinkaufspreisLockMO,SRC.SelbstkostenLockMO,SRC.VerkaufspreisLockMO,
							 SRC.Dim1,SRC.Dim2,SRC.Dim3,SRC.DocuwareLink1,SRC.DocuwareLink2,SRC.DocuwareLink3,SRC.GrandTotalME,SRC.GrandTotalMO,SRC.FinalGB,SRC.EP
						   )
              WHEN MATCHED THEN
              UPDATE SET 
              T.ProjectID = SRC.ProjectID,
              T.Position_OZ = SRC.PositionOZ,
              T.Parent_OZ = SRC.ParentPositonID,
			  T.Title = SRC.Title,
			  T.GetTitle = SRC.GetTitle,
              T.ShortDescription = SRC.ShortDescription,
              T.PositionKZ = SRC.PositionKZ,
			  T.Fabricate = SRC.Fabricate,
			  T.LiefrantMA = SRC.LiefrantMA,
			 T.DetailKZ = SRC.DetailKZ,
			  T.LVSection = SRC.LVSection,
              T.WG = SRC.WG,
              T.WA = SRC.WA,
              T.WI = SRC.WI,
              T.Menge = SRC.Menge,
              T.ME = SRC.ME,
              T.[Type] = SRC.[Type],
              T.LVStatus = SRC.LVStatus,
              T.LastUpdated_By = SRC.UserID,
			  T.surchargePercentage = SRC.SurchargePer,
			  T.surchargefrom =	SRC.SurchargeFrom,
			  T.surchargeto = SRC.SurchargeTO,
			  T.surchargePercentage_MO = SRC.surchargePercentageMO,
			  T.validitydate = SRC.ValidityDate,  
			  T.MA = SRC.MA,
			  T.MO = SRC.MO,
			  T.minutes = SRC.Mins,
			  T.Faktor = SRC.Faktor,
			  T.MA_listprice = SRC.LPMA,
			  T.MO_listprice = SRC.LPMO,
			  T.MA_Multi1 = SRC.Multi1MA,
			  T.MA_multi2 = SRC.Multi2MA,
			  T.MA_multi3 = SRC.Multi3MA,
			  T.MA_multi4 = SRC.Multi4MA,
			  T.MA_multi5 = SRC.Multi5MA,
			  T.MA_einkaufspreis = SRC.EinkaufspreisMA,
			  T.MA_selbstkosten = SRC.SelbstkostenValueMA,
			  T.MA_selbstkostenMulti = SRC.SelbstkostenMultiMA,
			  T.MA_verkaufspreis = SRC.VerkaufspreisValueMA,
			  T.MA_verkaufspreis_Multi = SRC.VerkaufspreisMultiMA,
			  T.MO_multi1 = SRC.Multi1MO,
			  T.MO_multi2 = SRC.Multi2MO,
			  T.MO_multi3 = SRC.Multi3MO,
			  T.MO_multi4 = SRC.Multi4MO,
			  T.MO_multi5 = SRC.Multi5MO,
			  T.MO_Einkaufspreis = SRC.EinkaufspreisMO,
			  T.MO_selbstkostenMulti = SRC.SelbstkostenMultiMO,
			  T.MO_selbstkosten = SRC.SelbstkostenValueMO,
			  T.MO_verkaufspreisMulti = SRC.VerkaufspreisMultiMO,
			  T.MO_verkaufspreis = SRC.VerkaufspreisValueMO,
			  T.PreisText = SRC.PreisText,
			  T.MA_einkaufspreis_lck = SRC.EinkaufspreisLockMA,
			  T.MA_selbstkosten_lck = SRC.SelbstkostenLockMA,
			  T.MA_verkaufspreis_lck = SRC.VerkaufspreisLockMA,
			  T.MO_Einkaufspreis_lck = SRC.EinkaufspreisLockMO,
			  T.MO_selbstkosten_lck = SRC.SelbstkostenLockMO,
			  T.MO_verkaufspreis_lck = SRC.VerkaufspreisLockMO,
			  T.std_satz = SRC.StdSatz,
			  T.A = SRC.Dim1,
              T.B = SRC.Dim2,
			  T.L = SRC.Dim3,
			  T.DocuwareLink1 = SRC.DocuwareLink1,
			  T.DocuwareLink2 = SRC.DocuwareLink2,
			  T.DocuwareLink3 = SRC.DocuwareLink3,
			  T.GrandTotalME = SRC.GrandTotalME,
			  T.GrandTotalMO = SRC.GrandTotalMO,
			  T.FinalGB = SRC.FinalGB,
			  T.EP = SRC.EP
			  OUTPUT
                     INSERTED.PositionID into @Output;
			END
              EXEC sp_xml_removedocument @XmlDocumentHandle
       
             select @positionId=ID FROM @Output
			    
				  IF NOT EXISTS (SELECT positionID FROM Position_Longdesc WHERE positionID = @positionId)
				    BEGIN
				       INSERT INTO Position_Longdesc(positionID,Longdiscription) VALUES (@positionId,@LongDescription)
				    END
				 SELECT * FROM @Output
              COMMIT TRAN
       END TRY
       BEGIN CATCH
              SELECT ERROR_MESSAGE() AS ErrorMessage
              IF(@@TRANCOUNT > 0)
                     ROLLBACK TRAN
       END CATCH
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Project]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Project]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Project]
@ProjectID INT = -1,
@Location NVARCHAR(50),
@ProjectNumber NVARCHAR(50),
@ComissionNumber NVARCHAR(50),
@CustomerID INT,
@ProjectDescription NVARCHAR(MAX),
@PlannerID INT,
@LV_Raster NVARCHAR(50),
@LV_Raster_GAEB NVARCHAR(50),
@LV_Sprung INT,
@Intern_X DECIMAL(10,2),
@Intern_S DECIMAL(10,2),
@Vat DECIMAL(10,2),
@Submit_Location NVARCHAR(100),
@Submit_Date DATETIME,
@Submit_Time TIME,
@Estimated_LV INT,
@Round_Off INT,
@Remarks NVARCHAR(MAX),
@Project_Discount DECIMAL(10,2),
@Lock_LVHierarchy BIT,
@UserID INT,
@CustomerName NVARCHAR(100),
@CustomerNumber NVARCHAR(100),
@PlannerName NVARCHAR(100),
@ProjectStartDate DateTime,
@ProjectEndDate DateTime
AS
BEGIN
SET NOCOUNT ON;

if @ComissionNumber is null
begin
if exists(select 1 from Project where ProjectNumber = ProjectNumber)
begin
select ''ProjectNumber is already exists''
return
end
end

if @ComissionNumber is not null
begin
if exists(select 1 from Project where ComissionNumber = @ComissionNumber)
begin
select ''ComissionNumber is Already Exists''
end
end

	BEGIN TRY
		BEGIN TRAN
			IF(@ProjectID <= 0)
				BEGIN
					INSERT INTO Project
					(
						Location,
						ProjectNumber,
						CustomerID,
						ProjectDescription,
						PlannerID,
						LV_Raster,
						LV_Raster_GAEB,
						LV_Sprung,
						Intern_X,
						Intern_S,
						Vat,
						Submit_Location,
						Submit_Date,
						Submit_Time,
						Estimated_LV,
						Round_Off,
						Remarks,
						Project_Discount,
						Lock_LVHierarchy,
						Created_By,
						Created_Date,
						PlannerName,
						CustomerName,
						CustomerNumber,
						ProjectStartDate,
						ProjectEndDate
					)
					VALUES
					(
						@Location,
						@ProjectNumber,
						@CustomerID,
						@ProjectDescription,
						@PlannerID,
						@LV_Raster,
						@LV_Raster_GAEB,
						@LV_Sprung,
						@Intern_X,
						@Intern_S,
						@Vat,
						@Submit_Location,
						@Submit_Date,
						@Submit_Time,
						@Estimated_LV,
						@Round_Off,
						@Remarks,
						@Project_Discount,
						@Lock_LVHierarchy,
						@UserID,
						GETDATE(),
						@PlannerName,
						@CustomerName,
						@CustomerNumber,
						@ProjectStartDate,
						@ProjectEndDate
					)
				SET @ProjectID = SCOPE_IDENTITY()

				INSERT INTO LVSection (LVSectionName,ProjectID) VALUES(''HA'',@ProjectID)
				INSERT INTO LVSection (LVSectionName,ProjectID) VALUES(''NT'',@ProjectID)
				INSERT INTO LVSection (LVSectionName,ProjectID) VALUES(''NTM'',@ProjectID)

				END
		ELSE
			BEGIN
				IF(@ComissionNumber = '''')
					SET @ComissionNumber = NULL
				ELSE
					BEGIN
						UPDATE Position SET LVSection = ''HA'' WHERE ProjectID = @ProjectID AND ISNULL(PositionKZ,''zzz'') != ''zzz''
						UPDATE Position SET 
						LVStatus = ''B'',
						MA_selbstkosten_lck = 1,
						MO_selbstkosten_lck = 1,
						MA_einkaufspreis_lck = 1,
						MO_Einkaufspreis_lck = 1,
						MA_verkaufspreis_lck = 1,
						MO_verkaufspreis_lck = 1
						WHERE ProjectID = @ProjectID AND ISNULL(PositionKZ,''zzz'') != ''zzz'' AND LVStatus != ''A''
						
					END
				UPDATE Project 
					SET 
					    Project.ProjectNumber=@ProjectNumber,
						Project.ComissionNumber = @ComissionNumber,
						Project.Location = @Location,
						Project.CustomerID = @CustomerID,
						Project.ProjectDescription = @ProjectDescription,
						Project.PlannerID = @PlannerID,
						Project.LV_Raster = @LV_Raster,
						Project.LV_Sprung = @LV_Sprung,
						Project.Intern_X = @Intern_X,
						Project.Intern_S = @Intern_S,
						Project.Vat = @Vat,
						Project.Submit_Location = @Submit_Location,
						Project.Submit_Date = @Submit_Date,
						Project.Submit_Time = @Submit_Time,
						Project.Estimated_LV = @Estimated_LV,
						Project.Round_Off = @Round_Off,
						Project.Remarks = @Remarks,
						Project.Project_Discount = @Project_Discount,
						Project.Lock_LVHierarchy = @Lock_LVHierarchy,
						Project.LastUpdated_By = @UserID,
						Project.LastUpdated_Date = GETDATE(),
						Project.PlannerName = @PlannerName,
						Project.CustomerName = @CustomerName,
						Project.CustomerNumber = @CustomerNumber,
						Project.ProjectStartDate = @ProjectStartDate,
						Project.ProjectEndDate = @ProjectEndDate
					WHERE Project.ProjectID = @ProjectID
			END
		SELECT @ProjectID
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMessage
        IF(@@TRANCOUNT > 0)
		   ROLLBACK TRAN
	END CATCH
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_BulkProcess_ActionA]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_BulkProcess_ActionA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Upd_BulkProcess_ActionA]
@Bulk_Process_ActionA_Table As [dbo].Bulk_Process_ActionA Readonly,
@projectID INT,
@Position_Type varchar(50),
@MA_selbstkostenMulti DECIMAL(10,3),
@MO_selbstkostenMulti DECIMAL(10,3),
@MA_verkaufspreis_Multi DECIMAL(10,3),
@MO_verkaufspreisMulti DECIMAL(10,3)
AS
BEGIN

CREATE TABLE #temp
(
[id] int identity(1,1),
[P_id] int ,
[MA_selbstkosten] DECIMAL(10,3),
[MO_selbstkosten] DECIMAL(10,3),
[MA_verkaufspreis] DECIMAL(10,3),
[MO_verkaufspreis] DECIMAL(10,3)

)

			INSERT INTO #temp select * from @Bulk_Process_ActionA_Table

  if(@Position_Type =''Remove'')
  BEGIN
      
	            IF(@MA_selbstkostenMulti=1)
		        BEGIN		    

		             UPDATE Position
                     SET MA_selbstkostenMulti = @MA_selbstkostenMulti,
					  MA_selbstkosten = dbo.Cal_MultiValue(@MA_selbstkostenMulti,Position.MA_einkaufspreis)
					 FROM #temp t
					 WHERE Position.PositionID =t.P_id AND MA_selbstkosten_lck=0
      
					 update Position
					 set MA_verkaufspreis = dbo.Cal_MultiValue(Position.MA_verkaufspreis_Multi,Position.MA_selbstkosten),
					 Position.EP = Position.MA_verkaufspreis + Position.MO_verkaufspreis,
					 Position.FinalGB = (Position.MA_verkaufspreis + Position.MO_verkaufspreis) * Menge
					 from #temp t WHERE Position.PositionID =t.P_id AND MA_selbstkosten_lck=0
              END
			  IF(@MO_selbstkostenMulti=1)
		        BEGIN		    

		             UPDATE Position
			         SET MO_selbstkostenMulti=@MO_selbstkostenMulti,
					  MO_selbstkosten = dbo.Cal_MultiValue(@MO_selbstkostenMulti,Position.MO_Einkaufspreis)				               
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id AND MO_selbstkosten_lck=0

					 update Position
				     set MO_verkaufspreis = dbo.Cal_MultiValue(Position.MO_verkaufspreisMulti,Position.MO_selbstkosten),
				     Position.EP = Position.MA_verkaufspreis + Position.MO_verkaufspreis,
					 Position.FinalGB = (Position.MA_verkaufspreis + Position.MO_verkaufspreis) * Menge
					 from #temp t WHERE Position.PositionID =t.P_id AND MO_selbstkosten_lck=0
              END
			  IF(@MA_verkaufspreis_Multi=1)
		        BEGIN		    

		             UPDATE Position
			         SET MA_verkaufspreis_Multi=@MA_verkaufspreis_Multi,
					 MA_verkaufspreis = dbo.Cal_MultiValue(@MA_verkaufspreis_Multi,Position.MA_selbstkosten),
					 Position.EP = Position.MA_verkaufspreis + Position.MO_verkaufspreis,
					 Position.FinalGB = (Position.MA_verkaufspreis + Position.MO_verkaufspreis) * Menge	
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id AND MA_verkaufspreis_lck=0
              END
			  IF(@MO_verkaufspreisMulti=1)
		        BEGIN		    

		             UPDATE Position
			         SET MO_verkaufspreisMulti=@MO_verkaufspreisMulti,	
					 MO_verkaufspreis = dbo.Cal_MultiValue(@MO_verkaufspreisMulti,Position.MO_selbstkosten),
					 Position.EP = Position.MA_verkaufspreis + Position.MO_verkaufspreis,
					 Position.FinalGB = (Position.EP) * Menge         
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id AND MO_verkaufspreis_lck=0
              END
 END

 if(@Position_Type !=''Remove'')
 BEGIN
		  IF(@MA_selbstkostenMulti!=0.0)
		        BEGIN		    

		             UPDATE Position
			         SET MA_selbstkostenMulti = @MA_selbstkostenMulti,
					 MA_selbstkosten = dbo.Cal_MultiValue(@MA_selbstkostenMulti,Position.MA_einkaufspreis)					    
			         FROM #temp t
			         WHERE Position.PositionID =t.P_id AND MA_selbstkosten_lck=0

					 update Position
				     set MA_verkaufspreis = dbo.Cal_MultiValue(Position.MA_verkaufspreis_Multi,Position.MA_selbstkosten),
				     Position.EP = Position.MA_verkaufspreis + Position.MO_verkaufspreis,
					 Position.FinalGB = (Position.MA_verkaufspreis + Position.MO_verkaufspreis) * Menge
					 from #temp t WHERE Position.PositionID =t.P_id AND MA_selbstkosten_lck=0
              END

			  IF(@MO_selbstkostenMulti!=0.0)
		        BEGIN		    

		             UPDATE Position
			         SET MO_selbstkostenMulti=@MO_selbstkostenMulti,
					 MO_selbstkosten = dbo.Cal_MultiValue(@MO_selbstkostenMulti,Position.MO_Einkaufspreis)             
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id AND MO_selbstkosten_lck=0

					 update Position
				     set MO_verkaufspreis = dbo.Cal_MultiValue(Position.MO_verkaufspreisMulti,Position.MO_selbstkosten),
					 Position.EP = Position.MA_verkaufspreis + Position.MO_verkaufspreis,
					 Position.FinalGB = (Position.MA_verkaufspreis + Position.MO_verkaufspreis) * Menge
					 from #temp t WHERE Position.PositionID =t.P_id AND MO_selbstkosten_lck=0
              END
			  IF(@MA_verkaufspreis_Multi!=0.0)
		        BEGIN		    

		             UPDATE Position
			         SET MA_verkaufspreis_Multi=@MA_verkaufspreis_Multi,
				     MA_verkaufspreis = dbo.Cal_MultiValue(@MA_verkaufspreis_Multi,Position.MA_selbstkosten),
					 Position.EP = Position.MA_verkaufspreis + Position.MO_verkaufspreis,
					 Position.FinalGB = (Position.MA_verkaufspreis + Position.MO_verkaufspreis) * Menge
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id AND MA_verkaufspreis_lck=0
              END
			  IF(@MO_verkaufspreisMulti!=0.0)
		        BEGIN		    

		             UPDATE Position
			         SET MO_verkaufspreisMulti=@MO_verkaufspreisMulti,
					 MO_verkaufspreis = dbo.Cal_MultiValue(@MO_verkaufspreisMulti,Position.MO_verkaufspreis),
					 Position.EP = Position.MA_verkaufspreis + Position.MO_verkaufspreis,
					 Position.FinalGB = (Position.MA_verkaufspreis + Position.MO_verkaufspreis) * Menge         
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id AND MO_verkaufspreis_lck=0
              END

		 --   UPDATE Position
			--SET MA_selbstkostenMulti = @MA_selbstkostenMulti,MO_selbstkostenMulti=@MO_selbstkostenMulti,MA_verkaufspreis_Multi=@MA_verkaufspreis_Multi,MO_verkaufspreisMulti=@MO_verkaufspreisMulti
			--FROM #temp T
			--JOIN Position
			--ON  Position.PositionID = T.P_id
			--WHERE Position.ProjectID=@projectID
		
  END
		  
       
 
	  DROP TABLE #temp 	  
END



' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_BulkProcess_ActionB]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_BulkProcess_ActionB]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Upd_BulkProcess_ActionB]
@Bulk_Process_ActionB_Table As [dbo].Bulk_Process_ActionB Readonly,
@projectID INT,
@Position_Type varchar(50),
@Menge varchar(50),
@MA NVARCHAR(10),
@MO NVARCHAR(10),
@PreisText NVARCHAR(200),
@Fabricate NVARCHAR(100),
@Type NVARCHAR(50),
@LiefrantMA NVARCHAR(50),
@WG varchar(50),
@WA varchar(50),
@WI varchar(50),
@LVSection NVARCHAR(10)
AS
BEGIN

CREATE TABLE #temp
(
[id] int identity(1,1),
[P_id] int ,
[Menge] varchar(50),
[MA] NVARCHAR(10),
[MO] NVARCHAR(10),
[PreisText] NVARCHAR(200),
[Fabricate] NVARCHAR(100),
[Type] NVARCHAR(50),
[LiefrantMA] NVARCHAR(50),
[WG] varchar(50),
[WA] varchar(50),
[WI] varchar(50),
[LVSection] NVARCHAR(10)
)

			INSERT INTO #temp select * from @Bulk_Process_ActionB_Table

  --if(@Position_Type =''Remove'')
  --BEGIN
      
	            IF(@Menge!='''') 
		        BEGIN		    

		             UPDATE Position
			         SET Menge = @Menge,					 
				     Position.FinalGB = (Position.MA_verkaufspreis + Position.MO_verkaufspreis) * @Menge					    
			         FROM #temp t
			         WHERE Position.PositionID =t.P_id

              END
			  IF(@MA!='''')
		        BEGIN		    

		             UPDATE Position
			         SET MA = @MA					    
			         FROM #temp t
			         WHERE Position.PositionID =t.P_id
              END
			  IF(@MA=''S'')
			  BEGIN
			       UPDATE Position
			         SET MO = @MO					    
			         FROM #temp t
			         WHERE Position.PositionID =t.P_id
			  END

			  IF(@MO!='''')
		        BEGIN		    

		             UPDATE Position
			         SET MO = @MO					    
			         FROM #temp t
			         WHERE Position.PositionID =t.P_id
              END
			  IF(@PreisText!='''')
		        BEGIN		    

		             UPDATE Position
			         SET PreisText=@PreisText			               
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id
              END
			  IF(@Fabricate!='''')
		        BEGIN		    

		             UPDATE Position
			         SET Fabricate=@Fabricate
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id
              END
			  IF(@Type!='''')
		        BEGIN		    

		             UPDATE Position
			         SET Type=@Type
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id
              END
			  IF(@LiefrantMA!='''')
		        BEGIN	
		             UPDATE Position
			         SET LiefrantMA=@LiefrantMA       
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id
              END
			  IF(@WG!='''')
		        BEGIN		    

		             UPDATE Position
			         SET WG=@WG       
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id
              END		
			 
			  IF(@WA!='''')
		        BEGIN		    

		             UPDATE Position
			         SET WA=@WA       
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id
              END
			  
			  IF(@WI!='''')
		        BEGIN		    

		             UPDATE Position
			         SET WI=@WI       
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id
              END
			  
			  IF(@LVSection!='''')
		        BEGIN		    
				     exec P_Ins_LVSection @LVSection,@projectID

		             UPDATE Position
			         SET LVSection=@LVSection       
			         FROM #temp t
			         WHERE Position.PositionID = t.P_id
					 
              END
 --END

 
		 --   UPDATE Position
			--SET Menge = @Menge,MA=@MA,MO=@MO,PreisText=@PreisText,Fabricate=@Fabricate,Type=@Type,LiefrantMA=@LiefrantMA
			--FROM #temp T
			--JOIN Position
			--ON  Position.PositionID = T.P_id
			--WHERE Position.ProjectID=@projectID
		
  --END
		  
       
 
	  DROP TABLE #temp 	  
END



' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_LongDescription]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_LongDescription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Upd_LongDescription]
@PositionID INT,
@LongDescription NVARCHAR(MAX)
AS
BEGIN
IF EXISTS(SELECT 1 FROM Position_Longdesc WHERE positionID = @PositionID)
	BEGIN
		UPDATE Position_Longdesc SET Longdiscription = @LongDescription WHERE positionID = @PositionID
	END
ELSE
	BEGIN
		INSERT INTO Position_Longdesc(positionID,Longdiscription)
		VALUES (@PositionID,@LongDescription)
	END
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_Project]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_Project]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Upd_Project]
@ProjectXML XML
AS
BEGIN

SET NOCOUNT ON;

	BEGIN TRY

		BEGIN TRAN
			UPDATE Project 
			SET 
				Project.Location = ProjectXML.value(''(Location/text())[1]'',''nvarchar(100)''),
				Project.CustomerID = ProjectXML.value(''(CustomerID/text())[1]'',''int''),
				Project.ProjectDescription = ProjectXML.value(''(ProjectDescription/text())[1]'',''nvarchar(MAX)''),
				Project.PlannerID = ProjectXML.value(''(PlannerID/text())[1]'',''int''),
				Project.LV_Raster = ProjectXML.value(''(LV_Raster/text())[1]'',''nvarchar(50)''),
				Project.LV_Sprung = ProjectXML.value(''(LV_Sprung/text())[1]'',''int''),
				Project.Intern_X = ProjectXML.value(''(Intern_X/text())[1]'',''decimal(10, 2)''),
				Project.Intern_S = ProjectXML.value(''(Intern_S/text())[1]'',''decimal(10, 2)''),
				Project.Vat = ProjectXML.value(''(Vat/text())[1]'',''decimal(10, 2)''),
				Project.Submit_Location = ProjectXML.value(''(Submit_Location/text())[1]'',''nvarchar(100)''),
				Project.Submit_Date = ProjectXML.value(''(Submit_Date/text())[1]'',''date''),
				Project.Submit_Time = ProjectXML.value(''(Submit_Time/text())[1]'',''time(7)''),
				Project.Estimated_LV = ProjectXML.value(''(Estimated_LV/text())[1]'',''int''),
				Project.Round_Off = ProjectXML.value(''(Round_Off/text())[1]'',''int''),
				Project.Remarks = ProjectXML.value(''(Remarks/text())[1]'',''nvarchar(MAX)''),
				Project.Planned_Duration = ProjectXML.value(''(Planned_Duration/text())[1]'',''int''),
				Project.Project_Discount = ProjectXML.value(''(Project_Discount/text())[1]'',''decimal(10, 2)''),
				Project.Lock_LVHierarchy = ProjectXML.value(''(Lock_LVHierarchy/text())[1]'',''bit''),
				Project.LastUpdated_By = ProjectXML.value(''(LastUpdated_By/text())[1]'',''int''),
				Project.LastUpdated_Date = GETDATE()
			FROM 
			@ProjectXML.nodes(''/Project'')AS NODES(ProjectXML)
			WHERE Project.ProjectID = ProjectXML.value(''(ProjectID/text())[1]'',''int'')
		COMMIT TRAN
	END TRY

	BEGIN CATCH
        IF(@@TRANCOUNT > 0)
		   ROLLBACK TRAN
	END CATCH
END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[Cal_MultiValue]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cal_MultiValue]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

CREATE FUNCTION [dbo].[Cal_MultiValue]
(    
      @multi decimal(18, 3),
      @value decimal(18, 3)
)
RETURNS DECIMAL(18,3)
AS
BEGIN

      DECLARE @OutputEP DECIMAL(18,3)

	  SET @OutputEP = @value + ((@multi - 1) * @value)

RETURN @OutputEP
END

' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[PrepareOZ]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrepareOZ]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
create FUNCTION [dbo].[PrepareOZ]
(    
      @r NVARCHAR(MAX),
      @o NVARCHAR(MAX)
)
RETURNS NVARCHAR(100)
AS
BEGIN

DECLARE @dtRaster TABLE(item INT, itemnumber INT,itemlength INT)
DECLARE @dtOZ TABLE(item INT, itemnumber INT,itemlength INT)
INSERT INTO @dtRaster
SELECT item,itemnumber, LEN(Item) FROM  DelimitedSplit8K(@r,''.'')

INSERT INTO @dtOZ
SELECT item,itemnumber, LEN(Item) FROM  DelimitedSplit8K(@o,''.'')

DECLARE @Count INT = 0 DECLARE @i INT = 0

SELECT @count  = COUNT(*) FROM DelimitedSplit8K(@o,''.'')
DECLARE @OutputOZ NVARCHAR(50)

WHILE (@count > 0)
BEGIN
SET @i = @i+1
SET @count = @count - 1

DECLARE @OZPart INT
DECLARE @rasterpartlength INT
DECLARE @OzPartLength INT

SELECT @OZPart = item FROM @dtOZ  WHERE itemnumber= @i 
SELECT @rasterpartlength = itemlength FROM @dtRaster WHERE itemnumber = @i
SELECT @OzPartLength = itemlength FROM @dtOZ WHERE itemnumber = @i

IF @Count = 0
	BEGIN
		IF @rasterpartlength = 1 AND @OzPartLength > 0
			BEGIN
			SET @OutputOZ = ISNULL(@OutputOZ,'''') + REPLICATE('' '',@rasterpartlength - @OzPartLength) + cast(@OZPart AS NVARCHAR)
			END
		ELSE IF @OzPartLength > 0
			BEGIN
			SET @OutputOZ = ISNULL(@OutputOZ,'''') + REPLICATE('' '',@rasterpartlength - @OzPartLength) + cast(@OZPart AS NVARCHAR) + ''.''
			END
	END
ELSE
	BEGIN
	SET @OutputOZ = ISNULL(@OutputOZ,'''') + REPLICATE('' '',@rasterpartlength - @OzPartLength) + cast(@OZPart AS NVARCHAR) + ''.''
	END
END

RETURN @OutputOZ
END
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SplitString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[SplitString]
(    
      @Input NVARCHAR(MAX),
      @Character CHAR(1)
)
RETURNS @Output TABLE (
      Item NVARCHAR(1000)
)
AS
BEGIN
      DECLARE @StartIndex INT, @EndIndex INT
      SET @StartIndex = 1
      IF SUBSTRING(@Input, LEN(@Input) - 1, LEN(@Input)) <> @Character
      BEGIN
            SET @Input = @Input + @Character
      END
      WHILE CHARINDEX(@Character, @Input) > 0
      BEGIN
            SET @EndIndex = CHARINDEX(@Character, @Input)
           
            INSERT INTO @Output(Item)
            SELECT SUBSTRING(@Input, @StartIndex, @EndIndex - 1)
           
            SET @Input = SUBSTRING(@Input, @EndIndex + 1, LEN(@Input))
      END
      RETURN
END' 
END

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lookup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Lookup](
	[LookupID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](50) NULL,
	[MapID] [int] NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[LookupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LVRaster]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LVRaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LVRaster](
	[LVRasterID] [int] IDENTITY(1,1) NOT NULL,
	[LVRasterName] [nvarchar](50) NULL,
 CONSTRAINT [PK_LVRaster] PRIMARY KEY CLUSTERED 
(
	[LVRasterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LVSection]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LVSection]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LVSection](
	[LVSectionID] [int] IDENTITY(1,1) NOT NULL,
	[LVSectionName] [nvarchar](50) NULL,
	[ProjectID] [int] NULL,
	[SNo] [int] NULL,
 CONSTRAINT [PK_LVSection] PRIMARY KEY CLUSTERED 
(
	[LVSectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LvSectionDetails]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LvSectionDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LvSectionDetails](
	[LVSectionDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[LVSectionID] [int] NULL,
	[SNO] [int] NULL,
 CONSTRAINT [PK_LvSectionDetails] PRIMARY KEY CLUSTERED 
(
	[LVSectionDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Map]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Map]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Map](
	[MapID] [int] IDENTITY(1,1) NOT NULL,
	[MapName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Map] PRIMARY KEY CLUSTERED 
(
	[MapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Planner]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Planner]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Planner](
	[PlannerID] [int] IDENTITY(1,1) NOT NULL,
	[PlannerName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Planner] PRIMARY KEY CLUSTERED 
(
	[PlannerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Position]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Position](
	[PositionID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Position_OZ] [nvarchar](100) NOT NULL,
	[Parent_OZ] [int] NULL,
	[Title] [nvarchar](100) NULL,
	[ShortDescription] [nvarchar](1000) NULL,
	[PositionKZ] [nvarchar](10) NULL,
	[LVSection] [nvarchar](10) NULL,
	[WG] [int] NULL,
	[WA] [int] NULL,
	[WI] [int] NULL,
	[Menge] [int] NULL,
	[ME] [nvarchar](50) NULL,
	[Fabricate] [nvarchar](100) NULL,
	[Type] [nvarchar](50) NULL,
	[LVStatus] [nvarchar](50) NULL,
	[ProposalNo] [int] NULL,
	[surchargefrom] [nvarchar](20) NULL,
	[surchargeto] [nvarchar](20) NULL,
	[surchargePercentage] [decimal](18, 3) NULL,
	[sequenceNo] [int] NULL,
	[LiefrantMA] [nvarchar](50) NULL,
	[DetailKZ] [int] NULL,
	[LVStatus_GAEB] [nvarchar](20) NULL,
	[LVStatus_OTTO] [nvarchar](20) NULL,
	[SubmitProposalNr] [nvarchar](50) NULL,
	[A] [int] NULL,
	[B] [int] NULL,
	[L] [int] NULL,
	[dim] [varchar](10) NULL,
	[mabeinheit] [nvarchar](10) NULL,
	[validitydate] [datetime] NULL,
	[MA] [nvarchar](10) NULL,
	[MO] [nvarchar](10) NULL,
	[minutes] [decimal](18, 3) NULL,
	[Faktor] [decimal](18, 3) NULL,
	[std_satz] [decimal](18, 3) NULL,
	[std_satz_lck] [bit] NULL,
	[MA_listprice] [decimal](18, 3) NULL,
	[MO_listprice] [decimal](18, 3) NULL,
	[MA_Multi1] [decimal](8, 3) NULL,
	[MA_multi2] [decimal](8, 3) NULL,
	[MA_multi3] [decimal](8, 3) NULL,
	[MA_multi4] [decimal](8, 3) NULL,
	[MA_multi5] [decimal](8, 3) NULL,
	[MA_einkaufspreis] [decimal](18, 3) NULL,
	[MA_einkaufspreis_lck] [bit] NULL,
	[MA_selbstkosten] [decimal](18, 3) NULL,
	[MA_selbstkosten_lck] [bit] NULL,
	[MA_verkaufspreis] [decimal](18, 3) NULL,
	[MA_verkaufspreis_lck] [bit] NULL,
	[MO_multi1] [decimal](8, 3) NULL,
	[MO_multi2] [decimal](8, 3) NULL,
	[MO_multi3] [decimal](8, 3) NULL,
	[MO_multi4] [decimal](8, 3) NULL,
	[MO_multi5] [decimal](8, 3) NULL,
	[MO_Einkaufspreis] [decimal](18, 3) NULL,
	[MO_Einkaufspreis_lck] [bit] NULL,
	[MO_selbstkosten] [decimal](18, 3) NULL,
	[MO_selbstkosten_lck] [bit] NULL,
	[MO_verkaufspreis] [decimal](18, 3) NULL,
	[MO_verkaufspreis_lck] [bit] NULL,
	[PreisText] [nvarchar](200) NULL,
	[Created_By] [int] NULL,
	[Created_Date] [datetime] NULL,
	[LastUpdated_By] [int] NULL,
	[LastUpdated_Date] [datetime] NULL,
	[GetTitle] [nvarchar](max) NULL,
	[surchargePercentage_MO] [decimal](18, 3) NULL,
	[MA_selbstkostenMulti] [decimal](18, 3) NULL,
	[MA_verkaufspreis_Multi] [decimal](18, 3) NULL,
	[MO_selbstkostenMulti] [decimal](18, 3) NULL,
	[MO_verkaufspreisMulti] [decimal](18, 3) NULL,
	[DocuwareLink1] [nvarchar](1000) NULL,
	[DocuwareLink2] [nvarchar](1000) NULL,
	[DocuwareLink3] [nvarchar](1000) NULL,
	[GrandTotalME] [decimal](18, 3) NULL,
	[GrandTotalMO] [decimal](18, 3) NULL,
	[FinalGB] [decimal](18, 3) NULL,
	[EP] [decimal](18, 3) NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Position_OZ] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[Position_OZ] ASC,
	[DetailKZ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Position_Longdesc]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position_Longdesc]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Position_Longdesc](
	[positionID] [int] NULL,
	[Longdiscription] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Project]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Project](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[Location] [nvarchar](100) NULL,
	[ProjectNumber] [nvarchar](50) NULL,
	[ComissionNumber] [nvarchar](50) NULL,
	[CustomerID] [int] NULL,
	[ProjectDescription] [nvarchar](max) NULL,
	[PlannerID] [int] NULL,
	[LV_Raster] [nvarchar](50) NULL,
	[LV_Raster_GAEB] [nvarchar](50) NULL,
	[LV_Sprung] [int] NULL,
	[Intern_X] [decimal](10, 2) NULL,
	[Intern_S] [decimal](10, 2) NULL,
	[Vat] [decimal](10, 2) NULL,
	[Submit_Location] [nvarchar](100) NULL,
	[Submit_Date] [datetime] NULL,
	[Submit_Time] [time](7) NULL,
	[Estimated_LV] [int] NULL,
	[Actual_LV] [int] NULL,
	[Round_Off] [int] NULL,
	[Remarks] [nvarchar](max) NULL,
	[Planned_Duration] [int] NULL,
	[Project_Discount] [decimal](10, 2) NULL,
	[Lock_LVHierarchy] [bit] NULL,
	[Created_By] [int] NULL,
	[Created_Date] [datetime] NULL,
	[LastUpdated_By] [int] NULL,
	[LastUpdated_Date] [datetime] NULL,
	[CustomerName] [nvarchar](100) NULL,
	[PlannerName] [nvarchar](100) NULL,
	[CustomerNumber] [nvarchar](100) NULL,
	[ProjectStartDate] [datetime] NULL,
	[ProjectEndDate] [datetime] NULL,
 CONSTRAINT [PK_ProjectID] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_ProjectNumber] UNIQUE NONCLUSTERED 
(
	[ProjectNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  UserDefinedFunction [dbo].[DelimitedSplit8K]    Script Date: 2/3/2017 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DelimitedSplit8K]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[DelimitedSplit8K]
(@pString VARCHAR(8000), @pDelimiter CHAR(1))
RETURNS TABLE WITH SCHEMABINDING AS
 RETURN
--===== "Inline" CTE Driven "Tally Table" produces values from 0 up to 10,000...
     -- enough to cover NVARCHAR(4000)
  WITH E1(N) AS (
                 SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL 
                 SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL 
                 SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1
                ),                          --10E+1 or 10 rows
       E2(N) AS (SELECT 1 FROM E1 a, E1 b), --10E+2 or 100 rows
       E4(N) AS (SELECT 1 FROM E2 a, E2 b), --10E+4 or 10,000 rows max
 cteTally(N) AS (--==== This provides the "base" CTE and limits the number of rows right up front
                     -- for both a performance gain and prevention of accidental "overruns"
                 SELECT TOP (ISNULL(DATALENGTH(@pString),0)) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) FROM E4
                ),
cteStart(N1) AS (--==== This returns N+1 (starting position of each "element" just once for each delimiter)
                 SELECT 1 UNION ALL
                 SELECT t.N+1 FROM cteTally t WHERE SUBSTRING(@pString,t.N,1) = @pDelimiter
                ),
cteLen(N1,L1) AS(--==== Return start and length (for use in substring)
                 SELECT s.N1,
                        ISNULL(NULLIF(CHARINDEX(@pDelimiter,@pString,s.N1),0)-s.N1,8000)
                   FROM cteStart s
                )
--===== Do the actual split. The ISNULL/NULLIF combo handles the length for the final element when no delimiter is found.
 SELECT ItemNumber = ROW_NUMBER() OVER(ORDER BY l.N1),
        Item       = SUBSTRING(@pString, l.N1, l.L1)
   FROM cteLen l
;

' 
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_CreatedBy] FOREIGN KEY([Created_By])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_CreatedBy]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_CustomerID]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LastUpdatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_LastUpdatedBy] FOREIGN KEY([LastUpdated_By])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LastUpdatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_LastUpdatedBy]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PlannerID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_PlannerID] FOREIGN KEY([PlannerID])
REFERENCES [dbo].[Planner] ([PlannerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PlannerID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_PlannerID]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

GO
INSERT [dbo].[Customer] ([CustomerID], [CustomerName]) VALUES (1, N'abdc')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

GO
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName]) VALUES (1, N'abcd')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Lookup] ON 

GO
INSERT [dbo].[Lookup] ([LookupID], [Value], [MapID], [Description]) VALUES (1, N'N', 1, N'N-Normal Position')
GO
INSERT [dbo].[Lookup] ([LookupID], [Value], [MapID], [Description]) VALUES (2, N'S', 1, N'S-Sum Position')
GO
INSERT [dbo].[Lookup] ([LookupID], [Value], [MapID], [Description]) VALUES (3, N'T', 1, N'T-Text Position')
GO
INSERT [dbo].[Lookup] ([LookupID], [Value], [MapID], [Description]) VALUES (4, N'Z', 1, N'Z-Surcharge Position')
GO
INSERT [dbo].[Lookup] ([LookupID], [Value], [MapID], [Description]) VALUES (5, N'H', 1, NULL)
GO
INSERT [dbo].[Lookup] ([LookupID], [Value], [MapID], [Description]) VALUES (6, N'ZZZ', 1, N'ZZZ-Title Position')
GO
SET IDENTITY_INSERT [dbo].[Lookup] OFF
GO
SET IDENTITY_INSERT [dbo].[LVRaster] ON 

GO
INSERT [dbo].[LVRaster] ([LVRasterID], [LVRasterName]) VALUES (1, N'99.1111.9')
GO
INSERT [dbo].[LVRaster] ([LVRasterID], [LVRasterName]) VALUES (2, N'99.99.1111.9')
GO
INSERT [dbo].[LVRaster] ([LVRasterID], [LVRasterName]) VALUES (3, N'99.99.99.1111.9')
GO
INSERT [dbo].[LVRaster] ([LVRasterID], [LVRasterName]) VALUES (4, N'99.99.99.99.1111.9')
GO
SET IDENTITY_INSERT [dbo].[LVRaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Map] ON 

GO
INSERT [dbo].[Map] ([MapID], [MapName]) VALUES (1, N'PositionKZ')
GO
SET IDENTITY_INSERT [dbo].[Map] OFF
GO
SET IDENTITY_INSERT [dbo].[Planner] ON 

GO
INSERT [dbo].[Planner] ([PlannerID], [PlannerName]) VALUES (1, N'abdc')
GO
SET IDENTITY_INSERT [dbo].[Planner] OFF
GO