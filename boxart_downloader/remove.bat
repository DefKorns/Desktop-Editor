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
tools\clovershell.exe exec "rm /var/lib/hakchi/rootfs/etc/init.d/S52defkornsdesktophack"
tools\clovershell.exe exec "rm -r /var/lib/hakchi/rootfs/boxart/"
tools\clovershell.exe exec "unset cfg_DefKorns_desktophack_enabled"
tools\clovershell.exe exec "rm -r /var/lib/hakchi/rootfs/borders/"