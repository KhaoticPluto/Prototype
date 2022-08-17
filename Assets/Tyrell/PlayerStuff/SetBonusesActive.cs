using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBonusesActive : MonoBehaviour
{
    #region singleton
    public static SetBonusesActive instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public Upgradeables upgrade;



    public void OnSetComplete(BonusType bonusType, float amount)
    {

        switch (bonusType)
        {
            case BonusType.ArmorPiercer:
                ArmorPiercer(amount);
                break;

            case BonusType.MegaRicochet:
                MegaRicochet(amount);
                break;

            case BonusType.ExplosiveMagnet:
                ExplosionMagnet(amount);
                break;

            case BonusType.Seeking:
                Seeking();
                break;
        }
        
    }

    public void OnSetRemoved(BonusType bonusType, float amount)
    {
        switch (bonusType)
        {
            case BonusType.ArmorPiercer:
                RemoveArmorPiercer(amount);
                break;

            case BonusType.MegaRicochet:
                RemoveMegaRicochet(amount);
                break;

            case BonusType.ExplosiveMagnet:
                RemoveExplosionMagnet(amount);
                break;

            case BonusType.Seeking:
                RemoveSeeking();
                break;
        }

    }

    public void ArmorPiercer(float amount)
    {
        upgrade.ArmorPiercer = true;
        upgrade.PierceCountUpgraded += amount;
    }
    public void RemoveArmorPiercer(float amount)
    {
        upgrade.ArmorPiercer = false;
        upgrade.PierceCountUpgraded -= amount;
    }

    public void MegaRicochet(float amount)
    {
        Debug.Log("Mega Ricochet");
        upgrade.MegaRicochet = true;
        upgrade.ricochetCountUpgraded += (int)amount;
    }
    public void RemoveMegaRicochet(float amount)
    {
        Debug.Log("Mega Ricochet Removed");
        upgrade.MegaRicochet = false;
        upgrade.ricochetCountUpgraded -= (int)amount;
    }

    public void ExplosionMagnet(float amount)
    {
        Debug.Log("Explosive Magnet");
        upgrade.ExplosionMagnet = true;
        upgrade.ExplosionArea += (int)amount;
    }
    public void RemoveExplosionMagnet(float amount)
    {
        Debug.Log("Explosive Magnet Removed");
        upgrade.ExplosionMagnet = false;
        upgrade.ExplosionArea -= (int)amount;
    }

    public void Seeking()
    {
        Debug.Log("Seeking");
        upgrade.Seeking = true;
    }
    public void RemoveSeeking()
    {
        Debug.Log("Removed Seeking");
        upgrade.Seeking = false;
    }


}
