@echo off
:::  ____        __ _  __                                                                        
::: |  _ \  ___ / _| |/ /___  _ __ _ __  ___                                                     
::: | | | |/ _ \ |_| ' // _ \| '__| '_ \/ __|                                                    
::: | |_| |  __/  _| . \ (_) | |  | | | \__ \                                                    
::: |____/ \___|_| |_|\_\___/|_|  |_| |_|___/                      _                 _           
::: | __ )  _____  __   / \   _ __| |_  |  _ \  _____      ___ __ | | ___   __ _  __| | ___ _ __ 
::: |  _ \ / _ \ \/ /  / _ \ | '__| __| | | | |/ _ \ \ /\ / / '_ \| |/ _ \ / _` |/ _` |/ _ \ '__|
::: | |_) | (_) >  <  / ___ \| |  | |_  | |_| | (_) \ V  V /| | | | | (_) | (_| | (_| |  __/ |   
::: |____/ \___/_/\_\/_/   \_\_|   \__| |____/ \___/ \_/\_/ |_| |_|_|\___/ \__,_|\__,_|\___|_|   
:::                                                                                              
for /f "delims=: tokens=*" %%A in ('findstr /b ::: "%~f0"') do @echo(%%A
echo Make sure that your SNES/NES Mini Classic is connected to PC and turned on, also close hakchi2 if it's opened.
choice /d y /t 5 > nul
@echo off
tools\clovershell.exe exec "cat /etc/issue" > tools\version
FOR /F "tokens=4 delims= " %%a IN (tools\version) DO CALL :CHECKVERSION %%a %%b
:CHECKVERSION 
if [%1] == [dp-sneseur-nerd] goto SNES
if [%1] == [dp-snesusa-nerd] goto SNES
if [%1] == [dp-neseur-nerd] goto NES
if [%1] == [dp-nesusa-nerd] goto NES
if [%1] == [dp-nes-nerd] goto NES
if [%1] == [dp-shvc-nerd] goto SNES
if [%1] == [dp-hvc-nerd] goto NES
:SNES
ECHO Looking for SNES Classic Edition files. Please wait...
for /f "delims=" %%i in (tools\gamecodessnes) do tools\clovershell.exe pull /var/lib/hakchi/squashfs/usr/share/games/%%i/%%i.desktop 2>NUL
for /f "delims=" %%i in (tools\gamecodessnes) do tools\clovershell.exe pull /var/lib/hakchi/squashfs/usr/share/games/%%i/%%i.png 2>NUL
for /f "delims=" %%i in (tools\gamecodessnes) do tools\clovershell.exe pull /var/lib/hakchi/squashfs/usr/share/games/%%i/%%i_small.png 2>NUL
:NES
ECHO Looking for NES Classic Edition files. Please wait...
for /f "delims=" %%i in (tools\gamecodesnes) do tools\clovershell.exe pull /var/lib/hakchi/squashfs/usr/share/games/nes/kachikachi/%%i/%%i.desktop 2>NUL
for /f "delims=" %%i in (tools\gamecodesnes) do tools\clovershell.exe pull /var/lib/hakchi/squashfs/usr/share/games/nes/kachikachi/%%i/%%i.png 2>NUL
for /f "delims=" %%i in (tools\gamecodesnes) do tools\clovershell.exe pull /var/lib/hakchi/squashfs/usr/share/games/nes/kachikachi/%%i/%%i_small.png 2>NUL
)
echo Moving files...
if EXIST tools\version del tools\version
move /Y *.png boxart_hack\boxart\
move /Y *.desktop boxart_hack\boxart\
echo "Script complete"
