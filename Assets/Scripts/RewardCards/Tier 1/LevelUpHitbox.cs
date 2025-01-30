using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class LevelUpHitbox :  BaseReward
{
    public GameObject weaponHitbox;
    public float hitboxScaleAmount;
    void Awake()
    {
        weaponHitbox = GameObject.Find("SubtractHitbox");
    }

    public override void Reward()
    {
        weaponHitbox.transform.localScale = new Vector3(weaponHitbox.transform.localScale.x * hitboxScaleAmount, weaponHitbox.transform.localScale.x * hitboxScaleAmount, 1 );
        RewardManager.Instance.DisableRewardMenu();
    }



    
}
