using UnityEngine;

public static class Extensions
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");

    public static bool Raycast(this Rigidbody2D rigidbody2D, Vector2 direction)
    {
        if (rigidbody2D.isKinematic)
        {
            return false;
        }

        float radius = 0.25f;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.CircleCast(rigidbody2D.position, radius, direction, distance, layerMask);
        
        return (hit.collider != null && hit.rigidbody != rigidbody2D);    
    }
}
