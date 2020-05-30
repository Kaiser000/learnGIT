using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace todoapi.Model{

  /**
   **/
  public class Order:IComparable<Order>{

    [Key]
    public string Id { get; set; }

    public string Customer { get; set; }
    
    public DateTime CreateTime { get; set; }

    public List<OrderItem> Items { get; set; }



    public Order() {
      Id = Guid.NewGuid().ToString();
      Items = new List<OrderItem>();
      CreateTime = DateTime.Now;
    }

    public Order(List<OrderItem> items):this() {
      this.CreateTime = DateTime.Now;
      if (items != null) Items = items;
    }

    public double TotalPrice {
      get =>Items==null?0: Items.Sum(item => item.Number*item.totalPrice);
    }

    public void AddItem(OrderItem orderItem) {
      if(Items.Contains(orderItem))
        throw new ApplicationException($"添加错误：订单项已经存在!");
      Items.Add(orderItem);
    }

    public void RemoveItem(OrderItem orderItem) {
      Items.Remove(orderItem);
    }


    public override bool Equals(object obj) {
      var order = obj as Order;
      return order != null &&
             Id == order.Id;
    }

    public override int GetHashCode() {
      var hashCode = -531220479;
      hashCode = hashCode * -1521134295 + Id.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Customer);
      hashCode = hashCode * -1521134295 + CreateTime.GetHashCode();
      return hashCode;
    }

    public int CompareTo(Order other) {
      if (other == null) return 1;
      return this.Id.CompareTo(other.Id);
    }
  }
}