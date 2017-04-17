IF NOT EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[PodPunkti]')) 
   ALTER TABLE [dbo].[PodPunkti] 
   ENABLE  CHANGE_TRACKING
GO
