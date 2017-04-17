IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Neschastn_sluch]')) 
   ALTER TABLE [dbo].[Neschastn_sluch] 
   DISABLE  CHANGE_TRACKING
GO
