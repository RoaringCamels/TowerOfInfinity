using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReward
{
    Sprite Icon {
        get; set;
    }

    string Description {
        get; set; 
    }

    void Reward();
    void Start();
}
