﻿using System.ComponentModel.DataAnnotations;

namespace TKMaster.Common.Application.DTO;

public abstract class FilterBaseDTO
{
    [Range(0, 2, ErrorMessage = "O valor do status é inválido.")]
    public int Status { get; set; } = 0;

    public int CurrentPage { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string OrderBy { get; set; } = "name";

    public string SortBy { get; set; } = "asc";
}