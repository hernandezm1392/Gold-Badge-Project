using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    private readonly MenuRepository _mRepo = new MenuRepository();

    public void Run()
    {
        SeedData();
        RunApplication();
    }

    private void SeedData()
    {
        Menu item1 = new Menu (1, "Oldy", "overdone Pizza", "dough, pizza sauce, sausage, peperoni, cheese", 22.50);
        Menu item2 = new Menu (2, "Cheese Basket", "cheese platter with items", "cheese sticks, cheese curds, provolone slices, cheese fondoo", 10.50);

        _mRepo.AddMenuItemToDB(item1);
        _mRepo.AddMenuItemToDB(item2);

    }

    public void RunApplication()
    {
        bool isRunning = true;

        while(isRunning)
        {
            Console.Clear();

            System.Console.WriteLine("\tKomodo Cafe \n" +
            "===================== \n" +
            "Please make a selection: \n" +
            "1. Add a Menu Item \n" +
            "2. Delete a Menu Item \n" +
            "3. See All Menu Items \n" +
            "===================== \n" +
            "X. Close Application");

            string userInput = Console.ReadLine();

            switch(userInput.ToLower())
            {
                case "1":
                    AddMenuItem();
                    break;
                case "2":
                    DeleteMenuItem();
                    break;
                case "3":
                    ViewAllMenuItems();
                    break;
                case "x":
                    CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    break;
                
            }
        }
    }

    private void AddMenuItem()
    {
        Console.Clear();
        Menu menuItem = new Menu();

        System.Console.WriteLine("Enter a name for your Menu Item: ");
        menuItem.MealName = Console.ReadLine();

        System.Console.WriteLine("Enter a description for your Menu Item: ");
        menuItem.Description = Console.ReadLine();

        System.Console.WriteLine("Enter the ingredients for your Menu Item: ");
        menuItem.Ingredients = Console.ReadLine();

        System.Console.WriteLine("Enter the price for your Menu Item: ");
        menuItem.Price = double.Parse(Console.ReadLine());

        bool isSuccessful = _mRepo.AddMenuItemToDB(menuItem);
        if(isSuccessful)
        {
            System.Console.WriteLine($"Your Menu Item named {menuItem.MealName} has been added!");
        }
        else
        {
            System.Console.WriteLine("Your Menu Item was not added to the database.");
        }

        PressAnyKey();
    }

    private void ViewAllMenuItems()
    {
        Console.Clear();

        System.Console.WriteLine("***Current Menu Items***");
        var menuItemsInDB = _mRepo.GetAllMenuItems();
        foreach(Menu m in menuItemsInDB)
        {
            DisplayCurrentMenuItems(m);
        }

        PressAnyKey();
    }

    private void DisplayCurrentMenuItems(Menu menu)
    {
        System.Console.WriteLine($"Menu Item Number: {menu.MealNumber} \nMenu Item Name: {menu.MealName} \nDescription: {menu.Description} \nIngredients: {menu.Ingredients} \nPrice: {menu.Price} \n");
    }

    private void DeleteMenuItem()
    {
        Console.Clear();

        System.Console.WriteLine("***Remove Menu Item***");
        var menuItems = _mRepo.GetAllMenuItems();
        foreach(Menu m in menuItems)
        {
            DisplayCurrentMenuItems(m);
        }

        try
        {
            System.Console.WriteLine("Please select an item by their number: \n");
            int selectedItem = int.Parse(Console.ReadLine());
            bool isSuccessful = _mRepo.RemoveMenuItemFromDB(selectedItem);
            
            if(isSuccessful)
            {
                System.Console.WriteLine("Menu Item was removed!");
            }
            else
            {
                System.Console.WriteLine("Menu Item could not be removed at this time.");
            }
        }
        catch
        {
            System.Console.WriteLine("Invalid");
        }

        PressAnyKey();
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press a key to continue...");
        Console.ReadLine();
    }

    private void CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Please come again!");
        PressAnyKey();
        Environment.Exit(0);
    }
}