# Hotels

For this we will use Selenium Web Driver to search Trivargo for hotels!

We will collect results from Trivargo and write them to a CSV file.

## Steps

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
