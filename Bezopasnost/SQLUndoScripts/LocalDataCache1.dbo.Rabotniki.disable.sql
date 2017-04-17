IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Rabotniki]')) 
   ALTER TABLE [dbo].[Rabotniki] 
   DISABLE  CHANGE_TRACKING
GO
