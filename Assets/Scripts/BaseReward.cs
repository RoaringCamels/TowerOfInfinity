using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "NewBaseReward", menuName = "UpgradeReward/NewReward")]
public abstract class BaseReward : MonoBehaviour
{

    [Header("UI References")]
    public Image buttonIcon;
    public TMP_Text descriptionText;

    [Header("Properties")]
    [SerializeField] private Sprite icon;
    [SerializeField] private string description;
    public string Description 
    { 
        get => description; 
        set => description = value; 
    }

    Sprite Icon {
        get; set;
    }

    [Header("Audio")]
    public AudioClip confirmSFX;
    public AudioMixerGroup UIamg;

    public void OnRewardSelected()
    {
        AudioManager.Instance.PlayOneShot(confirmSFX, 1f, UIamg);
        Reward();
    }

    public abstract void Reward();
    public void Start()
    {
        descriptionText.text = Description;
        buttonIcon.sprite = icon;
    }

}
