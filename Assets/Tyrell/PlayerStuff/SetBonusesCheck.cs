using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBonusesCheck : MonoBehaviour
{
    public Upgradeables upgrades;

    [Header("Set Bonuses")]
    public SetBonuses _ArmorPiercer;
    bool _armorPierceSet = false;
    public SetBonuses _MegaRicochet;
    bool _megaRicochetSet = false;
    public SetBonuses _ExplosionMagnet;
    bool _explosionMagnetSet = false;
    public SetBonuses _Seeking;
    bool _seekingSet = false;


    private void Update()
    {
        //Armor Pierce set bonus
        if (upgrades.PierceUpgraded >= 2 &&_armorPierceSet == false)
        {
            _ArmorPiercer.setComplete();
            _armorPierceSet = true;
        }
        else if (upgrades.PierceUpgraded < 2 && _armorPierceSet == true)
        {
            _ArmorPiercer.setRemoved();
            _armorPierceSet = false;
        }

        //Mega Ricochet Set Bonus
        if(upgrades.RicochetUpgraded >= 2 && upgrades.ProDamageUpgraded >=1
            && upgrades.ProSpeedUpgraded >= 1 && _megaRicochetSet == false)
        {
            _MegaRicochet.setComplete();
            _megaRicochetSet = true;
        }
        else if ((upgrades.RicochetUpgraded < 2 || upgrades.ProDamageUpgraded < 1
            || upgrades.ProSpeedUpgraded < 1) && _megaRicochetSet == true)
        {
            _MegaRicochet.setRemoved();
            _megaRicochetSet = false;
        }

        //Explosion Magnet set bonus
        if (upgrades.ExplosionUpgraded >= 4 &&  _explosionMagnetSet == false)
        {
            _ExplosionMagnet.setComplete();
            _explosionMagnetSet = true;
        }
        else if (upgrades.ExplosionUpgraded < 4 && _explosionMagnetSet == true)
        {
            _ExplosionMagnet.setRemoved();
            _explosionMagnetSet = false;
        }

        //Seeking Set Bonus
        if(upgrades.ExplosionUpgraded >= 1 && upgrades.ProSpeedUpgraded >= 2 && _seekingSet == false)
        {
            _Seeking.setComplete();
            _seekingSet = true;
        }
        else if(upgrades.ExplosionUpgraded < 1 && upgrades.ProSpeedUpgraded < 2 && _seekingSet == true)
        {
            _Seeking.setRemoved();
            _seekingSet = false;
        }


    }


}
