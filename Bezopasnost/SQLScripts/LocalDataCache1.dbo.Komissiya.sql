IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Komissiya]')) 
   ALTER TABLE [dbo].[Komissiya] 
   ENABLE  CHANGE_TRACKING
GO
