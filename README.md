AI Final Project
Andrew Kassing
April 28, 2025

A bare-bones implementation of GOAP in Unity using CrashKonijn's GOAP for Unity. An NPC cat with a few simple behaviors, including wandering, drinking, sleeping, and fleeing from player. Pretty much everything important is in the Assets/Scripts/GOAP folder.

Mostly used this video as a guide for CrashKonijn's GOAP System; a lot of code is taken from it:
https://www.youtube.com/watch?v=85kogmzcLXw

Made using Unity 6000.0.33f1

To properly build project:

From package manager, install package from git URL: https://github.com/crashkonijn/GOAP.git?path=/Package#2.1.22

Import the following free assets:
- "Starter Assets - FirstPerson": https://assetstore.unity.com/packages/essentials/starter-assets-firstperson-updates-in-new-charactercontroller-pa-196525
- "Free chibi cat": https://assetstore.unity.com/packages/3d/characters/animals/mammals/free-chibi-cat-165490
- "Old Rusted Bowl": https://assetstore.unity.com/packages/3d/props/electronics/old-rusted-bowl-24448
- TextMeshPro Essential Resources

Tools > GOAP > Node Viewer provides a live visualization of the GOAP framework upon pressing Play and clicking the "Cat" box on the left side of the window.