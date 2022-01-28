# P3F Item Renamer
[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/S6S838859)

A tool for creating pnachs to rename items in Persona 3 Fes.

To use simply run the exe and follow the command line instructions. The tool should work with any type of items in the game however, if there are any things missing they can easily be added.

One limitation of the tool to note is that item names cannot be much longer than the original due to the way they are stored. Item names are stored in 4 byte chunks so if an item's name is 6 characters long it will have space for 7 characters (as one is required for the string terminator).

## Renaming Other Things
This tool is flexible and can in fact make pnaches for changing any static strings in any place of any game. To add a new section of strings you want to rename firstly find the strings in cheat engine. 
From there in the memory viewer select File -> Save memory region entering the correct start and end addresses for the chunk of strings. Make sure to tick "Don't include Cheat Engine header in the file" then save the CEM file into the NameLists folder of P3F Item Renamer.

Now that you have the memory dump, open up NameLists.json in the NameLists folder and add your new CEM to it. The StartAddress is the "from" address you entered when saving the memory in cheat engine converted to decimal format (use the windows calculator's programmer mode or any online tool) and the File is the name of the CEM you created.

That's all there is to it, now when you open up the tool you will be able to type any string from your chunk of strings and rename it the same way as you rename items.
