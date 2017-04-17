IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Otveti]')) 
   ALTER TABLE [dbo].[Otveti] 
   DISABLE  CHANGE_TRACKING
GO
