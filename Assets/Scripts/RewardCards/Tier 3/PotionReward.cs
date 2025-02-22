using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionReward : BaseReward
{
    public string potionValue;
    public override void Reward()
    {
        PlayerHealth.instance.GetPotion(potionValue);
        RewardManager.Instance.DisableRewardMenu();
    }
}
