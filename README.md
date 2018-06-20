# Pong
## Demonstration of how to break up MonoBehaviours into smaller, more isolated pieces

This repository contains a Pong game which goes through a number of steps as it is gradually decomposed into smaller bits and pieces. The intention here is to demonstrate the techniques - for the example Pong game it makes little difference, but the same principles can be used successfully on larger projects.

It is the companion source code to my Unite Berlin 2018 presentation, "From Pong to 15-person project".

### YouTube presentation

See the presentation (45 mins) at the start of [this video](https://www.youtube.com/watch?v=BW9qSy6ZB0A).

### Presentation slides

Slides as PDF [within the repository](https://github.com/Kalmalyzer/Pong/blob/master/From%20Pong%20to%2015-person%20project.pdf).

## Different versions of the Pong game

### Minimal, initial implementation of the Pong game

[Source code](https://github.com/Kalmalyzer/Pong/tree/minimal-implementation)

This is a straight-forward implementation of the Pong game. One MonoBehaviour for each 'thing' in the game.

### Shared data has been moved out from Prefabs and into ScriptableObjects

[Source code](https://github.com/Kalmalyzer/Pong/tree/shared-data-in-scriptable-objects)

Any parameters in prefabs which are not intended to be tweaked individually per-instance has been moved to ScriptableObjects. This makes it easier to see in the editor which prefab values are intended to be tweaked per-instance and which shouldn't (these parameters need to be edited via the shared ScriptableObjects instead).

### Most logic has been moved out of MonoBehaviours

[Source code](https://github.com/Kalmalyzer/Pong/tree/logic-moved-out-of-monobehaviours)

The bulk of logic has been moved out of MonoBehaviours and into separate Logic/Simulation/etc classes. MonoBehaviours are mostly controlling object lifetime and ensuring Unity engine callbacks are forwarded to the appropriate classes.

### Logic is independent of MonoBehaviours

[Source code](https://github.com/Kalmalyzer/Pong/tree/logic-independent-of-monobehaviours)

Delegates and interfaces are used to make Logic/Simulation/etc classes be more self-contained, with the adaptation logic present in the MonoBehaviour.

### Master control coroutine split into subroutines

[Source code](https://github.com/Kalmalyzer/Pong/tree/coroutine-split-into-subroutines)

A coroutine which does several fiddly things has been broken into sub-coroutines. This creates a bit more separation between intent and execution.
