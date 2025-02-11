namespace Calculator.Domain.Entities;

/// <summary>
/// Result data!!!
/// </summary>
public class ReturnEntity
{
    /// <summary>
    /// First number
    /// </summary>
    public double First { get; set; }

    /// <summary>
    /// Operation (add/sub/mult/div)
    /// </summary>
    public string Operation { get; set; } = string.Empty;
    
    /// <summary>
    /// Second number
    /// </summary>
    public double Second { get; set; }
    
    /// <summary>
    /// Result
    /// </summary>
    public double Result { get; set; }
}