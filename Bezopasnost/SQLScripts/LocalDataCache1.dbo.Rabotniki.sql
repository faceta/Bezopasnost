IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Rabotniki]')) 
   ALTER TABLE [dbo].[Rabotniki] 
   ENABLE  CHANGE_TRACKING
GO
