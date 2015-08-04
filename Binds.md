# Xim Configure #
X2 supports converting a .xim file so the most appropriate current approach to creating a set of key and mouse binds is to start with Xim Configure and loading the file into X2.

To do this, load the .xim file of your choice through the "Load Config" button.  This will convert it.  Once thats done save it by clicking "Save Config".

# Default Config #
When you exit X2, the configuration currently loaded will be saved to a file called default.cfg in the users AppData folder and reloaded when you start the application back up again.

# Manual Editing #
Manually editing a X2 config is currently the only way to access some of the best features, hopefully there will be a better UI in the future, for now here is the info:

## Basic Binding Syntax ##

> 'bind key xboxbutton'

Key can be one of a long laundry list of keyboard or mouse keys. The [key list](http://code.google.com/p/ximtranslator/wiki/KeysAndMouseButtons) can be found on a seperate wiki page.

The [xbox buttons](http://code.google.com/p/ximtranslator/wiki/XboxButtons) can also be found on a seperate wiki page:

## Button Moderators ##
Button moderators change how the xbox button reacts to the key being pressed, these moderators include Tap, Hold, Press, Release, Rapid Fire, and Toggle.

### Tap ###

> 'bind space a'

Tap presses the xbox button for 1 frame regardless of how long the key ( space in this case ) is being held down.

### Hold (.) ###

> 'bind tab .guide'

The '.' modifier will cause the xbox key to be held down as long as the key is held down. for this example the guide button will be pressed for as long as the tab key is pressed.

### Press (+) and Release (-) ###

> 'bind W +up'
> 'bind E -up'

The '+' modifier will press and hold an xbox key until it is released with a release event. In this example Up on the D-pad will be pressed when W is hit and released when E is hit.

### Rapid Fire (`*`) ###

> 'bind mouseleft `*`righttrigger'

The '`*`' modifier allows you to hold a key or mouse button down and the software will change the state of the button from off->on->off repeatedly untill you release, when you release it will leave the button in the off position.

This example is what i use for cod4 if i feel like autofiring :)

### Toggle (!) ###

> 'bind mouseright !lefttrigger'

The toggle (!) modifier can be used to swap the state of a button from on to off.  In this example clicking mouseright will change the state of the right trigger to the opposite state that it was just in. if it was pressed it will now be released, if it was released it will now be pressed.

This example is what i use to toggle zoom in cod4.

## Advanced Binding ##

### Exec ###

I havent tested this much, but the concept is pretty sweet:

'bind x exec 1234.cfg'

With this bind, when x is pressed xEmulate will search for 1234.cfg in 3 locations:
1) the current working folder
2) my documents\xim configs
3) appdata\xEmulate

If it finds the config, it will load it.  This can be useful for switching between "game modes" like in gta for driving vs walking.

## Useful Game Specific Bindings ##

Heres some useful binds for games

### COD4 ###

| Toggle sniping | bind x !lefttrigger |
|:---------------|:--------------------|
| Run even if you were sniping, this is similar to PC where running causes you to exit sniping. | bind x +leftstick;-lefttrigger;wait 100;-leftstick; |
| Go Prone       | bind x +b;wait 1000;-b |
| Swap weapons   | bind x +y;wait 1000;-y |
