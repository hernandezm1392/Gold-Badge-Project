
public class MenuRepository 
{
    private readonly List<Menu> _menuDatabase = new List<Menu>();
    private int _count = 0;
    public bool AddMenuItemToDB(Menu menuItem)
        {
            if(menuItem != null)
            {
                _count++;
                menuItem.MealNumber = _count;
                _menuDatabase.Add(menuItem);
                // Convert.ToString(menuItem.Price);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Menu> GetAllMenuItems()
        {
            return _menuDatabase;
        }

        public Menu GetMenuItemByNumber(int MealNumber)
        {
            foreach(Menu m in _menuDatabase) 
            {
                if(m.MealNumber == MealNumber)
                {
                    return m; 
                }
            }

            return null; 
        }

        public bool RemoveMenuItemFromDB(int mealNumber)
        {
            var menuItem = GetMenuItemByNumber(mealNumber);

            if(menuItem != null)
            {
                _menuDatabase.Remove(menuItem);
                return true;
            }
            else
            {
                return false;
            }
        }

}