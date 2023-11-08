using MagicVilla_CouponAPI.Models;

namespace MagicVilla_CouponAPI.Data
{
    public class CouponStore
    {
        public static List<Coupon> couponList = new List<Coupon>
        {
            new Coupon{Id=1, Name="10oFF", Percent=10, IsActive=true },
            new Coupon{Id=2, Name="20oFF", Percent=20, IsActive= false},
            new Coupon{Id=3, Name="30oFF", Percent=30, IsActive= true}
        };
    }
}
