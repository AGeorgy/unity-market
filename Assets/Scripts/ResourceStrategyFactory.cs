
using System;
using System.Collections.Generic;
using Core;

public class ResourceStrategyFactory : IResourceStrategyFactory
{
    private Dictionary<Type, IResourceStrategy> _strategies;
    public ResourceStrategyFactory()
    {
        _strategies = new Dictionary<Type, IResourceStrategy>();
    }

    public void AddStrategy<T>(T strategy)
    where T : IResourceStrategy
    {
        _strategies.Add(typeof(T), strategy);
    }

    public IResourceStrategy GetStrategy<T>()
    {
        var type = typeof(T);
        if (!_strategies.ContainsKey(type))
        {
            throw new Exception($"No strategy for type {type}");
        }

        return _strategies[type];
    }
}