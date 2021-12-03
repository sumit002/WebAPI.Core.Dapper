﻿using Microsoft.EntityFrameworkCore;

namespace Core.WebApi.Dapper.Business.DataContext
{
    public class AppContext : DbContext
    {
        public AppContext() { }
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
    }
}
