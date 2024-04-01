using UnityEngine;

public class GunTypes : MonoBehaviour
{
    public enum GunType
    {
        Pistol,
        Shotgun,
        Assault_Rifle,
        Sniper_Rifle,
    }

    public static float GetDefaultGunDamage(GunType type)
    {
        //TODO Implement shotgun damage based on distance
        switch (type)
        {
            case GunType.Pistol:
                return 10f;
            case GunType.Assault_Rifle:
                return 10f;
            case GunType.Sniper_Rifle:
                return 80f;
            default:
                return 5f;
        }
    }
}
