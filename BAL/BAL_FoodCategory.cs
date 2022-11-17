using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BEL;

namespace BAL
{
    public class BAL_FoodCategory
    {
        public DataTable loadCategory()
        {
            DAL_FoodCategory loadCategory = new DAL_FoodCategory();
            return loadCategory.loadCategory();
        }
        public int getIDCategory(string FCName)
        {
            DAL_FoodCategory getID = new DAL_FoodCategory();
            return getID.getIDCategory(FCName);
        }
        public bool addCategory(BEL_FoodCategory category)
        {
            DAL_FoodCategory addCategory = new DAL_FoodCategory();
            return addCategory.addCategory(category);
        }
        public bool updateCategory(BEL_FoodCategory category, int ID)
        {
            DAL_FoodCategory updateC = new DAL_FoodCategory();
            return updateC.updateCategory(category, ID);
        }
        public bool deleteCategory(int IDCategory)
        {
            DAL_FoodCategory deleteC = new DAL_FoodCategory();
            return deleteC.deleteCategory(IDCategory);
        }
    }
}
