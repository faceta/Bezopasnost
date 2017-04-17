IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Ekzamen]')) 
   ALTER TABLE [dbo].[Ekzamen] 
   DISABLE  CHANGE_TRACKING
GO
