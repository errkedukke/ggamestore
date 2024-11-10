namespace Gamestore.Application.Features.OrdersDetails.Queries
{
    public class OrderDetailsDto
    {
        public Guid GameId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; } = 1;

        public decimal Discount { get; set; }
    }
}
