using DataAccesLayer;
using DataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MenuItemBusiness
    {
        private readonly MenuItemRepository menuItemRepository;

        public MenuItemBusiness()
        {
            this.menuItemRepository = new MenuItemRepository();
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return this.menuItemRepository.GetAllMenuItems();
        }

        public bool InsertMenuItem(MenuItem mi)
        {
            if (this.menuItemRepository.InsertMenuItem(mi) > 0)
                return true;
            return false;
        }

        public bool UpdateMenuItem(MenuItem mi,int id)
        {
            if (this.menuItemRepository.UpdateMenuItem(mi,id) > 0)
                return true;
            return false;
        }

        public List<MenuItem> GetAllMenuItemsIB(decimal min, decimal max)
        {
            return this.menuItemRepository.GetAllMenuItems().Where(mi => mi.Price > min && mi.Price < max).ToList();
        }
    }
}
