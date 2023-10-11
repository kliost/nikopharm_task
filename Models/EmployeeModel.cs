using System;
using System.ComponentModel.DataAnnotations;

public class EmployeeModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле FirstName є обов'язковим")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "FirstName має містити від 2 до 50 символів")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Поле LastName є обов'язковим")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "LastName має містити від 2 до 50 символів")]
    public string? LastName { get; set; }

    public string? Patronimyc { get; set; }

    [Required(ErrorMessage = "Поле Birthday є обов'язковим")]
    public DateTime Birthday { get; set; }

    [Required(ErrorMessage = "Поле Department є обов'язковим")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Department має містити від 2 до 100 символів")]
    public string? Department { get; set; }

    [Required(ErrorMessage = "Поле Position є обов'язковим")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Position має містити від 2 до 100 символів")]
    public string? Position { get; set; }

    [Required(ErrorMessage = "Поле Salary є обов'язковим")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Salary має бути більшою або рівною 0.01")]
    public decimal Salary { get; set; }
}

