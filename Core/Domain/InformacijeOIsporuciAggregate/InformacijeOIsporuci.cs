﻿namespace Core.Domain.InformacijeOIsporuciAggregate
{
    public class InformacijeOIsporuci
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
}
