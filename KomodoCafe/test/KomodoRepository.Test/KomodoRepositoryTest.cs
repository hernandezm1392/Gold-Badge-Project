using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


    public class KomodoRepositoryTest
    {
        private readonly MenuRepository _mRepo;
        private Menu _menu;
        
        public MenuRepository()
        {
        _mRepo = new MenuRepository();
        _menu = new Menu(5, "Chicken Salad","beautiful hand tossed salad with tomatoes, crutons, and your favorite sauce" 9.00);
        _mRepo.AddMenuItemToDB(_menu);
        }

        [Fact]
        public void AddMenuItemToDB_ShouldReturnTrue()
        {
            var menuItem = new Menu(5, "Chicken Salad","beautiful hand tossed salad with tomatoes, crutons, and your favorite sauce" 9.00);
            var expectingTrue = _mRepo.AddMenuItemToDB(menuItem);
            Assert.True(expectingTrue);
        }
    }