Name: Brayden Faulkner and Jon Sulcer
Program: Incredible Inventory Program
Date: 4/29/18

This program was designed to give the user an easy to use and flexible program through which he or she
could keep track of an inventory. The main features of the program are being able to add, remove, and
modify items in the user's inventory. Each item is of an object we created called database object. The
databaseobject class contains a string to store the name, another string to store the id of the object, and
an int to store the amount of that object that the user has. Each users inventory is loaded up into the
TDatabase class that contains a private list of databaseobjects. TDatabase then has methods that control how
the user interacts with the list. Each function of the program is controlled by its own window. For example
if the user wants to add an item to his or her inventory they must navigate to the add window. Each window
is built by a factory that builds it according to the specifications given by the user on the settings
page. This allows the user to do things such as change the background color of the windows. The user's
inventory is stored in the database, with each user having his or her own table within the database. When
the user logs into the program, their inventory is loaded into a TDatabase object that allows the program
to track what the user's inventory contains. As the inventory is updated, such as items being added or
removed, the database is also updated.