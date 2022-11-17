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
    public class BAL_Food
    {
        public DataTable showFood()
        {
            DAL_Food showFood = new DAL_Food();
            return showFood.showFood();
        }
        public DataTable loadFood(int idCategory)
        {
            DAL_Food loadFood = new DAL_Food();
            return loadFood.loadFood(idCategory);
        }
        public int getID(string FName)
        {
            DAL_Food getID = new DAL_Food();
            return getID.getID(FName);
        }
        public bool addFood(BEL_Food food)
        {
            DAL_Food add = new DAL_Food();
            return add.addFood(food);
        }
        public bool updateFood(BEL_Food food, int idFood)
        {
            DAL_Food update = new DAL_Food();
            return update.updateFood(food, idFood);
        }
        public bool deleteFood(int idFood)
        {
            DAL_Food delete = new DAL_Food();
            return delete.deleteFood(idFood);
        }
        public DataTable searchFood(string nameFood)
        {
            DAL_Food search = new DAL_Food();
            return search.searchFood(nameFood);
        }
    }
}
