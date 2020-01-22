# Pizza Creator (ITSE 1430)
## Version 1.2

In this lab you will create a console application to order a pizza. The application will provide the user options to order a pizza and display the running total for the order.

[Skills Needed](#skills-needed)\
[General Guidelines](#general-guidelines) \
[Story 1](#story-1)\
[Story 2](#story-2)\
[Story 3](#story-3)\
[Story 4](#story-4)\
[Story 5](#story-5)\
[Story 6](#story-6)\
[Console Help](#Console Help)\
[Requirements](#requirements)

## Skills Needed

- C#
	- Control flow statements
	- Functions and parameters
	- Types
	- Variables
- Console read/write

## General Guidelines

### General 

- It is strongly recommended that you complete the stories in order. Some stories rely on the work done in previous stories.
- Commit your changes to Github frequently to ensure you don't lose any work. You do not need to wait for a story to be completed.
- After you implement a story ensure it meets all the acceptance criteria. In some cases a later story may change the behavior of an earlier story.
- After you complete a story you should commit the changes you've made to Github and then PR the changes to `master`. If something comes up and you are not able to complete the remaining stories you can at least get credit for the work you've done.

### Naming Conventions

- USE descriptive nouns for variable and parameter identifiers (e.g. `payRate`, `name`, `index`).
- USE descriptive verbs for function identifiers (e.g. `getName`, `showProgress`).
- DO NOT use single letters or abbreviations in identifiers (e.g. `x`, `descriptValue`).
- DO ensure spelling for identifiers.
- DO use camel casing for variables, parameters and fields.
- DO use Pascal casing for types and public members.

### Coding Style

- DO put a file header at the top of each file you create. The file header should contain the class, date and your name.
- DO use consistent indentation. In general each block indents one time (3 or 4 spaces). Curly braces should be aligned.
  ```csharp
  //NO
  while (someCondition) 
     { 
    Foo();
	     };
		 
  //YES
  while (someCondition)
  {
     Foo();
  };
  ```
- DO use a single blank line between blocks of code (e.g. functions, control flow statements, etc).
  ```csharp
  //NO
  void DoWork ()
  {
  }
  void DoMoreWork()
  {
  }
  
  //YES
  void DoWork ()
  {
  }
  
  void DoWork ()
  {
  }
  ```
- DO consider declaring variables just before or as part of their first usage instead of up front.
  ```csharp
  //NO
  int hours;
  double payRate, totalPay;
  ...
  totalPay = payRate * hours;
  
  //YES
  double totalPay = payRate * hours;
  ```
- DO put comments above code that is not clear.
- DO NOT put comments in code that repeats what the code does.
  ```csharp
  //NO
  //Loop through stuff
  for (...)
  //YES
  for (...)
  ```
  
## Story 1 - Create the Project

Create a new console project to hold your code.

### Description 

For this first lab here are the directions.

1. Start Visual Studio.
1. Create a new project by using the `Create a new project` option in the `Start Window`.
   1. Under the languages filter select `C#`. Then search for the template `Console App`.
   1. Select `Console App (.NET Core)`. Ensure that the language is shown as `C#`. Click `Next`.
   1. For the project name use `PizzaCreator`.
   1. Ensure the project location is set to the `Labs` folder of your Github repo that you have previously cloned.
   1. Click `Create` to create the project.
1. Display basic program information including the program name (`PizzaCreator`), class, semester and your name.

### Acceptance Criteria

1. The application compiles cleanly without warnings or errors.
1. The application runs.
1. Can see the program information on startup.

## Story 2 - Display the Main Menu

Display a menu of options to the user.

### Description

The user will need to choose from a list of options in a menu. Set up a simple menu function that displays the available menu options, validates the user input and calls the appropriate menu handler. For now put in a dummy menu option to test your code.

For user input you should use either letters or numbers to get input (you don't need both). For example a quit command may be mapped to the letter `Q` or the number `0`. You may use whichever is easiest for you but be consistent. For letters, case does not matter.

Unless otherwise stated after a command is executed the user should return to the main menu so they may choose another option.

The cart price should be shown (with a label) each time the menu is. The cart should show the current price based upon the order.

*Note: Create a helper function to display the menu.*
*Note: Consider using an enumeration to identify the options.*
*Note: To show prices use the currency format specifier `price.ToString("C")`.*

### Acceptance Criteria

1. User is shown a menu of options.
1. If a user selects a valid menu option then that acction is performed.
1. If a user selects an incorrect option then they receive an error message and can try again.
1. If letters are used for menu options then case does not matter.
1. The current price is shown as part of the menu.

## Story 3 - Quit

Allows the user to exit the program.

### Description

Add an option to the menu to quit the program. It should be the last option. If the user selects the quit option then prompt them for confirmation and then quit.

*Note: Consider creating a function to prompt for Yes/No questions and returns a boolean result.*

### Acceptance Criteria

1. Command appears as last option in menu.
1. Selecting command prompts user to confirm.
1. User is limited to the defined yes/no options.
1. Case does not matter on user input.
1. Confirming quit terminates program.
1. Declining quit returns to menu.

## Story 4 - New Order

Allows the user to create a new order. 

### Description

Add an option to the menu to create a new order. If an order is already created then the user is first prompted to overwrite the existing order.

The order process walks the user through the process of creating a pizza. The following choices are available

- Size (one is required).
    - Small ($5)
    - Medium ($6.25)
    - Large ($8.75)
- Meats (zero or more). Each option is $0.75 extra. The user can select or unselect the options until done.
    - Bacon
    - Ham
    - Pepperoni
    - Sausage
- Vegetables (zero or more). Each option is $0.50 extra. The user can select or unselect the options until done.
    - Black olives
    - Mushrooms
    - Onions
    - Peppers
- Sauce (one is required). 
    - Traditional ($0)
    - Garlic ($1)
    - Oregano ($1)
- Cheese (one is required).
    - Regular ($0)
    - Extra ($1.25)
- Delivery (one is required).
    - Take Out ($0)
    - Delivery ($2.50)

After the user has entered their order information then the application will display the order information and return to the main menu.

The data entered here will be needed in other functions so for now you will need to make them "global". To do that define the variables outside any function using the following syntax.

```csharp
class Program 
{
   static int hours;
}
```

### Acceptance Criteria

1. If no order already exists then the user starts creating a new order.
1. If an order exists then the user is prompted to start over. If the user chooses yes then a new order is created. If the user chooses no then nothing happens.
1. User is required to select a size.
1. User may select zero or more meats. 
1. User can unselect a selected meat option.
1. User may select zero or more vegetables.
1. User can unselect a selected vegetable option.
1. User can select a type of sauce.
1. User can select a type of cheese.
1. User can select a delivery type.
1. After order entry user is shown the order information.
1. If the user enters any invalid options then they receive an error message.
1. Prices are shown in the correct currency format.

## Story 5 - Display Order

Shows the order information to the user.

### Description

Add a menu option to display the existing order. The order information includes the order options, price for each one and the total price. Prices are shown in correct currency format.

For example.

```
Medium Pizza     $6.25
Take Out   
Meats
   Bacon         $0.75
   Ham           $0.75
Vegetables
   Onions        $0.50
Sauce
   Traditional   
-----------------------
Total            $8.25
```

*Note: Create a function to do this since it is needed in several places.*
*Note: To format numeric values as price use the currency format `price.ToString("C")`.*
*Note: Prices can change. Consider declaring the price information as constants.*

### Acceptance Criteria

1. All order information is shown and correct.
1. Order total is correct.
1. Prices are shown in the correct currency format.

## Story 6 - Modify Order

Allows the user to modify an existing order.

### Description

Add a menu option to modify an existing order. If there is no existing order then an error is displayed.

The user is sent through the order process again. Any existing selections are left intact. Currently selected options are marked as selected to indicate to the user their previous choice. After the order is modified the order is displayed again.

*Note: To determine if there is an existing order rely on one of the variables that would have been set earlier (e.g. size).*

### Acceptance Criteria

1. If there is no existing order then display an error and return to main menu.
1. If there is an order then send the user back through the order process again. Each existing selection is shown and user can change the selection.
1. After order is finished the order is displayed as before.

## Console Help 

[Console.WriteLine](https://docs.microsoft.com/en-us/dotnet/api/system.console.writeline) can be used to write a line of text with a newline.

[Console.ReadLine](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline) can be used to read an entire line input.

[Console.ReadKey](https://docs.microsoft.com/en-us/dotnet/api/system.console.readkey) can be used to read a single key and, optional, not display it to the user. When using this method note that you have to use the [Key](https://docs.microsoft.com/en-us/dotnet/api/system.consolekeyinfo.key) property of the return value to get the actual key pressed.

Output can be colored for emphasis using the [Console.ForegroundColor](https://docs.microsoft.com/en-us/dotnet/api/system.console.foregroundcolor) and [Console.BackgroundColor](https://docs.microsoft.com/en-us/dotnet/api/system.console.backgroundcolor) values. If changing the color then be sure to reset the colors using [Console.ResetColor](https://docs.microsoft.com/en-us/dotnet/api/system.console.resetcolor).

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.