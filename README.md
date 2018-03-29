# unity-RAM
A small experiment to make Realtime Audio Mixer (RAM) for Unity game engine. Unity's snapshot mixer system felt insufficient for our needs, so we felt like sharing.
Audio in the example made by Robertas Zutautas; (GNU General Public License v3.0)
Scripts (C#) by Danielius Vargonas; (GNU General Public License v3.0)
---
About the example
Launch "main" scene to check how it works.
Top part of UI buttons is for Unity's snapshot system.
Bottom part - the custom one.
They are not 'friends' for now, but it can be improved on that.
---
Parameters:
Core functionality contains in just 2 scripts under the "Realtime Audio Controller" GameObject in the scene:
-SourceSwitcher.cs- Acts as a playlist generator, stacking track groups into order.
    /Track groups - tracks groups which are/can be played at the same time are stacked here. Group count shows how long the playlist will be.
    Group size is not editable in the editor, but it can be increased/decreased in the script. Just look for the appropriate lines.
    The group size corresponds to the Child objects, and their AudioSource references - they MUST have the same amount. (possible improvement for later dev - auto generate the hierarchy)
    //Play List - auto generated. Simply shows what the order will be for the playable track groups.
-AudioLevelControl.cs- Controls audio levels for each AudioMixerGroup under the mixer.
    /Mixer - reference to your mixer in the Assets.
    //Time to Fade In - how long it takes to fade in (seconds)
    ///Time to Fade Out - how long it takes to fade out
    ////Time to Stay - how long it takes for the both tracks to play, before starting the next fading sequence
    /////Final Level A - Audio Volume level in correspondins AudioMixerGroup which will be set after Fade Out
    //////Final Level B - <...> after Fade in.
    ///////Groups to Ignore - indexes of groups which to ignore and not set in. This is used for background music AudioMixerGroup, which is intended to be always playing (i.e. boss)
-There are other scripts from earlier experiments with snapshots, you can use them as well if/where you see fit. They are not part of the solution, but were not discarded, in order to stand as a demo of capabilities.
---
Setup:
Same as in example;
Important notice - regarding the exposing AudioMixerGroup Volume parameter
