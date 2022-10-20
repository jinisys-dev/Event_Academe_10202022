@ECHO OFF
for /f "tokens=1-4 delims=/ " %%a in ('date/t') do (
set fname=%%b%%c%%d
)

set bkupdir="C:\Program Files\Jinisys Software, Inc\Folio Plus\Main\DB Backup\"

SET mysqldir="C:\Program Files\MySQL\MySQL Server 5.0\"
SET dbname=hotelmgtsystem
SET dbuser=root
SET dbpass=root
SET dbHost=localhost

@ECHO Beginning backup of %dbname%...

%mysqldir%\bin\mysqldump -B %dbname% -u %dbuser% -p --password=%dbpass% --host=%dbHost% -f > "%fname%.sql"

@ECHO Done! New File: %fname% 

@ECHO Backup Complete. 

pause

