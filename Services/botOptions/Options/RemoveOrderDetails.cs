using System.Collections.Generic;
using Models;
using Models.Data;
using System.Linq;

namespace TelegramPizzaria.Services.botOptions.Options
{
    public class RemoveOrderDetails : IOption
    {
        private ContextDb db;
        public RemoveOrderDetails(int id)
        {
            db = new ContextDb();
            MessageComboText(id);
            OptionFromOrigin = (int)ButtonsTypes.Botoes;
            LabelQuestionCurrent = "Que bom! muito Obrigado pela preferência!";
            OptionQuestionCurrent = new List<string>() {
                "Voltar"
            };
        }
        public void MessageComboText(int id)
        {
            try
            {
                var x = db.orders.Where(xi => xi.OrdersId == id).FirstOrDefault();
                var rOrder = db.ordersCompleted.Add(new OrdersCompleted(){
                    OrdersCompletedId =  x.OrdersId,
                    UserID =  x.UserID,
                    ComboNameReference =  x.ComboNameReference,
                    Address =  x.Address,
                    DateOrder =  x.DateOrder
                });
                db.orders.Remove(x);
                db.SaveChanges(); 
            }
            catch (System.Exception)
            {
                return;
                throw;
            }


        }
    }
}