﻿using System;
using System.Globalization;
using System.Text;
using ExercícioProposto_EnumeraçõesEComposição_.Entities.Enum;
namespace ExercícioProposto_EnumeraçõesEComposição_.Entities
{
	public class Order
	{
		public DateTime Moment { get; set; }
		public OrderStatus Status { get; set; }
		public Client Client { get; set; }
		public List<OrderItem> Items { get; set; } = new List<OrderItem>();
       

        public Order()
		{ 
		}
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
            
        }

        public void AddItem(OrderItem item)
		{
            Items.Add(item);
		}
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
            
        }
        public double Total()
        {
            double total = 0;
            foreach (OrderItem items in Items)
            {
                total += items.SubTotal();
            }
            return total;
        }
             public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}

