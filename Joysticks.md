# Introduction #

xEmulate supports standard joysticks as well as XInput joysticks ( xbox 360 controllers ) as inputs.


# Detecting Controllers #

xEmulate will auto-detect controllers connected to the PC and display notification when you start up the application, three possible messages will appear.

"Initialized 1 XInput Controller, skipping Joysticks" : Means that you have an xbox 360 controller connected and you can use the xbox 360 controller binds.

"Initialized 1 Joystick" : One regular joystick was found, joy binds will work for this controller.

"No Joysticks Found, Joystick functionality disabled" : No controllers found.

# 360 Binds #

The 360 controller is very specific so i created a sample 1:1 mapping.  Why you would want an exact 1:1 mapping is up for debate, but you can add macro functionality to your controller.  I personally use it so that i can use my wireless controller while i'm playing with Xim so that i dont have to worry about tugging on the modded controllers wires or something.

```
bind 360a .a
bind 360b .b
bind 360x .x
bind 360y .y
bind 360leftshoulder .leftbumper
bind 360rightshoulder .rightbumper
bind 360back .back
bind 360start .start
bind 360leftstick .leftstick
bind 360rightstick .rightstick
bind 360dpadup .up
bind 360dpaddown .down
bind 360dpadleft .left
bind 360dpadright .right
bind 360arightstickx rightstickx
bind 360arightsticky rightsticky
bind 360aleftstickx leftstickx
bind 360aleftsticky leftsticky
bind 360arighttrigger righttrigger
bind 360alefttrigger lefttrigger
```

Each of the 360 controller "keys" start with "360" to distinguish from other input devices. Analog sticks start with "360a" as well.  360 binds follow the same rules as all other binds and macros do work for them.

# Joy Binds #

Joysticks are a bit more complicated because every controller is different, however xEmulate supports joy buttons 1 through 30, all 4 PoV hat buttons,  and all 3 axis.

Joystick Buttons:

  * Joy1 - Joy30
  * PovUp
  * PovDown
  * PovLeft
  * PovRight

Joystick Analog Sticks:

  * JoyX
  * JoyY
  * JoyZ
  * JoyRx
  * JoyRy
  * JoyRz

## Setting up the Joystick ##

### Joy Buttons ###

Joystick Buttons are the easy part of the process. You can check out your Control Panel for "Game Controllers", goto the controller you want and take note of which button is which in the UI.  For each one, you can map something like:

'bind joy1 .a'

This will map joystick button 1 to a

### POV buttons ###

Some controllers have POV or DPAD buttons, these are fairly easy to map 1:1 as well

```
bind povup .up
bind povdown .down
bind povleft .left
bind povright .right
```

### Analog Sticks ###

Analog sticks are the trickiest part.  Joysticks in windows support 6 axis directions     JoyX, JoyY, JoyZ, JoyRx, JoyRy, JoyRz

Typically the first thing to try is:

```
bind joyx leftstickx
bind joyy leftsticky -invert
bind joyrx rightstickx
bind joyry rightsticky -invert
bind joyz righttrigger
bind joyrz lefttrigger
```

Once these binds are set, try your analog sticks in a game and see if they are right. if the sticks are on the wrong side then try swapping leftstick for rightstick.

It seems like the xbox normally uses an inverted Y axis from windows, but if they Y axis is inverted, remove the -invert to switch it back.