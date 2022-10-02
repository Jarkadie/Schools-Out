using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : Interactable
{
    [SerializeField] private int keyID;
    public string lockedMessage = "Seems like it's locked.";

    [SerializeField] AnimationClip lockedAnimation;

    public void Unlock(){
        if(GameManager.keys.ContainsKey(keyID)){
            print("You Unlocked this!");
        }
        else{
            print(lockedMessage);
        }
    }

}
