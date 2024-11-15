
# docker and wsl 2

# following running the emulator

1. Before executing the setup script, we need to allow execution of unsigned scripts. Run the below command in the PowerShell window:

`$>Start-Process powershell -Verb RunAs -ArgumentList 'Set-ExecutionPolicy Bypass –Scope CurrentUser’`

2. Execute setup script `LaunchEmulator.ps1`. Running the script would bring up two containers – Event Hubs Emulator & Azurite (dependency for Emulator)


```

曾东  …/EventHub-Emulator/Scripts/Windows   main   ♥ 18:14  .\LaunchEmulator.ps1
By pressing "Y", you are expressing your consent to the End User License Agreement (EULA) for Event-Hubs Emulator: https://github.com/Azure/azure-event-hubs-emulator-installer/blob/main/EMULATOR_EULA.md: y
EULA has been accepted. Proceeding with launching containers..
[+] Running 7/7
 ✔ emulator Pulled                                                                                                                                    8.0s
   ✔ 4d8e791c4d43 Download complete                                                                                                                   6.3s
   ✔ 85534760f3c1 Download complete                                                                                                                   2.6s
   ✔ d7ac76ea30fe Download complete                                                                                                                   0.3s
   ✔ 60122052401d Download complete                                                                                                                   0.3s
   ✔ 4f4fb700ef54 Download complete                                                                                                                   0.2s
 ✔ azurite Pulled                                                                                                                                     0.3s
[+] Running 3/3
 ✔ Network microsoft-azure-eventhubs_eh-emulator  Created                                                                                             0.0s
 ✔ Container azurite                              Started                                                                                             0.7s
 ✔ Container eventhubs-emulator                   Started                                                                                             0.8s
Emulator Service and dependencies have been successfully launched!
```