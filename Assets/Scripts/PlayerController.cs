using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera playerView;
    [SerializeField] private ToolTip toolTip;
    [SerializeField] private GameObject flashLight;
    [SerializeField] private float distanceToRegister;

    private RaycastHit hit;
    private bool onInteractable = false;
    private Interactable interactable;



    // Update is called once per frame
    void Update()
    {
        if(onInteractable)
             toolTip.UpdateText(interactable.entityName);
        else
            toolTip.UpdateText("");

        if(Physics.Raycast(playerView.transform.position, playerView.transform.forward,out hit,Mathf.Infinity)){
            Debug.DrawRay(playerView.transform.position, playerView.transform.forward * hit.distance, Color.yellow);
            
            if(hit.distance < distanceToRegister){
                interactable = hit.transform.GetComponent<Interactable>();
                onInteractable = interactable != null; 
            }
            else{
                onInteractable = false;
            }
        }
        else
        {
            Debug.DrawRay(playerView.transform.position, playerView.transform.forward * 1000, Color.white);
            onInteractable = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && onInteractable){
            if(interactable is Unlockable){
                ((Unlockable)interactable).Unlock();
            }
            else{
                GameManager.keys.Add(interactable.Id,true);
                print(interactable.entityName + " Collected");
                Destroy(interactable.gameObject);
                interactable = null;
                onInteractable = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.F)){
            flashLight.SetActive(!flashLight.activeSelf);
        }
    }
}
