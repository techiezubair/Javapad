# Javapad
A notepad styled IDE for Java written in C#

#### App version : Alpha v2

##### Features in Alpha 
* Portable
* ProjectEuler (476 questions, taken from [offline-proejcteuler-github](https://github.com/davidcorbin/euler-offline))
* Profile (Track solved solutions and points)
* Auto-detects JDK in the system, even if it is not set in PATH (Windows environment variables)

Screenshots
-----------
![Screenshot1](https://imgur.com/HOTvnvj.jpg)
![Screenshot2](https://imgur.com/6zkZ5aF.jpg)
![Screenshot3](https://imgur.com/O3kVYUP.jpg)

Purpose
-----------
* OFFLINE Java learning experience
* Improve your programming skills and typing speed
* Fun

Why make such an app
--------------------
* Firstly, just because I can
* Mainly, OFFLINE and portability
* This is why I chose to use Windows registry to store data to keep the app portable (I might come up with a better solution in the future)


Why C#?
--------
* Quick development
* Easy calls to Win32Api
* Java alone can't make Win32Api calls, I would have to rely on C.
* I just wanted to develop an app using C#

Alpha v2 Compatibility
-----------------------
* All versions of Windows with .NET Framework 3.5 client profile - download it from [Microsoft](https://www.microsoft.com/en-ca/download/details.aspx?id=5007)
* & with  Java development kit [JDK], download it from [Oracle](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html)
  - Windows XP
  - Windows Vista
  - Windows 7
  - Windows 8
  - Windows 10

Alpha v3 Features (coming soon)
-------------------------------
* IDE usage timer
* Timer in solving ProjectEuler problems
* Fixing some of the major bugs listed below
* Profile - change username, avatar, and background color

Beta Features (released after Alpha v3)
---------------------------------------
* More custom questions to solve
* An offline Java learning book
* Change theme

Final Release (released after Beta v1)
--------------------------------------
* Fixed known bugs
* A better UI, a better UX

##### Known Bugs
* When pasting Java code, the encoder doesn't do anything (Not implemented)
* When using System.out.print("Enter: ") and use accepts input from the user, the ConsoleView does not display "Enter: "
* In ConsolveView when pressing the enter key the application throws a catch exception
* User profile - user can't change name or picture (Not implemented)
* When clicking "PROJECTEULER" or "PROFILE" labels, the Expander expands without any boundary checks
* Auto-detect only searches the C drive (It should search all available drives in the system)

