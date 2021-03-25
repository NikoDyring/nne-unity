# NNE Unity Assignment

By Nikolaj Dyring Jensen

## Controls

**WASD** - For moving your player.
**E** - For interacting.
**ESC** - For closing the UI Window.

## Considerations

1. Since the testscene is very flat and has no stairs/slopes, I've decided not to implement gravity / stepping on the player controller. This would be easy to implement in the future if the needs were to come.
2. After spending a lot of time trying to figure out how to get the alignment right I spend a lot of time hard-coding it in the beginning to later on change it after I got a better understanding of Quarternions.

## Other Comments
The prototype I've handed in is missing the syncronization between two clients when they click a QR code. It works if you're the server/host, but not if the clients sends the request. I will be looking into this issue until we speak next time.

I spend a lot of time reading through documentation as the previous experience I've had with Unity has mainly been 2D projects. This was quite the challenge, but none the less I am confident that this type of work is something that'd challenge and motivate me to work even harder. Overall, it has been a very insightful challenge, and I especially liked the complexity of it as some of the functionality I've never touched upon (synchronizing gameObjects between clients in a 3D World space)