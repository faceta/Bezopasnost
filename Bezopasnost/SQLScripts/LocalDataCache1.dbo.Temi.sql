IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Temi]')) 
   ALTER TABLE [dbo].[Temi] 
   ENABLE  CHANGE_TRACKING
GO
