IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Chleni_komissii]')) 
   ALTER TABLE [dbo].[Chleni_komissii] 
   DISABLE  CHANGE_TRACKING
GO
