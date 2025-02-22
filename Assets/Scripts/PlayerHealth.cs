using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    private TMP_Text healthText;
    public string health = "20";
    public bool hasPotion;

    void Start()
    {
        healthText = GetComponentInChildren<TMP_Text>();
        healthText.text = health.ToString();
        hasPotion = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            if(hasPotion)
            {
                hasPotion = false;
            }
        }
    }
    public void ChangeHealth(string attack)
    {
        ExpressionTree tree = new ExpressionTree();
        tree.BuildFromInfix(health+attack);
        tree.InorderTraversal();
        health = tree.Evaluate().ToString();
        UpdateHealth();
    }

    //public void ChangePotion

    public void UpdateHealth(){
        if(health == "0") {
            Destroy(gameObject);
        } else {
            healthText.text = health;
        }
    }
}
