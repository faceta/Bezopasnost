IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Voprosi]')) 
   ALTER TABLE [dbo].[Voprosi] 
   DISABLE  CHANGE_TRACKING
GO
