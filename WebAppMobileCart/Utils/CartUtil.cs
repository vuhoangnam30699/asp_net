using WebAppMobile.Models.DTOs;

namespace WebAppMobile.Utils
{
    public static class CartUtil
    {
        public static MobileItem CheckMobileItem(List<MobileItem> list, int slNo)
        {
            foreach(MobileItem item in list)
            {
                if (item.SlNo == slNo)
                    return item;
            }

            return null;
        }
    }
}
