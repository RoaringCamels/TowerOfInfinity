using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;
    
    public KeyCode actionKey = KeyCode.Space;
    public KeyCode levelKeyLeft;
    public KeyCode selectKeyLeft;
//     public KeyCode rightKey = KeyCode.RightArrow;

    public GameObject upgradeMenu;


    void Update()
    {
        if(upgradeMenu.activeSelf)
        {
            levelKeyLeft = KeyCode.F15;
            selectKeyLeft = KeyCode.LeftArrow;
        }
        else
        {
            levelKeyLeft = KeyCode.LeftArrow;
            selectKeyLeft = KeyCode.F15;
        }
    }
    

}
