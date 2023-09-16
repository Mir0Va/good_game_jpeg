using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInsideCollider : MonoBehaviour
{
    [SerializeField] private LayerMask _wallLayer;
    [SerializeField] private PlayerDeath _playerdeath;
    [SerializeField] private CircleCollider2D _collider;

    void Update()
    {
        if (!_collider.isTrigger)
        {
            if(IsInsideWall())
            {
                _playerdeath.Die();
            }
        }
        
    }
    private bool IsInsideWall()
    {
        return Physics2D.OverlapCircle(transform.position, 0.1f, _wallLayer);
    }
}
