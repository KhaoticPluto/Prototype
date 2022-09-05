using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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



    public void OnSetComplete(BonusType bonusType, float amount )
    {

        switch (bonusType)
        {
            case BonusType.ArmorPiercer:
                ArmorPiercer(amount);
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.MegaRicochet:
                MegaRicochet(amount);
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.ExplosiveMagnet:
                ExplosionMagnet(amount);
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.Seeking:
                Seeking();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.LifeSteal:
                LifeSteal();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.UltraFreeze:
                UltraFreeze(amount);
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;
        }
        
    }

    public void OnSetRemoved(BonusType bonusType, float amount  )
    {
        switch (bonusType)
        {
            case BonusType.ArmorPiercer:
                RemoveArmorPiercer(amount);
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.MegaRicochet:
                RemoveMegaRicochet(amount);
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.ExplosiveMagnet:
                RemoveExplosionMagnet(amount);
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.Seeking:
                RemoveSeeking();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.LifeSteal:
                RemoveLifeSteal();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.UltraFreeze:
                RemoveUltraFreeze(amount);
                SetBonusUI.instance.RemoveSetIcon(bonusType);
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

    public void LifeSteal()
    {
        Debug.Log("Life Steal");
        upgrade.LifeSteal = true;
        
    }
    public void RemoveLifeSteal()
    {
        Debug.Log("Remove Life Steal");
        upgrade.LifeSteal = false;
        
    }

    public void UltraFreeze(float amount)
    {
        Debug.Log("Ultra freeze");
        upgrade.UltraFreeze = true;
        upgrade.FreezeTime += amount;
        
    }
    public void RemoveUltraFreeze(float amount)
    {
        Debug.Log("Remove Ultra freeze");
        upgrade.UltraFreeze = false;
        upgrade.FreezeTime -= amount;
        
    }


}
