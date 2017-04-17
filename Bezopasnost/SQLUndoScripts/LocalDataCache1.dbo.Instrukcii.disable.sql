IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Instrukcii]')) 
   ALTER TABLE [dbo].[Instrukcii] 
   DISABLE  CHANGE_TRACKING
GO
