using System;
using System.Collections.Generic;
namespace Models.Data
{
    public class OrdersCompleted : Entity
    {
        public int OrdersCompletedId {get;set;}
        public double UserID {get;set;}
        public string ComboNameReference {get;set;}
        public string Address {get;set;}
        public DateTime DateOrder {get;set;}

        
    }
}