using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class WeaponTypes : MonoBehaviour
{
    public enum WeaponType
    {
        Pistol,
        Shotgun,
        Assault_Rifle,
        Sniper_Rifle,
    }

    public static float GetDefaultWeaponDamage(WeaponType type)
    {
        //TODO Implement shotgun damage based on distance
        switch (type)
        {
            case WeaponType.Pistol:
                return 10f;
            case WeaponType.Assault_Rifle:
                return 10f;
            case WeaponType.Sniper_Rifle:
                return 80f;
            default:
                return 5f;
        }
    }
}
