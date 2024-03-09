using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour
{

    public Text textToChange;
    public Color startColor;
    public Color hoverColor;

    private void Start()
    {
        startColor = textToChange.color;
    }


    private void OnMouseEnter()
    {
        textToChange.color = hoverColor;
    }

    private void OnMouseExit()
    {
        textToChange.color = startColor;
    }


}
