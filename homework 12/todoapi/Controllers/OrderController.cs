using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using todoapi.Model;

namespace todoapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class orderController : ControllerBase
    {
        private readonly OrderContext orderDb;

        public orderController(OrderContext context)
        {
            this.orderDb = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            var order = orderDb.Orders.FirstOrDefault(t => t.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        //按照id删除订单
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(t => t.Id == id);
                if (order != null)
                {
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

        //增加订单
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        //按照id给相应订单增加订单明细
        [HttpPost("item/{id}")]
        public ActionResult<OrderItem> PostOrderItem(OrderItem orderItem,string id)
        {
            try
            {
                orderItem.OrderId = id;
                var order = orderDb.Orders.FirstOrDefault(t => t.Id == id);
                order.Items.Add(orderItem);
                orderDb.OrderItems.Add(orderItem);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return orderItem;
        }

        //更该订单信息
        [HttpPut("{id}")]
        public ActionResult<Order> PutTodoItem(string id, OrderItem order)
        {
            if (id != order.Id)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        //查找订单
        [HttpGet("Query")]
        public ActionResult<List<Order>> queryTodoItem(string Id, string customer)
        {
            var query = buildQuery(Id, customer);
            return query.ToList();
        }

        private IQueryable<Order> buildQuery(string Id, string customer)
        {
            IQueryable<Order> query = orderDb.Orders;
            if (Id != null)
            {
                query = query.Where(t => t.Id.Contains(Id));
            }
            if (customer != null)
            {
                query = query.Where(t => t.Customer == customer);
            }
            return query;
        }

        //按照订单id获取订单明细
        [HttpGet("item/{id}")]
        public ActionResult<List<OrderItem>> GetOrderItem(string id)
        {
            var item = orderDb.OrderItems.Where(t=>t.OrderId == id);
            if (item == null)
            {
                return NotFound();
            }
            return item.ToList();
        }

        // 删除订单明细
        [HttpDelete("item/{OrderId}/{id}")]
        public ActionResult DeleteOrderItem(string id,string OrderId)
        {
            try
            {
                var item = orderDb.OrderItems.FirstOrDefault(t => t.Id == id);
                if (item != null)
                {
                    orderDb.Remove(item);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }


      

    }

}