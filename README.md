# Picturebot

----
## Description

Picturebot is photo organizer app which allows the user to organize photos in a proper way. It allows the user to easily add pictures to a shoot whereas the shoot is stored within a workspace.

A shoot contains workflows, every workflow has a unique purpose. There are seven defined workflows: backup, editing, base, preview, selection, edited and Instagram.

* **Backup** flow contains all pictures taken during a shoot
* **Editing** flow contains the image files that have embedded editing information about a certain picture
* **Base** flow contains all filtered photos (blurred, unsharp, duplicate, … pictures are deleted)
* **Preview** flow contains converted RAW images to a JPG image
* **Selection** flow contains all the pictures which are selected for editing and can later be edited
* **Edited** flow contains pictures that are edited
* **Instagram** flow contains cropped images that are used to post on Instagram

All pictures follow a special naming convention

    <shoot_dd-mm-YYYY_index.extension>

The oldest pictures in the shoot is marked with index one

     <shoot_02-06-2020_1.jpg>
The second oldest pictures in the shoot is marked with index two

    <shoot_02-06-2020_2.jpg>

----
## Workflow

1. Create a workspace (just once)
2. Add a new shoot
3. Drag the pictures to the listBox
4. Save the pictures
5. Delete blurred, unsharp and duplicated pictures
6. Rename the pictures accordingly to the shoot
7. Edit the pictures within the selection flow
8. After editing the picture save the picture within the edited flow

<a href="https://imgur.com/A1pWAMZ"><img src="https://i.imgur.com/A1pWAMZ.gif" title="source: imgur.com" /></a>

----
## Manual

> Under construction :warning:

An in depth manual can be found on the wiki page of this Git repository [wiki](https://github.com/Tomekske/PicturebotGUI/wiki).

----
## Features

* Add, update and delete workspaces
* Switch between workspaces
* Reorder workspace order
* Add a new shoot to the workspace
* Rename shoot and pictures accordingly 
* Delete shoots
* Delete pictures
* Open current workspace in explorer
* Open current shoot in explorer
* Edit pictures
* Upload pictures to the cloud in a very basic and straightforward way
* Convert RAW pictures to a JPG picture format
* Picture slideshow when displaying pictures in full screen
* View log file with the user’s default editor

----
## TODO

* Port the application to WPF using dotnet core(front-end and back-end), refactor code in doing so
* Move to a database system instead of working with absolute file paths
* Add functionality to import pictures to the new database system once the new system is rolled out
* Add a picture rating system and the ability to filter pictures based on their rating
* Speed up converting RAW pictures to a JPG picture format
* Visual representation whether a shoot is fully edited, partially edited, or not edited at all
* Investigate whether it is possible to add a tool to automatically upload pictures to google pictures
* Add / configure an installer to install Picturebot on a machine
* Ability to delete a picture when the user is browsing the pictures in the slideshow
* Different themes 
* Update the application whenever a newer version is available without overwriting the user’s settings
* Investigate and implement the best way how to add a picture within the backup flow to the base flow
* Add pictures to an existing shoot
* Add meta-data information to pictures
* Investigate and implement a way of dragging pictures to lightroom, since lightroom doesn’t support a CLI to open files
* Import mixed file formats shoots (RAW and JPG combined)
* CI to run C# tests
* Detect whether an external memory-card is connected and automatically open the directory when adding a new shoot
* Let the user decide how they want to format the datetime format

----
## Converting pictures

Converting RAW images to a JPG format is done by using [ImageMagick](https://imagemagick.org/), [download](https://imagemagick.org/script/download.php) ImageMagick.