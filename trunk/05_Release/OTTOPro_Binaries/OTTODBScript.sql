IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PlannerID]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_PlannerID]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LastUpdatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_LastUpdatedBy]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_CreatedBy]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OTTOContact]') AND parent_object_id = OBJECT_ID(N'[dbo].[OTTOContact]'))
ALTER TABLE [dbo].[OTTOContact] DROP CONSTRAINT [FK_OTTOContact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerContact]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerContact]'))
ALTER TABLE [dbo].[CustomerContact] DROP CONSTRAINT [FK_CustomerContact]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAddress]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerAddress]'))
ALTER TABLE [dbo].[CustomerAddress] DROP CONSTRAINT [FK_CustomerAddress]
GO
/****** Object:  Index [IX_OTTOMaster]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[OTTOMaster]') AND name = N'IX_OTTOMaster')
DROP INDEX [IX_OTTOMaster] ON [dbo].[OTTOMaster]
GO
/****** Object:  Index [IX_Customer]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND name = N'IX_Customer')
DROP INDEX [IX_Customer] ON [dbo].[Customer]
GO
/****** Object:  UserDefinedFunction [dbo].[DelimitedSplit8K]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DelimitedSplit8K]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[DelimitedSplit8K]
GO
/****** Object:  Table [dbo].[WI]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WI]') AND type in (N'U'))
DROP TABLE [dbo].[WI]
GO
/****** Object:  Table [dbo].[WGWA]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WGWA]') AND type in (N'U'))
DROP TABLE [dbo].[WGWA]
GO
/****** Object:  Table [dbo].[WG]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WG]') AND type in (N'U'))
DROP TABLE [dbo].[WG]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRole]') AND type in (N'U'))
DROP TABLE [dbo].[UserRole]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfo]') AND type in (N'U'))
DROP TABLE [dbo].[UserInfo]
GO
/****** Object:  Table [dbo].[Typ]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Typ]') AND type in (N'U'))
DROP TABLE [dbo].[Typ]
GO
/****** Object:  Table [dbo].[TextModuleArea]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TextModuleArea]') AND type in (N'U'))
DROP TABLE [dbo].[TextModuleArea]
GO
/****** Object:  Table [dbo].[TextModule]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TextModule]') AND type in (N'U'))
DROP TABLE [dbo].[TextModule]
GO
/****** Object:  Table [dbo].[SupplierProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplierProposal]') AND type in (N'U'))
DROP TABLE [dbo].[SupplierProposal]
GO
/****** Object:  Table [dbo].[SupplierContact]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplierContact]') AND type in (N'U'))
DROP TABLE [dbo].[SupplierContact]
GO
/****** Object:  Table [dbo].[SupplierAddress]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplierAddress]') AND type in (N'U'))
DROP TABLE [dbo].[SupplierAddress]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Supplier]') AND type in (N'U'))
DROP TABLE [dbo].[Supplier]
GO
/****** Object:  Table [dbo].[SpecialCost]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpecialCost]') AND type in (N'U'))
DROP TABLE [dbo].[SpecialCost]
GO
/****** Object:  Table [dbo].[RoleFeatureMap]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleFeatureMap]') AND type in (N'U'))
DROP TABLE [dbo].[RoleFeatureMap]
GO
/****** Object:  Table [dbo].[ReportDesign]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportDesign]') AND type in (N'U'))
DROP TABLE [dbo].[ReportDesign]
GO
/****** Object:  Table [dbo].[Rabatt]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rabatt]') AND type in (N'U'))
DROP TABLE [dbo].[Rabatt]
GO
/****** Object:  Table [dbo].[ProposalSupplier]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProposalSupplier]') AND type in (N'U'))
DROP TABLE [dbo].[ProposalSupplier]
GO
/****** Object:  Table [dbo].[ProposalPosition]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProposalPosition]') AND type in (N'U'))
DROP TABLE [dbo].[ProposalPosition]
GO
/****** Object:  Table [dbo].[ProposalDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProposalDetails]') AND type in (N'U'))
DROP TABLE [dbo].[ProposalDetails]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project]') AND type in (N'U'))
DROP TABLE [dbo].[Project]
GO
/****** Object:  Table [dbo].[PositionDeleteStatus]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PositionDeleteStatus]') AND type in (N'U'))
DROP TABLE [dbo].[PositionDeleteStatus]
GO
/****** Object:  Table [dbo].[Position_Longdesc]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position_Longdesc]') AND type in (N'U'))
DROP TABLE [dbo].[Position_Longdesc]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position]') AND type in (N'U'))
DROP TABLE [dbo].[Position]
GO
/****** Object:  Table [dbo].[Planner]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Planner]') AND type in (N'U'))
DROP TABLE [dbo].[Planner]
GO
/****** Object:  Table [dbo].[OTTOMaster]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OTTOMaster]') AND type in (N'U'))
DROP TABLE [dbo].[OTTOMaster]
GO
/****** Object:  Table [dbo].[OTTOContact]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OTTOContact]') AND type in (N'U'))
DROP TABLE [dbo].[OTTOContact]
GO
/****** Object:  Table [dbo].[Map]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Map]') AND type in (N'U'))
DROP TABLE [dbo].[Map]
GO
/****** Object:  Table [dbo].[LvSectionDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LvSectionDetails]') AND type in (N'U'))
DROP TABLE [dbo].[LvSectionDetails]
GO
/****** Object:  Table [dbo].[LVSection]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LVSection]') AND type in (N'U'))
DROP TABLE [dbo].[LVSection]
GO
/****** Object:  Table [dbo].[LVRaster]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LVRaster]') AND type in (N'U'))
DROP TABLE [dbo].[LVRaster]
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lookup]') AND type in (N'U'))
DROP TABLE [dbo].[Lookup]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
DROP TABLE [dbo].[Invoice]
GO
/****** Object:  Table [dbo].[Feature]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Feature]') AND type in (N'U'))
DROP TABLE [dbo].[Feature]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[Dimension]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dimension]') AND type in (N'U'))
DROP TABLE [dbo].[Dimension]
GO
/****** Object:  Table [dbo].[DeliveryNumber]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryNumber]') AND type in (N'U'))
DROP TABLE [dbo].[DeliveryNumber]
GO
/****** Object:  Table [dbo].[DeliveryInvoices]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryInvoices]') AND type in (N'U'))
DROP TABLE [dbo].[DeliveryInvoices]
GO
/****** Object:  Table [dbo].[DeliverNoteMSR]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliverNoteMSR]') AND type in (N'U'))
DROP TABLE [dbo].[DeliverNoteMSR]
GO
/****** Object:  Table [dbo].[CustomerContact]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerContact]') AND type in (N'U'))
DROP TABLE [dbo].[CustomerContact]
GO
/****** Object:  Table [dbo].[CustomerAddress]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerAddress]') AND type in (N'U'))
DROP TABLE [dbo].[CustomerAddress]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
DROP TABLE [dbo].[Customer]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[BlattDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BlattDetails]') AND type in (N'U'))
DROP TABLE [dbo].[BlattDetails]
GO
/****** Object:  Table [dbo].[Blatt]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Blatt]') AND type in (N'U'))
DROP TABLE [dbo].[Blatt]
GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SplitString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[SplitString]
GO
/****** Object:  UserDefinedFunction [dbo].[PrepareOZ]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrepareOZ]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[PrepareOZ]
GO
/****** Object:  UserDefinedFunction [dbo].[Cal_MultiValue]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cal_MultiValue]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Cal_MultiValue]
GO
/****** Object:  StoredProcedure [dbo].[p_Upd_SupplierPrice]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_Upd_SupplierPrice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_Upd_SupplierPrice]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_SpecialCost]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_SpecialCost]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_SpecialCost]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_Project]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_Project]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_Project]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_Password]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_Password]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_Password]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_Multi6]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_Multi6]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_Multi6]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_Multi]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_Multi]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_Multi]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_LongDescription]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_LongDescription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_LongDescription]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_BulkProcess_ActionB]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_BulkProcess_ActionB]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_BulkProcess_ActionB]
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_BulkProcess_ActionA]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_BulkProcess_ActionA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Upd_BulkProcess_ActionA]
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_ProjectAndCustomerAndOTTODetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_ProjectAndCustomerAndOTTODetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Rpt_ProjectAndCustomerAndOTTODetails]
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_PositionForProposalPrice]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_PositionForProposalPrice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Rpt_PositionForProposalPrice]
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_OTTOMaster]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_OTTOMaster]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Rpt_OTTOMaster]
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_GetTotalSummery]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_GetTotalSummery]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Rpt_GetTotalSummery]
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_GetSupplierProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_GetSupplierProposal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Rpt_GetSupplierProposal]
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_DeliveryNotes]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_DeliveryNotes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Rpt_DeliveryNotes]
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_BlattdetailsforProject]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_BlattdetailsforProject]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Rpt_BlattdetailsforProject]
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_Blattdetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_Blattdetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Rpt_Blattdetails]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_WGWA]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_WGWA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_WGWA]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_UserRole]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_UserRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_UserRole]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_UserInfo]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_UserInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_UserInfo]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Typ]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Typ]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Typ]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_TextModule]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_TextModule]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_TextModule]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_SupplierProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_SupplierProposal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_SupplierProposal]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Supplier_Contact]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Supplier_Contact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Supplier_Contact]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Supplier_Address]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Supplier_Address]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Supplier_Address]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Supplier]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Supplier]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Supplier]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_SaveSelection]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_SaveSelection]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_SaveSelection]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_RoleFeatureMap]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_RoleFeatureMap]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_RoleFeatureMap]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_ReportDesign]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_ReportDesign]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_ReportDesign]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Rabatt]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Rabatt]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Rabatt]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_ProposalValues]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_ProposalValues]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_ProposalValues]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_ProposalDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_ProposalDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_ProposalDetails]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Project]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Project]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Project]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Position]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Position]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Position]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_OTTODetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_OTTODetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_OTTODetails]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_OTTO_Contact]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_OTTO_Contact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_OTTO_Contact]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_LVSection]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_LVSection]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_LVSection]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Invoice]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Invoice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Invoice]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_DimensionCopy]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_DimensionCopy]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_DimensionCopy]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Dimension]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Dimension]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Dimension]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_DeletePosition]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_DeletePosition]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_DeletePosition]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Customer_Contact]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Customer_Contact]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Customer_Contact]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Customer_Address]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Customer_Address]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Customer_Address]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Customer]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Customer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Customer]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Category]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Category]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Category]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_BlattDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_BlattDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_BlattDetails]
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Article]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Article]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Ins_Article]
GO
/****** Object:  StoredProcedure [dbo].[P_Import]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Import]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Import]
GO
/****** Object:  StoredProcedure [dbo].[P_Imp_ArticleData]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Imp_ArticleData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Imp_ArticleData]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_WGWAForProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_WGWAForProposal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_WGWAForProposal]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_WGForMulti6]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_WGForMulti6]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_WGForMulti6]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_WGForMulti]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_WGForMulti]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_WGForMulti]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_UserRoles]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_UserRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_UserRoles]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_UserInfo]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_UserInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_UserInfo]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_Typ]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Typ]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_Typ]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_TMLFile]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_TMLFile]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_TMLFile]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_TextModuleTypes]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_TextModuleTypes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_TextModuleTypes]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_TextModuleAreas]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_TextModuleAreas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_TextModuleAreas]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_SupplierProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_SupplierProposal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_SupplierProposal]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_Supplier]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Supplier]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_Supplier]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_SpecialCost]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_SpecialCost]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_SpecialCost]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ShowUmlage]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ShowUmlage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ShowUmlage]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ReportDesignTypes]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ReportDesignTypes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ReportDesignTypes]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ReportDesign]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ReportDesign]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ReportDesign]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_Rabatt]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Rabatt]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_Rabatt]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectNumber]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ProjectNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ProjectNumber]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectList]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ProjectList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ProjectList]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectDetailsforOTTOMaster]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ProjectDetailsforOTTOMaster]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ProjectDetailsforOTTOMaster]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ProjectDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ProjectDetails]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionsForProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionsForProposal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionsForProposal]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionsForDelivery]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionsForDelivery]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionsForDelivery]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionOZ]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionOZ]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionOZ]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionList_Copy]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionList_Copy]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionList_Copy]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionList]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionList]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionKZ]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionKZ]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionKZ]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionForTML]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionForTML]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_PositionForTML]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_OTTODetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_OTTODetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_OTTODetails]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_NonActivedelivery]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_NonActivedelivery]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_NonActivedelivery]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_NewBlattNumber]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_NewBlattNumber]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_NewBlattNumber]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVSectionForProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVSectionForProposal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_LVSectionForProposal]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVSectionForImport]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVSectionForImport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_LVSectionForImport]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVSection]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVSection]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_LVSection]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVRaster]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVRaster]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_LVRaster]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LongDescription]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LongDescription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_LongDescription]
GO
/****** Object:  StoredProcedure [dbo].[p_Get_Invoices]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_Get_Invoices]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_Get_Invoices]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_Feature]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Feature]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_Feature]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_DocuwareLinks]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_DocuwareLinks]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_DocuwareLinks]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_Customer]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Customer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_Customer]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_CheckUserCredentials]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_CheckUserCredentials]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_CheckUserCredentials]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_Category]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Category]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_Category]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_BlattNumbers]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_BlattNumbers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_BlattNumbers]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_BlattDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_BlattDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_BlattDetails]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ArticleByWG]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ArticleByWG]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ArticleByWG]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ArticleByType]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ArticleByType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ArticleByType]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ArticleByDimension]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ArticleByDimension]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_ArticleByDimension]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_article]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_article]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_article]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_AccessLevels]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_AccessLevels]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Get_AccessLevels]
GO
/****** Object:  StoredProcedure [dbo].[P_Del_Project]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Del_Project]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Del_Project]
GO
/****** Object:  StoredProcedure [dbo].[P_Del_Position]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Del_Position]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Del_Position]
GO
/****** Object:  StoredProcedure [dbo].[P_Del_Customer]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Del_Customer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_Del_Customer]
GO
/****** Object:  UserDefinedTableType [dbo].[Strings]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Strings' AND ss.name = N'dbo')
DROP TYPE [dbo].[Strings]
GO
/****** Object:  UserDefinedTableType [dbo].[SpecialCost]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'SpecialCost' AND ss.name = N'dbo')
DROP TYPE [dbo].[SpecialCost]
GO
/****** Object:  UserDefinedTableType [dbo].[RoleFeatureMap]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'RoleFeatureMap' AND ss.name = N'dbo')
DROP TYPE [dbo].[RoleFeatureMap]
GO
/****** Object:  UserDefinedTableType [dbo].[Project_Import]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Project_Import' AND ss.name = N'dbo')
DROP TYPE [dbo].[Project_Import]
GO
/****** Object:  UserDefinedTableType [dbo].[Positions]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Positions' AND ss.name = N'dbo')
DROP TYPE [dbo].[Positions]
GO
/****** Object:  UserDefinedTableType [dbo].[Position_OZ_List]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Position_OZ_List' AND ss.name = N'dbo')
DROP TYPE [dbo].[Position_OZ_List]
GO
/****** Object:  UserDefinedTableType [dbo].[MultiUpdate]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'MultiUpdate' AND ss.name = N'dbo')
DROP TYPE [dbo].[MultiUpdate]
GO
/****** Object:  UserDefinedTableType [dbo].[IntTable]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'IntTable' AND ss.name = N'dbo')
DROP TYPE [dbo].[IntTable]
GO
/****** Object:  UserDefinedTableType [dbo].[Import]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Import' AND ss.name = N'dbo')
DROP TYPE [dbo].[Import]
GO
/****** Object:  UserDefinedTableType [dbo].[dtUpdateSupplierPrice]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'dtUpdateSupplierPrice' AND ss.name = N'dbo')
DROP TYPE [dbo].[dtUpdateSupplierPrice]
GO
/****** Object:  UserDefinedTableType [dbo].[dtInvoice]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'dtInvoice' AND ss.name = N'dbo')
DROP TYPE [dbo].[dtInvoice]
GO
/****** Object:  UserDefinedTableType [dbo].[dtDimension]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'dtDimension' AND ss.name = N'dbo')
DROP TYPE [dbo].[dtDimension]
GO
/****** Object:  UserDefinedTableType [dbo].[dtDelivery]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'dtDelivery' AND ss.name = N'dbo')
DROP TYPE [dbo].[dtDelivery]
GO
/****** Object:  UserDefinedTableType [dbo].[dtArticle]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'dtArticle' AND ss.name = N'dbo')
DROP TYPE [dbo].[dtArticle]
GO
/****** Object:  UserDefinedTableType [dbo].[Dimension]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Dimension' AND ss.name = N'dbo')
DROP TYPE [dbo].[Dimension]
GO
/****** Object:  UserDefinedTableType [dbo].[Bulk_Process_ActionB]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Bulk_Process_ActionB' AND ss.name = N'dbo')
DROP TYPE [dbo].[Bulk_Process_ActionB]
GO
/****** Object:  UserDefinedTableType [dbo].[Bulk_Process_ActionA]    Script Date: 6/6/2017 11:28:52 AM ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Bulk_Process_ActionA' AND ss.name = N'dbo')
DROP TYPE [dbo].[Bulk_Process_ActionA]
GO
/****** Object:  UserDefinedTableType [dbo].[Bulk_Process_ActionA]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Bulk_Process_ActionA' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Bulk_Process_ActionA] AS TABLE(
	[ID] [int] NULL,
	[MA_selbstkostenMulti] [decimal](10, 3) NULL,
	[MO_selbstkostenMulti] [decimal](10, 3) NULL,
	[MA_verkaufspreis_Multi] [decimal](10, 3) NULL,
	[MO_verkaufspreisMulti] [decimal](10, 3) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Bulk_Process_ActionB]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  UserDefinedTableType [dbo].[Dimension]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Dimension' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Dimension] AS TABLE(
	[DimensionID] [int] NULL,
	[WIID] [int] NULL,
	[A] [nvarchar](10) NULL,
	[B] [nvarchar](10) NULL,
	[L] [nvarchar](10) NULL,
	[ListPrice] [decimal](8, 3) NULL,
	[Minuten] [decimal](8, 1) NULL,
	[GMulti] [decimal](8, 3) NULL,
	[ValidityDate] [date] NULL,
	[Multi1] [decimal](8, 3) NULL,
	[Multi2] [decimal](8, 3) NULL,
	[Multi3] [decimal](8, 3) NULL,
	[Multi4] [decimal](8, 3) NULL,
	[Einkaufspreis] [decimal](8, 3) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[dtArticle]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'dtArticle' AND ss.name = N'dbo')
CREATE TYPE [dbo].[dtArticle] AS TABLE(
	[Key] [int] NULL,
	[Warengrouppe] [nvarchar](10) NULL,
	[WGDesc] [nvarchar](200) NULL,
	[Warenart] [nvarchar](10) NULL,
	[WADesc] [nvarchar](200) NULL,
	[Warennummer] [nvarchar](10) NULL,
	[WIDesc] [nvarchar](200) NULL,
	[Fabrikat] [nvarchar](100) NULL,
	[TYP] [nvarchar](20) NULL,
	[Lieferant] [nvarchar](200) NULL,
	[Dimension] [nvarchar](20) NULL,
	[Masseinheit] [nvarchar](200) NULL,
	[Rabattgruppe] [nvarchar](20) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[dtDelivery]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'dtDelivery' AND ss.name = N'dbo')
CREATE TYPE [dbo].[dtDelivery] AS TABLE(
	[PositionID] [int] NULL,
	[Menge] [int] NULL,
	[SNO] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[dtDimension]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'dtDimension' AND ss.name = N'dbo')
CREATE TYPE [dbo].[dtDimension] AS TABLE(
	[Key] [int] NULL,
	[A] [nvarchar](10) NULL,
	[B] [nvarchar](10) NULL,
	[L] [nvarchar](10) NULL,
	[ValidityDate] [datetime] NULL,
	[L-Preis] [decimal](8, 3) NULL,
	[Multi1] [decimal](8, 3) NULL,
	[Multi2] [decimal](8, 3) NULL,
	[Multi3] [decimal](8, 3) NULL,
	[Multi4] [decimal](8, 3) NULL,
	[Montage Zeit] [decimal](8, 3) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[dtInvoice]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'dtInvoice' AND ss.name = N'dbo')
CREATE TYPE [dbo].[dtInvoice] AS TABLE(
	[BlattID] [int] NULL,
	[BlattPrice] [decimal](8, 3) NULL,
	[SELECTED] [bit] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[dtUpdateSupplierPrice]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'dtUpdateSupplierPrice' AND ss.name = N'dbo')
CREATE TYPE [dbo].[dtUpdateSupplierPrice] AS TABLE(
	[PositionID] [int] NULL,
	[ListPrice] [decimal](8, 3) NULL,
	[Fabrikate] [nvarchar](20) NULL,
	[Supplier] [nvarchar](50) NULL,
	[Multi1] [decimal](8, 3) NULL,
	[Multi2] [decimal](8, 3) NULL,
	[Multi3] [decimal](8, 3) NULL,
	[Multi4] [decimal](8, 3) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Import]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  UserDefinedTableType [dbo].[IntTable]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'IntTable' AND ss.name = N'dbo')
CREATE TYPE [dbo].[IntTable] AS TABLE(
	[ID] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[MultiUpdate]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'MultiUpdate' AND ss.name = N'dbo')
CREATE TYPE [dbo].[MultiUpdate] AS TABLE(
	[WG] [int] NULL,
	[XValue] [decimal](18, 2) NULL,
	[SValue] [decimal](18, 2) NULL,
	[XFactor] [decimal](18, 3) NULL,
	[SFactor] [decimal](18, 3) NULL,
	[WGDescritpion] [nvarchar](500) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Position_OZ_List]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Position_OZ_List' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Position_OZ_List] AS TABLE(
	[_FronPos] [int] NULL,
	[_ToPos] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Positions]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Positions' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Positions] AS TABLE(
	[FromOZ] [nvarchar](50) NULL,
	[ToOZ] [nvarchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Project_Import]    Script Date: 6/6/2017 11:28:52 AM ******/
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
	[Title] [nvarchar](100) NULL,
	[SNO] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[RoleFeatureMap]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'RoleFeatureMap' AND ss.name = N'dbo')
CREATE TYPE [dbo].[RoleFeatureMap] AS TABLE(
	[FeatureID] [int] NULL,
	[AccessLevelID] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SpecialCost]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'SpecialCost' AND ss.name = N'dbo')
