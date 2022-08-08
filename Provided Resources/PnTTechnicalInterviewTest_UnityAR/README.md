# Pixel and Texel Unity AR Technical Interview
Import the .unitypackage included in this zip foler into an empty Unity project, and begin the tasks outlined below.

## Rendering/General Tasks:
Open the scene `Scenes/ShaderScene`, review the objects in the scene, and complete the tasks outlined below.

1. Create a new Unity surface shader. Demonstrate the new shader on a game object in the scene.

2. Write a simple script to spawn and randomly position 1000 instances of a prefab game object which uses the new shader.

3. Add the appropriate colliders and rigidbodies to the prefab such that all the spawned game objects instances fall onto the plane object collider below.

4. Create a new screen-space Canvas game object, and add a button to trigger the game object instance spawning.

_Bonus_ Instead of creating a new Unity surface shader in step 1, create a new unlit vert/frag shader (not surface or compute), and add standard diffuse (Lambert) lighting logic to the pass. Then, add support for GPU instancing to the shader to lower the draw calls.


## Programming/AR Tasks:
Open the scene `Scenes/ARScene`, review the objects in the scene, and complete the tasks outlined below in the Update function in `Scripts/PositionBuilding.cs`.

1. Without parenting the building object to the marker object, smoothly interpolate the position of the building object to the marker object's world position, offset by 3 units in the marker object's local positive y-axis direction.

2. Align the building rotation such that it appears to be sitting upright on top of the marker object plane.

3. Slowly rotate the building around its local positive y-axis 10 degrees/second.

_Bonus_ Assume that this is an AR application, and you're faced with the challange of accomodating the marker being positioned either on a poster on the wall, or laying flat on a table. In some AR technologies, there is no concept of a "world up direction" - you only have the user device's accelerometer motion expressed in m/s², which changes as the user moves their phone or tablet. Using the motion data received in the event listener in `PositionBuilding.cs`, orient the building object such that it always appears to be standing upright in the user's real world space - in both flat and upright marker orientations.
