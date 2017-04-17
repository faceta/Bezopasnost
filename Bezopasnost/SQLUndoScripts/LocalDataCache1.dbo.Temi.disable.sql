IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Temi]')) 
   ALTER TABLE [dbo].[Temi] 
   DISABLE  CHANGE_TRACKING
GO
