@ECHO OFF
for /f "tokens=1-4 delims=/ " %%a in ('date/t') do (
set dw=%%a
set mm=%%b
set dd=%%c
set yy=%%d
)

SET bkupdir=C:\
SET mysqldir="C:\Program Files\MySQL\MySQL Server 5.0\"
SET dbname=hotelmgtsystem
SET dbuser=root
SET dbpass=root

@ECHO Beginning backup of %dbname%...

%mysqldir%\bin\mysqldump -B %dbname% -u %dbuser% -p --password=%dbpass% --host=%dbhost% -f > "%fname%"

@ECHO Done! New File: %fname% 

@ECHO Copying Database %dbname% to LocalHost. Please wait.

%mysqldir%\bin\mysql -u root -p --password=root -f < "%fname%"

@ECHO Backup Complete. 

pause

