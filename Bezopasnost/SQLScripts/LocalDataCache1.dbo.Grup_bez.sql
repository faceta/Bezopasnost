IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Grup_bez]')) 
   ALTER TABLE [dbo].[Grup_bez] 
   ENABLE  CHANGE_TRACKING
GO
