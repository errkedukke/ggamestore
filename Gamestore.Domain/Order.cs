using Gamestore.Domain.Common;
using Gamestore.Domain.Enums;

namespace Gamestore.Domain;

public class Order : BaseEntity
{
    public User? Customer { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public decimal Sum { get; set; }
}
