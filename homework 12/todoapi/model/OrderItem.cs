using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoapi.Model {

  /**
   **/
  public class OrderItem {

    [Key]
    public string Id { get; set; }

    public String Name { get;set; }

    public double totalPrice { get;set; }

    public string OrderId { get; set; }

    public int Number { get; set; }

    public OrderItem() {
      Id = Guid.NewGuid().ToString();
    }

    public OrderItem(int quantity) : this() {
      this.Number = quantity;
    }


    public override bool Equals(object obj) {
      var item = obj as OrderItem;
      return item != null &&
             Name == item.Name;
    }

    public override int GetHashCode() {
      var hashCode = -2127770830;
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
      hashCode = hashCode * -1521134295 + Number.GetHashCode();
      return hashCode;
    }
  }
}