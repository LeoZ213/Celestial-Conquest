using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(GunTypes.GunType gunType);

    void Damage(SwordTypes.SwordType swordType);
}
