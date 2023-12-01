using UnityEngine;

public class AreaObjectChecker
{
    public bool CheckArea<ObjectType>(Vector3 point, float radius)
    {
        Collider2D[] objectsInArea = Physics2D.OverlapCircleAll(point, radius);

        foreach(Collider2D coll in objectsInArea)
        {
            if (coll.gameObject.TryGetComponent<ObjectType>(out ObjectType obj))
            {
                return true;
            }
        }
        return false;
    }
}