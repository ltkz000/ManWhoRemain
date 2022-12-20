using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapon
{
    public override void OutOfRange()
    {
        if(_attacker != null)
        {
            float distance = Vector3.Distance(weaponTransform.position, lastPosition);

            if(distance > _attacker.attackRange - 1f)
            {
                isFlyback = true;
            }
        }
    }
}
