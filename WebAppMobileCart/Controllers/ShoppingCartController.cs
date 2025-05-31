using Microsoft.AspNetCore.Mvc;
using WebAppMobile.Models;
using WebAppMobile.Models.DTOs;
using WebAppMobile.Utils;

namespace WebAppMobile.Controllers
{
    public class ShoppingCartController : Controller
    {
        MobileShoppingContext context = new MobileShoppingContext();
        public IActionResult Index()
        {
            //get Data from Session to show 

            return View( HttpContext.Session.GetObject<List<MobileItem>>("cart") );
        }

        public IActionResult AddToCart(Mobile mobile)
        {
            //Get Mobile detail from DB by slNo
            //Mobile? mobile = context.Mobiles.Find(SlNo);

            if (mobile != null)
            {
                if (HttpContext.Session.GetObject<List<MobileItem>>("cart") == null)
                {
                    List<MobileItem> li = new List<MobileItem>();

                    li.Add( new MobileItem() { SlNo = mobile.SlNo , mobile = mobile, quantity = 1 } ); //only 1 mobile

                    HttpContext.Session.SetObject("cart", li);
                    ViewBag.cart = li.Count();

                    HttpContext.Session.SetObject("count", 1);
                }
                else
                {
                    // Has Shpping cart
                    List<MobileItem> li = HttpContext.Session.GetObject<List<MobileItem>>("cart");

                    MobileItem mobileItem = CartUtil.CheckMobileItem(li, mobile.SlNo);
                    if ( mobileItem != null )
                    {
                        li.Remove(mobileItem);

                        li.Add(
                            new MobileItem() { SlNo = mobile.SlNo, mobile = mobile, quantity = ++mobileItem.quantity }
                        );
                    } 

                    HttpContext.Session.SetObject("cart", li);
                    //ViewBag.cart = li.Count();

                    HttpContext.Session.SetObject("count", li.Count());
                }
            }    

            return RedirectToAction("Index", "Mobiles");
        }


        public IActionResult Remove(int slNo)
        {
            var cart = HttpContext.Session.GetObject<List<MobileItem>>("cart");
            if (cart == null)
            {
                // Handle empty cart scenario
                return RedirectToAction("Index", "Mobiles");
            }

            var mobileItem = cart.Find(item => item.SlNo == slNo);
            if (mobileItem != null)
            {
                if (mobileItem.quantity > 1)
                {
                    // Decrease the quantity if it's more than 1
                    mobileItem.quantity--;
                }
                else
                {
                    // Remove the item from the cart if its quantity is 1
                    cart.Remove(mobileItem);
                }

                // Update session with the modified cart
                HttpContext.Session.SetObject("cart", cart);
                HttpContext.Session.SetInt32("count", cart.Count);
            }

            return RedirectToAction("Index");
        }


    }
}
