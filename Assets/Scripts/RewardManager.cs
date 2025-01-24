using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static RewardManager Instance;
    public GameObject rewardMenu;
    public int count;

    public bool rewardIsUp = false;

    [Header("Tier 3 Rewards")]
    public int tier3Wieght;
    public GameObject[] tier3Rewards;
    [Header("Tier 2 Rewards")]
    public int tier2Wieght;
    public GameObject[] tier2Rewards;
    [Header("Tier 1 Rewards")]
    public int tier1Wieght;
    public GameObject[] tier1Rewards;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void EnemyKilled()
    {
        if(!rewardIsUp)
        {
            rewardIsUp = true;
            EnableRewardMenu();
           
        }
        else{
            count++;
        }
    }


    public void EnableRewardMenu()
    {
        for(int i=0; i<3; i++)
        {
            GameObject curr= Instantiate(GenerateRewardCard());
            curr.transform.SetParent(rewardMenu.transform);
        }
        rewardMenu.SetActive(true);
    }

    public void DisableRewardMenu()
    {
        rewardMenu.SetActive(false);
        rewardIsUp = false;
        if(count > 0)
        {
            count--;
            EnemyKilled();
        }
    }

    private GameObject GenerateRewardCard()
    {
        int random = Random.Range(0, tier3Wieght+tier2Wieght+tier1Wieght);
        if(random< tier3Wieght)
        {
            return tier3Rewards[Random.Range(0, tier3Rewards.Count())];
        }
        else if(random< tier3Wieght +tier2Wieght)
        {
            return tier3Rewards[Random.Range(0, tier3Rewards.Count())];
        }
        else //tier 1
        {
            return tier3Rewards[Random.Range(0, tier3Rewards.Count())];
        }
    }
    ///reward menu prefab
    ///when you instaniate it, it chooses the cards randomly
    /// counter of how many rewards there are currently
    /// when disabled, if count is not zero, do it again


}
