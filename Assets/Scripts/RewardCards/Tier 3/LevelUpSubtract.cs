using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class LevelUpSubtract : MonoBehaviour, IReward
{
    public Image buttonIcon;
    public TMP_Text descriptionText;

    [SerializeField]
    private Sprite icon;

    
    public Sprite Icon 
    { 
        get => icon; 
        set => icon = value; 
    }


    [SerializeField]
    private string description;
    public string Description 
    { 
        get => description; 
        set => description = value; 
    }

    public void Reward()
    {
        WeaponHandler.Instance.weapons[0].LevelUp();
    }

    public void Start()
    {
        descriptionText.text = Description;
        buttonIcon.sprite = Icon;
    }


    
}
