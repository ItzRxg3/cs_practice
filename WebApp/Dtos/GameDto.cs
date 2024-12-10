using System.ComponentModel.DataAnnotations;

namespace GameWebApplication.Dtos;

public class GameDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public decimal Amount { get; set; }
    public GameStatus Status { get; set; }
    public DateTime GameDate { get; set; }
}