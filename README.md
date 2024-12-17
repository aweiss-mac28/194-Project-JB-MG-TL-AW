# Recycling and Trash Disposal Simulator 
by Jeorie Brockenberry, Avi Weiss, Tenzin Lungrik, Momoima Gichana
 ---
Description:
In this program a user will be put in the environment of a room with various pieces of disposable waste around them. They will be tasked with sorting each of the waste items on the table into one of four bins, and will have 10 points given or taken away depending if they put the item in the correct bin or not.

Components:
The grabObject script needs to be attached to the controllers and allows for the user to pick up interactible objects before throwing them. An object that is interactible requires the following components: a collider, rigidbody physics, and XR Grab Interactible. 

The leaderboard above the scene currently connects to an itch.io (https://danqzq.itch.io/leaderboard-creator) website, with the key in the code for the leaderboard manager corresponding to the file on the itch.io project. 

The leaderboard score connects to the score displayed on the computer screen. The name input for the leaderboard is currently unimplemented, but it was intended to take the Oculus account username of the current user of the headset and submit it to the leaderboard attached to a score. 

Each of the four bins has a collider and script associated with it. This script takes in a tag as a string and will delete all objects that pass through it. If the tag of the object matches the string passed to the script, the score will increase by 10. Otherwise, the score will decrease by 10. 