using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class LevelUpHitbox : MonoBehaviour, IReward
{
    [Header("Settings")]
    public float hitboxScaleAmount;
    [SerializeField]private string description;

    [Header("References")]
    public Image buttonIcon;
    public TMP_Text descriptionText;
    [HideInInspector]public GameObject weaponHitbox;

    [SerializeField]
    private Sprite icon;

    
    public Sprite Icon 
    { 
        get => icon; 
        set => icon = value; 
    }


    
    
    public string Description 
    { 
        get => description; 
        set => description = value; 
    }

    void Awake()
    {
        weaponHitbox = GameObject.Find("SubtractHitbox");
    }

    public void Reward()
    {
        weaponHitbox.transform.localScale = new Vector3(weaponHitbox.transform.localScale.x * hitboxScaleAmount, weaponHitbox.transform.localScale.x * hitboxScaleAmount, 1 );
        RewardManager.Instance.DisableRewardMenu();
    }

    public void Start()
    {
        descriptionText.text = Description;
        buttonIcon.sprite = Icon;
    }


    
}
