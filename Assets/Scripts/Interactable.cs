using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum function
    {
        Inventory,
        Viewable,
    }

    public string entityName;
    public string description;
     public int Id;
    [SerializeField] private AnimationClip actionAnimation;

}
