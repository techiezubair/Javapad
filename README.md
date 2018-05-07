# Javapad
A notepad styled IDE for Java. 

/***************************************************************************

Author : Zee Safi

Support group: https://www.facebook.com/groups/198026730690268/

Report bugs (to): techiezubair@gmail.com or the support group.

***************************************************************************/

There are two bugs in the alpha version involving accepting an input from the user.
1. 
...
System.out.println("Enter input");
Scanner in = new Scanner(System.in);
String str = in.nextLine();
System.out.println("input: " + str);

Console output
--------------
Enter input
testing  <--- if the user types here
input: testing

But this is what happens if the user types data on the first line of the console view

Console output
--------------
Enter inputtesting  <--- the cursor was right after "Enter input" so the user entered the data next to it
input: Enter inputtesting

2. (with System.out.print <-- )
...
System.out.print("Enter input: ");
Scanner in = new Scanner(System.in);
String str = in.nextLine();
System.out.println("input: " + str);

Console output
--------------
testing
intput: testing

The "Enter input: " line is missing! 

I will fix this in the next update. It is still the alpha version, but everything else is working fine.


