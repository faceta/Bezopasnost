IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Stetchik]')) 
   ALTER TABLE [dbo].[Stetchik] 
   DISABLE  CHANGE_TRACKING
GO
