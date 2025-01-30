using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Levelup2subtract : BaseReward
{
   
    public override void Reward()
    {
        WeaponHandler.Instance.weapons[0].LevelUp(2);
        RewardManager.Instance.DisableRewardMenu();
    }

    

    
}
