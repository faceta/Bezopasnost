IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Soderzhanie]')) 
   ALTER TABLE [dbo].[Soderzhanie] 
   DISABLE  CHANGE_TRACKING
GO