CREATE TYPE [dbo].[SpecialCost] AS TABLE(
	[SpecialCostID] [int] NULL,
	[Cost_Description] [nvarchar](500) NULL,
	[Price] [decimal](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Strings]    Script Date: 6/6/2017 11:28:52 AM ******/
IF NOT EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Strings' AND ss.name = N'dbo')
CREATE TYPE [dbo].[Strings] AS TABLE(
	[Item] [nvarchar](50) NULL
)
GO
/****** Object:  StoredProcedure [dbo].[P_Del_Customer]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Del_Customer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Del_Customer]
@CustomerID INT
AS
BEGIN

UPDATE Customer SET IsActive=0 WHERE CustomerID=@CustomerID


END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Del_Position]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Del_Project]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Get_AccessLevels]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_AccessLevels]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Get_AccessLevels]
AS

BEGIN	
 
     	SELECT LookupID,Value FROM Lookup WHERE MapID=2

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_article]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_article]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_article]
AS
BEGIN
--Retrieving WG WA article detais
SELECT
WGID,WG,WA,WGDescription,WADescription
FROM WG
--Retrieving WI article detais
SELECT W.WIID,WGID,WI,WIDescription,Fabrikate,Masseinheit,Dimension,Menegenheit,
			Remarks,TextKZ,
			ISNULL(D.ValidityDate,GETDATE()) AS ValidityDate,
			ISNULL(W.Multi1,1) AS Multi1,
			ISNULL(W.Multi2,1) AS Multi2,
			ISNULL(W.Multi3,1) AS Multi3,
			ISNULL(W.Multi4,1) AS Multi4,
			DataNormNumber,
			T.Typ,
			S.FullName,
			R.Rabatt
			FROM WI 
			W LEFT JOIN  
			(SELECT MAX(ValidityDate)AS ValidityDate,WIID FROM Dimension WHERE ValidityDate <= GETDATE() GROUP BY WIID) D ON W.WIID = D.WIID
			LEFT JOIN 
			(SELECT T.TypID,SupplierID,T.WIID,Typ,CreatedBy,LastUpdatedBy,CreatedDate,LastUpdatedDate 
				FROM Typ T INNER JOIN(SELECT  MIN(TypID) AS TypID,WIID FROM Typ GROUP BY WIID) AS S ON T.TypID = s.TypID) AS
			 T ON W.WIID = T.WIID
			LEFT JOIN Supplier S ON T.SupplierID = S.SupplierID
			LEFT JOIN (SELECT
						T.RabattID,Rabatt,T.TypeID,Multi1,Multi2,Multi3,Multi4,T.ValidityDate
						FROM Rabatt T INNER JOIN(SELECT  MAX(ValidityDate) AS ValidityDate ,TypeID 
						FROM Rabatt WHERE ValidityDate <= GETDATE() GROUP BY TypeID) AS S 
						ON T.TypeID = S.TypeID AND T.ValidityDate = S.ValidityDate)
			 R ON T.TypID = R.TypeID
--Retreiving Dimension article Details
SELECT D.DimensionID,
	D.WIID,
	D.A,
	D.B,
	D.L,
	D.ListPrice,
	D.Minuten,
	W.Multi1 * W.Multi2 * W.Multi3 *W.Multi4 AS GMulti,
	D.ValidityDate,
	W.Multi1,
	W.Multi2,
	W.Multi3,
	W.Multi4,
	(W.Multi1 * W.Multi2 * W.Multi3 *W.Multi4) * D.ListPrice AS Einkaufspreis
	FROM 
	(SELECT  D.DimensionID,D.WIID,D.A,D.B,D.L,
	D.ListPrice,D.Minuten,D.GMulti,D.ValidityDate 
	FROM Dimension D 
	INNER JOIN (SELECT MAX(ValidityDate) AS ValidityDate,WIID FROM Dimension WHERE 
	ValidityDate <= GETDATE() GROUP BY WIID
	)D1 ON D1.WIID = D.WIID AND D1.ValidityDate = D.ValidityDate)
	D INNER JOIN WI W ON D.WIID = W.WIID ORDER BY D.DimensionID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ArticleByDimension]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ArticleByDimension]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_ArticleByDimension]
@WG NVARCHAR(10),
@WA NVARCHAR(10),
@WI NVARCHAR(10),
@A NVARCHAR(10),
@B NVARCHAR(10),
@L NVARCHAR(10),
@dtSubmitDate DATE
AS
BEGIN

DECLARE @WGID INT ,@WIID INT
SELECT @WGID = WGID FROM WG WHERE WG= @WG AND WA = @WA
SELECT @WIID = WIID FROM WI WHERE WGID = @WGID AND WI = @WI

SELECT D1.ListPrice,D1.Minuten,1 AS Factor FROM 
(SELECT MAX(ValidityDate) AS ValidityDate,DimensionID FROM Dimension 
WHERE ValidityDate <= @dtSubmitDate  AND A = @A AND B = @B AND L = @L
GROUP BY DimensionID)D 
INNER JOIN Dimension D1 ON D.DimensionID = D1.DimensionID
WHERE WIID = @WIID

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ArticleByType]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ArticleByType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_ArticleByType]
@Typ NVARCHAR(20),
@dtSubmitDate DATE
AS
BEGIN
DECLARE @WIID INT,@TypID INT
SELECT @WIID = WIID,@TypID = TypID FROM Typ WHERE Typ = @Typ
SELECT
T.TypID,T.Typ,
W1.WGID,W1.WG,W1.WA,
W.WIID,W.WI,W.Dimension,W.Fabrikate,W.Masseinheit,W.Menegenheit,W.TextKZ,W.ValidityDate,
D.DimensionID,D.A,D.B,D.L,D.ListPrice,D.Minuten,1 AS Factor,
S.SupplierID,S.FullName,S.ShortName,
ISNULL(R.Multi1,W.Multi1) AS Multi1,
ISNULL(R.Multi2,W.Multi2) AS Multi2,
ISNULL(R.Multi3,W.Multi3) AS Multi3,
ISNULL(R.Multi4,W.Multi4) AS Multi4
FROM Typ T
	INNER JOIN WI W ON T.WIID = W.WIID
	INNER JOIN WG W1 ON W.WGID = W1.WGID
	LEFT JOIN 
	(
	SELECT TOP(1) D1.DimensionID,D1.A,D1.B,D1.L,D1.ListPrice,D1.Minuten,D1.WIID
	 FROM(SELECT MAX(ValidityDate) AS ValidityDate,WIID FROM Dimension 
	 WHERE ValidityDate <= @dtSubmitDate
	 GROUP BY WIID) D
	INNER JOIN Dimension D1 ON D.WIID = D1.WIID AND D.ValidityDate = D1.ValidityDate
	AND D.ValidityDate = D1.ValidityDate AND D1.WIID = @WIID
	ORDER BY DimensionID
	) D ON W.WIID = D.WIID
	INNER JOIN Supplier S ON T.SupplierID = S.SupplierID
	LEFT JOIN (SELECT TOP(1) * FROM Rabatt where ValidityDate <= @dtSubmitDate 
	AND TypeID = @TypID ORDER BY ValidityDate DESC) R ON T.TypID = R.TypeID
WHERE TypID = @TypID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ArticleByWG]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ArticleByWG]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_ArticleByWG]
@WG NVARCHAR(10) = 0,
@WA NVARCHAR(10) = 0,
@WI NVARCHAR(10) = 0,
@dtSubmitDate DATE
AS
BEGIN
DECLARE @WGID INT, @WIID INT
SELECT @WGID = WGID FROM WG WHERE WG = @WG AND WA = @WA
SELECT  @WIID = WIID FROM WI WHERE WI = @WI AND WGID = @WGID
SELECT 
T.TypID,T.Typ,
W.WIID,W.WI,W.Dimension,W.Fabrikate,W.Masseinheit,W.Menegenheit,W.TextKZ,W.ValidityDate,
D.DimensionID,D.A,D.B,D.L,D.ListPrice,D.Minuten,1 AS Factor,
S.SupplierID,S.FullName,S.ShortName,
ISNULL(R.Multi1,W.Multi1) AS Multi1,
ISNULL(R.Multi2,W.Multi2) AS Multi2,
ISNULL(R.Multi3,W.Multi3) AS Multi3,
ISNULL(R.Multi4,W.Multi4) AS Multi4
		FROM WI W
		LEFT JOIN (SELECT TOP(1) D1.DimensionID,D1.A,D1.B,D1.L,D1.ListPrice,D1.Minuten,D1.WIID
					 FROM(SELECT MAX(ValidityDate) AS ValidityDate,WIID FROM Dimension 
					 WHERE ValidityDate <= @dtSubmitDate
					 GROUP BY WIID) D INNER JOIN Dimension D1 
					 ON D.WIID = D1.WIID AND D.ValidityDate = D1.ValidityDate AND D1.WIID = @WIID
					 ORDER BY D1.DimensionID
				) D ON W.WIID = D.WIID
		LEFT JOIN (SELECT TOP(1) * FROM Typ WHERE WIID = @WIID ORDER BY TypID ASC) T ON W.WIID = T.WIID
		LEFT JOIN Supplier S ON S.SupplierID = T.SupplierID
		LEFT JOIN (SELECT R.RabattID,R.TypeID,R.Rabatt,R.ValidityDate,R.Multi1,R.Multi2,R.Multi3,R.Multi4
					FROM Rabatt R INNER JOIN (SELECT MAX(ValidityDate) AS ValidityDate,TypeID FROM Rabatt 
					WHERE ValidityDate <= @dtSubmitDate GROUP BY TypeID) R1 
					ON R.TypeID = R1.TypeID AND R.ValidityDate = R1.ValidityDate) R ON T.TypID = R.TypeID
WHERE W.WIID = @WIID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_BlattDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_BlattDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_BlattDetails]

@BlattID INT

AS

BEGIN

SELECT 

P.PositionID,

P.Position_OZ,

ISNULL(B.Menge,0) AS Menge,

CASE P.PositionKZ 

	WHEN ''N'' THEN ''Normalposition''

	WHEN ''E'' THEN ''Bedarfspos. o. GB''

	WHEN ''A'' THEN ''Alternativposition''

	WHEN ''M'' THEN ''Bedarfspos m. GB'' END AS PositionKZ,

CASE WHEN P.LVStatus = ''B'' THEN 1 ELSE 0 END AS Ordered,

P.ShortDescription,

ISNULL(P.Menge,0) AS OrderedQuantity,

((ISNULL(P.Menge,0) - ISNULL(B.DeliveredQuantity,0)) + B.Menge) AS RemainingQuantity,

ISNULL(B.DeliveredQuantity,0) AS DeliveredQuantity,

B.SNO,

P.LVSection,

P.LVStatus

FROM Position P 

INNER JOIN (SELECT 

B.PositionID,

B.SNO,

B.Quantity AS Menge,

B1.Quantity AS DeliveredQuantity

FROM BlattDetails B 

LEFT JOIN (SELECT PositionID,ISNULL(SUM(Quantity),0) AS Quantity

FROM BlattDetails WHERE IsActiveDelivery = 1 GROUP BY PositionID) B1

	ON B.PositionID = B1.PositionID

WHERE B.BlattID = @BlattID) B ON P.PositionID = B.PositionID

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_BlattNumbers]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_BlattNumbers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_BlattNumbers]
@ProjectID INT
AS
BEGIN
DECLARE @Select Bit = 0
SELECT S.BlattID,
BlattNumber,
IsActiveDelivery,
CASE WHEN IsInvoiced = 1 THEN ''YES'' ELSE ''NO'' END AS IsInvoiced,
CreatedBy,
CreatedDate,
T.NoOfPositions,
T.BlattPrice,
@Select AS SELCETED
FROM Blatt S
INNER JOIN (SELECT A.BlattID,COUNT(A.PositionID) AS NoOfPositions,SUM(A.FinalGB) AS BlattPrice FROM
(SELECT B.BlattID,B.PositionID, 
CAST(ISNULL((B.Quantity * 
(((P.surchargePercentage * P.MA_verkaufspreis)/100) + ((P.surchargePercentage_MO * P.MO_verkaufspreis)/100) + P.EP)
),0)AS decimal(8,3)) AS FinalGB
FROM BlattDetails B
INNER JOIN Position P ON B.PositionID = P.PositionID WHERE ProjectID = @ProjectID) AS A GROUP BY A.BlattID) T
ON S.BlattID = T.BlattID
WHERE ProjectID = @ProjectID AND IsActiveDelivery = 1
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_Category]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Category]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[P_Get_Category]
@TextareaID int
AS

BEGIN	
 
     SELECT CategoryID,CategoryName FROM Category
	 WHERE TextAreaID=@TextareaID
	 

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_CheckUserCredentials]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_CheckUserCredentials]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_CheckUserCredentials]
@UserName NVARCHAR(20),
@Password NVARCHAR(50)
AS
BEGIN
IF NOT EXISTS(SELECT 1 FROM UserInfo WHERE UserName = @UserName)
BEGIN
SELECT ''Please Enter Valid UserName''
RETURN
END
IF NOT EXISTS(SELECT 1 FROM UserInfo WHERE UserName = @UserName AND [Password] = @Password)
BEGIN
SELECT ''Please Enter Valid Password''
RETURN
END
DECLARE @RoleID INT
SELECT @RoleID = RoleID FROM UserInfo WHERE UserName = @UserName
SELECT UserID,RoleID,UserName,FirstName,LastName,MobileNo,EmailID,IsOTP
FROM UserInfo WHERE UserName = @UserName
SELECT 
R.RoleID, 
F.FeatureID,
F.FeatureName,
F.[Description],
R.AccessLevel
FROM Feature F 
INNER JOIN RoleFeatureMap R 
	ON F.FeatureID = R.FeatureID 
	WHERE R.RoleID = @RoleID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_Customer]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Customer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[P_Get_Customer]

AS

BEGIN	
 
     SELECT CustomerID,CustomerFullName,CustomerShortName,Street,PostalCode,City,Country,ILN,Telephone,Fax,EmailID,TaxNumber,
	 BankName,BankPostalCode,BankAccountNumber,DVNr,TenderNumber,DebitorNumber,CountryType,CountryName,Commentary,IsActive
	 FROM Customer
  
     SELECT ContactPersonID, CustomerID,Salutation,ContatPersonName,Designation,EmailID,Telephone,FAX,DefaultContact,IsActive
	 FROM CustomerContact
  
     SELECT  AddressID, CustomerID,AddressShortName,StreetNo,PostalCode,City,Country,DefaultAddress,IsActive
	 FROM CustomerAddress

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_DocuwareLinks]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Get_Feature]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Feature]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Get_Feature]
@RoleID INT = -1
AS

BEGIN	

IF NOT EXISTS(SELECT 1 FROM RoleFeatureMap WHERE RoleID = @RoleID)
BEGIN

SELECT A.FeatureID,A.FeatureName,A.Description,A.AccessLevelID,
L.Value  AS AccessLevel FROM (SELECT FeatureID,FeatureName,[Description],
9 AS AccessLevelID FROM Feature) AS A 
INNER JOIN Lookup L 
	ON A.AccessLevelID = L.LookupID 

END
ELSE
BEGIN

SELECT 
A.FeatureID,A.FeatureName,A.Description,A.AccessLevelID,
L.Value  AS AccessLevel FROM
(SELECT R.FeatureID,F.FeatureName,F.Description,R.AccessLevel AS AccessLevelID
FROM RoleFeatureMap R 
INNER JOIN Feature F 
	ON R.FeatureID = F.FeatureID
	WHERE R.RoleID = @RoleID) AS A INNER JOIN Lookup L 
	ON A.AccessLevelID = L.LookupID 

END
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_Get_Invoices]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_Get_Invoices]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[p_Get_Invoices]
@ProjectID INT
AS
BEGIN
SELECT I.InvoiceID,
ProjectID,
InvoiceNumber,
InvoiceAmount,
D.NoOfBlatts,
CreatedBy,
CreatedDate
FROM Invoice I 
INNER JOIN (SELECT InvoiceID,COUNT(BlattID) AS NoOfBlatts
	FROM DeliveryInvoices 
	GROUP BY InvoiceID) D
ON I.InvoiceID = D.InvoiceID
WHERE ProjectID = @ProjectID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LongDescription]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Get_LVRaster]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Get_LVSection]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Get_LVSectionForImport]    Script Date: 6/6/2017 11:28:52 AM ******/
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
SELECT DISTINCT(LVSection) FROM Position 
WHERE ProjectID = @ProjectID AND LVSection != ''''
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_LVSectionForProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_LVSectionForProposal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_LVSectionForProposal]
@ProjectID INT
--@LVSection NVARCHAR(500)
AS
BEGIN
    SELECT DISTINCT LVSection FROM Position
    SELECT DISTINCT LVSection,CAST(WG AS VARCHAR) + ''-'' + CAST(WA AS VARCHAR) AS [WGWA] FROM Position
	WHERE ProjectID=@ProjectID AND WG IS NOT NULL AND WA IS NOT NULL
 
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_NewBlattNumber]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_NewBlattNumber]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_NewBlattNumber]
@ProjectID INT
AS
BEGIN
SELECT ''BLATT '' + 
REPLICATE(''0'',3 - DATALENGTH(cast(ISNULL(max(BlattNumberID),0) + 1 AS VARCHAR))) 
+ cast(ISNULL(max(BlattNumberID),0) + 1 as VARCHAR) 
FROM Blatt WHERE ProjectID = @ProjectID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_NonActivedelivery]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_NonActivedelivery]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_NonActivedelivery]
@ProjectID INT
AS
BEGIN
SELECT 
P.PositionID,
P.Position_OZ,
ISNULL(B.Menge,0) AS Menge,
CASE P.PositionKZ 
	WHEN ''N'' THEN ''Normalposition''
	WHEN ''E'' THEN ''Bedarfspos. o. GB''
	WHEN ''A'' THEN ''Alternativposition''
	WHEN ''M'' THEN ''Bedarfspos m. GB'' END AS PositionKZ,
CASE WHEN P.LVStatus = ''B'' THEN 1 ELSE 0 END AS Ordered,
P.ShortDescription,
ISNULL(P.Menge,0) AS OrderedQuantity,
(ISNULL(P.Menge,0) - ISNULL(B.DeliveredQuantity,0)) AS RemainingQuantity,
ISNULL(B.DeliveredQuantity,0) AS DeliveredQuantity,
B.SNO,
P.LVSection,
P.LVStatus
FROM Position P 
INNER JOIN (SELECT 
B.PositionID,
B.SNO,
B.Quantity AS Menge,
B1.Quantity AS DeliveredQuantity
FROM BlattDetails B 
LEFT JOIN (SELECT PositionID,ISNULL(SUM(Quantity),0) AS Quantity
FROM BlattDetails WHERE IsActiveDelivery = 1 GROUP BY PositionID) B1
	ON B.PositionID = B1.PositionID
WHERE B.IsActiveDelivery = 0) B ON P.PositionID = B.PositionID
SELECT BlattID,BlattNumber FROM Blatt 
WHERE ProjectID = @ProjectID 
AND IsActiveDelivery = 0
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_OTTODetails]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_OTTODetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[P_Get_OTTODetails]

AS

BEGIN	
 
     SELECT OttoID,ShortName,FullName,IsBranch,Street,PostalCode,City,Country,ILN,BankName,BankPostalCode,BankAccNo,DVNr,
	 TenderNo,DebtorNo,CountryType,Industry,ArtBevBew,ArtNU,BGBez,BGDatum,BGNr,Telefon,Telefax,Website,HotLine,IBAN,BIC,
	 USTIDNr,SeatofCompany,ManagingDirector,Complementary,IsActive
	 FROM OTTOMaster
  
     SELECT ContactID, OttoID,ContactPerson,Telephone,Fax,EmailID,TaxNo,DefaultContact,IsActive
	 FROM OTTOContact
  

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionForTML]    Script Date: 6/6/2017 11:28:52 AM ******/
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
SELECT PositionID from Position WHERE ProjectID = @ProjectID     
    AND (PositionKZ = ''N'' OR PositionKZ = ''E'' OR PositionKZ = ''A'' OR PositionKZ = ''M'' OR PositionKZ = ''H'')  
    AND DetailKZ = 0 AND ISNULL(LVStatus,'''') != ''A''  
SELECT @Count = ISNULL(count(PositionID),0) FROM #Postions    
SELECT @Raster = LV_Raster FROM Project WHERE ProjectID = @ProjectID    
WHILE(@Count > 0)    
 BEGIN    
  SELECT     
  P.PositionID,P.Parent_OZ,PositionKZ AS Art,
  Position_OZ AS OZ,
  isnull(Menge,0) AS Menge,ISNULL(ME,'''') AS Einheit,isnull(ShortDescription,'''') AS Kurztext,'''' AS KurztextTA,
  ISNULL(P1.Longdiscription,'''') AS Langtext,
    '''' AS LangtextTA,'''' AS LangtextTB,ISNULL(MA_verkaufspreis,0) + ISNULL(MO_verkaufspreis,0) AS EP,
    (ISNULL(MA_verkaufspreis,0) + ISNULL(MO_verkaufspreis,0)) * ISNULL(Menge,0) AS GB,    
    ISNULL(LVSection,'''') AS Nachlass,'''' AS SB,'''' AS SummePsch,    
    CASE P.PositionKZ 
	WHEN ''E''THEN ''E''
	WHEN ''M''THEN ''M'' 
	ELSE ''''	END AS Bedarf,
	'''' AS StPos,'''' AS ZZGruppeNr,'''' AS ZZLfdNr,'''' AS BezugBeschr,'''' AS BezugOZ,'''' AS LeitBeschr,    
    '''' AS ZuschlArt,'''' AS Nr,'''' AS Bez,'''' AS Entf,'''' AS EPAufgl,'''' AS Bezuschl,'''' AS StLNr,'''' AS SPos,    
'''' AS NachtrNr,'''' AS NachtrStatus,'''' AS BezugAusfNr,'''' AS MeAng,'''' AS PrAng,'''' AS FrMenge,'''' AS VaMenge,    
    '''' AS ReMenge,'''' AS Beauftragt,
	CASE 
	WHEN P.PositionKZ = ''E'' AND P.LVStatus = ''B'' THEN ''E''
	WHEN P.PositionKZ = ''M'' AND P.LVStatus = ''B'' THEN ''M'' 
	ELSE '''' END AS BedarfAuftr,
	'''' AS EP110,'''' AS EPAnteil1,'''' AS EPAnteil2,    
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
 ORDER BY sequenceNo   
    INSERT INTO #TEMP    
    SELECT DISTINCT P.Parent_OZ FROM Position P INNER JOIN #Postions P1 ON P.PositionID = P1.PositionID    
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
SELECT PositionID from Position WHERE ProjectID = @ProjectID     
    AND (PositionKZ = ''N'' OR PositionKZ = ''E'' OR PositionKZ = ''A'' OR PositionKZ = ''M'' OR PositionKZ = ''H'')  
    AND DetailKZ = 0 AND LVSection = @LVSection AND ISNULL(LVStatus,'''') != ''A''  
SELECT @Count = ISNULL(count(PositionID),0) FROM #Postions    
SELECT @Raster = LV_Raster FROM Project WHERE ProjectID = @ProjectID    
WHILE(@Count > 0)    
 BEGIN    
  SELECT     
  P.PositionID,P.Parent_OZ,PositionKZ AS Art,
  Position_OZ AS OZ,
  isnull(Menge,0) AS Menge,ISNULL(ME,'''') AS Einheit,isnull(ShortDescription,'''') AS Kurztext,'''' AS KurztextTA,
  ISNULL(P1.Longdiscription,'''') AS Langtext,
    '''' AS LangtextTA,'''' AS LangtextTB,ISNULL(MA_verkaufspreis,0) + ISNULL(MO_verkaufspreis,0) AS EP,
    (ISNULL(MA_verkaufspreis,0) + ISNULL(MO_verkaufspreis,0)) * ISNULL(Menge,0) AS GB,    
    ISNULL(LVSection,'''') AS Nachlass,'''' AS SB,'''' AS SummePsch,    
    CASE P.PositionKZ 
	WHEN ''E''THEN ''E''
	WHEN ''M''THEN ''M'' 
	ELSE ''''	END AS Bedarf,
	'''' AS StPos,'''' AS ZZGruppeNr,'''' AS ZZLfdNr,'''' AS BezugBeschr,'''' AS BezugOZ,'''' AS LeitBeschr,    
    '''' AS ZuschlArt,'''' AS Nr,'''' AS Bez,'''' AS Entf,'''' AS EPAufgl,'''' AS Bezuschl,'''' AS StLNr,'''' AS SPos, 
	'''' AS NachtrNr,'''' AS NachtrStatus,'''' AS BezugAusfNr,'''' AS MeAng,'''' AS PrAng,'''' AS FrMenge,'''' AS VaMenge,    
    '''' AS ReMenge,'''' AS Beauftragt,
	CASE 
	WHEN P.PositionKZ = ''E'' AND P.LVStatus = ''B'' THEN ''E''
	WHEN P.PositionKZ = ''M'' AND P.LVStatus = ''B'' THEN ''M'' 
	ELSE '''' END AS BedarfAuftr,
	'''' AS EP110,'''' AS EPAnteil1,'''' AS EPAnteil2,    
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
 ORDER BY sequenceNo   
    INSERT INTO #TEMP    
    SELECT DISTINCT P.Parent_OZ FROM Position P INNER JOIN #Postions P1 ON P.PositionID = P1.PositionID    
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
/****** Object:  StoredProcedure [dbo].[P_Get_PositionKZ]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Get_PositionList]    Script Date: 6/6/2017 11:28:52 AM ******/
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
    
 SELECT    
 p.[PositionID],[ProjectID],[Position_OZ],[Parent_OZ],[Title],[GetTitle],[ShortDescription],[PositionKZ]  
 ,[LVSection],[WG],[WA],[WI],  
 Menge,[ME],[Fabricate],[LiefrantMA],[Type],  
 [LVStatus],[ProposalNo],[surchargefrom],[surchargeto],[surchargePercentage],[surchargePercentage_MO],  
 [DetailKZ],[LVStatus_GAEB],[LVStatus_OTTO],[GetTitle],  
 CAST(MA_verkaufspreis + MO_verkaufspreis AS DECIMAL(10,3)) AS EP,  
 cast(((MA_verkaufspreis + MO_verkaufspreis) * Menge) as decimal(10,3))AS GB,  
 validitydate,MA,MO,minutes,Faktor,MA_listprice,MO_listprice,  
 MA_Multi1,MA_multi2,MA_multi3,MA_multi4,MA_multi5,  
 MA_einkaufspreis,MA_selbstkosten,MA_selbstkostenMulti,MA_verkaufspreis,MA_verkaufspreis_Multi,  
 MO_multi1,MO_multi2,MO_multi3,MO_multi4,MO_multi5,  
 MO_Einkaufspreis,MO_selbstkostenMulti,MO_selbstkosten,MO_verkaufspreisMulti,MO_verkaufspreis,std_satz,  
 PreisText,MA_einkaufspreis_lck,MA_selbstkosten_lck,MA_verkaufspreis_lck,  
 MO_Einkaufspreis_lck,MO_selbstkosten_lck,MO_verkaufspreis_lck,A,B,L,  
 DocuwareLink1,DocuwareLink2,DocuwareLink3,GrandTotalME,GrandTotalMO,FinalGB,sequenceNo AS SNO,
 ISNULL((MA_verkaufspreis * Menge),0) AS MAWithMulti,
 ISNULL((MO_verkaufspreis * Menge),0) AS MOWithMulti
 FROM Position P WHERE [ProjectID] = @projectID  
 ORDER BY SNO  
  
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionList_Copy]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionList_Copy]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[P_Get_PositionList_Copy]  
@projectID INT = 1  
AS  
BEGIN   
    
 SELECT    
 p.[PositionID],[ProjectID],[Position_OZ],[Parent_OZ],[Title],[GetTitle],[ShortDescription],[PositionKZ]  
 ,[LVSection],[WG],[WA],[WI],  
 Menge,[ME],[Fabricate],[LiefrantMA],[Type],  
 [LVStatus],[ProposalNo],[surchargefrom],[surchargeto],[surchargePercentage],[surchargePercentage_MO],  
 [DetailKZ],[LVStatus_GAEB],[LVStatus_OTTO],[GetTitle],  
 CAST(MA_verkaufspreis + MO_verkaufspreis AS DECIMAL(10,3)) AS EP,  
 cast(((MA_verkaufspreis + MO_verkaufspreis) * Menge) as decimal(10,3))AS GB,  
 validitydate,MA,MO,minutes,Faktor,MA_listprice,MO_listprice,  
 MA_Multi1,MA_multi2,MA_multi3,MA_multi4,MA_multi5,  
 MA_einkaufspreis,MA_selbstkosten,MA_selbstkostenMulti,MA_verkaufspreis,MA_verkaufspreis_Multi,  
 MO_multi1,MO_multi2,MO_multi3,MO_multi4,MO_multi5,  
 MO_Einkaufspreis,MO_selbstkostenMulti,MO_selbstkosten,MO_verkaufspreisMulti,MO_verkaufspreis,std_satz,  
 PreisText,MA_einkaufspreis_lck,MA_selbstkosten_lck,MA_verkaufspreis_lck,  
 MO_Einkaufspreis_lck,MO_selbstkosten_lck,MO_verkaufspreis_lck,A,B,L,  
 DocuwareLink1,DocuwareLink2,DocuwareLink3,GrandTotalME,GrandTotalMO,FinalGB,sequenceNo AS SNO,
 ISNULL((MA_verkaufspreis * Menge),0) AS MAWithMulti,
 ISNULL((MO_verkaufspreis * Menge),0) AS MOWithMulti
 FROM Position P 
	WHERE [ProjectID] = @projectID 
	AND (PositionKZ = ''NG'' OR PositionKZ = ''N'' OR PositionKZ = ''E'' OR PositionKZ = ''A'' OR PositionKZ = ''M'')
 ORDER BY SNO  
  
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionOZ]    Script Date: 6/6/2017 11:28:52 AM ******/
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
 DECLARE @RASTER NVARCHAR(50)
 SELECT @RASTER = LV_Raster FROM Project WHERE ProjectID = @projectID
 
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
		CREATE TABLE #TempFinalResult(PositionID INT)
		--Create a temp table here with positionId
		WHILE(@tempRowCount>=@count)
			BEGIN
				SELECT @FromOZ= dbo.PrepareOZ(@RASTER,[Position_From]+''.''), @ToOZ= dbo.PrepareOZ(@RASTER,[Position_To]+''.'') from #temp where id=@count
              
				INSERT INTO #TempChilds(PositionID,PositionOZ)
				SELECT PositionID,Position_OZ FROM Position WHERE ProjectID = @projectID and PositionKZ =''NG''
				ORDER BY 
					sequenceNo
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
			INSERT INTO #TempFinalResult
			SELECT DISTINCT(Positionid) FROM #TempParents

			INSERT INTO #TempFinalResult
			SELECT P.PositionID FROM Position P INNER JOIN (SELECT DISTINCT(Positionid) FROM #TempParents) T ON P.Parent_OZ = t.PositionID
			WHERE PositionKZ = ''N''

			SELECT P.PositionID,ProjectID,Position_OZ,DetailKZ,PositionKZ,WG,WA,WI,Menge,MA,MO,PreisText,Fabricate,Type,LVSection,LiefrantMA,
			MA_Multi1,MA_multi2,MA_multi3,MA_multi4,MA_einkaufspreis,MA_selbstkostenMulti,MA_verkaufspreis_Multi,MO_multi1,MO_multi2,MO_multi3,
			MO_multi4,MO_Einkaufspreis,MO_selbstkostenMulti,MO_verkaufspreisMulti,ME
            FROM Position P INNER JOIN #TempFinalResult T ON P.PositionID = T.PositionID
			ORDER BY sequenceNo

		DROP TABLE #TempParents
		DROP TABLE #TempChilds 
		DROP TABLE #TempResultP
	END				
  IF(@Position_Type =''LV Position'')  
  BEGIN  
            CREATE  TABLE #tempPosition(PositionID INT,PositionOZ NVARCHAR(50), [Indetity_Column] int identity(1,1))
			INSERT INTO #tempPosition(PositionID,PositionOZ)
			SELECT PositionID,Position_OZ FROM Position WHERE PositionKZ = ''N'' AND
			ProjectID= @projectID ORDER BY sequenceNo
			INSERT INTO #temp select * from @Position_OZ_Table
			SET @tempRowCount=(SELECT COUNT(*) FROM #temp)
			SET @count=1
			DECLARE @RasterCount int = 0,@Raster1 NVARCHAR(50),@OZCount int = 0
			SELECT @Raster1  = LV_raster from Project where ProjectID = @ProjectID
			select @RasterCount = Count(*) from splitstring(@Raster1,''.'')
			
		CREATE TABLE #Tempresult(PositionID INT,ID int)
           IF(@tempRowCount>0)
			 BEGIN
         WHILE(@tempRowCount>=@count)
             BEGIN
                      SELECT @FromOZ= dbo.PrepareOZ(@Raster1,[Position_From]), @ToOZ= dbo.PrepareOZ(@Raster1,[Position_To]) from #temp where id=@count
					
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
		   CREATE TABLE #FinalResult (PositionID INT)
		   INSERT INTO #FinalResult
		   SELECT DISTINCT PositionID FROM #Tempresult
		   CREATE TABLE #TEMPP (PositonID INT)
		   DECLARE @PCount INT = 0
		   SELECT @PCount = COUNT(*) FROM #Tempresult
			WHILE (@PCount > 0)
				BEGIN
					INSERT INTO #TEMPP
					SELECT DISTINCT Parent_OZ FROM Position P INNER JOIN #Tempresult T ON P.PositionID = T.PositionID
			
					DELETE FROM #Tempresult
					INSERT INTO #Tempresult(PositionID)
					SELECT PositonID FROM #TEMPP
					INSERT INTO #FinalResult
					SELECT PositonID FROM #TEMPP
					SELECT @PCount = COUNT(*) FROM #Tempresult
					DELETE FROM #TEMPP
				END
			SELECT P.PositionID,ProjectID,Position_OZ,DetailKZ,PositionKZ,WG,WA,WI,Menge,MA,MO,PreisText,Fabricate,Type,LVSection,
			LiefrantMA,MA_Multi1,MA_multi2,MA_multi3,MA_multi4,MA_einkaufspreis,MA_selbstkostenMulti,MA_verkaufspreis_Multi,MO_multi1,
			MO_multi2,MO_multi3,MO_multi4,MO_Einkaufspreis,MO_selbstkostenMulti,MO_verkaufspreisMulti,ME
            FROM Position P INNER JOIN #FinalResult T ON P.PositionID = T.PositionID
			ORDER BY sequenceNo
         END
  END  
  IF(@Position_Type =''WG/WA'')  
  BEGIN  
IF(@WG!='''') 
    BEGIN  
        SELECT P.PositionID,ProjectID,Position_OZ,DetailKZ,PositionKZ,WG,WA,WI,Menge,MA,MO,PreisText,Fabricate,Type,LVSection,
		LiefrantMA,MA_Multi1,MA_multi2,MA_multi3,MA_multi4,MA_einkaufspreis,MA_selbstkostenMulti,MA_verkaufspreis_Multi,MO_multi1,
		MO_multi2,MO_multi3,MO_multi4,MO_Einkaufspreis,MO_selbstkostenMulti,MO_verkaufspreisMulti,ME
        FROM #tempPosition T inner join Position P on T.PositionID = P.PositionID
        WHERE WG=@WG and WA=@WA ORDER BY T.Indetity_Column
    END  
    ELSE  
     BEGIN  
        SELECT P.PositionID,ProjectID,Position_OZ,DetailKZ,PositionKZ,WG,WA,WI,Menge,MA,MO,PreisText,Fabricate,Type,LVSection,
		LiefrantMA,MA_Multi1,MA_multi2,MA_multi3,MA_multi4,MA_einkaufspreis,MA_selbstkostenMulti,MA_verkaufspreis_Multi,MO_multi1,
		MO_multi2,MO_multi3,MO_multi4,MO_Einkaufspreis,MO_selbstkostenMulti,MO_verkaufspreisMulti,ME
        FROM #tempPosition T inner join Position P on T.PositionID = P.PositionID
        WHERE WG=@WG ORDER BY T.Indetity_Column
     END  
  END  
   DROP TABLE #temp      
  
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionsForDelivery]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionsForDelivery]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_PositionsForDelivery]
@ProjectID INT
AS
BEGIN
	SELECT P.PositionID,P.Position_OZ,P.Menge,
	CASE P.PositionKZ 
	WHEN ''N'' THEN ''Normalposition''
	WHEN ''E'' THEN ''Bedarfspos. o. GB''
	WHEN ''A'' THEN ''Alternativposition''
	WHEN ''M'' THEN ''Bedarfspos m. GB'' END AS PositionKZ,
	CASE WHEN P.LVStatus = ''B'' THEN 1 ELSE 0 END AS Ordered,
	P.ShortDescription,
	P.Menge AS OrderedQuantity,
	P1.RemainingQuantity,
	P1.DeliveredQuantity,
	0 AS SNO,
	P.LVSection,
	P.LVStatus
	FROM Position P LEFT JOIN(	
	SELECT 
	P.PositionID,
	ISNULL(P.Menge,0) AS Menge,
	ISNULL(P.Menge,0)-ISNULL(D.Quantity,0) AS RemainingQuantity,
	ISNULL(D.Quantity,0) AS DeliveredQuantity
	FROM Position P 
	LEFT JOIN 
	(SELECT PositionID,ISNULL(SUM(Quantity),0) AS Quantity FROM BlattDetails WHERE IsActiveDelivery = 1 GROUP BY PositionID)D 
		ON P.PositionID = D.PositionID  
			WHERE ProjectID = @ProjectID) AS P1 ON P.PositionID = P1.PositionID 
			WHERE P.ProjectID = @ProjectID AND (P.PositionKZ = ''N'' OR P.PositionKZ = ''E'' OR P.PositionKZ = ''A'' OR P.PositionKZ = ''M'')
			AND P.DetailKZ = 0
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_PositionsForProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_PositionsForProposal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_PositionsForProposal]
@SupplierProposalID INT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM SupplierProposal WHERE SupplierProposalID = @SupplierProposalID)
	BEGIN
		SELECT * INTO #Temp1 FROM(
		SELECT P1.PositionID,
		Position_OZ,
		ISNULL(P1.MA_listprice,0) AS MA_listprice,
		P1.ShortDescription,
		ISNULL(P1.Menge,0) AS Menge,
		ISNULL(P1.A,'''') AS A,
		ISNULL(P1.B,'''') AS B,
		ISNULL(P1.L,'''') AS L,
		ISNULL(P1.ME,'''') AS ME,
		ISNULL(P1.MA_Multi1,1) AS MA_Multi1,
		ISNULL(P1.MA_multi2,1) AS MA_multi2,  
		ISNULL(P1.MA_multi3,1) AS MA_multi3,
		ISNULL(P1.MA_multi4,1) AS MA_multi4,
		ISNULL(P1.LiefrantMA,'''') AS LiefrantMA,
		ISNULL(P1.Fabricate,'''') AS Fabricate,
		CAST(0.000 AS DECIMAL) AS Cheapest
		FROM Position P1 INNER JOIN ProposalPosition P
		ON P.PositionID = P1.PositionID WHERE P.SupplierProposalID = @SupplierProposalID) AS R
		DECLARE @Suppliers NVARCHAR(MAX)
		SELECT @Suppliers = 
		COALESCE(@Suppliers + '','','''') + CAST(ParameterName AS VARCHAR(50)) 
		FROM (SELECT DISTINCT(ParameterName) FROM ProposalDetails where supplierproposalID = @SupplierProposalID) AS A
		DECLARE @strQuery nvarchar(max)
		set @strQuery = ''SELECT * FROM (
		SELECT PositionID, ParameterName, ParameterValue
		FROM ProposalDetails WHERE supplierproposalID = '' + CAST(@SupplierProposalID AS VARCHAR) + '') A
		PIVOT (MAX(ParameterValue) FOR ParameterName IN ('' + @Suppliers + '')) AS pvt''
		DECLARE @strNewQuery VARCHAR(MAX)
		SET @strNewQuery =''SELECT * INTO ##tmh FROM (''+@strQuery+'') AS T''
		EXEC(@strNewQuery)
		SELECT * INTO #Temp FROM ##tmh
		SELECT * FROM #Temp T inner join #Temp1 T1 on T.PositionID = T1.PositionID
		DROP TABLE ##tmh
		DROP TABLE #Temp1
		DROP TABLE #Temp
	END
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
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
CASE WHEN PO.Actual_LV > 0 THEN ''true'' ELSE ''false'' END AS IsDisable,
ISNULL(P.InvoiceType,0) As IsCumulated
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
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectDetailsforOTTOMaster]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ProjectDetailsforOTTOMaster]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[P_Get_ProjectDetailsforOTTOMaster]

AS

BEGIN	
 
     SELECT ProjectID,UPPER(ProjectNumber) AS ProjectNumber FROM Project

     SELECT ProjectID, InvoiceID,InvoiceNumber,InvoiceAmount FROM Invoice

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectList]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Get_ProjectNumber]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ProjectNumber]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_ProjectNumber]
AS
BEGIN
  
  SELECT ProjectID,ProjectNumber FROM Project


END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_Rabatt]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Rabatt]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_Rabatt]
AS
BEGIN

SELECT 
	T.TypID,
	T.Typ,
	W1.WG + ''/'' + W1.WA + ''/'' + W.WI + ''-'' + S.FullName AS ArtDesc,
	W.Multi1,
	W.Multi2,
	W.Multi3,
	W.Multi4
	FROM Typ T
	INNER JOIN Supplier S ON T.SupplierID = S.SupplierID
	INNER JOIN WI W ON T.WIID = W.WIID
	INNER JOIN WG W1 ON W.WGID = W1.WGID


SELECT 
R.RabattID,
R.Rabatt,
R.TypeID,
R.Multi1,
R.Multi2,
R.Multi3,
R.Multi4,
R.ValidityDate,
T.Typ
FROM Rabatt R INNER JOIN Typ T ON R.TypeID = T.TypID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ReportDesign]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ReportDesign]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_ReportDesign]
@Type varchar(200)

AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
		       SELECT DesignID,DesignType,COL1,COL2,COL3,COL4,COL5,COL6,COL7,COL8,COL9,COL10
			   FROM ReportDesign 
			   WHERE DesignType=@Type
			  
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
/****** Object:  StoredProcedure [dbo].[P_Get_ReportDesignTypes]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ReportDesignTypes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[P_Get_ReportDesignTypes]
@Type varchar(100)
AS

BEGIN	
     IF(@Type='''')
	 BEGIN
       SELECT DesignID,DesignType FROM ReportDesign
	 END
	 ELSE
	  BEGIN
	   SELECT TextID,TextModuleArea,Category,Contents FROM TextModule 
	  WHERE TextModuleArea=@Type
	 END
	 

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_ShowUmlage]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_ShowUmlage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_ShowUmlage]
@ProjectId INT
AS
BEGIN

DECLARE @MATotal DECIMAL(8,3),@MOTotal DECIMAL(8,3),@MaUmlage DECIMAL(8,3),@MOUmlage DECIMAL(8,3)

SELECT @MATotal = ISNULL(SUM(MA_einkaufspreis),0) FROM Position 
WHERE ProjectID = @ProjectId
--AND MA_selbstkosten_lck = 0
AND DetailKZ = 0 
AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
AND LVSection = ''HA''

SELECT @MOTotal = ISNULL(SUM(MO_Einkaufspreis),0) FROM Position
WHERE ProjectID = @ProjectId
--AND MO_selbstkosten_lck = 0
AND DetailKZ = 0 
AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
AND LVSection = ''HA''

SELECT @MaUmlage = ISNULL(SUM(ISNULL(MA_einkaufspreis,0) *  (ISNULL(MA_SelbakostenUmlage,1) - 1)),0) FROM Position
WHERE ProjectID = @ProjectId
--AND MA_selbstkosten_lck = 0
AND DetailKZ = 0 
AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
AND LVSection = ''HA''

SELECT @MOUmlage = ISNULL(SUM(ISNULL(MO_Einkaufspreis,0) *  (ISNULL(MO_SelbakostenUmlage,1) - 1)),0) FROM Position
WHERE ProjectID = @ProjectId
--AND MO_selbstkosten_lck = 0
AND DetailKZ = 0 
AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
AND LVSection = ''HA''

SELECT @MATotal + @MOTotal AS TotalPrice,@MaUmlage + @MOUmlage AS TotalUmlage

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_SpecialCost]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_SpecialCost]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_SpecialCost]
@ProjectID INT
AS
	BEGIN
		IF EXISTS (SELECT 1 FROM SpecialCost WHERE ProjectID = @ProjectID)
			BEGIN
			SELECT SpecialCostID, 
					Cost_Desciption,
					Price FROM SpecialCost 
						WHERE ProjectID = @ProjectID
			END
		ELSE
			BEGIN
				DECLARE @dt SpecialCost
				INSERT INTO @dt
				VALUES (0,''Baustelleneinrichtung/Set up of construction site'',0)
				INSERT INTO @dt
				VALUES (0,''Umlage Logistik/Logistic Costs'',0)
				INSERT INTO @dt
				VALUES (0,''Konventionalstrafe/Contract Penality'',0)
				INSERT INTO @dt
				VALUES (0,''VDI6022 Hygienereinigung/Cleaning'',0)
				INSERT INTO @dt
				VALUES (0,''Befestigungsmaterial/Material of Fixing'',0)
				INSERT INTO @dt
				VALUES (0,''Besondere Anforderungen a.d. Montage/Special '',0)
				INSERT INTO @dt
				VALUES (0,''Sonstige/Other'',0)
				INSERT INTO @dt
				VALUES (0,''Sonstige/Other'',0)
				INSERT INTO @dt
				VALUES (0,''Sonstige/Other'',0)

				SELECT 
				SpecialCostID,
				Cost_Description AS Cost_Desciption,
				Price
				FROM @dt
			END
	END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_Supplier]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Supplier]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[P_Get_Supplier]
