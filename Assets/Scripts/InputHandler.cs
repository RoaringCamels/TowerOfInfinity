using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;
    
    public KeyCode actionKey = KeyCode.Space;
    public KeyCode levelKeyLeft;
    public KeyCode levelKeyRight;
    public KeyCode selectKeyLeft;
    public KeyCode selectKeyRight;
//     public KeyCode rightKey = KeyCode.RightArrow;

    public GameObject upgradeMenu;
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


    void Update()
    {
        if(upgradeMenu.activeSelf)
        {
            levelKeyLeft = KeyCode.F15;
            levelKeyRight = KeyCode.F15;
            selectKeyLeft = KeyCode.LeftArrow;
            selectKeyRight = KeyCode.RightArrow;
        }
        else
        {
            levelKeyLeft = KeyCode.LeftArrow;
            levelKeyRight = KeyCode.RightArrow;
            selectKeyLeft = KeyCode.F15;
            selectKeyRight = KeyCode.F15;
        }
    }
    

}
