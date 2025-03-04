﻿namespace Nexion.Application.Dtos;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Employee definition
/// </summary>
public class EmployeeDto
{
    /// <summary>
    /// the Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// the Name
    /// </summary>
    [Required]
    public string? Name { get; init; }

    /// <summary>
    /// the Surname
    /// </summary>
    [Required]
    public string? Surname { get; init; }

    /// <summary>
    /// the Mail
    /// </summary>
    [Required]
    public string? Mail { get; init; }
}