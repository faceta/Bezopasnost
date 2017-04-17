IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Otveti]')) 
   ALTER TABLE [dbo].[Otveti] 
   ENABLE  CHANGE_TRACKING
GO
