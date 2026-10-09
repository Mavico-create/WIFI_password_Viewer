# WifiPasswordViewer
A simple C# console application that retrieves and displays saved WiFi passwords on Windows to help manage forgotten network credentials. 

## The Problem
We've all been there: you have a friend or family member over, they ask for your WiFi password, and your mind goes completely blank. Or, you buy a new device, but the password is saved on your computer, and you have no idea what it is. 

I constantly found myself forgetting my own complex WiFi passwords. Having to reset the router or log into the admin panel to get the password was frustrating and time-consuming.

## The Solution
I created this **WiFi Password Viewer** to solve that exact problem. Instead of digging through Windows settings or resetting routers, I built a simple C# command-line tool that does the hard work for me. 

It runs a quick Windows `netsh` command in the background, reads the system's saved network profiles, and instantly reveals the password for any network my computer has previously connected to. 

##  Built With
*   **C#** (.NET Console Application)
*   **System.Diagnostics** (To run Windows command-line processes)
*   **Regular Expressions (Regex)** (To parse the command-line output)

## How It Works
1. The program runs the command `netsh wlan show profiles` to get a list of all saved WiFi networks.
2. It parses the results and displays a numbered list of networks.
3. The user selects a network by typing its number.
4. The program runs `netsh wlan show profile name="[Network]" key=clear` to extract the password.
5. The password is displayed on the screen.

##  How to Run It
1. Clone this repository to your local machine.
2. Open the solution file (`.sln`) in Visual Studio.
3. Build and run the project (Press `F5` or `Ctrl + F5`).
4. *Note: You may need to run Visual Studio or the compiled .exe as Administrator for the command to work properly.*

## !! Disclaimer !!
This tool is intended for personal use only to recover your *own* saved WiFi passwords on your *own* computer. Do not use this tool on machines you do not own or have permission to access.
