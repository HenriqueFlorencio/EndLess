using System;

namespace End.Less.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime DataStamp { get; set; } = DateTime.Now;
    }
}
