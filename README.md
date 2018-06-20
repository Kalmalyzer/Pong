# Pong
## Demonstration of how to break up MonoBehaviours into smaller, more isolated pieces

This repository contains a Pong game which goes through a number of steps as it is gradually decomposed into smaller bits and pieces. The intention here is to demonstrate the techniques - for the example Pong game it makes little difference, but the same principles can be used successfully on larger projects.

## Different versions of the Pong game

[Minimal, initial implementation of the Pong game](https://github.com/Kalmalyzer/Pong/tree/minimal-implementation)
[Shared data has been moved out from Prefabs and into ScriptableObjects](https://github.com/Kalmalyzer/Pong/tree/shared-data-in-scriptable-objects)
[Most logic has been moved out of MonoBehaviours](https://github.com/Kalmalyzer/Pong/tree/logic-moved-out-of-monobehaviours)
[Logic is independent of MonoBehaviours](https://github.com/Kalmalyzer/Pong/tree/logic-independent-of-monobehaviours)
[Master control coroutine split into subroutines](https://github.com/Kalmalyzer/Pong/tree/coroutine-split-into-subroutines)
