@echo off

cd C:\Jinisys Softwares\Main

ren Folio_Plus.exe.config Folio_Plus_Local.exe.config

cd config_backup

move Folio_Plus.exe.config ..

@ECHO DATABASE SERVER LOCATION: DBSERVER

pause