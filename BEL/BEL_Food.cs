using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_Food
    {
        private string foodName;
        private int idCategory;
        private float price;
        private string status;

        public BEL_Food()
        {
            this.foodName = "Chưa đặt tên";
            this.idCategory = 0;
            this.price = 0;
            this.status = "True";
        }
        public BEL_Food (string foodName, int idCategory, float price, string status)
        {
            this.foodName = foodName;
            this.idCategory = idCategory;
            this.price = price;
            this.status = status;
        }
        public string FoodName
        {
            get { return this.foodName; }
            set { this.foodName = value; }
        }
        public int IDCategory
        {
            get { return this.idCategory; }
            set { this.idCategory = value; }
        }
        public float Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
    }
}