AS
BEGIN	
 
     SELECT SupplierID,FullName,ShortName,PaymentCondition,Commentary,EmailID
	 FROM Supplier
  
     SELECT ContactPersonID, SupplierID,ContactName,Salutation,Designation,EmailID,Telephone,FAX,DefaultContact
	 FROM SupplierContact
  
     SELECT  AddressID, SupplierID,ShortName,StreetNo,PostalCode,City,Country,DefaultAddress
	 FROM SupplierAddress

	 SELECT WGWAID,SupplierID,WG,WA,WGDescription FROM WGWA
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_SupplierProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_SupplierProposal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_SupplierProposal]
@ProjectID INT
AS
BEGIN
    
SELECT S.SupplierProposalID,
ProposalID,
ProjectID,
LVSection,
WG + ''-'' + WA AS WGWA,
T.Supplier,
S.CreatedDate
FROM SupplierProposal S INNER JOIN (SELECT SupplierProposalID, Supplier = 
    STUFF((SELECT '', '' + ShortName
           FROM 
		   (SELECT P.SupplierProposalID,S.ShortName 
		   FROM ProposalSupplier P 
			INNER JOIN Supplier S 
			ON P.SupplierID = S.SupplierID)b 
           WHERE b.SupplierProposalID = a.SupplierProposalID
          FOR XML PATH('''')), 1, 2, '''')
FROM SupplierProposal a
GROUP BY SupplierProposalID) AS T ON S.SupplierProposalID = T.SupplierProposalID
WHERE S.ProjectID = @ProjectID
 
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_TextModuleAreas]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_TextModuleAreas]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Get_TextModuleAreas]

AS
BEGIN
SELECT  *FROM TextModuleArea

SELECT TextID,TextModuleArea,Category,Contents,IsSelect,TextAreaID,CategoryID FROM TextModule

--SELECT TM.TextID, TMA.TextAreas,C.CategoryName,TM.Contents FROM TextModule TM
--join TextModuleArea TMA
--on TM.TextAreaID=TMA.TextAreaID
--join Category C
--on TM.CategoryID=C.CategoryID

END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_TextModuleTypes]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_TextModuleTypes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE Proc [dbo].[P_Get_TextModuleTypes]
@Type varchar(100)
AS

BEGIN	
 
     SELECT TextID,TextModuleArea,Category,Contents FROM TextModule 
	 WHERE TextModuleArea=@Type
	 

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_TMLFile]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Get_Typ]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_Typ]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_Typ]

AS

BEGIN

SELECT WGID,WG,WA,WGDescription,WG + ''/'' + WA + ''-'' + WGDescription AS [WGWADesc] FROM WG

SELECT WIID,WGID,WI,WIDescription,WI + ''-'' + WIDescription AS [WIDesc] FROM WI

SELECT SupplierID,FullName,ShortName FROM Supplier

SELECT TypID,Typ,W.WIID,W.WI,W1.WGID,W1.WG,W1.WA,T.SupplierID,S.FullName
FROM Typ T
INNER JOIN WI W ON T.WIID = W.WIID
INNER JOIN WG W1 ON W.WGID = W1.WGID
INNER JOIN Supplier S ON T.SupplierID = S.SupplierID

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_UserInfo]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_UserInfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Get_UserInfo]
AS

BEGIN	
 
     SELECT UserID,RoleID,UserName,FirstName,LastName,Password,MobileNo,EmailID
	 FROM UserInfo

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_UserRoles]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_UserRoles]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[P_Get_UserRoles]
AS

