using MVC.Models.Database;
using MVC.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Carts
{
    [Serializable] //可序列化
    public class Cart : IEnumerable<CartItem> //購物車類別
    {
        //建構值
        public Cart()
        {
            this.cartItems = new List<CartItem>();
        }

        //儲存所有商品
        public List<CartItem> cartItems;

        //取得商品總價
        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount = 0.0m;
                foreach (var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;
                }
                return totalAmount;
            }
        }


        public bool AddProduct(int ProductId)
        {
            var findItem = this.cartItems
                            .Where(s => s.PSID == ProductId)
                            .Select(s => s)
                            .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(Models.Carts.CartItem))
            {   //不存在購物車內，則新增一筆
                using (Models.Database._1MVC1Model db = new _1MVC1Model())
                {
                    var product = (
                                   from ps in db.ProductSpecifications
                                   where ps.ProductSpecificationID == ProductId
                                   select new ChartViewModels
                                   {
                                       ProductSpecificationID = ps.ProductSpecificationID,
                                       ProductID = ps.ProductID,
                                       Price = ps.Price,
                                       Colour = ps.Colour,
                                       Image = ps.Image,
                                       ProductName = ps.Product.ProductName,
                                       Quantity = ps.Product.Quantity,
                                   }).FirstOrDefault();


                    if (product != default(ViewModels.ChartViewModels))
                    {
                        this.AddProduct(product);
                    }
                }
            }
            else
            {   //存在購物車內，則將商品數量累加
                findItem.Quantity += 1;
            }
            return true;
        }

        private bool AddProduct(ViewModels.ChartViewModels product)
        {
            //將Product轉為CartItem
            var cartItem = new Models.Carts.CartItem()
            {
                PSID = product.ProductSpecificationID,
                Id = product.ProductID,
                Name = product.ProductName,
                Price = product.Price,
                Image = product.Image,
                color = product.Colour,
                Quantity = 1
            };
            //加入CartItem至購物車
            this.cartItems.Add(cartItem);
            return true;
        }

        //移除一筆Product，使用ProductId
        public bool RemoveProduct(int ProductId)
        {
            var findItem = this.cartItems
                            .Where(s => s.PSID == ProductId)
                            .Select(s => s)
                            .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem == default(Models.Carts.CartItem))
            {
                //不存在購物車內，不需做任何動作
            }
            else
            {   //存在購物車內，將商品移除
                this.cartItems.Remove(findItem);
            }
            return true;
        }

        public bool SubQty(int ProductId)
        {
            var findItem = this.cartItems
                            .Where(s => s.PSID == ProductId)
                            .Select(s => s)
                            .FirstOrDefault();

            //判斷相同Id的CartItem是否已經存在購物車內
            if (findItem.Quantity == 1)
            {   //不存在購物車內，則新增一筆

                return RemoveProduct(ProductId);



            }
            else
            {   //存在購物車內，則將商品數量累加
                findItem.Quantity -= 1;
            }
            return true;
        }








        //清空購物車
        public bool ClearCart()
        {
            this.cartItems.Clear();
            return true;
        }


        public List<Models.Database.OrderDetail> ToOrderDetailList(int orderId)
        {
            var result = new List<Models.Database.OrderDetail>();
            foreach (var cartItem in this.cartItems)
            {
                result.Add(new Models.Database.OrderDetail()
                {
                    ProductSpecificationID = cartItem.PSID,
                    Price = cartItem.Price,
                    BuyQuantity = cartItem.Quantity,
                    OrderID = orderId
                });
            }
            return result;
        }
        IEnumerator<CartItem> IEnumerable<CartItem>.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        
    }
}