IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[tmp$voprosi]')) 
   ALTER TABLE [dbo].[tmp$voprosi] 
   DISABLE  CHANGE_TRACKING
GO
