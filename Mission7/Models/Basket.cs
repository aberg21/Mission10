using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mission7.Models
{
    public class Basket
    {
        public List<BasketLineItem> Carts { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Book boo, int qty)
        {
            BasketLineItem line = Carts
                .Where(b => b.Books.BookId == boo.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Carts.Add(new BasketLineItem
                {
                    Books = boo,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }


        public virtual void RemoveItem (Book boo)
        {
            Carts.RemoveAll(x => x.Books.BookId == boo.BookId);
        }

        public virtual void ClearBasket()
        {
            Carts.Clear();
        }



        public double CalculateTotal()
        {
            double sum = Carts.Sum(x => x.Quantity * x.Books.Price);

            return sum;
        }

    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Books { get; set; }
        public int Quantity { get; set; }
    }
}
