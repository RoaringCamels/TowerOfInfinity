using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class LevelUpSubtract : BaseReward
{
    
    public override void Reward()
    {
        WeaponHandler.Instance.weapons[0].LevelUp();
        RewardManager.Instance.DisableRewardMenu();
        print("Button clicked");
    }



    
}
