using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static RewardManager Instance;
    public GameObject rewardMenu;
    public int count;

    public bool rewardIsUp = false;

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

    public void AddCount()
    {
        count++;
        if(count == 0)
        {
            DisableRewardMenu();
        } 
        else
        {
            EnableRewardMenu();
            
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
    ///reward menu prefab
    ///when you instaniate it, it chooses the cards randomly
    /// counter of how many rewards there are currently
    /// when disabled, if count is not zero, do it again


}
