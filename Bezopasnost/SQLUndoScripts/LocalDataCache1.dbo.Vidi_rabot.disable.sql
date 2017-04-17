IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Vidi_rabot]')) 
   ALTER TABLE [dbo].[Vidi_rabot] 
   DISABLE  CHANGE_TRACKING
GO
