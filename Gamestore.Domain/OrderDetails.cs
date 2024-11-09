using Gamestore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain;

public class OrderDetails : BaseEntity
{
    [ForeignKey(nameof(Game))]
    public Guid GameId { get; set; }

    public Game? Game { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public decimal Discount { get; set; }
}
