IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Razdelenie]')) 
   ALTER TABLE [dbo].[Razdelenie] 
   DISABLE  CHANGE_TRACKING
GO
