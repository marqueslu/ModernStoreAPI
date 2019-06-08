﻿using ModernStoreAPI.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Domain.Commands.Results
{
    public class GetProductListCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
