# cMenu
ConsoleApplication Menu C#


How to use:

Object: 

```c#static hMenuItemConfig v1 = new hMenuItemConfig();```

Add Items:

```C#[code]string[] itemsToAdd = {"Item1", "Item2", "Item3","Item4" };
            v1.AddItems(itemsToAdd);[/code]```


The loop to go through the menu:

```c#

while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        v1.DecrementList();
                        break;
                    case ConsoleKey.DownArrow:
                        v1.IncrementList();
                        break;
                    case ConsoleKey.Enter:
                        if (v1[v1.selectedItem] == itemsToAdd[0])
                        {
                            //code here when the selected item is "Item1"
                            Console.WriteLine("\n\nHiya pals");
                        }
                        break;
                }
            }
            ```
            
            
Events:
SelectionChange

```c#
v1.SelectionChange += v1_SelectionChange;
static void v1_SelectionChange(object sender, cMenu.Events.MenuItemChangedEventArgs e)
{
           
            v1.highLightText = colors[new Random().Next(0,colors.Length)];
}
```
