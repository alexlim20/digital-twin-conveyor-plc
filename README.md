# Virtual Commissioning & Digital Twin of a Conveyor Sorting System
Designed and programmed a physics-based Digital Twin to virtually commission a Siemens PLC. This project bridges OT (Operational Technology) and IT (Information Technology) by allowing real-time, bidirectional communication between a live PLC environment and a 3D physics simulation.
## Tech Stack
+ **PLC / Logic** → Siemens TIA Portal V1X, PLCSIM, S7-1500

+ **Simulation Environment** → Unity 3D Engine

+ **Networking / Middleware** → NetToPLCsim, C#, S7.Net Library

## System Architecture
![Flow Chart of Connection between all the components.](diagram(1).png)

## Key Features & Problem Solving
+ **Physics-Based Material Handling**: Implemented rigidbodies and custom convezor physics in Unity to simulate gravity, friction, and material flow, replacing standard "teleportation" scripts.
+ **Asynchronous Motor Interlocks**: Programmed safety logic in TIA Portal to ensure the two Top Bands never operate simultaneously to prevent hopper overflow.
+ **State Memory & Timmer Logic**: Switches are implemented utilizing SR Flip-Flops to latch momentary inputs, feeding into TOF (Off-Delay) timers for precise 2-second and 6-second material clearing sequences.

## Demo



