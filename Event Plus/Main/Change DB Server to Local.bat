@echo off

cd C:\Jinisys Softwares\Main

move Folio_Plus.exe.config config_backup

ren Folio_Plus_Local.exe.config Folio_Plus.exe.config

@echo DATABASE SERVER LOCATION: LOCALHOST

pause