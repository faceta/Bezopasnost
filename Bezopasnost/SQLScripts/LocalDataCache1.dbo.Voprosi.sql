IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Voprosi]')) 
   ALTER TABLE [dbo].[Voprosi] 
   ENABLE  CHANGE_TRACKING
GO
