using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deathscreen : MonoBehaviour
{
    //start is called before the first frame update
    public void Start()
    {
        //disables text
        gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
    }
    //function to enable text and animation
    public void Activate()
    {
        //enables text
        gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        //enables animation
        gameObject.GetComponent<Animator>().enabled = true;
    }
    //function to disable animation
    public void StopAnimation()
    {
        //disables animation
        gameObject.GetComponent<Animator>().enabled = false;
    }
}
