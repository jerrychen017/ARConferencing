# ARConferencing

Rise of video-conferencing during the pandemic has highlighted the value of in-person communication. It has become especially problematic when giving virtual presentations - your body movements cannot be fully seen by other parties. 

We are proposing AR conferencing, which is an app that generates a augmentation of an individual from video, then project this augmentation into virtual space of participants to increase immersion. For the demo of the project, we will show one use case of the app - presentations. 

## Requirements
* Unity: 2020.3.4f1 (with iOS build support installed)
* iOS device with A12 chip (running on iOS 14.0 or above)
* a device with camera (it can be a PC, laptop, android or iOS device).
* a multi-target AR marker for AR camera. 

Here are steps on how to make your own AR marker: 
1. Print the following images in color. [img1](imgs/img1.png), [img2](imgs/img2.png), [img3](imgs/img3.png), [img4](imgs/img4.png), [img5](imgs/img5.png), [img6](imgs/img6.png)
2. Find a cardbox to make a cube, and attach 6 images to the 6 sides of the cube. Here's an [image](imgs/multi-target-flatten.png) that can help you figure out which side to put which image on. Make sure that you have the correct orientation for each side. Here's the [multi-target](imgs/multi-target-3d.png) in 3D. 

## Components 
There are three scenes in the project. 
* [Launcher](imgs/launcher.png): 
You can enter your name and join the room. You can choose to use your current device as a Tracking Client or a Viewer Client by clicking on the corresponding button. 
* [Tracking Client](imgs/tracking-client.png): Tracks your body movement and synchronize your movements over the cloud. Note: this client only runs on an iOS device equipped with an A12 chip or above.
* [Viewer Client](imgs/viewer-client.png): View the avatar and presentation slides through an AR camera. The Avatar and presentation slides are positioned with respect to the location and orientation of the AR marker. So it's important to display the AR marker in front of the camera. 

## How to Run
1. Build Unity project for iOS, then use `xcode` to deploy it to your iOS device. When you build, make sure you've selected scenes in the following order: `Launcher`, `Tracking Client Scene`, `Viewer Client Scene`. Note: the iOS device must have an A12 chip or above since we are using ARKit4 framework in this project.
2. Build and deploy the Unity project for your device of choice. If you choose to run on a PC or laptop, you can simply run it in Unity play mode. When you build, make sure you've selected scenes in the following order: `Launcher`, `Viewer Client Scene`, `Tracking Client Scene`.
3. Open the app on your viewer device. Enter your name and click on `Viewer Client`. 
4. Open the app on your tracking device (iOS). Enter your name and click on `Tracking Client`. 
5. Place your multi-target AR marker in front of your viewer device. 
6. Stand in front of your tracking device. 
7. Now, you can see your avatar in the Viewer Client Scene! 
