So i've been working on a xim 2 program thats coming along quite nicely.  I currently have all of the existing xim 2 software support except for joysticks.

I added support for macro/binds quake 3 style - like "bind button macro"

here is an example of the "config" that I set up for myself for COD4:

Code:
```
bind f1 guidebind k leftsticknegativey
bind i leftstickpositivey
bind j leftsticknegativex
bind l leftstickpositivex
bind space a
bind rightalt b
bind n +b;wait 1000;-b
bind semicolon leftstick
bind m rightstick
bind h x
bind backspace back
bind u +x;wait 1000;-x
bind up up
bind return start
            
bind mouse1 .righttrigger
bind mouse3 .rightbumper
bind mouse2 !lefttrigger
bind mwheelup y
bind mwheeldown y

set sensitivity1 6000
set sensitivity2 8500
set transexponent1 0.35
set transexponent2 0.35
set deadzone 3000
set xyratio 2.0
set clearsmoothonstop true
set smoothness 1
```

Most of it is pretty simple but the + - . ! and wait may be a bit strange:

Code:
```
+x;wait 1000;-x 
```
This line i use to swap weapons in COD4, pretty sweet.

Prefixes to xbox control buttons alter how it is interpreted, no prefix is similar to "." except if used inside a macro with a wait they will act differently, but otherwise.
"!" - adds a toggle to the state of a button, this is great for adding a toggle scope option to cod4 as i've done here
"+" and "-" - Sets or Resets the state of a button, the "+" sets the button indefinitely.
"." - This holds a xbox button as long as the keyboard key is held down.
"**" - Rapid fire the xbox button as long as the keyboard key is being held down.**

Features:

  * Allow multiple keyboard keys to access a single xbox button
  * Allow for simple macros for some interesting actions including rapid fire and timed holds.
  * Supports setting variables on the fly with binds: i.e. "bind r set sensitivity1 1000;"
  * Supports reading from .xim configs .xim files, converts all but a few things.
  * Does not require elevated priveleges in Vista
  * Command line allows editing the config on the fly
  * App does not crash if your Xim gets hung
  * Alt-Tab works
  * Added support for "text mode" which translates keystrokes to xbox message text, currently only supports [a-z][0-9]