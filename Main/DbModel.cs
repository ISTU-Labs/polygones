using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;


namespace Main //создал контекст данных для взаимодействия с базой
{

    class BaseContext : DbContext
    {
        public BaseContext()
            : base("DB")
        { }

        public DbSet<Circle> Circle { get; set; }
        public DbSet<Polygon> Polygon { get; set; }
        public DbSet<Rectangle> Rectangle { get; set; }
    }

}