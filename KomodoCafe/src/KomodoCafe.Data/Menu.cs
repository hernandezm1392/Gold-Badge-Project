
public class Menu
{
    public Menu(){}

    public Menu(
        int mealNumber,
        string mealName,
        string description,
        string ingredients,
        double price
    )
    {
        MealNumber = mealNumber;
        MealName = mealName;
        Description = description;
        Ingredients = ingredients;
        Price = price;
    }

    public int MealNumber { get; set; }
    public string MealName { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public double Price { get; set; }
}