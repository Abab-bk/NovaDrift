set WORKSPACE=.
set LUBAN_DLL=%WORKSPACE%\Tools\Luban\Luban.dll
set CONF_ROOT=.

dotnet %LUBAN_DLL% ^
    -t all ^
    -d json ^
    -c cs-dotnet-json ^
    --conf %CONF_ROOT%\luban.conf ^
    -x outputDataDir=..\..\Src\Assets\DataBase ^
    -x outputCodeDir=..\..\Src\Scripts\DataBase

pause