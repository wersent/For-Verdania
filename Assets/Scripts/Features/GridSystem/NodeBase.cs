using System.Collections;
using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class NodeBase
{
    public List<NodeBase> Neighbors { get; protected set; } = new();
    public NodeBase Connection { get; private set; }
    public ICoords Coords;
    public float G { get; private set; }
    public float H { get; private set; }
    public float F => G + H;
    public int WalkPriority { get; set; }
    public float GetDistance(NodeBase other) => Coords.GetDistance(other.Coords);
    // добавить Walkable и что-то для обозначения приоритета поля

    public virtual void Init(int walkPriority, ICoords coords)
    {
        WalkPriority = walkPriority;

        Coords = coords;
    }

    public abstract void CacheNeighbors(Func<Vector2, NodeBase> getTileAtPosition);

    public void SetConnection(NodeBase nodeBase)
    {
        Connection = nodeBase;
    }

    public void SetG(float g)
    {
        G = g;
    }

    public void SetH(float h)
    {
        H = h;
    }
}

public interface ICoords
{
    public float GetDistance(ICoords other);
    public Vector2 Pos { get; set; }
}
