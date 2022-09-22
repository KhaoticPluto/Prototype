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
                ArmorPiercer();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.MegaRicochet:
                MegaRicochet();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;

            case BonusType.ExplosiveMagnet:
                ExplosionMagnet();
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
                UltraFreeze();
                SetBonusUI.instance.CompleteSetIcon(bonusType);
                break;
        }
        
    }

    public void OnSetRemoved(BonusType bonusType, float amount  )
    {
        switch (bonusType)
        {
            case BonusType.ArmorPiercer:
                RemoveArmorPiercer();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.MegaRicochet:
                RemoveMegaRicochet();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;

            case BonusType.ExplosiveMagnet:
                RemoveExplosionMagnet();
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
                RemoveUltraFreeze();
                SetBonusUI.instance.RemoveSetIcon(bonusType);
                break;
        }

    }

    public void ArmorPiercer()
    {
        upgrade.ArmorPiercer = true;
        
    }
    public void RemoveArmorPiercer()
    {
        upgrade.ArmorPiercer = false;
        
    }

    public void MegaRicochet()
    {
        Debug.Log("Mega Ricochet");
        upgrade.MegaRicochet = true;
        
    }
    public void RemoveMegaRicochet()
    {
        Debug.Log("Mega Ricochet Removed");
        upgrade.MegaRicochet = false;
        
    }

    public void ExplosionMagnet()
    {
        Debug.Log("Explosive Magnet");
        upgrade.ExplosionMagnet = true;
        
    }
    public void RemoveExplosionMagnet()
    {
        Debug.Log("Explosive Magnet Removed");
        upgrade.ExplosionMagnet = false;
        
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

    public void UltraFreeze()
    {
        Debug.Log("Ultra freeze");
        upgrade.UltraFreeze = true;
        
    }
    public void RemoveUltraFreeze()
    {
        Debug.Log("Remove Ultra freeze");
        upgrade.UltraFreeze = false;
        
    }


}
