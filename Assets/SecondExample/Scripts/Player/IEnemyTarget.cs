using UnityEngine;

public interface IEnemyTarget: IDamagable
{
    Vector3 Position { get; }
}
