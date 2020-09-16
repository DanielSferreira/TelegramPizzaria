using Models;
namespace Services.MakeOrder
{
    public class OrderCombo
    {
        private ContextDb db;
        public double id_user {get; set;}
        public string combo_name {get; set;}
        public string Address {get; set;}
        public System.DateTime Data {get; set;}
        public OrderCombo()
        {
            db = new ContextDb();
        }

        public void addNewOrderCombo()
        {
            db.orders.Add(new Models.Data.Orders()
            {
                UserID = id_user,
                ComboNameReference = combo_name,
                Address = Address,
                DateOrder = Data
            });

            db.SaveChanges();
        }
    }
}