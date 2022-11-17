using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BEL_FoodCategory
    {
        private string foodCName;
        private string status;

        public BEL_FoodCategory()
        {
            this.foodCName = "Chưa đặt tên";
            this.status = "True";
        }
        public BEL_FoodCategory(string foodCName, string status)
        {
            this.foodCName = foodCName;
            this.status = status;
        }
        public string FoodCName
        {
            get { return this.foodCName; }
            set { this.foodCName = value; }
        }
        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
    }
}
