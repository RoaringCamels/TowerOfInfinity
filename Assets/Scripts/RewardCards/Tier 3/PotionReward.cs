using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionReward : BaseReward
{
    public string potionValue;
    public string ifHasPotionDescription;
    public string potionStrengthIncrease;

    void Start()
    {
        base.Start();
        if(PlayerHealth.instance.hasPotion)
        {
            descriptionText.text = ifHasPotionDescription;
        }

    }

    public override void Reward()
    {
        if(PlayerHealth.instance.hasPotion)
        {
            PlayerHealth.instance.ChangePotionHealth(potionStrengthIncrease);
        }
        else
        {
            PlayerHealth.instance.GetPotion(potionValue);
        }
        
        RewardManager.Instance.DisableRewardMenu();
    }
}
