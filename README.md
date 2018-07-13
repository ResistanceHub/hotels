# Hotels

For this we will use Selenium Web Driver to search Trivargo for hotels!

We will collect results from Trivargo and write them to a CSV file.

Once this is working we will switch to writing e2e tests.

## Step 1 - Read and Write

### Make a new C# Console Application

Make a new console application at in the `hotels` folder.

Add all the Web Driver packages that are needed.

### Read and Write

Using Web Driver, navigate to https://www.trivago.co.uk and search for `London`


Dismiss any popups.


Fetch all the results from the 1st page. Write the details to a CSV file.

These are the details to capture:

The hotel name, the hotels rating

E.g.

```
Holiday Inn London - Regent's Park, 8.0
Holiday Inn Express London-Royal Docks, Docklands, 7.5
...
...
...
```

### Include the price

Extend the application to read and write the price, the one that is in green.


## Help! - Reading and Writing Files

To solve this challenge you need to be able to write to text files. It may also be helpful to be able to read from files hint hint.

This tutorial shows how to read and write to files in C# - http://csharp.net-tutorials.com/file-handling/reading-and-writing/

Look out for:

- File.ReadAllText
- File.WriteAllText


Also note where your file is being placed. I suspect that if you don't supply a full path or relative path, the file will end up in the bin/debug folder.


## Step 2 - Page Objects

Once step one is working we can create page objects. 

First read this write up on classes in C# - https://www.tutorialspoint.com/csharp/csharp_classes.htm

This page seems to give a good description of page objects: https://github.com/SeleniumHQ/selenium/wiki/PageObjects

Take note at how the web driver instance is passed in through the constructor.

I suggest you follow this pattern:

1. Make sure you are using many small, yet meaningful, functions
2. Create a class and move the functions into the class (don't use static functions)
3. In the main function, instantiate this new class and use it
4. Make sure your program still works :)


The best way to get this working is to work together and help each other!


These are some of the top results I got from doing a Google search:

- https://www.automatetheplanet.com/page-object-pattern/
- https://engineering.thetrainline.com/writing-automated-tests-using-page-object-design-pattern-2697ce19b752

There might be better resources out there, Google is your friend! 