IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Prilozheniya]')) 
   ALTER TABLE [dbo].[Prilozheniya] 
   DISABLE  CHANGE_TRACKING
GO
