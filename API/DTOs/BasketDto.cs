using System;

namespace API.DTOs;

public class BasketDto
{
    public int Id { get; set; }
    public required string BasketId { get; set; }
    public required List<BasketItemDto> Items { get; set; }
}
