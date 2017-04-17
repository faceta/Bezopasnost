IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Raspredelenie]')) 
   ALTER TABLE [dbo].[Raspredelenie] 
   DISABLE  CHANGE_TRACKING
GO