BEGIN	
 
     SELECT RoleID,RoleName
	 FROM UserRole

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_WGForMulti]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_WGForMulti]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_WGForMulti]
@ProjectID INT,
@LVSection NVARCHAR(500)
AS
BEGIN
--Retrieving LV Sections from Imput
DECLARE @dtLVSection TABLE(LVSection NVARCHAR(10))
INSERT INTO @dtLVSection(LVSection)
SELECT * FROM SplitString(@LVSection,'','')
--Temp table to persist distinct WG
CREATE Table #wDetails(WG INT,XValue DECIMAL(18,3),SValue DECIMAL(18,3),XFactor DECIMAL(18,3),SFactor DECIMAL(18,3))
INSERT INTO #wDetails(WG)
SELECT DISTINCT WG FROM Position P WHERE ProjectID = @ProjectID 
AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
AND WG IS NOT NULL
AND P.DetailKZ = 0 
AND (PositionKZ = ''N'' OR PositionKZ = ''M'') 
AND P.MA_selbstkosten_lck = 0
--Updating Xfactor
UPDATE  T 
SET T.XValue = (
SELECT ISNULL(SUM(P.MA_einkaufspreis),0) 
FROM Position P 
WHERE P.WG = T.WG 
AND P.ProjectID = @ProjectID
AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
AND P.DetailKZ = 0 
AND (PositionKZ = ''N'' OR PositionKZ = ''M'') 
AND P.MA = ''X''
AND P.MA_selbstkosten_lck = 0
)
FROM #wDetails T
--Updating Sfactor
UPDATE  T 
SET T.SValue = (
SELECT ISNULL(SUM(P.MA_einkaufspreis),0) 
FROM Position P 
WHERE P.WG = T.WG 
AND P.ProjectID = @ProjectID
AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
AND P.DetailKZ = 0 
AND (PositionKZ = ''N'' OR PositionKZ = ''M'') 
AND P.MA = ''S''
AND P.MA_selbstkosten_lck = 0
)
FROM #wDetails T
update #wDetails set XFactor = 0,SFactor = 0
SELECT *,''Test Description'' AS WGDescritpion FROM #wDetails
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_WGForMulti6]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_WGForMulti6]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_WGForMulti6]
@ProjectID INT,
@LVSection NVARCHAR(500),
@Type NVARCHAR(50)
AS
BEGIN
	--Retrieving LV Sections from Imput
	DECLARE @dtLVSection TABLE(LVSection NVARCHAR(10))
	INSERT INTO @dtLVSection(LVSection)
	SELECT * FROM SplitString(@LVSection,'','')
	--Temp table to persist distinct WG
	CREATE Table #wDetails(WG INT,XValue DECIMAL(18,3),SValue DECIMAL(18,3),XFactor DECIMAL(18,3),SFactor DECIMAL(18,3))
	IF(@Type = ''Material'')
		BEGIN
			INSERT INTO #wDetails(WG)
			SELECT DISTINCT WG FROM Position P WHERE ProjectID = @ProjectID 
			AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
			AND WG IS NOT NULL
			AND P.DetailKZ = 0 
			AND (PositionKZ = ''N'' OR PositionKZ = ''M'') 
			AND P.MA_verkaufspreis_lck = 0
				print ''test''
			--Updating Xfactor
			UPDATE  T 
			SET T.XValue = (
			SELECT ISNULL(SUM(P.MA_selbstkosten),0) 
			FROM Position P 
			WHERE 
			P.ProjectID = @ProjectID 
			AND P.WG = T.WG 
			AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
			AND P.DetailKZ = 0 
			AND (PositionKZ = ''N'' OR PositionKZ = ''M'') 
			AND P.MA = ''X''
			AND P.MA_verkaufspreis_lck = 0
			)
			FROM #wDetails T
			--Updating Sfactor
			UPDATE  T 
			SET T.SValue = (
			SELECT ISNULL(SUM(P.MA_selbstkosten),0) 
			FROM Position P 
			WHERE P.WG = T.WG 
			AND P.ProjectID = @ProjectID 
			AND (LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection) OR LVSection = '''')
			AND P.DetailKZ = 0 
			AND (PositionKZ = ''N'' OR PositionKZ = ''M'') 
			AND P.MA = ''S''
			AND P.MA_verkaufspreis_lck = 0
			)
			FROM #wDetails T
		END
	ELSE IF(@Type = ''Montage'')
		BEGIN
			
			INSERT INTO #wDetails(WG)
			SELECT DISTINCT WG FROM Position P WHERE ProjectID = @ProjectID 
			AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
			AND WG IS NOT NULL
			AND P.DetailKZ = 0 
			AND (PositionKZ = ''N'' OR PositionKZ = ''M'') 
			AND P.MO_verkaufspreis_lck = 0
			--Updating Xfactor
			UPDATE  T 
			SET T.XValue = (
			SELECT ISNULL(SUM(P.MO_selbstkosten),0) 
			FROM Position P 
			WHERE P.WG = T.WG 
			AND P.ProjectID = @ProjectID
			AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
			AND P.DetailKZ = 0 
			AND (PositionKZ = ''N'' OR PositionKZ = ''M'') 
			AND P.MO = ''X''
			AND P.MO_verkaufspreis_lck = 0
			)
			FROM #wDetails T
			--Updating Sfactor
			UPDATE  T 
			SET T.SValue = (
			SELECT ISNULL(SUM(P.MO_selbstkosten),0) 
			FROM Position P 
			WHERE P.WG = T.WG 
			AND P.ProjectID = @ProjectID
			AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
			AND P.DetailKZ = 0 
			AND (PositionKZ = ''N'' OR PositionKZ = ''M'') 
			AND P.MO = ''S''
			AND P.MO_verkaufspreis_lck = 0
			)
			FROM #wDetails T
		END
	update #wDetails set XFactor = 0,SFactor = 0
	SELECT *,''Test Description'' AS WGDescritpion FROM #wDetails
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Get_WGWAForProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Get_WGWAForProposal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Get_WGWAForProposal]
@ProjectID INT,
@LVSection NVARCHAR(500),
@WG INT,
@WA INT
AS
BEGIN
CREATE TABLE #temp
	(
		[id] int,
		[ShortName] NVARCHAR(200),
		[StreetNo] NVARCHAR(200),
		[EmailID] NVARCHAR(200),
		[SupplierMail] NVARCHAR(200)
    )
	
	SELECT * INTO #TEMPDETAILS FROM (SELECT P.PositionID,sequenceNo, Position_OZ,L.Longdiscription as Longdiscription,Menge,PositionKZ,
	CASE WHEN (SELECT COUNT(PositionID) FROM ProposalPosition WHERE positionID = P.PositionID) > 0 THEN ''P''
	WHEN (SELECT COUNT(PositionID) FROM PositionDeleteStatus WHERE positionID = P.PositionID) > 0 THEN ''D''
	ELSE ''N'' END AS PositionsStatus
	FROM Position P
	INNER JOIN Position_Longdesc L
		on L.positionID=P.PositionID
    WHERE P.WG=@WG and P.WA=@WA and P.LVSection=@LVSection and PositionKZ!=''ZS'' and PositionKZ!=''Z'' and P.ProjectID=@ProjectID AND P.DetailKZ=0) AS A
	SELECT * FROM #TEMPDETAILS WHERE PositionsStatus = ''N'' ORDER BY sequenceNo
	SELECT * FROM #TEMPDETAILS WHERE PositionsStatus = ''D'' ORDER BY sequenceNo
	SELECT * FROM #TEMPDETAILS WHERE PositionsStatus = ''P'' ORDER BY sequenceNo
	
	INSERT INTO #temp SELECT s.SupplierID, s.ShortName,SA.StreetNo,sc.EmailID,S.EmailID as SupplierMail FROM Supplier as S
    LEFT JOIN SupplierAddress as SA
    ON S.SupplierID=SA.SupplierID
    LEFT JOIN SupplierContact as SC
	ON s.SupplierID=SC.SupplierID
	
	SELECT distinct T.id,T.ShortName,T.StreetNo,T.EmailID,T.SupplierMail as SupplierMail FROM #temp as T
	INNER JOIN WGWA as W
    ON T.id=W.SupplierID
    WHERE WG=@WG and WA=@WA
	DROP TABLE #temp
	DROP TABLE #TEMPDETAILS
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Imp_ArticleData]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Imp_ArticleData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Imp_ArticleData]
@dtArticle dtArticle READONLY,
@dtDimensions dtDimension READONLY
AS
BEGIN


SET NOCOUNT ON;
BEGIN TRY
BEGIN TRAN

CREATE TABLE #WIDetails(
WGID INT,
WIID INT,
WG NVARCHAR(10),
WA NVARCHAR(10), 
WI NVARCHAR(10),
WIDesc NVARCHAR(200),
Fabrikat NVARCHAR(100),
Masseinheit NVARCHAR(20),
Dimension NVARCHAR(20),
TYP NVARCHAR(100),
Supplier NVARCHAR(100),
SupplierID INT,
TYPID INT,
Rabattgruppe NVARCHAR(10),
[KEY] INT
)
--Inserting WGWa Details
INSERT INTO WG(
WG,
WA,
WGDescription,
WADescription,
CreatedBy,
CreatedDate,
IsActive)
SELECT DISTINCT 
Warengrouppe,
Warenart,
WGDesc,
WADesc,
1,
GETDATE(),
1 
FROM @dtArticle
INSERT INTO #WIDetailS(
WG,
WA,
WI,
WIDesc,
Fabrikat,
Masseinheit,
Dimension,
TYP,
Supplier,
Rabattgruppe,
[KEY])
SELECT Warengrouppe,
Warenart,
Warennummer,
WIDesc,
Fabrikat,
Masseinheit,
Dimension,
Typ,
Lieferant,
Rabattgruppe,
[Key] 
FROM @dtArticle
--Saving WI details with WGID in temparary
UPDATE W SET 
WGID = WG.WGID
FROM #WIDetails W 
INNER JOIN WG 
	ON W.WG = WG.WG AND W.WA = WG.WA
--Inserting WI details
INSERT INTO WI(
WGID,
WI,
WIDescription,
Fabrikate,
Masseinheit,
Dimension,
ValidityDate,
Multi1,
Multi2,
Multi3,
Multi4,
IsActive)
SELECT DISTINCT WGID,
WI,
WIDesc,
Fabrikat,
Masseinheit,
Dimension,
GETDATE(),
1,1,1,1,1 
FROM #WIDetails
---UPDATING WIID to main table
UPDATE W SET 
WIID = WI.WIID
FROM #WIDetails W 
INNER JOIN WI 
	ON W.WI = WI.WI AND W.WGID = WI.WGID
--Inserting Supplier details
INSERT INTO Supplier(
FullName,
ShortName,
CreatedBy,
CreatedDate,
IsActive)
SELECT DISTINCT 
Supplier,
Supplier,
1,
GETDATE(),1 
FROM #WIDetails T WHERE 
NOT EXISTS(SELECT FullName FROM Supplier S 
WHERE S.FullName = T.Supplier) AND T.Supplier != ''''
--UPDATING supplierID to Main Table
UPDATE W SET 
SupplierID = S.SupplierID
FROM #WIDetails W 
INNER JOIN Supplier S 
	ON W.Supplier = S.FullName
--select * from #WIDetails
-- Inserting Typ Details
INSERT INTO Typ(SupplierID,WIID,Typ,CreatedBy,CreatedDate)
SELECT SupplierID,WIID,TYP,1,GETDATE() FROM 
(SELECT MIN(WIID) AS WIID ,TYP,SupplierID 
FROM #WIDetails GROUP BY TYP,SupplierID) AS A WHERE
NOT EXISTS (SELECT TYP FROM Typ T WHERE T.Typ = A.TYP) AND A.TYP != ''''
--Updating TypID in main table
UPDATE W SET 
TYPID = T.TypID
FROM #WIDetails W 
INNER JOIN Typ T 
	ON W.TYP = T.Typ
--Inserting Rabatt Details
INSERT INTO Rabatt(Rabatt,TypeID,Multi1,Multi2,Multi3,Multi4,ValidityDate,CreatedBy,CreatedDate)
SELECT Rabattgruppe,
TYPID,
ISNULL(Multi1,1),
ISNULL(Multi2,1),
ISNULL(Multi3,1),
ISNULL(Multi4,1),
ISNULL(ValidityDate,GETDATE()),1,GETDATE() FROM 
(SELECT [KEY],A.TYPID,B.Rabattgruppe FROM ((SELECT MIN([KEY]) AS [KEY],TYPID FROM #WIDetails GROUP BY TYPID) A
INNER JOIN (SELECT Rabattgruppe,MIN(TYPID) AS TYPID FROM #WIDetails GROUP BY Rabattgruppe) B 
ON A.TYPID = B.TYPID)) S LEFT JOIN (SELECT DISTINCT [Key],Multi1,Multi2,Multi3,Multi4,ValidityDate FROM @dtDimensions) T
ON S.[KEY] = T.[Key] WHERE S.Rabattgruppe != ''''
----Inserting Dimensions
----INSERT INTO Dimension(WIID,A,B,L,ListPrice,GMulti,Minuten,CreatedBy,CreatedDate,ValidityDate,IsActive)
--SELECT A.WIID,D.A,D.B,D.L,D.[L-Preis],1,D.[Montage Zeit],1,GETDATE(),ValidityDate,1 
--FROM @dtDimensions D 
--INNER JOIN #WIDetails A 
--	ON D.[Key] = A.[KEY]
INSERT INTO Dimension(WIID,A,B,L,ListPrice,GMulti,Minuten,CreatedBy,CreatedDate,ValidityDate,IsActive)
SELECT A.WIID,D.A,D.B,D.L,MIN(D.[L-Preis]),1,MIN(D.[Montage Zeit]),1,GETDATE(),MIN(ValidityDate),1 
FROM @dtDimensions D 
INNER JOIN #WIDetails A 
	ON D.[Key] = A.[KEY]
GROUP BY A.WIID,D.A,D.B,D.L
COMMIT TRAN

END TRY
BEGIN CATCH
SELECT ERROR_MESSAGE() AS ErrorMessage
IF(@@TRANCOUNT > 0)
ROLLBACK TRAN
END CATCH

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Import]    Script Date: 6/6/2017 11:28:52 AM ******/
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
 SELECT Position_OZ FROM Position WHERE Position_OZ IN (SELECT OZ FROM @dtImport) AND ProjectID = @ProjectID AND Position_OZ != ''''  
 SELECT @Count = COUNT(*) FROM @dt      
  
 IF(@Count = 0)      
  BEGIN      
         
   INSERT INTO Position(ProjectID,Position_OZ,ShortDescription,PositionKZ,Menge,DetailKZ,ME,LVSection,Title,sequenceNo)  
   SELECT @ProjectID,OZ,Kurztext,Art,Menge,0,Einheit,Nachlass,Title,SNO  
   FROM @dtImport WHERE Art = ''NG''      
         
    INSERT INTO Position(ProjectID,Position_OZ,ShortDescription,PositionKZ,Menge,DetailKZ,ME,  
       LVSection,MA_Multi1,MA_multi2,MA_multi3,MA_multi4,MO_multi1,MO_multi2,MO_multi3,MO_multi4,      
       MA_selbstkostenMulti,MA_verkaufspreis_Multi,MO_selbstkostenMulti,MO_verkaufspreisMulti,MA,MO,  
       MA_einkaufspreis_lck,MA_selbstkosten_lck,MA_verkaufspreis_lck,MO_Einkaufspreis_lck,    
       MO_selbstkosten_lck,MO_verkaufspreis_lck,Faktor,Title,sequenceNo)      
   SELECT @ProjectID,OZ,Kurztext,Art,Menge,0,Einheit,Nachlass,1,1,1,1,1,1,1,1,1,1,1,1,''X'',''X'',0,0,0,0,0,0,1,Title,SNO  
   FROM @dtImport WHERE Art != ''NG''      
         
   UPDATE      
    Position      
   SET      
    Position.Parent_OZ = P1.ParentID  
   FROM      
   (      
   SELECT I.SNO,P.PositionID  AS ParentID  
   FROM @dtImport I       
   INNER JOIN Position P       
   ON I.ParentOZ = P.Position_OZ AND P.ProjectID = @ProjectID AND I.ParentOZ != ''''  
   ) AS P1      
   WHERE Position.sequenceNo = P1.SNO AND Position.ProjectID = @ProjectID  
            
   INSERT INTO Position_Longdesc(positionID,Longdiscription)      
   SELECT P.PositionID,D.Langtext FROM @dtImport D INNER JOIN Position P       
   ON D.SNO = P.sequenceNo WHERE P.ProjectID = @ProjectID      
         
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
/****** Object:  StoredProcedure [dbo].[P_Ins_Article]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Article]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Article]
@XMLArticle XML
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
		   --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLArticle 
			  SELECT * INTO #Temp from 
			  (SELECT 
			  A.WGID,A.WG,A.WA,A.WGDescription,A.WADescription,
			  A.WIID,A.WI,A.WIDescription,A.Fabrikate,A.Typ,A.Masseinheit,A.Dimension,
			  A.Menegenheit,A.Remarks,A.TextKZ,A.ValidityDate,
			  A.Multi1,A.Multi2,A.Multi3,A.Multi4,A.DataNormNumber,
			  A.CreatedBy,A.LastUpdatedBy
              FROM OPENXML (@XmlDocumentHandle, ''/Nouns/Article'',2) 
                              WITH (WGID INT,WG NVARCHAR(10),WA NVARCHAR(10),WGDescription NVARCHAR(500),WADescription NVARCHAR(500),
							  WIID INT,WI NVARCHAR(10),WIDescription NVARCHAR(500),Fabrikate NVARCHAR(100),Typ NVARCHAR(100),Masseinheit NVARCHAR(100),Dimension NVARCHAR(100),
							  Menegenheit NVARCHAR(100),Remarks NVARCHAR(500),TextKZ NVARCHAR(10),ValidityDate DATE,
							  Multi1 DECIMAL(8,3),Multi2 DECIMAL(8,3),Multi3 DECIMAL(8,3),Multi4 DECIMAL(8,3),DataNormNumber NVARCHAR(100),
							  CreatedBy int,LastUpdatedBy int
							   )
							  A) As T
	DECLARE @WGID INT, @WIID INT, @WG NVARCHAR(10),@WA NVARCHAR(10),@WI NVARCHAR(10)
	SELECT @WGID = WGID , @WIID = WIID,@WG = WG,@WA = WA,@WI = WI FROM #Temp
	IF(@WGID < 0)
	BEGIN
		IF EXISTS (SELECT 1 FROM WG WHERE WG = @WG AND WA = @WA)
		BEGIN
			SELECT @WGID = WGID FROM WG WHERE WG = @WG AND WA = @WA
		END
		ELSE
		BEGIN
			INSERT INTO WG(WG,WA,WGDescription,WADescription,CreatedBy,CreatedDate,IsActive)
			SELECT WG,WA,WGDescription,WADescription,CreatedBy,GETDATE(),1 FROM #Temp
			SET @WGID = SCOPE_IDENTITY()
		END
	END
	ELSE
	BEGIN
		UPDATE T
		SET T.WG = S.WG,
		T.WGDescription = S.WGDescription,
		T.WA = S.WA,
		T.WADescription = S.WADescription,
		T.LastUpdatedBy = S.LastUpdatedBy,
		T.LastUpdateDate = GETDATE()
		FROM WG T
		INNER JOIN #Temp S ON T.WGID = S.WGID
	END
	
	IF(@WIID < 0)
	BEGIN
		INSERT INTO WI(WGID,WI,WIDescription,Fabrikate,Masseinheit,Dimension,Menegenheit,
		Remarks,TextKZ,ValidityDate,Multi1,Multi2,Multi3,Multi4,DataNormNumber,CreatedBy,CreateDate,IsActive)
		SELECT 
		@WGID,WI,WIDescription,Fabrikate,Masseinheit,Dimension,Menegenheit,
		Remarks,TextKZ,ValidityDate,Multi1,Multi2,Multi3,Multi4,DataNormNumber,CreatedBy,GETDATE(),1
		FROM #Temp
		SET @WIID = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		UPDATE T
		SET 
		T.WGID = S.WGID,
		T.WI = S.WI,
		T.WIDescription = S.WIDescription,
		T.Fabrikate = S.Fabrikate,
		T.Masseinheit = S.Masseinheit,
		T.Dimension = S.Dimension,
		T.Menegenheit = S.Menegenheit,
		T.Remarks = S.Remarks,
		T.TextKZ = S.TextKZ,
		T.ValidityDate = S.ValidityDate,
		T.Multi1 = S.Multi1,
		T.Multi2 = S.Multi2,
		T.Multi3 = S.Multi3,
		T.Multi4 = S.Multi4,
		T.DataNormNumber = S.DataNormNumber,
		T.LastUpdatedBy = S.LastUpdatedBy,
		T.LastUpdatedDate = GETDATE()
		FROM WI T
		INNER JOIN #Temp S ON T.WIID = S.WIID
	END
	SELECT @WGID,@WIID
	
	SELECT WGID,WG,WA,WGDescription,WADescription
		FROM WG
	
	SELECT W.WIID,WGID,WI,WIDescription,Fabrikate,Masseinheit,Dimension,Menegenheit,
			Remarks,TextKZ,
			ISNULL(D.ValidityDate,GETDATE()) AS ValidityDate,
			ISNULL(W.Multi1,1) AS Multi1,
			ISNULL(W.Multi2,1) AS Multi2,
			ISNULL(W.Multi3,1) AS Multi3,
			ISNULL(W.Multi4,1) AS Multi4,
			DataNormNumber,
			T.Typ,
			S.FullName,
			R.Rabatt
			FROM WI 
			W LEFT JOIN  
			(SELECT MAX(ValidityDate)AS ValidityDate,WIID FROM Dimension WHERE ValidityDate <= GETDATE() GROUP BY WIID) D ON W.WIID = D.WIID
			LEFT JOIN 
			(SELECT T.TypID,SupplierID,T.WIID,Typ,CreatedBy,LastUpdatedBy,CreatedDate,LastUpdatedDate 
				FROM Typ T INNER JOIN(SELECT  MIN(TypID) AS TypID,WIID FROM Typ GROUP BY WIID) AS S ON T.TypID = s.TypID) AS
			 T ON W.WIID = T.WIID
			LEFT JOIN Supplier S ON T.SupplierID = S.SupplierID
			LEFT JOIN (SELECT
						T.RabattID,Rabatt,T.TypeID,Multi1,Multi2,Multi3,Multi4,T.ValidityDate
						FROM Rabatt T INNER JOIN(SELECT  MAX(ValidityDate) AS ValidityDate ,TypeID 
						FROM Rabatt WHERE ValidityDate <= GETDATE() GROUP BY TypeID) AS S 
						ON T.TypeID = S.TypeID AND T.ValidityDate = S.ValidityDate)
			 R ON T.TypID = R.TypeID
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
/****** Object:  StoredProcedure [dbo].[P_Ins_BlattDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_BlattDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_BlattDetails]
@BlattID int = -1,
@ProjetcID INT,
@BlattNumber NVARCHAR(50),
@IsActiveDelivery BIT,
@Delivery dtDelivery READONLY
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRAN
			IF EXISTS(SELECT 1 FROM @Delivery WHERE Menge <= 0 OR Menge is null)
			BEGIN
			SELECT ''Please Enter Valid Menge''
			ROLLBACK TRAN
			return
			END
			IF @BlattID < 0
				BEGIN
					DECLARE @BlattNumberID INT = 0
					SELECT @BlattNumberID = ISNULL(MAX(BlattNumberID),0) + 1 FROM Blatt WHERE ProjectID = @ProjetcID
					INSERT INTO Blatt(BlattNumber,BlattNumberID,IsActiveDelivery,IsInvoiced,ProjectID,CreatedBy,CreatedDate)
					VALUES(@BlattNumber,@BlattNumberID,@IsActiveDelivery,0,@ProjetcID,1,GETDATE())
					SET @BlattID = SCOPE_IDENTITY()
				END
			ELSE
				BEGIN
					UPDATE Blatt SET 
					BlattNumber = @BlattNumber,
					IsActiveDelivery = @IsActiveDelivery,
					ProjectID = @ProjetcID,
					LastUpdatedBy = 1,
					LastUpdatedDate = GETDATE()
					WHERE BlattID = @BlattID
				END
			DELETE FROM BlattDetails WHERE BlattID = @BlattID
			INSERT INTO BlattDetails(BlattID,IsActiveDelivery,IsInvoiced,PositionID,Quantity,CreatedBy,CreatedDate,Status,SNO)
			SELECT @BlattID,@IsActiveDelivery,0,PositionID,Menge,1,GETDATE(),1,SNO FROM @Delivery
			
			SELECT @BlattID
			EXEC P_Get_PositionsForDelivery @ProjetcID
			EXEC P_Get_BlattNumbers @ProjetcID
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMessage
		IF(@@TRANCOUNT > 0)
		ROLLBACK TRAN
	END CATCH
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Category]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Category]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Category]
@XMLCategory XML
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
		   --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @CategoryID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLCategory 
			  SELECT * INTO #Temp from 
			  (SELECT 
			  CU.CategoryID,TextAreaID,
              CU.CategoryName,CU.CreatedBy,CU.LastUpdatedBy
              FROM OPENXML (@XmlDocumentHandle, ''/Nouns/Category'',2) 
                              WITH (CategoryID INT,TextAreaID INT,CategoryName NVARCHAR(200),CreatedBy int,LastUpdatedBy int
							   )
							  CU) As T
			  MERGE Category AS T
              USING #Temp as  SRC ON T.CategoryID = SRC.CategoryID
			  WHEN MATCHED THEN
              UPDATE SET 
              T.CategoryName = SRC.CategoryName,
              T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE()
              WHEN NOT MATCHED THEN
              INSERT
                 (
                       TextAreaID,CategoryName,CreatedBy,CreatedDate
						   )
              VALUES
                     (
                       SRC.TextAreaID, SRC.CategoryName,
						SRC.CreatedBy,GETDATE()
						   )             
			 
			  OUTPUT
                     INSERTED.CategoryID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
			  SELECT * FROM @Output

			  SELECT CategoryID,CategoryName
				 FROM Category
			  
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
/****** Object:  StoredProcedure [dbo].[P_Ins_Customer]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Customer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Customer]
@XMLCustomers XML
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
		   --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @CustomerID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLCustomers 
			  SELECT * INTO #Temp from 
			  (SELECT 
			  CU.CustomerID,
              CU.CustomerFullName,CU.CustomerShortName,CU.Street,CU.PostalCode,CU.City,CU.Country,CU.ILN,CU.Telephone,
			  CU.Fax,CU.EmailID,CU.TaxNumber,CU.BankName,CU.BankPostalCode,CU.BankAccountNumber,CU.DVNr,CU.TenderNumber,
			  CU.DebitorNumber,CU.CountryType,CU.CountryName,CU.CreatedBy,CU.LastUpdatedBy,CU.Commentary
              FROM OPENXML (@XmlDocumentHandle, ''/Nouns/Customer'',2) 
                              WITH ( CustomerID INT,CustomerFullName NVARCHAR(100),CustomerShortName NVARCHAR(100),Street NVARCHAR(500),
							  PostalCode NVARCHAR(50),City NVARCHAR(50),Country NVARCHAR(50),ILN NVARCHAR(100),Telephone NVARCHAR(50),
							  Fax NVARCHAR(50),EmailID NVARCHAR(50),TaxNumber NVARCHAR(50),BankName NVARCHAR(50),BankPostalCode NVARCHAR(50),
							   BankAccountNumber NVARCHAR(50),DVNr NVARCHAR(100),TenderNumber NVARCHAR(50),DebitorNumber NVARCHAR(50),
							   CountryType NVARCHAR(50),CountryName NVARCHAR(50),CreatedBy int,
							   LastUpdatedBy int,Commentary NVARCHAR(MAX)
							   )
							  CU) As T
			  MERGE Customer AS T
              USING #Temp as  SRC ON T.CustomerID = SRC.CustomerID
			  WHEN MATCHED THEN
              UPDATE SET 
              T.CustomerFullName = SRC.CustomerFullName,
              T.CustomerShortName = SRC.CustomerShortName,
			  T.Street = SRC.Street,
			  T.PostalCode = SRC.PostalCode,
              T.City = SRC.City,
              T.Country = SRC.Country,
			  T.ILN = SRC.ILN,
			  T.Telephone = SRC.Telephone,
			  T.Fax = SRC.Fax,
              T.EmailID = SRC.EmailID,
              T.TaxNumber = SRC.TaxNumber,
			  T.BankName=SRC.BankName,
			  T.BankPostalCode=SRC.BankPostalCode,
			  T.BankAccountNumber=SRC.BankAccountNumber,
			  T.DVNr=SRC.DVNr,
			  T.TenderNumber=SRC.TenderNumber,
			  T.DebitorNumber=SRC.DebitorNumber,
              T.CountryType = SRC.CountryType,
              T.CountryName = SRC.CountryName,
              T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE(),
			  T.Commentary = SRC.Commentary
              WHEN NOT MATCHED THEN
              INSERT
                 (
                        CustomerFullName,CustomerShortName,Street,PostalCode,City,Country,ILN,Telephone,Fax,EmailID,
						TaxNumber,BankName,BankPostalCode,BankAccountNumber,DVNr,TenderNumber,DebitorNumber,
						CountryType,CountryName,CreatedBy,CreatedDate,IsActive,Commentary
						   )
              VALUES
                     (
                        SRC.CustomerFullName,SRC.CustomerShortName,SRC.Street,SRC.PostalCode,SRC.City,SRC.Country,SRC.ILN,SRC.Telephone,SRC.Fax,SRC.EmailID,SRC.TaxNumber,
						SRC.BankName,SRC.BankPostalCode,SRC.BankAccountNumber, SRC.DVNr,SRC.TenderNumber,SRC.DebitorNumber,
						SRC.CountryType,SRC.CountryName,SRC.CreatedBy,GETDATE(),1,SRC.Commentary
						   )             
			 
			  OUTPUT
                     INSERTED.CustomerID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
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
/****** Object:  StoredProcedure [dbo].[P_Ins_Customer_Address]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Customer_Address]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Customer_Address]
@XMLCustomerAddress XML

AS
BEGIN
SET NOCOUNT ON;


  BEGIN TRY
           
		BEGIN TRAN
			  --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @CustomerID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLCustomerAddress 
			  print ''test''

			  SELECT * INTO #Temp  from (SELECT 
			  CU.AddressID,CU.CustomerID,CU.AddressShortName,CU.StreetNo,CU.PostalCode,CU.City,CU.Country,CU.DefaultAddress,CU.CreatedBy,CU.LastUpdatedBy
			   FROM OPENXML (@XmlDocumentHandle, ''/Nouns/CustomerAddress'',2)  
                              WITH (
                                AddressID INT,CustomerID INT,AddressShortName nvarchar(100),StreetNo nvarchar(50),PostalCode nvarchar(50),City nvarchar(50),Country nvarchar(50),
								DefaultAddress bit,CreatedBy int,
							   LastUpdatedBy int
							   )
                              CU) As T                
			  
			  DECLARE @Daddress bit=0
			  SELECT @Daddress=DefaultAddress FROM #Temp
			  IF(@Daddress=1)
			  BEGIN
			   SET @CustomerID= (select CustomerID from #Temp)
			   UPDATE CustomerAddress SET DefaultAddress=0 WHERE CustomerID=@CustomerID
			  END

			  MERGE CustomerAddress AS T
              USING #Temp as  SRC ON T.AddressID = SRC.AddressID
              WHEN NOT MATCHED THEN
              INSERT
                 (
                        CustomerID,
						AddressShortName,
						StreetNo,
						PostalCode,
						City,
						Country,
						DefaultAddress,
						CreatedBy,
						CreatedDate,
						IsActive
						   )
              VALUES
                     (
                        SRC.CustomerID,
						SRC.AddressShortName,
						SRC.StreetNo,
						SRC.PostalCode,
						SRC.City,
						SRC.Country,
						SRC.DefaultAddress,
						SRC.CreatedBy,
						GETDATE(),
						1
						   )
              WHEN MATCHED THEN
              UPDATE SET 
              --T.CustomerID = SRC.CustomerID,
              T.AddressShortName = SRC.AddressShortName,
			  T.StreetNo = SRC.StreetNo,
			  T.PostalCode = SRC.PostalCode,
              T.City = SRC.City,
              T.Country = SRC.Country,
			  T.DefaultAddress = SRC.DefaultAddress,
			  T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE()			 
			  OUTPUT
                     INSERTED.AddressID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
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
/****** Object:  StoredProcedure [dbo].[P_Ins_Customer_Contact]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Customer_Contact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Customer_Contact]
@XMLCustomerContact XML

AS
BEGIN
SET NOCOUNT ON;


  BEGIN TRY
		BEGIN TRAN
			--Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @CustomerID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLCustomerContact 
			  print ''test''

			  SELECT * INTO #Temp from (SELECT 
			           CU.ContactPersonID,CU.CustomerID,CU.Salutation,CU.ContatPersonName,CU.Designation,CU.EmailID,
						CU.Telephone,
						CU.FAX,
						CU.DefaultContact,CU.CreatedBy,CU.LastUpdatedBy
			   FROM OPENXML (@XmlDocumentHandle, ''/Nouns/CustomerContact'',2)  
                              WITH (
                               ContactPersonID INT, CustomerID INT,Salutation NVARCHAR(50),ContatPersonName NVARCHAR(50),Designation NVARCHAR(50),EmailID NVARCHAR(50),Telephone NVARCHAR(50),
								FAX NVARCHAR(50),DefaultContact bit,CreatedBy int,
							   LastUpdatedBy int
							   )
                              CU) As T

			  
			  DECLARE @DContact bit=0
			  SELECT @DContact=DefaultContact FROM #Temp
			  IF(@DContact=1)
			  BEGIN
			   SET @CustomerID= (select CustomerID from #Temp)
			  UPDATE CustomerContact SET DefaultContact=0 WHERE CustomerID=@CustomerID
			  END


			  MERGE CustomerContact AS T
              USING #Temp as  SRC ON T.ContactPersonID = SRC.ContactPersonID
              WHEN NOT MATCHED THEN
              INSERT
                 (
						CustomerID,
						Salutation,
						ContatPersonName,
						Designation,
						EmailID,
						Telephone,
						FAX,
						DefaultContact,
						CreatedBy,
						CreatedDate,
						IsActive
						   )
              VALUES
                     (                        
                        SRC.CustomerID,
						SRC.Salutation,
						SRC.ContatPersonName,
						SRC.Designation,
						SRC.EmailID,
						SRC.Telephone,
						SRC.FAX,
						SRC.DefaultContact,
						SRC.CreatedBy,
						GETDATE(),
						1
						   )		 
              WHEN MATCHED THEN
              UPDATE SET 
              T.Salutation = SRC.Salutation,
			  T.ContatPersonName = SRC.ContatPersonName,
			  T.Designation = SRC.Designation,
              T.EmailID = SRC.EmailID,
              T.Telephone = SRC.Telephone,
			  T.FAX = SRC.FAX,
			  T.DefaultContact = SRC.DefaultContact,
			  T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE()
			 
			  OUTPUT
                     INSERTED.ContactPersonID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
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
/****** Object:  StoredProcedure [dbo].[P_Ins_DeletePosition]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_DeletePosition]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_DeletePosition]
@PositionID INT,
@ProjectID INT
AS
BEGIN

  BEGIN TRY
       INSERT INTO PositionDeleteStatus(PositionID,ProjectID) 
	   VALUES(@PositionID,@ProjectID)
  END TRY
  BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMessage        
	END CATCH
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Dimension]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Dimension]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Dimension]
@XMlDimension xml
AS
BEGIN
BEGIN TRY
BEGIN TRAN
	DECLARE @XmlDocumentHandle INT
	-- Create an internal representation of the XML document.  
	EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMlDimension 
	SELECT * INTO #Temp from 
	(SELECT 
	D.DimensionID,
	D.WIID,
	D.A,
	D.B,
	D.L,
	D.ListPrice,
	D.GMulti,
	D.Minuten,
	D.ValidityDate,
	D.CreatedBy,
	D.LastUpdatedBy
	FROM OPENXML (@XmlDocumentHandle, ''/Nouns/Dimension'',2) 
					WITH (DimensionID INT,WIID INT,A NVARCHAR(10),B NVARCHAR(10),L NVARCHAR(10),
					ListPrice DECIMAL(8,3),GMulti DECIMAL(8,3),Minuten DECIMAL(8,3),ValidityDate DATE,
					CreatedBy int,LastUpdatedBy int
					)D) As T
	DECLARE @DimensionID INT = -1, @WIID INT,@ValidityDate DATE
	SELECT @DimensionID = DimensionID,@WIID = WIID FROM #Temp
	SELECT @ValidityDate = ValidityDate FROM WI WHERE WIID = @WIID
	IF(@DimensionID < 0)
		BEGIN
			INSERT INTO Dimension(WIID,A,B,L,ListPrice,Minuten,GMulti,ValidityDate,CreatedBy,CreatedDate)
			SELECT D.WIID,
			isnull(D.A,0),
			isnull(D.B,0),
			isnull(D.L,0),
			D.ListPrice,
			D.Minuten,
			D.GMulti,
			@ValidityDate,
			D.CreatedBy,
			D.LastUpdatedBy FROM #Temp D
			SET @DimensionID = SCOPE_IDENTITY()
		END
	ELSE
		BEGIN
			UPDATE D SET 
			D.WIID = T.WIID,
			D.A = T.A,
			D.B = T.B,
			D.L = T.L,
			D.ListPrice = T.ListPrice,
			D.GMulti = T.GMulti,
			D.Minuten = T.Minuten,
			--D.ValidityDate = @ValidityDate,
			D.LastUpdatedBy = T.LastUpdatedBy,
			D.LastUpdatedDate = GETDATE()
			FROM Dimension D INNER JOIN #Temp T ON D.DimensionID = T.DimensionID
		END
	SELECT @DimensionID
	
	SELECT D.DimensionID,
		D.WIID,
		D.A,
		D.B,
		D.L,
		D.ListPrice,
		D.Minuten,
		W.Multi1 * W.Multi2 * W.Multi3 *W.Multi4 AS GMulti,
		D.ValidityDate,
		W.Multi1,
		W.Multi2,
		W.Multi3,
		W.Multi4,
		(W.Multi1 * W.Multi2 * W.Multi3 *W.Multi4) * D.ListPrice AS Einkaufspreis
		FROM 
		(SELECT  D.DimensionID,D.WIID,D.A,D.B,D.L,
		D.ListPrice,D.Minuten,D.GMulti,D.ValidityDate 
		FROM Dimension D 
		INNER JOIN (SELECT MAX(ValidityDate) AS ValidityDate,WIID FROM Dimension WHERE 
		ValidityDate <= GETDATE() GROUP BY WIID
		)D1 ON D1.WIID = D.WIID AND D1.ValidityDate = D.ValidityDate)
		D INNER JOIN WI W ON D.WIID = W.WIID
		ORDER BY D.DimensionID
	COMMIT TRAN
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMessage
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRAN
	END CATCH
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_DimensionCopy]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_DimensionCopy]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_DimensionCopy]
@WIID INT,
@ValidityDate DATE,
@dtDimension Dimension READONLY
AS
BEGIN
INSERT INTO Dimension (A,B,L,WIID,ListPrice,GMulti,Minuten,ValidityDate)
SELECT A,B,L,WIID,ListPrice,GMulti,Minuten,@ValidityDate FROM @dtDimension WHERE WIID = @WIID
SELECT D.DimensionID,
	D.WIID,
	D.A,
	D.B,
	D.L,
	D.ListPrice,
	D.Minuten,
	D.GMulti,
	D.ValidityDate,
	W.Multi1,
	W.Multi2,
	W.Multi3,
	W.Multi4,
	(W.Multi1 * W.Multi2 * W.Multi3 *W.Multi4) * D.ListPrice AS Einkaufspreis
	FROM 
	(SELECT  D.DimensionID,D.WIID,D.A,D.B,D.L,
	D.ListPrice,D.Minuten,D.GMulti,D.ValidityDate 
	FROM Dimension D 
	INNER JOIN (SELECT MAX(ValidityDate) AS ValidityDate,WIID FROM Dimension WHERE 
	ValidityDate <= GETDATE() GROUP BY WIID
	)D1 ON D1.WIID = D.WIID AND D1.ValidityDate = D.ValidityDate)
	D INNER JOIN WI W ON D.WIID = W.WIID ORDER BY D.DimensionID
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Invoice]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Invoice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Invoice]
@InvoiceID INT = -1,
@ProjectID INT,
@InvoiceNumber NVARCHAR(50),
@dtInvoice dtInvoice READONLY,
@IsFinalInvoice BIT
AS
BEGIN
SET NOCOUNT ON;
	BEGIN TRY
		BEGIN TRAN
			IF NOT EXISTS (SELECT 1 FROM @dtInvoice WHERE [SELECTED] = 1)
				BEGIN
					SELECT ''Please select Atleast One Delivery Number''
					ROLLBACK TRAN  
					return
				END
			
			DECLARE @InvoiceAmount DECIMAL(8,3),@OldAmount DECIMAL(8,3),@TotalAmount DECIMAL(8,3)
			SELECT @InvoiceAmount = ISNULL(SUM(BlattPrice),0) FROM @dtInvoice WHERE [SELECTED] = 1
			SELECT @OldAmount = ISNULL(MAX(InvoiceAmount),0) FROM Invoice WHERE ProjectID = @ProjectID
	
			DECLARE @iScUMMULATED Bit = 0
			SELECT @iScUMMULATED = InvoiceType FROM Project WHERE ProjectID = @ProjectID
			IF(@iScUMMULATED = 1)
				BEGIN
					SET @TotalAmount = @InvoiceAmount + @OldAmount
				END
			ELSE
				BEGIN
					SET @TotalAmount = @InvoiceAmount
				END
			
			INSERT INTO Invoice(InvoiceNumber,InvoiceAmount,ProjectID,CreatedBy,CreatedDate,[Status])
			VALUES (@InvoiceNumber,@TotalAmount,@ProjectID,1,GETDATE(),1)
			SET @InvoiceID = SCOPE_IDENTITY()
			INSERT INTO DeliveryInvoices(BlattID,InvoiceID)
			SELECT BlattID,@InvoiceID FROM @dtInvoice WHERE [SELECTED] = 1
			
			UPDATE Blatt SET IsInvoiced = 1 
			WHERE BlattID IN 
			(SELECT BlattID FROM @dtInvoice WHERE [SELECTED] = 1)
			IF(@IsFinalInvoice = 1)
				BEGIN
					UPDATE Project SET [Status] = ''Completed'' WHERE ProjectID = @ProjectID
				END
			SELECT @InvoiceID
			EXEC P_Get_BlattNumbers @ProjectID
			EXEC p_Get_Invoices @ProjectID
		COMMIT TRAN  
	END TRY  
	BEGIN CATCH  
		SELECT ERROR_MESSAGE() AS ErrorMessage  
		IF(@@TRANCOUNT > 0)  
		ROLLBACK TRAN  
	END CATCH  
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_LVSection]    Script Date: 6/6/2017 11:28:52 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Ins_OTTO_Contact]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_OTTO_Contact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_OTTO_Contact]
@XMLOTTOContact XML

AS
BEGIN
SET NOCOUNT ON;


  BEGIN TRY
		BEGIN TRAN
			--Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @OttoID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLOTTOContact 
			  print ''test''

			  SELECT * INTO #Temp from (SELECT 
			           CU.ContactID,CU.OttoID,CU.ContactPerson,CU.Telephone,CU.Fax,CU.EmailID,
						CU.TaxNo,CU.CreatedBy,CU.LastUpdatedBy,CU.DefaultContact
			   FROM OPENXML (@XmlDocumentHandle, ''/Nouns/OTTOContact'',2)  
                              WITH (
                               ContactID INT, OttoID INT,ContactPerson NVARCHAR(50),Telephone NVARCHAR(50),Fax NVARCHAR(50),EmailID NVARCHAR(50),TaxNo NVARCHAR(50),
							   CreatedBy int,
							   LastUpdatedBy int,DefaultContact bit
							   )
                              CU) As T

              DECLARE @DContact bit=0
			  SELECT @DContact=DefaultContact FROM #Temp
			  IF(@DContact=1)
			  BEGIN
			   SET @OttoID= (select OttoID from #Temp)
			   UPDATE OTTOContact SET DefaultContact=0 WHERE OttoID=@OttoID
			  END
			  
			  MERGE OTTOContact AS T
              USING #Temp as  SRC ON T.ContactID = SRC.ContactID
              WHEN NOT MATCHED THEN
              INSERT
                 (
						OttoID,
						ContactPerson,
						Telephone,
						Fax,
						EmailID,
						TaxNo,											
						CreatedBy,
						CreatedDate,
						IsActive,
						DefaultContact
						   )
              VALUES
                     (                        
                        SRC.OttoID,
						SRC.ContactPerson,
						SRC.Telephone,
						SRC.Fax,
						SRC.EmailID,
						SRC.TaxNo,
						SRC.CreatedBy,
						GETDATE(),						
						1,
						SRC.DefaultContact				
						
						   )		 
              WHEN MATCHED THEN
              UPDATE SET 
              T.ContactPerson = SRC.ContactPerson,
			  T.Telephone = SRC.Telephone,
			  T.Fax = SRC.Fax,
              T.EmailID = SRC.EmailID,
              T.TaxNo = SRC.TaxNo,			 		  
			  T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE(),
			  T.DefaultContact = SRC.DefaultContact
			  OUTPUT
                     INSERTED.ContactID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
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
/****** Object:  StoredProcedure [dbo].[P_Ins_OTTODetails]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_OTTODetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_OTTODetails]
@XMLOTTO XML
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
		   --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @OttoID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLOTTO 
			  SELECT * INTO #Temp from 
			  (SELECT 
			  CU.OttoID,
              CU.ShortName,CU.FullName,CU.IsBranch,CU.Street,CU.PostalCode,CU.City,CU.Country,CU.ILN,
			  CU.BankName,CU.BankPostalCode,CU.BankAccNo,CU.DVNr,CU.TenderNo,CU.DebtorNo,CU.CountryType,CU.Industry,
			  CU.ArtBevBew,CU.ArtNU,CU.BGBez,CU.BGDatum,CU.BGNr,CU.Telefon,CU.Telefax,CU.Website,CU.HotLine,CU.IBAN,
			  CU.BIC,CU.USTIDNr,CU.SeatofCompany,CU.ManagingDirector,CU.Complementary,CU.CreatedBy,CU.LastUpdatedBy
              FROM OPENXML (@XmlDocumentHandle, ''/Nouns/OTTO'',2) 
                              WITH (OttoID INT,ShortName nvarchar(200),FullName nvarchar(500),IsBranch bit,
							  Street nvarchar(500),PostalCode nvarchar(100),City NVARCHAR(200),Country NVARCHAR(200),ILN NVARCHAR(500),
							  BankName NVARCHAR(500),BankPostalCode NVARCHAR(100),BankAccNo NVARCHAR(100),DVNr NVARCHAR(500),TenderNo NVARCHAR(200),
							   BankAccountNumber NVARCHAR(100),TenderNumber NVARCHAR(200),DebtorNo NVARCHAR(200),CountryType NVARCHAR(100),
							   Industry NVARCHAR(500),ArtBevBew NVARCHAR(500),ArtNU NVARCHAR(500),BGBez NVARCHAR(500),BGDatum NVARCHAR(500),BGNr NVARCHAR(500),
							   Telefon NVARCHAR(50),Telefax NVARCHAR(50),Website NVARCHAR(50),HotLine NVARCHAR(50),IBAN NVARCHAR(100),BIC NVARCHAR(100),
							   USTIDNr NVARCHAR(100),SeatofCompany NVARCHAR(100),ManagingDirector NVARCHAR(50),Complementary  NVARCHAR(200),
							   CreatedBy int,LastUpdatedBy int							   
							   )
							  CU) As T

              DECLARE @IsBranch bit=1
              IF NOT EXISTS(SELECT 1 FROM OTTOMaster)			  
			  BEGIN
			    SET @IsBranch=0
			  END
					 MERGE OTTOMaster AS T
					 USING #Temp as  SRC ON T.OttoID = SRC.OttoID
					 WHEN NOT MATCHED THEN			  
						 INSERT
							   (
								   ShortName,FullName,IsBranch,Street,PostalCode,City,Country,ILN,BankName,BankPostalCode,
									BankAccNo,DVNr,TenderNo,DebtorNo,CountryType,Industry,ArtBevBew,
									ArtNU,BGBez,BGDatum,BGNr,Telefon,Telefax,Website,HotLine,IBAN,BIC,USTIDNr,SeatofCompany,
									ManagingDirector,Complementary,CreatedBy,CreatedDate,IsActive
							   )
					  VALUES
							   (
										SRC.ShortName,SRC.FullName,@IsBranch,SRC.Street,SRC.PostalCode,SRC.City,SRC.Country,SRC.ILN,SRC.BankName,SRC.BankPostalCode,
										SRC.BankAccNo,SRC.DVNr,SRC.TenderNo,SRC.DebtorNo, SRC.CountryType,SRC.Industry,SRC.ArtBevBew,
										SRC.ArtNU,SRC.BGBez,SRC.BGDatum,SRC.BGNr,SRC.Telefon,SRC.Telefax,SRC.Website,SRC.HotLine,SRC.IBAN,SRC.BIC,SRC.USTIDNr,SRC.SeatofCompany,
										SRC.ManagingDirector,SRC.Complementary,
										SRC.CreatedBy,GETDATE(),1
							   )             
			 
			  
						 WHEN MATCHED THEN
						 UPDATE SET 
							 T.ShortName = SRC.ShortName,
							  T.FullName = SRC.FullName,
							 T.IsBranch = SRC.IsBranch,
							 T.Street = SRC.Street,
							 T.PostalCode = SRC.PostalCode,
							 T.City = SRC.City,
							 T.Country = SRC.Country,
							 T.ILN = SRC.ILN,
							 T.BankName = SRC.BankName,
							 T.BankPostalCode = SRC.BankPostalCode,
							 T.BankAccNo = SRC.BankAccNo,
							T.DVNr=SRC.DVNr,
							T.TenderNo=SRC.TenderNo,
							T.DebtorNo=SRC.DebtorNo,
							T.CountryType=SRC.CountryType,
							T.Industry=SRC.Industry,
							T.ArtBevBew=SRC.ArtBevBew,
							T.ArtNU = SRC.ArtNU,
							T.BGBez = SRC.BGBez,
							T.BGDatum = SRC.BGDatum,
							T.BGNr=SRC.BGNr,   
							T.Telefon= SRC.Telefon,
							T.Telefax=SRC.Telefax,
							T.Website=SRC.Website,
							T.HotLine=SRC.HotLine,
							T.IBAN=SRC.IBAN,
							T.BIC=SRC.BIC,
							T.USTIDNr=SRC.USTIDNr,
							T.SeatofCompany=SRC.SeatofCompany,
							T.ManagingDirector= SRC.ManagingDirector,    
							T.Complementary= SRC.Complementary,  
							T.LastUpdatedBy = SRC.LastUpdatedBy,
							T.LastUpdatedDate = GETDATE()
							OUTPUT
									INSERTED.OttoID into @Output;
							EXEC sp_xml_removedocument @XmlDocumentHandle
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
/****** Object:  StoredProcedure [dbo].[P_Ins_Position]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Position]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Position]   
@XMLPositions XML,  
@ProjectID INT,
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
	DECLARE @LVRaster NVARCHAR(50)
	SELECT @LVRaster = LV_Raster FROM Project WHERE ProjectID = @ProjectID	                
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
     ab.DocuwareLink1,ab.DocuwareLink2,ab.DocuwareLink3,ab.GrandTotalME,ab.GrandTotalMO,ab.FinalGB,ab.EP,ab.SNO  
              FROM OPENXML (@XmlDocumentHandle, ''/Nouns/Position'',2)    
                              WITH (  
                            PositionID INT,  ProjectID INT,PositionOZ NVARCHAR(100),ParentOZ NVARCHAR(100),Title NVARCHAR(100),ShortDescription NVARCHAR(1000),  
                            LongDescription VARBINARY(MAX),PositionKZ NVARCHAR(10),DetailKZ NVARCHAR(10),LVSection NVARCHAR(10), WG INT,WA INT,WI INT,  
                            Menge DECIMAL(10,3),ME NVARCHAR(50),  Fabricate NVARCHAR(100),LiefrantMA NVARCHAR(50), [Type] NVARCHAR(50),    
       LVStatus NVARCHAR(50),UserID NVARCHAR(10),SurchargePer DECIMAL(10,3),  
       SurchargeFrom NVARCHAR(20),SurchargeTO NVARCHAR(20),surchargePercentageMO DECIMAL(10,3),ValidityDate DateTime,KalkMenge INT,MECost DECIMAL(10,3),  
       MA NVARCHAR(10),MO NVARCHAR(10),Dim1 INT,Dim2 INT,Dim3 INT,Mins DECIMAL(10,3),Faktor DECIMAL(10,3),LPMA DECIMAL(10,3),LPMO DECIMAL(10,3),    
                            Multi1MA DECIMAL(10,3),Multi1MO DECIMAL(10,3),Multi2MA DECIMAL(10,3),Multi2MO DECIMAL(10,3),Multi3MA DECIMAL(10,3),Multi3MO DECIMAL(10,3),  
       Multi4MA DECIMAL(10,3),Multi4MO DECIMAL(10,3),Multi5MA DECIMAL(10,3),Multi5MO DECIMAL(10,3),EinkaufspreisMA DECIMAL(10,3),  
       EinkaufspreisMO DECIMAL(10,3),SelbstkostenMultiMA DECIMAL(10,3),SelbstkostenMultiMO DECIMAL(10,3),SelbstkostenValueMA DECIMAL(10,3),  
       SelbstkostenValueMO DECIMAL(10,3),VerkaufspreisMultiMA DECIMAL(10,3),VerkaufspreisMultiMO DECIMAL(10,3),VerkaufspreisValueMA DECIMAL(10,3),  
       VerkaufspreisValueMO DECIMAL(10,3),StdSatz DECIMAL(10,3),PreisText NVARCHAR(MAX),  
       EinkaufspreisLockMA BIT,EinkaufspreisLockMO BIT,SelbstkostenLockMA BIT,SelbstkostenLockMO BIT,VerkaufspreisLockMA BIT,VerkaufspreisLockMO BIT,  
       DocuwareLink1 NVARCHAR(MAX),DocuwareLink2 NVARCHAR(MAX),DocuwareLink3 NVARCHAR(MAX),GrandTotalME DECIMAL(10,3),GrandTotalMO DECIMAL(10,3),  
       FinalGB DECIMAL(10,3),EP DECIMAL(10,3),SNO INT  
        )  
                              AB LEFT JOIN   
         Position P  
         ON dbo.PrepareOZ(@LVRaster,AB.ParentOZ) = P.Position_OZ AND ab.ProjectID=p.ProjectID AND P.Position_OZ != ''''  
        ) as t   
   -- Declaring required variables  
    DECLARE @PositionOZ NVARCHAR(500), @ParentOZ INT=NULL,@Count int,@LVSection NVARCHAR(100),@LVSectionID int,@SNO INT,@TempSNO INT,@DetailKZ INT
	DECLARE @FromOZ NVARCHAR(50),@ToOZ NVARCHAR(50)
   -- Fetching the values from Temp table to manipulate the data  
    SELECT @PositionOZ = PositionOZ, 
		@ParentOZ = ParentPositonID,
		@SNO = ISNULL(SNO,0),
		@LVSection = LVSection,
		@positionId = PositionID,
		@DetailKZ = DetailKZ,
		@FromOZ =dbo.PrepareOZ(@LVRaster,SurchargeFrom),
		@ToOZ = dbo.PrepareOZ(@LVRaster, SurchargeTO)
		FROM #Temp  
	SET @PositionOZ = ISNULL(dbo.PrepareOZ(@LVRaster,@PositionOZ),'''')
    -- Generating the serial number in all cases  
    DECLARE @POSCOUNT INT = 0  
	IF(@positionId < 1)
	BEGIN
		SELECT @POSCOUNT = COUNT(Position_OZ) FROM Position WHERE Position_OZ = @PositionOZ AND ProjectID = @ProjectID AND Position_OZ != '''' AND DetailKZ = @DetailKZ  
	END
	ELSE
	BEGIN
		DECLARE @OOz NVARCHAR(50)
		SELECT @OOz = Position_OZ FROM Position WHERE PositionID = @positionId
		IF(@PositionOZ != @OOz)
		BEGIN
			SELECT @POSCOUNT = COUNT(Position_OZ) FROM Position WHERE Position_OZ = @PositionOZ AND ProjectID = @ProjectID AND Position_OZ != '''' AND DetailKZ = @DetailKZ  
		END
	END
      
    IF(@POSCOUNT > 0)  
    BEGIN  
    SELECT ''UNIQUE''  
	ROLLBACK TRAN  
    RETURN;  
    END  
    IF(@SNO >= 0)  
    BEGIN  
     SET @TempSNO = @SNO + 1  
     UPDATE Position SET sequenceNo = sequenceNo + 1 WHERE   
     sequenceNo >  @SNO AND ProjectID = @ProjectID  
    END  
   ELSE   
    BEGIN  
     SELECT @TempSNO = ISNULL(MAX(sequenceNo),0) + 1 FROM Position WHERE ProjectID = @PROJECTID  
    END  
     
   --Checking if title or subtitle are exists or not  
    SELECT @Count = COUNT(1) from SplitString(@PositionOZ,''.'')   
    IF (@Count > 2)  
     BEGIN  
     IF (@ParentOZ IS NULL)  
     BEGIN  
      SELECT ''Title or SubTitle does not exist''  
	  ROLLBACK TRAN
      return;  
     END  
     END  
     
     
   --Checking if LV section exists or not  
   IF(@LVSection != '''')
	   BEGIN
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
	END 
     
   --Checking PositionKZ of position to decide weather normal position or ant other position  
   DECLARE @PositionKZ NVARCHAR(10)  
   SELECT TOP(1) @PositionKZ = PositionKZ FROM #Temp  
   IF(@PositionKZ = ''NG'' OR @PositionKZ = ''ZS'' OR @PositionKZ = ''Z'' Or @PositionKZ = ''H'')  
    BEGIN  
     MERGE Position AS T  
       USING #temp as  SRC ON T.PositionID = SRC.PositionID  
       WHEN NOT MATCHED THEN  
       INSERT  
       (  
           ProjectID,Position_OZ,Parent_OZ,Title,ShortDescription,PositionKZ,DetailKZ,  
           LVSection,LVStatus,Created_By,Fabricate,LiefrantMA, GetTitle,  
                    surchargePercentage,surchargefrom,surchargeto,surchargePercentage_MO,PreisText,  
          DocuwareLink1,DocuwareLink2,DocuwareLink3,sequenceNo  
           )  
       VALUES  
        (  
           SRC.ProjectID,@PositionOZ,SRC.ParentPositonID,SRC.Title,SRC.ShortDescription,SRC.PositionKZ,SRC.DetailKZ,  
SRC.LVSection,SRC.LVStatus,SRC.UserID,SRC.Fabricate,SRC.LiefrantMA, SRC.GetTitle,  
         SRC.SurchargePer,@FromOZ,@ToOZ,SRC.surchargePercentageMO,  
         SRC.PreisText,SRC.DocuwareLink1,SRC.DocuwareLink2,SRC.DocuwareLink3,@TempSNO  
           )  
       WHEN MATCHED THEN  
       UPDATE SET   
       T.ProjectID = SRC.ProjectID,  
       T.Position_OZ = @PositionOZ,  
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
       T.surchargefrom = @FromOZ,  
       T.surchargeto = @ToOZ,  
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
		IF(@PositionKZ = ''Z'')
		BEGIN
			DECLARE @FID INT,@TID INT,@MAPER DECIMAL(8,3),@MOPER DECIMAL(8,3)
			SELECT @FID = sequenceNo FROM Position WHERE Position_OZ = @FromOZ AND ProjectID = @ProjectID AND Parent_OZ = @ParentOZ
			SELECT @TID = sequenceNo FROM Position WHERE Position_OZ = @ToOZ AND ProjectID = @ProjectID AND Parent_OZ = @ParentOZ
			SELECT @MAPER = SurchargePer,@MOPER = surchargePercentageMO FROM #Temp
			UPDATE Position SET surchargePercentage = @MAPER,surchargePercentage_MO = @MOPER WHERE 
			ProjectID = @ProjectID AND Parent_OZ = @ParentOZ AND sequenceNo >= @FID AND sequenceNo <= @TID
			AND DetailKZ = 0 AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
		END
    END  
   ELSE  
   BEGIN 
   
   --Manual overwriting selbakosten multi
   DECLARE @MAUmlage DECIMAL(8,2),@MOImlage DECIMAL(8,2),@SKMAMultiWithoutUmlage DECIMAL(8,3),@SKMOMultiWithoutUmlage DECIMAL(8,3)
   IF(@positionId > 0)
	   BEGIN
		
		DECLARE @ESKMAMulti DECIMAL(8,3),@ESKMOMulti DECIMAL(8,3),@SKMAMulti DECIMAL(8,3),@SKMOMulti DECIMAL(8,3)
		SELECT @ESKMAMulti = ISNULL(MA_selbstkostenMulti,1),
		@ESKMOMulti = ISNULL(MO_selbstkostenMulti,1),
		@MAUmlage = ISNULL(MA_SelbakostenUmlage,1),
		@MOImlage = ISNULL(MO_SelbakostenUmlage,1),
		@SKMAMultiWithoutUmlage = ISNULL(MA_SelbakostenWithoutImlage,1),
		@SKMOMultiWithoutUmlage = ISNULL(MO_SelbakostenWithoutUmlage,1)
		FROM Position WHERE PositionID = @positionId
		SELECT @SKMAMulti = SelbstkostenMultiMA,@SKMOMulti = SelbstkostenMultiMO FROM #Temp
		IF(@SKMAMulti > @ESKMAMulti)
			BEGIN
				SET @SKMAMultiWithoutUmlage = @SKMAMulti - (@MAUmlage - 1)
			END
		ELSE IF(@SKMAMulti < @ESKMAMulti)
			BEGIN
				SET @MAUmlage = (@SKMAMulti - @SKMAMultiWithoutUmlage) + 1
			END
		IF(@SKMOMulti > @ESKMOMulti)
			BEGIN
				SET @SKMOMultiWithoutUmlage = @SKMOMulti - (@MOImlage - 1)
			END
		ELSE IF(@SKMOMulti > @ESKMOMulti)
			BEGIN
				SET @MOImlage = (@SKMOMulti - @SKMOMultiWithoutUmlage) + 1
			END
	   END
	   
	   --INSERTNG OR UPDATING NEW LV POSITION
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
         MO_Einkaufspreis_lck,MO_selbstkosten_lck,MO_verkaufspreis_lck,A,B,L,  
         DocuwareLink1,DocuwareLink2,DocuwareLink3,GrandTotalME,GrandTotalMO,FinalGB,EP,sequenceNo,
		 MA_SelbakostenUmlage,MO_SelbakostenUmlage,MA_SelbakostenWithoutImlage,MO_SelbakostenWithoutUmlage
         )  
              VALUES  
                     (  
                           SRC.ProjectID,@PositionOZ,SRC.ParentPositonID,SRC.Title,SRC.ShortDescription,SRC.PositionKZ,SRC.DetailKZ,  
                           SRC.LVSection,SRC.WG,SRC.WA,SRC.WI,SRC.Menge,SRC.ME,SRC.[Type],SRC.LVStatus,SRC.UserID,SRC.Fabricate,SRC.LiefrantMA, SRC.GetTitle,  
       SRC.SurchargePer,@FromOZ,@ToOZ,SRC.surchargePercentageMO,  
       SRC.ValidityDate,SRC.MA,SRC.MO,SRC.Mins,SRC.Faktor,  
         SRC.LPMA,SRC.LPMO,    
                              SRC.Multi1MA,SRC.Multi2MA,SRC.Multi3MA,SRC.Multi4MA,SRC.Multi5MA,  
                SRC.EinkaufspreisMA,SRC.SelbstkostenValueMA,SRC.SelbstkostenMultiMA,SRC.VerkaufspreisValueMA,SRC.VerkaufspreisMultiMA,  
        SRC.Multi1MO,SRC.Multi2MO,SRC.Multi3MO,SRC.Multi4MO,SRC.Multi5MO,  
        SRC.EinkaufspreisMO,SRC.SelbstkostenMultiMO,SRC.SelbstkostenValueMO,SRC.VerkaufspreisMultiMO,SRC.VerkaufspreisValueMO,SRC.StdSatz,SRC.PreisText,  
        SRC.EinkaufspreisLockMA,SRC.SelbstkostenLockMA,SRC.VerkaufspreisLockMA,SRC.EinkaufspreisLockMO,SRC.SelbstkostenLockMO,SRC.VerkaufspreisLockMO,  
        SRC.Dim1,SRC.Dim2,SRC.Dim3,SRC.DocuwareLink1,SRC.DocuwareLink2,SRC.DocuwareLink3,SRC.GrandTotalME,SRC.GrandTotalMO,SRC.FinalGB,SRC.EP,@TempSNO,
		1,1,SRC.SelbstkostenMultiMA,SRC.SelbstkostenMultiMO
         )  
              WHEN MATCHED THEN  
              UPDATE SET   
              T.ProjectID = SRC.ProjectID,  
              T.Position_OZ = @PositionOZ,  
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
     T.surchargefrom = @FromOZ,  
     T.surchargeto = @ToOZ,  
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
 T.EP = SRC.EP,
	 T.MA_SelbakostenUmlage = @MAUmlage,
	 T.MO_SelbakostenUmlage = @MOImlage,
	 T.MA_SelbakostenWithoutImlage = @SKMAMultiWithoutUmlage,
	 T.MO_SelbakostenWithoutUmlage = @SKMOMultiWithoutUmlage
     OUTPUT  
                     INSERTED.PositionID into @Output;  
   END  
              EXEC sp_xml_removedocument @XmlDocumentHandle  
         
             select @positionId=ID FROM @Output  
         
   --Inserting Long description to for new LV Position  
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
END ' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Project]    Script Date: 6/6/2017 11:28:52 AM ******/
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
--@CustomerNumber NVARCHAR(100),
@PlannerName NVARCHAR(100),
@ProjectStartDate DateTime,
@ProjectEndDate DateTime,
@IsCummulated Bit
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
						ProjectStartDate,
						ProjectEndDate,
						InvoiceType
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
						@ProjectStartDate,
						@ProjectEndDate,
						@IsCummulated
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
						UPDATE Position SET LVSection = ''HA'',
						LVStatus = ''B'',
						MA_selbstkosten_lck = 1,
						MO_selbstkosten_lck = 1,
						MA_einkaufspreis_lck = 1,
						MO_Einkaufspreis_lck = 1,
						MA_verkaufspreis_lck = 1,
						MO_verkaufspreis_lck = 1
						WHERE ProjectID = @ProjectID
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
						Project.ProjectStartDate = @ProjectStartDate,
						Project.ProjectEndDate = @ProjectEndDate,
						Project.InvoiceType = @IsCummulated
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
/****** Object:  StoredProcedure [dbo].[P_Ins_ProposalDetails]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_ProposalDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_ProposalDetails]
@SupplierProposalID INT
AS
BEGIN
CREATE TABLE #sDetails(SuppplierName NVARCHAR(50))
CREATE TABLE #pDetails(PositionID INT)
INSERT INTO #sDetails(SuppplierName)
SELECT ShortName FROM Supplier S
INNER JOIN ProposalSupplier P ON S.SupplierID = P.SupplierID
WHERE P.SupplierProposalID = @SupplierProposalID

INSERT INTO #pDetails(PositionID)
SELECT PositionID FROM ProposalPosition WHERE SupplierProposalID = @SupplierProposalID

DELETE FROM ProposalDetails WHERE SupplierProposalID = @SupplierProposalID

INSERT INTO ProposalDetails(SupplierProposalID,PositionID,ParameterName,ParameterValue)
SELECT @SupplierProposalID,PositionID,SuppplierName,0 FROM #pDetails,#sDetails

INSERT INTO ProposalDetails(SupplierProposalID,PositionID,ParameterName,ParameterValue)
SELECT @SupplierProposalID,PositionID,SuppplierName + ''Check'',''false'' FROM #pDetails,#sDetails

INSERT INTO ProposalDetails(SupplierProposalID,PositionID,ParameterName,ParameterValue)
SELECT @SupplierProposalID,PositionID,SuppplierName + ''Multi1'',1 FROM #pDetails,#sDetails

INSERT INTO ProposalDetails(SupplierProposalID,PositionID,ParameterName,ParameterValue)
SELECT @SupplierProposalID,PositionID,SuppplierName + ''Multi2'',1 FROM #pDetails,#sDetails

INSERT INTO ProposalDetails(SupplierProposalID,PositionID,ParameterName,ParameterValue)
SELECT @SupplierProposalID,PositionID,SuppplierName + ''Multi3'',1 FROM #pDetails,#sDetails

INSERT INTO ProposalDetails(SupplierProposalID,PositionID,ParameterName,ParameterValue)
SELECT @SupplierProposalID,PositionID,SuppplierName + ''Multi4'',1 FROM #pDetails,#sDetails

INSERT INTO ProposalDetails(SupplierProposalID,PositionID,ParameterName,ParameterValue)
SELECT @SupplierProposalID,PositionID,SuppplierName + ''Fabricate'','''' FROM #pDetails,#sDetails

INSERT INTO ProposalDetails(SupplierProposalID,PositionID,ParameterName,ParameterValue)
SELECT @SupplierProposalID,PositionID,SuppplierName + ''SupplierName'','''' FROM #pDetails,#sDetails

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_ProposalValues]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_ProposalValues]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_ProposalValues]
@PostionID INT,
@SupplierProposalID INT,
@SupplierPrice DECIMAL(8,3),
@Multi1 DECIMAL(8,3),
@Multi2 DECIMAL(8,3),
@Multi3 DECIMAL(8,3),
@Multi4 DECIMAL(8,3),
@Fabrikate NVARCHAR(50),
@SupplierName NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRAN
		UPDATE ProposalDetails SET
		ParameterValue = @SupplierPrice 
			WHERE ParameterName =@SupplierName 
			AND PositionID = @PostionID 
			AND SupplierProposalID = @SupplierProposalID
		UPDATE ProposalDetails SET 
		ParameterValue = @Multi1
			WHERE ParameterName = @SupplierName + ''Multi1''
			AND PositionID = @PostionID 
			AND SupplierProposalID = @SupplierProposalID
		UPDATE ProposalDetails SET 
			ParameterValue = @Multi2
			WHERE ParameterName = @SupplierName + ''Multi2''
			AND PositionID = @PostionID 
			AND SupplierProposalID = @SupplierProposalID
		UPDATE ProposalDetails SET 
			ParameterValue = @Multi3
			WHERE ParameterName = @SupplierName + ''Multi3''
			AND PositionID = @PostionID 
			AND SupplierProposalID = @SupplierProposalID
		UPDATE ProposalDetails SET 
			ParameterValue = @Multi4
			WHERE ParameterName = @SupplierName + ''Multi4''
			AND PositionID = @PostionID 
			AND SupplierProposalID = @SupplierProposalID
		UPDATE ProposalDetails SET 
			ParameterValue = @Fabrikate
			WHERE ParameterName = @SupplierName + ''Fabricate''
			AND PositionID = @PostionID 
			AND SupplierProposalID = @SupplierProposalID
		UPDATE ProposalDetails SET 
			ParameterValue = @SupplierName
			WHERE ParameterName = @SupplierName + ''SupplierName''
			AND PositionID = @PostionID 
			AND SupplierProposalID = @SupplierProposalID
		SELECT @PostionID
	COMMIT TRAN
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMessage
        IF(@@TRANCOUNT > 0)
		   ROLLBACK TRAN
	END CATCH
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Rabatt]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Rabatt]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Rabatt]
@XMLRabatt XML
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRAN
	--Temparary Variable for XML Document
	DECLARE @XmlDocumentHandle INT
	-- Create an internal representation of the XML document.  
	EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLRabatt 
	SELECT * INTO #Temp from 
	(SELECT 
	A.RabattID,A.Rabatt,A.TypeID,A.Multi1,A.Multi2,A.Multi3,A.Multi4,A.ValidityDate,
	A.CreatedBy,A.LastUpdatedBy
	FROM OPENXML (@XmlDocumentHandle, ''/Nouns/Rabatt'',2) 
	WITH (RabattID INT, Rabatt NVARCHAR(50),TypeID INT,
	Multi1 DECIMAL(8,3),Multi2 DECIMAL(8,3),Multi3 DECIMAL(8,3),Multi4 DECIMAL(8,3),
	ValidityDate DATE,
	CreatedBy INT,LastUpdatedBy INT
	)A) As T
	DECLARE @RabattID INT = -1
	SELECT @RabattID = RabattID FROM #Temp
	IF(@RabattID < 0)
		BEGIN
			INSERT INTO Rabatt(Rabatt,TypeID,Multi1,Multi2,Multi3,Multi4,ValidityDate)
			SELECT Rabatt,TypeID,Multi1,Multi2,Multi3,Multi4,ValidityDate FROM #Temp
			SET @RabattID = SCOPE_IDENTITY()
		END
	ELSE
		BEGIN
			UPDATE R SET
			R.Rabatt = T.Rabatt,
			R.TypeID = T.TypeID,
			R.Multi1 = T.Multi1,
			R.Multi2 = T.Multi2,
			R.Multi3 = T.Multi3,
			R.Multi4 = T.Multi4,
			R.ValidityDate = T.ValidityDate
			FROM Rabatt R INNER JOIN #Temp T ON R.RabattID = T.RabattID
		END
	SELECT @RabattID
	SELECT 
		R.RabattID,
		R.Rabatt,
		R.TypeID,
		R.Multi1,
		R.Multi2,
		R.Multi3,
		R.Multi4,
		R.ValidityDate,
		T.Typ
		FROM Rabatt R INNER JOIN Typ T ON R.TypeID = T.TypID
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
/****** Object:  StoredProcedure [dbo].[P_Ins_ReportDesign]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_ReportDesign]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_ReportDesign]
@Type varchar(200),
@col1 nvarchar(MAX),
@col2 nvarchar(MAX),
@col3 nvarchar(MAX)
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
		       UPDATE ReportDesign 
			   SET COL1=@col1,COL2=@col2,COL3=@col3
			   WHERE DesignType =@Type
			  
			  
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
/****** Object:  StoredProcedure [dbo].[P_Ins_RoleFeatureMap]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_RoleFeatureMap]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_RoleFeatureMap]
@RoleID INT,
@dtFeatureMap dbo.RoleFeatureMap READONLY
AS
BEGIN
    BEGIN TRY
	BEGIN TRAN
	 
	 DELETE FROM RoleFeatureMap WHERE RoleID=@RoleID
	 INSERT INTO RoleFeatureMap(RoleID,FeatureID,AccessLevel) SELECT @RoleID,FeatureID,AccessLevelID FROM @dtFeatureMap
		
    COMMIT TRAN
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMessage
  
	END CATCH
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_SaveSelection]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_SaveSelection]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [dbo].[P_Ins_SaveSelection]
@SupplierProposalID INT,
@PositionID INT,
@dtStrings [Strings] READONLY,
@SelectedSupplier NVARCHAR(50),
@IsSelected Bit
AS
BEGIN


DECLARE @Result NVARCHAR(10) = ''false''
IF(@IsSelected = 1)
	BEGIN
		SET @Result = ''true''
		UPDATE P
		SET ParameterValue = ''false''
		FROM ProposalDetails P
		JOIN @dtStrings D
			ON P.ParameterName = D.Item 
		WHERE P.PositionID = @PositionID 
		AND P.SupplierProposalID = @SupplierProposalID
	END


UPDATE ProposalDetails SET
ParameterValue = @Result
WHERE ParameterName = @SelectedSupplier AND
PositionID = @PositionID 
AND SupplierProposalID = @SupplierProposalID

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_Supplier]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Supplier]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Supplier]
@XMLSupplier XML
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
		   --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @SupplierID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLSupplier 
			  SELECT * INTO #Temp from 
			  (SELECT 
			  CU.SupplierID,
              CU.FullName,CU.ShortName,CU.PaymentCondition,CU.Commentary,CU.CreatedBy,CU.LastUpdatedBy,CU.EmailID
              FROM OPENXML (@XmlDocumentHandle, ''/Nouns/Supplier'',2) 
                              WITH (SupplierID INT,FullName NVARCHAR(100),ShortName NVARCHAR(100),PaymentCondition NVARCHAR(500),
							   Commentary NVARCHAR(MAX),CreatedBy int,LastUpdatedBy int,EmailID nvarchar(50)
							   )
							  CU) As T
			  MERGE Supplier AS T
              USING #Temp as  SRC ON T.SupplierID = SRC.SupplierID
			  WHEN MATCHED THEN
              UPDATE SET 
              T.FullName = SRC.FullName,
              T.ShortName = SRC.ShortName,
			  T.PaymentCondition = SRC.PaymentCondition,			 
              T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE(),
			  T.Commentary = SRC.Commentary,
			  T.EmailID=SRC.EmailID
              WHEN NOT MATCHED THEN
              INSERT
                 (
                        FullName,ShortName,PaymentCondition,CreatedBy,CreatedDate,IsActive,Commentary,EmailID
						   )
              VALUES
                     (
                        SRC.FullName,SRC.ShortName,SRC.PaymentCondition,
						SRC.CreatedBy,GETDATE(),1,SRC.Commentary,SRC.EmailID
						   )             
			 
			  OUTPUT
                     INSERTED.SupplierID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
			  SELECT * FROM @Output

			  SELECT SupplierID,FullName,ShortName,PaymentCondition,Commentary,EmailID
				 FROM Supplier
			  
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
/****** Object:  StoredProcedure [dbo].[P_Ins_Supplier_Address]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Supplier_Address]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Supplier_Address]
@XMLSupplierAddress XML
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
           
		BEGIN TRAN
			  --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @SupplierID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLSupplierAddress 
			  print ''test''
			  SELECT * INTO #Temp  from (SELECT 
			  CU.AddressID,CU.SupplierID,CU.ShortName,CU.StreetNo,CU.PostalCode,CU.City,CU.Country,CU.DefaultAddress,CU.CreatedBy,CU.LastUpdatedBy
			   FROM OPENXML (@XmlDocumentHandle, ''/Nouns/SupplierAddress'',2)  
                              WITH (
                                AddressID INT,SupplierID INT,ShortName nvarchar(100),StreetNo nvarchar(50),PostalCode nvarchar(50),City nvarchar(50),Country nvarchar(50),
								DefaultAddress bit,CreatedBy int,
							   LastUpdatedBy int
							   )
                              CU) As T                
			  
			  DECLARE @Daddress bit=0
			  SELECT @Daddress= DefaultAddress FROM #Temp
			  IF(@Daddress=1)
			  BEGIN
			   SET @SupplierID= (select SupplierID from #Temp)
			   UPDATE SupplierAddress SET DefaultAddress=0 WHERE SupplierID=@SupplierID
			  END
			  MERGE SupplierAddress AS T
              USING #Temp as  SRC ON T.AddressID = SRC.AddressID
              WHEN NOT MATCHED THEN
              INSERT
                 (
                        SupplierID,
						ShortName,
						StreetNo,
						PostalCode,
						City,
						Country,
						DefaultAddress,
						CreatedBy,
						CreatedDate,
						IsActive
						   )
              VALUES
                     (
                        SRC.SupplierID,
						SRC.ShortName,
						SRC.StreetNo,
						SRC.PostalCode,
						SRC.City,
						SRC.Country,
						SRC.DefaultAddress,
						SRC.CreatedBy,
						GETDATE(),
						1
						   )
              WHEN MATCHED THEN
              UPDATE SET 
              T.ShortName = SRC.ShortName,
			  T.StreetNo = SRC.StreetNo,
			  T.PostalCode = SRC.PostalCode,
              T.City = SRC.City,
              T.Country = SRC.Country,
			  T.DefaultAddress = SRC.DefaultAddress,
			  T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE()			 
			  OUTPUT
                     INSERTED.AddressID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
			  SELECT * FROM @Output
			  SELECT  AddressID, SupplierID,ShortName,StreetNo,PostalCode,City,Country,DefaultAddress
				 FROM SupplierAddress
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
/****** Object:  StoredProcedure [dbo].[P_Ins_Supplier_Contact]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Supplier_Contact]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Supplier_Contact]
@XMLSupplierContact XML
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
			--Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @SupplierID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLSupplierContact 
			  print ''test''
			  SELECT * INTO #Temp from (SELECT 
			           CU.ContactPersonID,CU.SupplierID,CU.ContactName,CU.Salutation,CU.Designation,CU.EmailID,
						CU.Telephone,
						CU.FAX,
						CU.DefaultContact,CU.CreatedBy,CU.LastUpdatedBy
			   FROM OPENXML (@XmlDocumentHandle, ''/Nouns/SupplierContact'',2)  
                              WITH (
                               ContactPersonID INT, SupplierID INT,ContactName NVARCHAR(50),Salutation NVARCHAR(50),Designation NVARCHAR(50),EmailID NVARCHAR(50),Telephone NVARCHAR(50),
								FAX NVARCHAR(50),DefaultContact bit,CreatedBy int,
							   LastUpdatedBy int
							   )
                              CU) As T
			  
			  DECLARE @DContact bit=0
			  SELECT @DContact=DefaultContact FROM #Temp
			  IF(@DContact=1)
			  BEGIN
			   SET @SupplierID= (select SupplierID from #Temp)
			  UPDATE SupplierContact SET DefaultContact=0 WHERE SupplierID=@SupplierID
			  END
			  MERGE SupplierContact AS T
              USING #Temp as  SRC ON T.ContactPersonID = SRC.ContactPersonID
              WHEN NOT MATCHED THEN
              INSERT
                 (
						SupplierID,
						ContactName,
						Salutation,
						Designation,
						EmailID,
						Telephone,
						FAX,
						DefaultContact,
						CreatedBy,
						CreatedDate,
						IsActive
						   )
              VALUES
                     (                        
                        SRC.SupplierID,
						SRC.ContactName,
						SRC.Salutation,
						SRC.Designation,
						SRC.EmailID,
						SRC.Telephone,
						SRC.FAX,
						SRC.DefaultContact,
						SRC.CreatedBy,
						GETDATE(),
						1
						   )		 
              WHEN MATCHED THEN
              UPDATE SET 
              T.ContactName = SRC.ContactName,
			  T.Salutation = SRC.Salutation,
			  T.Designation = SRC.Designation,
              T.EmailID = SRC.EmailID,
              T.Telephone = SRC.Telephone,
			  T.FAX = SRC.FAX,
			  T.DefaultContact = SRC.DefaultContact,
			  T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE()
			 
			  OUTPUT
                     INSERTED.ContactPersonID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
			  SELECT * FROM @Output
				SELECT ContactPersonID, SupplierID,ContactName,Salutation,Designation,EmailID,Telephone,FAX,DefaultContact
					FROM SupplierContact
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
/****** Object:  StoredProcedure [dbo].[P_Ins_SupplierProposal]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_SupplierProposal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_SupplierProposal]
@ProjectID INT,
@LVSection NVARCHAR(50),
@WG INT,
@WA INT,
@dtPositionID dbo.IntTable READONLY,
@dtSupplierID dbo.IntTable READONLY,
@dtDeletedPositions dbo.IntTable READONLY
AS
BEGIN
    BEGIN TRY
	BEGIN TRAN
		DECLARE @ProposalID INT
		DECLARE @TempNO INT
		SELECT @TempNO = ISNULL(MAX(ProposalID),0) + 1 FROM SupplierProposal WHERE ProjectID = @ProjectID  
		INSERT INTO SupplierProposal(ProjectID,LVSection,WG,WA,ProposalID,CreatedDate)
		VALUES(@ProjectID,@LVSection,@WG,@WA,@TempNO,GETDATE())
		SET @ProposalID = SCOPE_IDENTITY()
		INSERT INTO ProposalPosition(SupplierProposalID,PositionID) SELECT @ProposalID,ID FROM @dtPositionID
		INSERT INTO ProposalSupplier(SupplierProposalID,SupplierID) SELECT @ProposalID,ID FROM @dtSupplierID
		DELETE FROM PositionDeleteStatus WHERE ProjectID=@ProjectID
		INSERT INTO PositionDeleteStatus(PositionID,ProjectID) SELECT ID,@ProjectID FROM @dtDeletedPositions
		EXEC P_ins_ProposalDetails @ProposalID
		SELECT @TempNO
    COMMIT TRAN
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMessage
  
	END CATCH
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Ins_TextModule]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_TextModule]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_TextModule]
@XMLTextModule XML
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
		   --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @TextID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLTextModule 
			  SELECT * INTO #Temp from 
			  (SELECT 
			  CU.TextID,
              CU.TextModuleArea,CU.Category,CU.Contents,CU.IsSelect,CU.CreatedBy,CU.LastUpdatedBy,CU.TextAreaID,CU.CategoryID
              FROM OPENXML (@XmlDocumentHandle, ''/Nouns/TextModule'',2) 
                              WITH (TextID INT,TextModuleArea NVARCHAR(200),Category NVARCHAR(200),Contents NVARCHAR(MAX),
							   IsSelect BIT,CreatedBy int,LastUpdatedBy int,TextAreaID int,CategoryID int
							   )
							  CU) As T
			  MERGE TextModule AS T
              USING #Temp as  SRC ON T.TextID = SRC.TextID
			  WHEN MATCHED THEN
              UPDATE SET 
              T.TextModuleArea = SRC.TextModuleArea,
              T.Category = SRC.Category,
			  T.Contents = SRC.Contents,			 
              T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE(),
			  T.IsSelect = SRC.IsSelect,
			  T.TextAreaID=SRC.TextAreaID,
			  T.CategoryID=SRC.CategoryID
              WHEN NOT MATCHED THEN
              INSERT
                 (
                        TextModuleArea,Category,Contents,CreatedBy,CreatedDate,IsSelect,TextAreaID,CategoryID
						   )
              VALUES
                     (
                        SRC.TextModuleArea,SRC.Category,SRC.Contents,
						SRC.CreatedBy,GETDATE(),1,SRC.TextAreaID,SRC.CategoryID
						   )             
			 
			  OUTPUT
                     INSERTED.TextID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
			  SELECT * FROM @Output

			  SELECT TextID,TextModuleArea,Category,Contents,IsSelect,TextAreaID,CategoryID
				 FROM TextModule
			  
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
/****** Object:  StoredProcedure [dbo].[P_Ins_Typ]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_Typ]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_Typ]
@XMLTyp XML
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRAN
	--Temparary Variable for XML Document
	DECLARE @XmlDocumentHandle INT
	-- Create an internal representation of the XML document.  
	EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLTyp 
	SELECT * INTO #Temp from 
	(SELECT 
	A.TypID,A.SupplierID,A.WIID,A.Typ,
	A.CreatedBy,A.LastUpdatedBy
	FROM OPENXML (@XmlDocumentHandle, ''/Nouns/Typ'',2) 
	WITH (TypID INT,SupplierID NVARCHAR(10),WIID NVARCHAR(10),Typ NVARCHAR(500),
	CreatedBy int,LastUpdatedBy int
	)A) As T
	DECLARE @TypID INT = -1
	SELECT @TypID = TypID FROM #Temp
	IF(@TypID < 0)
		BEGIN
			INSERT INTO Typ(Typ,WIID,SupplierID,CreatedBy,CreatedDate)
			SELECT Typ,WIID,SupplierID,CreatedBy,GETDATE() FROM #Temp
			SET @TypID = SCOPE_IDENTITY()
		END
	ELSE
		BEGIN
			UPDATE T
			SET T.Typ = S.Typ,
			T.WIID = S.WIID,
			T.SupplierID = S.SupplierID,
			T.LastUpdatedBy = S.LastUpdatedBy,
			t.LastUpdatedDate = GETDATE()
			FROM Typ T INNER JOIN #Temp S ON T.TypID = S.TypID
		END
	SELECT @TypID
	SELECT TypID,Typ,W.WIID,W.WI,W1.WGID,W1.WG,W1.WA,T.SupplierID,S.FullName
		FROM Typ T
		INNER JOIN WI W ON T.WIID = W.WIID
		INNER JOIN WG W1 ON W.WGID = W1.WGID
		INNER JOIN Supplier S ON T.SupplierID = S.SupplierID
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
/****** Object:  StoredProcedure [dbo].[P_Ins_UserInfo]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_UserInfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_UserInfo]
@XMLUserInfo XML
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
		   --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @UserID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLUserInfo 
			  SELECT * INTO #Temp from 
			  (SELECT 
			  CU.UserID,CU.RoleID,CU.UserName,
              CU.FirstName,CU.LastName,CU.Password,CU.PasswordSalt,CU.MobileNo,CU.EmailID,CU.CreatedBy,CU.LastUpdatedBy
              FROM OPENXML (@XmlDocumentHandle, ''/Nouns/UserInfo'',2) 
                              WITH (UserID INT,RoleID INT,UserName NVARCHAR(200),FirstName NVARCHAR(200),LastName NVARCHAR(200),Password NVARCHAR(200),
							  PasswordSalt NVARCHAR(200), MobileNo NVARCHAR(200),EmailID nvarchar(100),CreatedBy int,LastUpdatedBy int
							   )
							  CU) As T
			  MERGE UserInfo AS T
              USING #Temp as  SRC ON T.UserID = SRC.UserID
			  WHEN MATCHED THEN
              UPDATE SET 
			  T.RoleID=SRC.RoleID,
			  T.UserName=SRC.UserName,
              T.FirstName = SRC.FirstName,
              T.LastName = SRC.LastName,
			  T.MobileNo = SRC.MobileNo,
			  T.EmailID=SRC.EmailID,
			  T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE()
              WHEN NOT MATCHED THEN
              INSERT
                 (
                        RoleID,UserName,FirstName,LastName,[Password],PasswordSalt,MobileNo,EmailID,CreatedBy,CreatedDate,IsActive,IsOTP
						   )
              VALUES
                     (
                        SRC.RoleID,SRC.UserName,SRC.FirstName,SRC.LastName,SRC.[Password],PasswordSalt,SRC.MobileNo,
						SRC.EmailID,SRC.CreatedBy,GETDATE(),1,1
						   )             
			 
			  OUTPUT
                     INSERTED.UserID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
			  SELECT * FROM @Output
			  EXEC [dbo].[P_Get_UserInfo]
			  
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
/****** Object:  StoredProcedure [dbo].[P_Ins_UserRole]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_UserRole]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_UserRole]
@XMLUserRole XML
AS
BEGIN
SET NOCOUNT ON;
  BEGIN TRY
		BEGIN TRAN
		   --Temparary Variable for XML Document
              DECLARE @XmlDocumentHandle INT
			  DECLARE @RoleID INT
              DECLARE @Output AS TABLE(ID INT)
              -- Create an internal representation of the XML document.  
			  EXEC sp_xml_preparedocument @XmlDocumentHandle OUTPUT, @XMLUserRole 
			  SELECT * INTO #Temp from 
			  (SELECT 
			  CU.RoleID,
              CU.RoleName,CU.CreatedBy,CU.LastUpdatedBy
              FROM OPENXML (@XmlDocumentHandle, ''/Nouns/UserRole'',2) 
                              WITH (RoleID INT,RoleName NVARCHAR(200),CreatedBy int,LastUpdatedBy int
							   )
							  CU) As T
			  MERGE UserRole AS T
              USING #Temp as  SRC ON T.RoleID = SRC.RoleID
			  WHEN MATCHED THEN
              UPDATE SET 
              T.RoleName = SRC.RoleName,              
			  T.LastUpdatedBy = SRC.LastUpdatedBy,
              T.LastUpdatedDate = GETDATE()
              WHEN NOT MATCHED THEN
              INSERT
                 (
                        RoleName,CreatedBy,CreatedDate,IsActive
						   )
              VALUES
                     (
                        SRC.RoleName,SRC.CreatedBy,GETDATE(),1
						   )             
			 
			  OUTPUT
                     INSERTED.RoleID into @Output;
              EXEC sp_xml_removedocument @XmlDocumentHandle
			  SELECT * FROM @Output

			 EXEC [dbo].[P_Get_UserRoles]
			  
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
/****** Object:  StoredProcedure [dbo].[P_Ins_WGWA]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Ins_WGWA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Ins_WGWA]
@WGWAID INT = -1,
@SupplierID INT,
@WG NVARCHAR(10) = null,
@WA NVARCHAR(10) = null,
@WGDescription NVARCHAR(500) = null
AS
BEGIN
BEGIN TRY
		BEGIN TRAN
IF(@WGWAID < 0)
	BEGIN
		INSERT INTO WGWA(WG,WA,SupplierID,WGDescription)
		VALUES (@WG,@WA,@SupplierID,@WGDescription)
		SET @WGWAID = SCOPE_IDENTITY()
	END
ELSE
	BEGIN
		UPDATE WGWA SET 
		WGDescription = @WGDescription ,
		WG = @WG,
		WA = @WA
		WHERE WGWAID = @WGWAID
	END
SELECT @WGWAID
SELECT WGWAID,SupplierID,WG,WA,WGDescription FROM WGWA
COMMIT TRAN
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMessage
        IF(@@TRANCOUNT > 0)
		   ROLLBACK TRAN
	END CATCH
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_Blattdetails]    Script Date: 6/6/2017 11:28:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_Blattdetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Rpt_Blattdetails]
@BlattID INT
AS
BEGIN

SELECT 
B.BlattDetailsID,
B.BlattID,
B.PositionID,
B.Quantity,
B.SNO,
P.Position_OZ,
P.ShortDescription,
P.PositionKZ,
P.ME,
BL.BlattNumber
FROM BlattDetails B 
INNER JOIN Position P 
	ON B.PositionID = P.PositionID
INNER JOIN Blatt BL
  on BL.BlattID=B.BlattID
	WHERE B.BlattID = @BlattID

END




' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_BlattdetailsforProject]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_BlattdetailsforProject]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Rpt_BlattdetailsforProject]
@ProjectID INT
AS
BEGIN

SELECT 
B.BlattDetailsID,
B.BlattID,
B.PositionID,
B.Quantity,
B.SNO,
P.Position_OZ,
P.ShortDescription,
P.PositionKZ,
P.ME,
BL.BlattNumber,
P.Parent_OZ
FROM BlattDetails B 
INNER JOIN Position P 
	ON B.PositionID = P.PositionID
INNER JOIN Blatt BL
  on BL.BlattID=B.BlattID
	WHERE BL.ProjectID = @ProjectID
	order by P.sequenceNo
END




' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_DeliveryNotes]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_DeliveryNotes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Rpt_DeliveryNotes]
@DeliveryNumberID int
AS

BEGIN

SELECT 

D.DeliveryDetailsID,

D.DeliveryNumberID,

D.PositionID,

D.Quantity,

D.SNO,

B.BlattNumberID,

B.BlattNumberName,

P.Position_OZ,

P.ShortDescription,

P.PositionKZ

FROM DeliveryDetails D 

INNER JOIN Position P ON D.PositionID = P.PositionID

INNER JOIN BlattNumber B 

	ON D.BlattNumberID = B.BlattNumberID

	WHERE D.DeliveryNumberID = @DeliveryNumberID

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_GetSupplierProposal]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_GetSupplierProposal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Rpt_GetSupplierProposal]
@ProjectID INT,
@ProposalID INT
AS
BEGIN
		SELECT Position_OZ,L.Longdiscription,Menge,PositionKZ,PR.ProjectDescription,PR.ProjectNumber,
		CAST(SP.WG AS VARCHAR) + ''-'' + CAST(SP.WA AS VARCHAR) as WGWA,SP.ProposalID as ProposalNo
		FROM Position P
		INNER JOIN ProposalPosition PS
		ON P.PositionID=PS.PositionID
		INNER JOIN SupplierProposal SP
		ON SP.SupplierProposalID=PS.SupplierProposalID
		INNER JOIN Project PR
		ON SP.ProjectID=PR.ProjectID
		INNER JOIN Position_Longdesc L
		on L.positionID=P.PositionID
		WHERE SP.ProposalID=@ProposalID AND SP.ProjectID=@ProjectID
		ORDER BY P.sequenceNo
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_GetTotalSummery]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_GetTotalSummery]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Rpt_GetTotalSummery]
@ProjectID INT
AS

BEGIN
	
			SELECT
			P.PositionID,
			P.Parent_OZ,
			P.Position_OZ,
			ISNULL(A.MAPrice,0) AS MAPrice,
			ISNULL(A.MoPrice,0) AS MoPrice,
			ISNULL(A.EP,0) AS EP,
			ISNULL(A.GB,0) AS GB,
			ISNULL(P.ShortDescription,'''') AS ShortDescription
			FROM Position P
			INNER JOIN 
			(SELECT 
			Parent_OZ,
			sum(MA_verkaufspreis) as MAPrice,
			sum(MO_verkaufspreis) as MoPrice,
			Sum(EP) as EP,
			sum(FinalGB) as GB
			FROM Position WHERE ProjectID=@ProjectID
			AND PositionKZ=''N''
			AND DetailKZ=0
			GROUP BY Parent_OZ
			 ) as A
			ON P.PositionID=A.Parent_OZ


END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_OTTOMaster]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_OTTOMaster]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Rpt_OTTOMaster]
AS

BEGIN

 SELECT OttoID,ShortName,FullName,Street
	 FROM OTTOMaster
	 WHERE IsBranch=0
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_PositionForProposalPrice]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_PositionForProposalPrice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Rpt_PositionForProposalPrice]
@ProjectID INT
AS

BEGIN
		SELECT  Position.PositionID,
		ProjectID,
		Position_OZ,
		PositionKZ,
	    LVSection, 
		ISNULL(EP,0) AS EP, 
		ISNULL(FinalGB,0) AS FinalGB, 
		Parent_OZ,
		Menge, 
		ME,
	    ISNULL(MA_verkaufspreis,0) AS MA_verkaufspreis, 
		ISNULL(MO_verkaufspreis,0) AS MO_verkaufspreis, 
    	ISNULL(ShortDescription,'''') AS ShortDescription,
		ISNULL(L.Longdiscription,'''') AS LangText
		FROM    Position
		INNER JOIN Position_Longdesc L
		on L.positionID=Position.PositionID
		WHERE  ProjectID = @ProjectID AND PositionKZ = ''N'' AND DetailKZ=0

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Rpt_ProjectAndCustomerAndOTTODetails]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Rpt_ProjectAndCustomerAndOTTODetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Rpt_ProjectAndCustomerAndOTTODetails]
@ProjectID INT
AS

BEGIN
		SELECT A.ProjectID, 
		A.CustomerID,
		A.ProjectNumber,
		A.ProjectDescription,
		ISNULL(A.Vat,0) AS Vat,
		A.CustomerFullName,
		A.CustomerShortName,
		A.Street as CustomerStreet,
		A.PostalCode as CPostalCode,
		A.City as CCity,
		A.Country as CCountry,
		A.ILN as CILN,
		A.Telephone as CTelefone,
		A.Fax as CFax,
		A.EmailID as CMailid,
		A.TaxNumber as CTaxNo,
		A.BankName as CBankName,A.BankPostalCode as CBankPC ,A.BankAccountNumber as CBankAN,A.DVNr as CDVNr,
		O.FullName as OTTOFullname,O.ShortName as OTTOShortName,O.Street as OTTOStreet,O.PostalCode,O.City,O.Country,
        O.ILN,O.BankName,O.BankPostalCode,O.BankAccNo,O.DVNr,O.Telefon,O.Telefax,O.Website,O.HotLine,
		O.BGBez,O.BGDatum,O.BGNr
		FROM (SELECT P.ProjectID, 
		P.CustomerID,
		P.ProjectNumber,
		P.ProjectDescription,
		P.Vat,
		C.CustomerFullName,
		C.CustomerShortName,
		C.Street,
		c.PostalCode,
		C.City,
		C.Country,
		C.ILN,
		c.Telephone,
		c.Fax,
		C.EmailID,
		c.TaxNumber,
		C.BankName,C.BankPostalCode,C.BankAccountNumber,C.DVNr
		FROM Project P 
		INNER JOIN Customer C 
		ON P.CustomerID = C.CustomerID 
		WHERE ProjectID = @ProjectID) AS A,OTTOMaster O WHERE IsBranch = 0 And IsActive = 1

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_BulkProcess_ActionA]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Upd_BulkProcess_ActionB]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Upd_LongDescription]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Upd_Multi]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_Multi]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Upd_Multi]
@ProjectID INT,
@LVSection NVARCHAR(500),
@dt MultiUpdate READONLY
AS
BEGIN
--Retrieving LV Sections from Imput
DECLARE @dtLVSection TABLE(LVSection NVARCHAR(10))
INSERT INTO @dtLVSection(LVSection)
SELECT * FROM SplitString(@LVSection,'','')
--Updating xfactor to selbakosten multi
UPDATE P
	SET P.MA_selbstkostenMulti = D.XFactor,
	MA_selbstkosten = dbo.Cal_MultiValue(D.XFactor,P.MA_einkaufspreis)
	FROM Position P INNER JOIN @dt D ON P.WG = D.WG
	WHERE P.ProjectID = @ProjectID 
	AND DetailKZ = 0  
	AND (PositionKZ = ''N'' OR PositionKZ =''M'')
	AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
	AND P.MA = ''X''
	AND P.MA_selbstkosten_lck = 0
	AND D.XFactor != 0
	AND D.XFactor IS NOT NULL
--Updating sfactor to selbakosten multi
UPDATE P
SET P.MA_selbstkostenMulti = D.SFactor,
MA_selbstkosten = dbo.Cal_MultiValue(D.SFactor,P.MA_einkaufspreis)
FROM Position P INNER JOIN @dt D ON P.WG = D.WG
WHERE P.ProjectID = @ProjectID 
AND DetailKZ = 0  
AND (PositionKZ = ''N'' OR PositionKZ =''M'')
AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
AND P.MA = ''S''
AND P.MA_selbstkosten_lck = 0
AND D.SFactor != 0
AND D.SFactor IS NOT NULL
--Updating corresponding values
UPDATE P
	SET MA_verkaufspreis = dbo.Cal_MultiValue(P.MA_verkaufspreis_Multi,P.MA_selbstkosten),
	P.EP = P.MA_verkaufspreis + P.MO_verkaufspreis,
	P.FinalGB = (P.MA_verkaufspreis + P.MO_verkaufspreis) * Menge
	FROM Position P INNER JOIN @dt T ON P.WG = T.WG
	WHERE P.ProjectID = @ProjectID 
	AND DetailKZ = 0  
	AND (PositionKZ = ''N'' OR PositionKZ =''M'')
	AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
	AND P.MA_selbstkosten_lck = 0
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_Multi6]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_Multi6]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Upd_Multi6]
@ProjectID INT,
@LVSection NVARCHAR(500),
@dt MultiUpdate READONLY,
@Type NVARCHAR(50)
AS
BEGIN
	
	--Retrieving LV Sections from Imput
	DECLARE @dtLVSection TABLE(LVSection NVARCHAR(10))
	INSERT INTO @dtLVSection(LVSection)
	SELECT * FROM SplitString(@LVSection,'','')
	IF(@Type = ''Material'')
		BEGIN
	
			--Updating xfactor to selbakosten multi
			UPDATE P
				SET P.MA_verkaufspreis_Multi = D.XFactor,
				MA_verkaufspreis = dbo.Cal_MultiValue(D.XFactor,P.MA_selbstkosten)
				FROM Position P INNER JOIN @dt D ON P.WG = D.WG
				WHERE P.ProjectID = @ProjectID 
				AND DetailKZ = 0  
				AND (PositionKZ = ''N'' OR PositionKZ =''M'')
				AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
				AND P.MA = ''X''
				AND P.MA_verkaufspreis_lck = 0
				AND D.XFactor != 0
				AND D.XFactor IS NOT NULL
	
			--Updating sfactor to selbakosten multi
			UPDATE P
				SET P.MA_verkaufspreis_Multi = D.SFactor,
				MA_verkaufspreis = dbo.Cal_MultiValue(D.SFactor,P.MA_selbstkosten)
				FROM Position P INNER JOIN @dt D ON P.WG = D.WG
				WHERE P.ProjectID = @ProjectID 
				AND DetailKZ = 0  
				AND (PositionKZ = ''N'' OR PositionKZ =''M'')
				AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
				AND P.MA = ''S''
				AND P.MA_verkaufspreis_lck = 0
				AND D.SFactor != 0
				AND D.SFactor IS NOT NULL
	
			--Updating corresponding values
			UPDATE P
				SET P.EP = P.MA_verkaufspreis + P.MO_verkaufspreis,
				P.FinalGB = (P.MA_verkaufspreis + P.MO_verkaufspreis) * Menge
				FROM Position P INNER JOIN @dt T ON P.WG = T.WG
				WHERE P.ProjectID = @ProjectID 
				AND DetailKZ = 0  
				AND (PositionKZ = ''N'' OR PositionKZ =''M'')
				AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
				AND P.MA_verkaufspreis_lck = 0
		END
	ELSE IF(@Type = ''Montage'')
		BEGIN
			--Updating xfactor to selbakosten multi
			UPDATE P
				SET P.MO_verkaufspreisMulti = D.XFactor,
				MO_verkaufspreis = dbo.Cal_MultiValue(D.XFactor,P.MO_selbstkosten)
				FROM Position P INNER JOIN @dt D ON P.WG = D.WG
				WHERE P.ProjectID = @ProjectID 
				AND DetailKZ = 0  
				AND (PositionKZ = ''N'' OR PositionKZ =''M'')
				AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
				AND P.MA = ''X''
				AND P.MO_verkaufspreis_lck = 0
				AND D.XFactor != 0
				AND D.XFactor IS NOT NULL
			--Updating sfactor to selbakosten multi
			UPDATE P
				SET P.MO_verkaufspreisMulti = D.SFactor,
				MO_verkaufspreis = dbo.Cal_MultiValue(D.SFactor,P.MO_selbstkosten)
				FROM Position P INNER JOIN @dt D ON P.WG = D.WG
				WHERE P.ProjectID = @ProjectID 
				AND DetailKZ = 0  
				AND (PositionKZ = ''N'' OR PositionKZ =''M'')
				AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
				AND P.MA = ''S''
				AND P.MO_verkaufspreis_lck = 0
				AND D.SFactor != 0
				AND D.SFactor IS NOT NULL
			--Updating corresponding values
			UPDATE P
				SET P.EP = P.MA_verkaufspreis + P.MO_verkaufspreis,
				P.FinalGB = (P.MA_verkaufspreis + P.MO_verkaufspreis) * Menge
				FROM Position P INNER JOIN @dt T ON P.WG = T.WG
				WHERE P.ProjectID = @ProjectID 
				AND DetailKZ = 0  
				AND (PositionKZ = ''N'' OR PositionKZ =''M'')
				AND LVSection IN (SELECT LTRIM(RTRIM(LVSection)) FROM @dtLVSection)
				AND P.MO_verkaufspreis_lck = 0
		END
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_Password]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_Password]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Upd_Password]
@UserID INT,
@OldPassword NVARCHAR(200),
@NewPassword NVARCHAR(200),
@IsAdmin Bit = 0
AS
BEGIN
IF @IsAdmin = 1
	BEGIN
		UPDATE UserInfo SET 
		[Password] = @NewPassword,
		LastUpdatedDate = GETDATE(),
		IsOTP = 1
		WHERE UserID = @UserID
		SELECT ''''
	END
ELSE	
	BEGIN
		IF EXISTS(SELECT 1 FROM  UserInfo WHERE Password = @OldPassword AND UserID = @UserID)
			BEGIN
				UPDATE UserInfo SET 
				[Password] = @NewPassword,
				LastUpdatedDate = GETDATE(),
				IsOTP = 0
				WHERE UserID = @UserID
				SELECT ''''
			END
		ELSE	
			BEGIN
			SELECT ''Please Enter Valid Old Password''
			END
	END
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[P_Upd_Project]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  StoredProcedure [dbo].[P_Upd_SpecialCost]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_Upd_SpecialCost]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[P_Upd_SpecialCost]
@ProjectID INT,
@dt [SpecialCost] READONLY
AS
BEGIN


DECLARE @IsExists bit = 0
IF EXISTS (SELECT 1 FROM SpecialCost WHERE ProjectID = @ProjectID)
BEGIN
	SET	@IsExists = 1
END


--Deleting Existing special cost fo procject
DELETE FROM SpecialCost WHERE ProjectID = @ProjectID

--Inserting new special cost of project
INSERT INTO SpecialCost(Cost_Desciption,Price,ProjectID)
SELECT Cost_Description,Price,@ProjectID FROM @dt

--Variable Declarations
DECLARE 
@EKMAtotal DECIMAL(8,3),
@EKMOtotal DECIMAL(8,3),
@Umlage DECIMAL(8,2),
@SpecialCost DECIMAL(8,2)



--Calculating Special Cost
SELECT @SpecialCost = ROUND(ISNULL(SUM(Price),0),2) FROM @dt WHERE Cost_Description != ''''

IF(@IsExists = 0)
	BEGIN
		--Calculating total Material einkuafs preis
		SELECT @EKMAtotal = ISNULL(SUM(MA_einkaufspreis),0) FROM Position
		WHERE ProjectID = @ProjectID
		AND DetailKZ = 0 
		AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
		AND LVSection = ''HA''

		--Calculating total Montage einkuafs preis
		SELECT @EKMOtotal = ISNULL(SUM(MO_Einkaufspreis),0) FROM Position 
		WHERE ProjectID = @ProjectID
		AND DetailKZ = 0 
		AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
		AND LVSection = ''HA''

		SET @Umlage = ROUND(@SpecialCost/(@EKMAtotal + @EKMOtotal),2)
	END
ELSE
	BEGIN
		DECLARE @MALockedSpecialCost DECIMAL(18,3),@MOLockedSpecialCost DECIMAL(18,3)

		SELECT @MALockedSpecialCost = ISNULL(SUM(MA_einkaufspreis * (MA_SelbakostenUmlage - 1)),0) FROM Position 
		WHERE ProjectID = @ProjectID
		AND MA_selbstkosten_lck = 1
		AND DetailKZ = 0 
		AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
		AND LVSection = ''HA''

		SELECT @MOLockedSpecialCost = ISNULL(SUM(MO_Einkaufspreis * (MO_SelbakostenUmlage - 1)),0) FROM Position 
		WHERE ProjectID = @ProjectID
		AND MO_selbstkosten_lck = 1
		AND DetailKZ = 0 
		AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
		AND LVSection = ''HA''

		--Calculating total Material einkuafs preis
		SELECT @EKMAtotal = ISNULL(SUM(MA_einkaufspreis),0) FROM Position
		WHERE ProjectID = @ProjectID
		AND MA_selbstkosten_lck = 0
		AND DetailKZ = 0 
		AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
		AND LVSection = ''HA''

		--Calculating total Montage einkuafs preis
		SELECT @EKMOtotal = ISNULL(SUM(MO_Einkaufspreis),0) FROM Position 
		WHERE ProjectID = @ProjectID
		AND MO_selbstkosten_lck = 0
		AND DetailKZ = 0 
		AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
		AND LVSection = ''HA''
	
		SET @Umlage = ROUND(((@SpecialCost - @MALockedSpecialCost)-@MOLockedSpecialCost)/(@EKMAtotal + @EKMOtotal),2)
	END

--Updating new values
UPDATE Position SET
MA_SelbakostenUmlage = @Umlage + 1,
MA_selbstkostenMulti = MA_SelbakostenWithoutImlage + @Umlage,
MA_selbstkosten = dbo.Cal_MultiValue(MA_einkaufspreis,(MA_SelbakostenWithoutImlage + @Umlage))
WHERE ProjectID = @ProjectID
AND MA_selbstkosten_lck = 0
AND DetailKZ = 0 
AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
AND LVSection = ''HA''

UPDATE Position SET 
MA_verkaufspreis = dbo.Cal_MultiValue(MA_selbstkosten,MA_verkaufspreis_Multi),
EP = dbo.Cal_MultiValue(MA_selbstkosten,MA_verkaufspreis_Multi) + MO_verkaufspreis,
FinalGB = (dbo.Cal_MultiValue(MA_selbstkosten,MA_verkaufspreis_Multi) + MO_verkaufspreis) * Menge
WHERE ProjectID = @ProjectID
AND MA_selbstkosten_lck = 0
AND DetailKZ = 0 
AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
AND LVSection = ''HA''

UPDATE Position SET
MO_SelbakostenUmlage = @Umlage + 1,
MO_selbstkostenMulti = MO_SelbakostenWithoutUmlage + @Umlage,
MO_selbstkosten = dbo.Cal_MultiValue(MO_Einkaufspreis,(MO_SelbakostenWithoutUmlage + @Umlage))
WHERE ProjectID = @ProjectID
AND MO_selbstkosten_lck = 0
AND DetailKZ = 0 AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
AND LVSection = ''HA''

UPDATE Position SET
MO_verkaufspreis = dbo.Cal_MultiValue(MO_selbstkosten,MO_verkaufspreisMulti),
EP = MA_verkaufspreis + (dbo.Cal_MultiValue(MO_selbstkosten,MO_verkaufspreisMulti)),
FinalGB = (MA_verkaufspreis + (dbo.Cal_MultiValue(MO_selbstkosten,MO_verkaufspreisMulti))) * Menge
WHERE ProjectID = @ProjectID
AND MO_selbstkosten_lck = 0
AND DetailKZ = 0 AND (PositionKZ = ''N'' OR PositionKZ = ''M'')
AND LVSection = ''HA''

END' 
END
GO
/****** Object:  StoredProcedure [dbo].[p_Upd_SupplierPrice]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_Upd_SupplierPrice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[p_Upd_SupplierPrice]
@dtPositons dtUpdateSupplierPrice READONLY
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRAN

	IF EXISTS(SELECT 1 FROM @dtPositons WHERE ListPrice <= 0)
		BEGIN
			SELECT ''Some Positions are having Zero List Price''
			ROLLBACK TRAN
		END
		UPDATE P
		SET 
			P.Fabricate = T.Fabrikate,
			P.LiefrantMA = T.Supplier,
			P.MA_Multi1 = T.Multi1,
			P.MA_multi2 = T.Multi2,
			P.MA_multi3 = T.Multi3,
			P.MA_multi4 = T.Multi4,
			P.MA_listprice = T.ListPrice,
			P.MA_einkaufspreis = (Multi1 * Multi2 * Multi3 * Multi4) *  T.ListPrice,
			P.MA_selbstkosten = ((Multi1 * Multi2 * Multi3 * Multi4) *  T.ListPrice) * MA_selbstkostenMulti,
			P.MA_verkaufspreis = (((Multi1 * Multi2 * Multi3 * Multi4) *  T.ListPrice) * MA_selbstkostenMulti) * MA_verkaufspreis_Multi,
			P.EP = ((((Multi1 * Multi2 * Multi3 * Multi4) *  T.ListPrice) * MA_selbstkostenMulti) * MA_verkaufspreis_Multi) + MO_verkaufspreis,
			P.FinalGB = (((((Multi1 * Multi2 * Multi3 * Multi4) *  T.ListPrice) * MA_selbstkostenMulti) * MA_verkaufspreis_Multi) + MO_verkaufspreis) * P.Menge
		FROM 
		Position P
		INNER JOIN @dtPositons T
			ON P.PositionID = T.PositionID
		WHERE T.ListPrice != 0
		SELECT ''''
	COMMIT TRAN
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMessage
		IF(@@TRANCOUNT > 0)
			ROLLBACK TRAN
	END CATCH
END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[Cal_MultiValue]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[PrepareOZ]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrepareOZ]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[PrepareOZ]
(    
      @r NVARCHAR(MAX),
      @o NVARCHAR(MAX)
)
RETURNS NVARCHAR(100)
AS
BEGIN

DECLARE @dtRaster TABLE(item NVARCHAR(10), itemnumber INT,itemlength INT)
DECLARE @dtOZ TABLE(item NVARCHAR(10), itemnumber INT,itemlength INT)
INSERT INTO @dtRaster
SELECT item,itemnumber, LEN(LTRIM(RTRIM(Item))) FROM  DelimitedSplit8K(@r,''.'')

INSERT INTO @dtOZ
SELECT item,itemnumber, LEN(LTRIM(RTRIM(Item))) FROM  DelimitedSplit8K(@o,''.'')

DECLARE @Count INT = 0 DECLARE @i INT = 0

SELECT @count  = COUNT(*) FROM DelimitedSplit8K(@o,''.'')
DECLARE @OutputOZ NVARCHAR(50)

WHILE (@count > 0)
BEGIN
SET @i = @i+1
SET @count = @count - 1

DECLARE @OZPart NVARCHAR(10)
DECLARE @rasterpartlength INT
DECLARE @OzPartLength INT

SELECT @OZPart = LTRIM(RTRIM(item)) FROM @dtOZ  WHERE itemnumber= @i 
SELECT @rasterpartlength = itemlength FROM @dtRaster WHERE itemnumber = @i
SELECT @OzPartLength = itemlength FROM @dtOZ WHERE itemnumber = @i

IF @Count = 0
	BEGIN
		IF @rasterpartlength = 1 AND @OzPartLength > 0
			BEGIN
			SET @OutputOZ = ISNULL(@OutputOZ,'''') + REPLICATE('' '',@rasterpartlength - @OzPartLength) + LTRIM(RTRIM(@OZPart))
			END
		ELSE IF @OzPartLength > 0
			BEGIN
			SET @OutputOZ = ISNULL(@OutputOZ,'''') + REPLICATE('' '',@rasterpartlength - @OzPartLength) + LTRIM(RTRIM(@OZPart)) + ''.''
			END
	END
ELSE
	BEGIN
	SET @OutputOZ = ISNULL(@OutputOZ,'''') + REPLICATE('' '',@rasterpartlength - @OzPartLength) + LTRIM(RTRIM(@OZPart)) + ''.''
	END
END

RETURN @OutputOZ
END
' 
END

GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  Table [dbo].[Blatt]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Blatt]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Blatt](
	[BlattID] [int] IDENTITY(1,1) NOT NULL,
	[BlattNumberID] [int] NULL,
	[ProjectID] [int] NULL,
	[BlattNumber] [nvarchar](50) NULL,
	[IsInvoiced] [bit] NULL,
	[IsActiveDelivery] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Blatt] PRIMARY KEY CLUSTERED 
(
	[BlattID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_BlattNumber] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[BlattNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[BlattDetails]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BlattDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BlattDetails](
	[BlattDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[BlattID] [int] NULL,
	[PositionID] [int] NULL,
	[IsActiveDelivery] [bit] NULL,
	[IsInvoiced] [bit] NULL,
	[Quantity] [int] NULL,
	[SNO] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_BlattDetails] PRIMARY KEY CLUSTERED 
(
	[BlattDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[TextAreaID] [int] NULL,
	[CategoryName] [nvarchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerFullName] [nvarchar](100) NULL,
	[CustomerShortName] [nvarchar](100) NULL,
	[Street] [nvarchar](500) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[ILN] [nvarchar](100) NULL,
	[Telephone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[EmailID] [nvarchar](50) NULL,
	[TaxNumber] [nvarchar](50) NULL,
	[BankName] [nvarchar](50) NULL,
	[BankPostalCode] [nvarchar](50) NULL,
	[BankAccountNumber] [nvarchar](50) NULL,
	[DVNr] [nvarchar](100) NULL,
	[TenderNumber] [nvarchar](50) NULL,
	[DebitorNumber] [nvarchar](50) NULL,
	[CountryType] [nvarchar](50) NULL,
	[CountryName] [nvarchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[Commentary] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CustomerAddress]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerAddress]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerAddress](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[AddressShortName] [nvarchar](100) NULL,
	[StreetNo] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[DefaultAddress] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Customer_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[CustomerContact]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerContact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerContact](
	[ContactPersonID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[Salutation] [nvarchar](50) NULL,
	[ContatPersonName] [nvarchar](50) NULL,
	[Designation] [nvarchar](50) NULL,
	[EmailID] [nvarchar](50) NULL,
	[Telephone] [nvarchar](50) NULL,
	[FAX] [nvarchar](50) NULL,
	[DefaultContact] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Customer_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactPersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[DeliverNoteMSR]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliverNoteMSR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeliverNoteMSR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Position] [int] NULL,
	[Menge] [decimal](18, 2) NULL,
	[Bezeichnung] [nvarchar](500) NULL,
	[Einelpreis] [nvarchar](50) NULL,
	[Betrag] [nvarchar](50) NULL,
 CONSTRAINT [PK_DeliverNoteMSR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[DeliveryInvoices]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryInvoices]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeliveryInvoices](
	[DeliveryInvoicesID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NULL,
	[BlattID] [int] NULL,
 CONSTRAINT [PK_DeliveryInvoices] PRIMARY KEY CLUSTERED 
(
	[DeliveryInvoicesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[DeliveryNumber]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryNumber]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeliveryNumber](
	[DeliveryNumberID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NULL,
	[DeliveryNumberName] [nvarchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActiveDelivery] [bit] NULL,
	[IsInvoiced] [bit] NULL,
 CONSTRAINT [PK_DeliveryNumber] PRIMARY KEY CLUSTERED 
(
	[DeliveryNumberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Name] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[DeliveryNumberName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Dimension]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dimension]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Dimension](
	[DimensionID] [int] IDENTITY(1,1) NOT NULL,
	[WIID] [int] NULL,
	[A] [nvarchar](10) NULL,
	[B] [nvarchar](10) NULL,
	[L] [nvarchar](10) NULL,
	[ListPrice] [decimal](8, 3) NULL,
	[GMulti] [decimal](8, 3) NULL,
	[Minuten] [decimal](8, 1) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[ValidityDate] [date] NULL,
 CONSTRAINT [PK_Dimension] PRIMARY KEY CLUSTERED 
(
	[DimensionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Dimension] UNIQUE NONCLUSTERED 
(
	[WIID] ASC,
	[A] ASC,
	[B] ASC,
	[L] ASC,
	[ValidityDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  Table [dbo].[Feature]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Feature]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Feature](
	[FeatureID] [int] IDENTITY(1,1) NOT NULL,
	[FeatureName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Feature] PRIMARY KEY CLUSTERED 
(
	[FeatureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Invoice](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NULL,
	[InvoiceNumber] [nvarchar](50) NULL,
	[InvoiceAmount] [decimal](8, 3) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [date] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [date] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Invoice] UNIQUE NONCLUSTERED 
(
	[InvoiceNumber] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  Table [dbo].[LVRaster]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  Table [dbo].[LVSection]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  Table [dbo].[LvSectionDetails]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  Table [dbo].[Map]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  Table [dbo].[OTTOContact]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OTTOContact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OTTOContact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[OttoID] [int] NULL,
	[ContactPerson] [nvarchar](100) NULL,
	[Telephone] [nvarchar](100) NULL,
	[Fax] [nvarchar](100) NULL,
	[EmailID] [nvarchar](100) NULL,
	[TaxNo] [nvarchar](100) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[DefaultContact] [bit] NULL,
 CONSTRAINT [PK_OTTOContact] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OTTOMaster]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OTTOMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OTTOMaster](
	[OttoID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [nvarchar](200) NULL,
	[FullName] [nvarchar](500) NULL,
	[IsBranch] [bit] NULL,
	[Street] [nvarchar](500) NULL,
	[PostalCode] [nvarchar](100) NULL,
	[City] [nvarchar](200) NULL,
	[Country] [nvarchar](200) NULL,
	[ILN] [nvarchar](500) NULL,
	[BankName] [nvarchar](500) NULL,
	[BankPostalCode] [nvarchar](100) NULL,
	[BankAccNo] [nvarchar](100) NULL,
	[DVNr] [nvarchar](500) NULL,
	[TenderNo] [nvarchar](200) NULL,
	[DebtorNo] [nvarchar](200) NULL,
	[CountryType] [nvarchar](100) NULL,
	[Industry] [nvarchar](500) NULL,
	[ArtBevBew] [nvarchar](500) NULL,
	[ArtNU] [nvarchar](500) NULL,
	[BGBez] [nvarchar](500) NULL,
	[BGDatum] [nvarchar](500) NULL,
	[BGNr] [nvarchar](500) NULL,
	[Telefon] [nvarchar](50) NULL,
	[Telefax] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[HotLine] [nvarchar](50) NULL,
	[IBAN] [nvarchar](100) NULL,
	[BIC] [nvarchar](100) NULL,
	[USTIDNr] [nvarchar](100) NULL,
	[SeatofCompany] [nvarchar](100) NULL,
	[ManagingDirector] [nvarchar](50) NULL,
	[Complementary] [nvarchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_OTTOMaster] PRIMARY KEY CLUSTERED 
(
	[OttoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Planner]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  Table [dbo].[Position]    Script Date: 6/6/2017 11:28:53 AM ******/
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
	[MA_SelbakostenUmlage] [decimal](8, 2) NULL,
	[MO_SelbakostenUmlage] [decimal](18, 2) NULL,
	[MA_SelbakostenWithoutImlage] [decimal](18, 3) NULL,
	[MO_SelbakostenWithoutUmlage] [decimal](8, 3) NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Position_Longdesc]    Script Date: 6/6/2017 11:28:53 AM ******/
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
/****** Object:  Table [dbo].[PositionDeleteStatus]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PositionDeleteStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PositionDeleteStatus](
	[DeletePositionID] [int] IDENTITY(1,1) NOT NULL,
	[PositionID] [int] NULL,
	[ProjectID] [int] NULL,
 CONSTRAINT [PK_PositionDeleteStatus] PRIMARY KEY CLUSTERED 
(
	[DeletePositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Project]    Script Date: 6/6/2017 11:28:53 AM ******/
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
	[Status] [nvarchar](50) NULL,
	[InvoiceType] [bit] NULL,
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
/****** Object:  Table [dbo].[ProposalDetails]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProposalDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProposalDetails](
	[ProposalDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[PositionID] [int] NULL,
	[ParameterName] [nvarchar](100) NULL,
	[ParameterValue] [nvarchar](100) NULL,
	[SupplierProposalID] [int] NULL,
 CONSTRAINT [PK_ProposalDetails] PRIMARY KEY CLUSTERED 
(
	[ProposalDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProposalPosition]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProposalPosition]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProposalPosition](
	[ProposalPositionID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierProposalID] [int] NULL,
	[PositionID] [int] NULL,
 CONSTRAINT [PK_ProposalPosition] PRIMARY KEY CLUSTERED 
(
	[ProposalPositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ProposalSupplier]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProposalSupplier]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProposalSupplier](
	[ProposalSupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierProposalID] [int] NULL,
	[SupplierID] [int] NULL,
 CONSTRAINT [PK_ProposalSupplier] PRIMARY KEY CLUSTERED 
(
	[ProposalSupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Rabatt]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rabatt]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rabatt](
	[RabattID] [int] IDENTITY(1,1) NOT NULL,
	[Rabatt] [nvarchar](50) NULL,
	[TypeID] [int] NULL,
	[Multi1] [decimal](8, 3) NULL,
	[Multi2] [decimal](8, 3) NULL,
	[Multi3] [decimal](8, 3) NULL,
	[Multi4] [decimal](8, 3) NULL,
	[ValidityDate] [date] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LatestUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Rabatt] PRIMARY KEY CLUSTERED 
(
	[RabattID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Rabatt] UNIQUE NONCLUSTERED 
(
	[TypeID] ASC,
	[ValidityDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ReportDesign]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReportDesign]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReportDesign](
	[DesignID] [int] IDENTITY(1,1) NOT NULL,
	[DesignType] [nvarchar](200) NULL,
	[COL1] [nvarchar](max) NULL,
	[COL2] [nvarchar](max) NULL,
	[COL3] [nvarchar](max) NULL,
	[COL4] [nvarchar](max) NULL,
	[COL5] [nvarchar](max) NULL,
	[COL6] [nvarchar](max) NULL,
	[COL7] [nvarchar](max) NULL,
	[COL8] [nvarchar](max) NULL,
	[COL9] [nvarchar](max) NULL,
	[COL10] [nvarchar](max) NULL,
 CONSTRAINT [PK_DesignReport] PRIMARY KEY CLUSTERED 
(
	[DesignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[RoleFeatureMap]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleFeatureMap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RoleFeatureMap](
	[RoleFeatureMapID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[FeatureID] [int] NULL,
	[AccessLevel] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_RoleFeatureMap] PRIMARY KEY CLUSTERED 
(
	[RoleFeatureMapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SpecialCost]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SpecialCost]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SpecialCost](
	[SpecialCostID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NULL,
	[Cost_Desciption] [nvarchar](500) NULL,
	[Price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SpecialCost] PRIMARY KEY CLUSTERED 
(
	[SpecialCostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Supplier]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[ShortName] [nvarchar](100) NULL,
	[PaymentCondition] [nvarchar](500) NULL,
	[Commentary] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[EmailID] [nvarchar](50) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SupplierAddress]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplierAddress]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupplierAddress](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NULL,
	[ShortName] [nvarchar](100) NULL,
	[StreetNo] [nvarchar](100) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[DefaultAddress] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_SupplierAddress] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SupplierContact]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplierContact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupplierContact](
	[ContactPersonID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NULL,
	[ContactName] [nvarchar](100) NULL,
	[Salutation] [nvarchar](50) NULL,
	[Designation] [nvarchar](50) NULL,
	[EmailID] [nvarchar](50) NULL,
	[Telephone] [nvarchar](50) NULL,
	[FAX] [nvarchar](50) NULL,
	[DefaultContact] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_SupplierContact] PRIMARY KEY CLUSTERED 
(
	[ContactPersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SupplierProposal]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplierProposal]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupplierProposal](
	[SupplierProposalID] [int] IDENTITY(1,1) NOT NULL,
	[ProposalID] [int] NULL,
	[ProjectID] [int] NULL,
	[LVSection] [nvarchar](50) NULL,
	[WG] [nvarchar](10) NULL,
	[WA] [nvarchar](10) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_SupplierProposal] PRIMARY KEY CLUSTERED 
(
	[SupplierProposalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TextModule]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TextModule]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TextModule](
	[TextID] [int] IDENTITY(1,1) NOT NULL,
	[TextModuleArea] [nvarchar](200) NULL,
	[Category] [nvarchar](200) NULL,
	[Contents] [nvarchar](max) NULL,
	[IsSelect] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[TextAreaID] [int] NULL,
	[CategoryID] [int] NULL,
 CONSTRAINT [PK_TextModule] PRIMARY KEY CLUSTERED 
(
	[TextID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TextModuleArea]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TextModuleArea]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TextModuleArea](
	[TextAreaID] [int] IDENTITY(1,1) NOT NULL,
	[TextAreas] [nvarchar](100) NULL,
 CONSTRAINT [PK_TextModuleArea] PRIMARY KEY CLUSTERED 
(
	[TextAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Typ]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Typ]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Typ](
	[TypID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NULL,
	[WIID] [int] NULL,
	[Typ] [nvarchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [UC_Typ] UNIQUE NONCLUSTERED 
(
	[Typ] ASC,
	[WIID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_WIID] UNIQUE NONCLUSTERED 
(
	[WIID] ASC,
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserInfo](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[UserName] [nvarchar](200) NULL,
	[FirstName] [nvarchar](200) NULL,
	[LastName] [nvarchar](200) NULL,
	[Password] [nvarchar](200) NULL,
	[PasswordSalt] [nvarchar](200) NULL,
	[MobileNo] [nvarchar](200) NULL,
	[EmailID] [nvarchar](100) NULL,
	[IsOTP] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_UserName] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRole]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserRole](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](200) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[WG]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WG]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WG](
	[WGID] [int] IDENTITY(1,1) NOT NULL,
	[WG] [nvarchar](10) NULL,
	[WA] [nvarchar](10) NULL,
	[WGDescription] [nvarchar](500) NULL,
	[WADescription] [nvarchar](500) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_WG] PRIMARY KEY CLUSTERED 
(
	[WGID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_WGWA] UNIQUE NONCLUSTERED 
(
	[WG] ASC,
	[WA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[WGWA]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WGWA]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WGWA](
	[WGWAID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NULL,
	[WG] [nvarchar](10) NULL,
	[WA] [nvarchar](10) NULL,
	[WGDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_WGWA] PRIMARY KEY CLUSTERED 
(
	[WGWAID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_SWG] UNIQUE NONCLUSTERED 
(
	[WG] ASC,
	[WA] ASC,
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[WI]    Script Date: 6/6/2017 11:28:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WI]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WI](
	[WIID] [int] IDENTITY(1,1) NOT NULL,
	[WGID] [int] NULL,
	[WI] [nvarchar](10) NULL,
	[WIDescription] [nvarchar](500) NULL,
	[Fabrikate] [nvarchar](500) NULL,
	[Masseinheit] [nvarchar](50) NULL,
	[Dimension] [nvarchar](50) NULL,
	[Menegenheit] [nvarchar](50) NULL,
	[Remarks] [nvarchar](500) NULL,
	[TextKZ] [nvarchar](50) NULL,
	[ValidityDate] [date] NULL,
	[Multi1] [decimal](8, 3) NULL,
	[Multi2] [decimal](8, 3) NULL,
	[Multi3] [decimal](8, 3) NULL,
	[Multi4] [decimal](8, 3) NULL,
	[DataNormNumber] [nvarchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreateDate] [datetime] NULL,
	[LastUpdatedBy] [int] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_WI] PRIMARY KEY CLUSTERED 
(
	[WIID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_WI] UNIQUE NONCLUSTERED 
(
	[WGID] ASC,
	[WI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  UserDefinedFunction [dbo].[DelimitedSplit8K]    Script Date: 6/6/2017 11:28:53 AM ******/
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
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Customer]    Script Date: 6/6/2017 11:28:53 AM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND name = N'IX_Customer')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Customer] ON [dbo].[Customer]
(
	[CustomerShortName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_OTTOMaster]    Script Date: 6/6/2017 11:28:53 AM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[OTTOMaster]') AND name = N'IX_OTTOMaster')
CREATE UNIQUE NONCLUSTERED INDEX [IX_OTTOMaster] ON [dbo].[OTTOMaster]
(
	[ShortName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAddress]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerAddress]'))
ALTER TABLE [dbo].[CustomerAddress]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAddress] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAddress]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerAddress]'))
ALTER TABLE [dbo].[CustomerAddress] CHECK CONSTRAINT [FK_CustomerAddress]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerContact]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerContact]'))
ALTER TABLE [dbo].[CustomerContact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerContact] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerContact]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerContact]'))
ALTER TABLE [dbo].[CustomerContact] CHECK CONSTRAINT [FK_CustomerContact]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OTTOContact]') AND parent_object_id = OBJECT_ID(N'[dbo].[OTTOContact]'))
ALTER TABLE [dbo].[OTTOContact]  WITH CHECK ADD  CONSTRAINT [FK_OTTOContact] FOREIGN KEY([OttoID])
REFERENCES [dbo].[OTTOMaster] ([OttoID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OTTOContact]') AND parent_object_id = OBJECT_ID(N'[dbo].[OTTOContact]'))
ALTER TABLE [dbo].[OTTOContact] CHECK CONSTRAINT [FK_OTTOContact]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_CreatedBy] FOREIGN KEY([Created_By])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_CreatedBy]
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
SET IDENTITY_INSERT [dbo].[Employee] ON 

