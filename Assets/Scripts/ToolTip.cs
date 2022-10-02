using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolTip : MonoBehaviour
{
    private Canvas canvas;
    [SerializeField] private TextMeshProUGUI displayText;

    private void Start() {
        //displayText = canvas.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        displayText.text = "It's Working";
    }

    public void UpdateText(string text){
        displayText.text=text;
    }
}
