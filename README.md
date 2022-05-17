# gogcord.moe
Official repository of official website of Gogcord! Woop woop!

https://Gogcord.moe/ may not always work, and that's because I'm not using static files on the github pages system anymore. Thats at https://legacy.gogcord.moe/, and what I'm making will allow me to be much more flexible with what I make.

## This is my funny little thing to allow me to have a goal for use of learning things.
If I have a technology that you'd like to see in action, browse around, copy code, I don't care. Just don't expect anything close to perfection if you do copy-paste. I don't \[yet] work to have super optimized code, I just make it functional. 

## Some things of note I learned:
- Blazor Server doesn't expose any way to read or write cookies (that I could find) so I used JSInterop to have a javascript function do that. Make sure you `[Inject]`
