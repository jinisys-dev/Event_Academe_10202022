
SET bkupdir="D:\MySql\DB Backups"

cd "C:\Program Files\MySql\"

xcopy /E /Y /I "MySql Server 5.0" %bkupdir%


echo "Back up Complete..."