WebKeyboard
===========

Exposes an web based API for sending keys to the host computer


This two parts. API controller running on ASP.NET, desktop app runnning on user's desktop.

If someone can figure out how to send/use user32.dll commands to the desktop while using IIS, please let me know.

Instation: 
requires MSMQ. 

USE:
not quite a RESTFUL api. 
GET http://{hostname}/{appname}/api/values/{keycode} 

for a list of keycode, see here: 
http://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
