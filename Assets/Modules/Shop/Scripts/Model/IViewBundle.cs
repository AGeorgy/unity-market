using UnityEngine;

namespace Shop.Model
{
    public interface IViewBundle
    {
        string Name { get; }
        Color Color { get; }
    }
}