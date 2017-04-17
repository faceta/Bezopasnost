IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Podtemi]')) 
   ALTER TABLE [dbo].[Podtemi] 
   ENABLE  CHANGE_TRACKING
GO
