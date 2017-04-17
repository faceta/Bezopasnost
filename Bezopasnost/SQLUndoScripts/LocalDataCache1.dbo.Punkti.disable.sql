IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Punkti]')) 
   ALTER TABLE [dbo].[Punkti] 
   DISABLE  CHANGE_TRACKING
GO
