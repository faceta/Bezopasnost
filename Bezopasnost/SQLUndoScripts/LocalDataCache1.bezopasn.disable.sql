-- Этот код может использоваться для отключения отслеживания изменений в вашей базе данных
-- Перед выполнением этого кода убедитесь, что все таблицы перестали использовать отслеживание изменений
    
IF EXISTS (SELECT * FROM sys.change_tracking_databases WHERE database_id = DB_ID(N'bezopasn')) 
  ALTER DATABASE [bezopasn] 
  SET  CHANGE_TRACKING = OFF
GO
