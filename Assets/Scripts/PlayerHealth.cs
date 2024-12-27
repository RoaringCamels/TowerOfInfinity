using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    private TMP_Text healthText;
    public string health = "20";

    void Start()
    {
        healthText = GetComponentInChildren<TMP_Text>();
        healthText.text = health.ToString();
    }

    public void ChangeHealth(string attack)
    {
        ExpressionTree tree = new ExpressionTree();
        tree.BuildFromInfix(health+attack);
        tree.InorderTraversal();
        health = tree.Evaluate().ToString();
        UpdateHealth();
    }

    public void UpdateHealth(){
        if(health == "0") {
            Destroy(gameObject);
        } else {
            healthText.text = health;
        }
    }
}