GO
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName]) VALUES (1, N'abcd')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Feature] ON 

GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (1, N'Anlegen von Leistungsverzeichnissen', N'Creating an LV, Creating the LV positions, Importing GAEB file')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (2, N'Kalkulation', N'Calculation (adding prices, Multi 1 to Multi 5), Bulk operations, ')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (3, N'Erstellung von Nachtragspositionen', N'Creating an NT or NTM position')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (4, N'Bepreisung von NT-Positionen', N'Calculation (adding prices, Multi 1 to Multi 5) for NT or NTM positions')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (5, N'Artikelstammdaten', N'Artikel Stammdaten (List prices, Multi 1 to Multi 4, adding new measures, …)')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (6, N'Kundenstammdaten', N'Customer Stammdaten')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (7, N'Lieferantenstammdaten', N'Supplier Stammdaten')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (8, N'OTTO-Stammdaten', N'OTTO Stammdaten')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (9, N'Anlegen von Kom.-Nr.', N'Making a Project into a Commission')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (10, N'Erstellung Aufmaßblätter (Delivery notes)', N'Delivery Notes (BLATT, Aufmass, Aufmasszusammenstellung)')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (11, N'Erstellung Rechnung (Invoice)', N'Creating Invoices')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (12, N'Erstellen von Textmodulen allgemein', N'Creating text modules, general')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (13, N'Erstellen von Textmodule "Kalkulation"', N'Creating text modules, calculation department')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (14, N'Bearbeiten der Textmodule "Kalkulation"', N'Editing text modules, calculation department')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (15, N'Erstellen von Textmodulen "Rechnungslegung"', N'Creating text odules, invoicing department')
GO
INSERT [dbo].[Feature] ([FeatureID], [FeatureName], [Description]) VALUES (16, N'Bearbeiten von Textmodulen Rechnungslegung"', N'Editing text modules, invoicing department')
GO
SET IDENTITY_INSERT [dbo].[Feature] OFF
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
INSERT [dbo].[Lookup] ([LookupID], [Value], [MapID], [Description]) VALUES (7, N'R', 2, N'Read')
GO
INSERT [dbo].[Lookup] ([LookupID], [Value], [MapID], [Description]) VALUES (8, N'R/W', 2, N'Read and Write')
GO
INSERT [dbo].[Lookup] ([LookupID], [Value], [MapID], [Description]) VALUES (9, N'None', 2, N'None')
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
INSERT [dbo].[LVRaster] ([LVRasterID], [LVRasterName]) VALUES (5, N'9.9.11.9')
GO
INSERT [dbo].[LVRaster] ([LVRasterID], [LVRasterName]) VALUES (6, N'9.9.111.9')
GO
SET IDENTITY_INSERT [dbo].[LVRaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Map] ON 

GO
INSERT [dbo].[Map] ([MapID], [MapName]) VALUES (1, N'PositionKZ')
GO
INSERT [dbo].[Map] ([MapID], [MapName]) VALUES (2, N'FeatureValue')
GO
SET IDENTITY_INSERT [dbo].[Map] OFF
GO
SET IDENTITY_INSERT [dbo].[Planner] ON 

GO
INSERT [dbo].[Planner] ([PlannerID], [PlannerName]) VALUES (1, N'abdc')
GO
SET IDENTITY_INSERT [dbo].[Planner] OFF
GO
SET IDENTITY_INSERT [dbo].[TextModuleArea] ON 

GO
INSERT [dbo].[TextModuleArea] ([TextAreaID], [TextAreas]) VALUES (4, N'Aufmasse')
GO
INSERT [dbo].[TextModuleArea] ([TextAreaID], [TextAreas]) VALUES (5, N'Angebot erstellen')
GO
INSERT [dbo].[TextModuleArea] ([TextAreaID], [TextAreas]) VALUES (6, N'Lieferantenanfrage')
GO
SET IDENTITY_INSERT [dbo].[TextModuleArea] OFF
GO