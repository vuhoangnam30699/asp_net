
namespace ShoppingCart.Models
{
    public class MobileDetails
    {
        public int Id { get; set; }

        public int? MobileId { get; set; }

        public string? Features { get; set; }

        public string? Model { get; set; }

        public string? Color { get; set; }

        public string? SimType { get; set; }

        public virtual Mobiles? Mobile { get; set; }
    }
}
