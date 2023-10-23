using System;
using System.Collections.Generic;

namespace TaskTrendxAPI.Infrastructure.Repositories
{
    public partial class TaskTb
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool Completed { get; set; }
    }
}
