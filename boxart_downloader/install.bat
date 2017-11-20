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
set OLDPATH=%PATH%
set PATH=%PATH%;..\tools
echo Make sure that your SNES/NES Mini Classic is connected to PC and turned on, also close hakchi2 if it's opened.
choice /d y /t 5 > nul
@echo off
if NOT ERRORLEVEL 0 goto install
tools\clovershell.exe exec "rm /var/lib/hakchi/rootfs/etc/init.d/S52defkornsdesktophack"
tools\clovershell.exe exec "rm -r /var/lib/hakchi/rootfs/boxart/"
tools\clovershell.exe exec "unset cfg_DefKorns_desktophack_enabled"
tools\clovershell.exe exec "cat /etc/issue" > tools\version
:install
findstr /m "dp-sneseur-nerd" tools\version
if %errorlevel%==0 (
ECHO Uploading SNES Classic Edition files. Please wait...
cd boxart_hack
..\tools\bsdtar.exe -czvf ../boxart.tar.gz boxart/CLV-P-SA* boxart/CLV-P-VA*
cd ..
tools\clovershell.exe push "boxart_hack\S52defkornsdesktophack" "/var/lib/hakchi/rootfs/etc/init.d/S52defkornsdesktophack" 2>NUL
tools\clovershell.exe exec "cd /var/lib/hakchi/rootfs && tar -xzv" boxart.tar.gz 2>NUL
tools\clovershell.exe exec "chmod +x /var/lib/hakchi/rootfs/etc/init.d/S52defkornsdesktophack" 2>NUL
tools\clovershell.exe exec "cfg_DefKorns_desktophack_enabled='y'"
)else (
ECHO Looking for NES Classic Edition files. Please wait...
cd boxart_hack
..\tools\bsdtar.exe -czvf ../boxart.tar.gz boxart/CLV-P-NA* boxart/CLV-P-HA*
cd ..
tools\clovershell.exe push "boxart_hack\S52defkornsdesktophack" "/var/lib/hakchi/rootfs/etc/init.d/S52defkornsdesktophack" 2>NUL
tools\clovershell.exe exec "cd /var/lib/hakchi/rootfs && tar -xzv" boxart.tar.gz 2>NUL
tools\clovershell.exe exec "chmod +x /var/lib/hakchi/rootfs/etc/init.d/S52defkornsdesktophack" 2>NUL
tools\clovershell.exe exec "cfg_DefKorns_desktophack_enabled='y'" 2>NUL
)
:done
if EXIST boxart.tar.gz del boxart.tar.gz
set PATH=%OLDPATH%