using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Scroll : MonoBehaviour
{
    //reference to material component
    private Material material;

    //creates a vector2 variable for offset
    private Vector2 offset;

    //creates variable for scroll speed
    public float scrollSpeed = 0.03f;

    //awake is called just like start is lmao
    private void Awake()
    {
        //reference to material component
        material = GetComponent<Renderer>().material;
    }

    //update is called once per frame
    void Update()
    {
        //offset variable is in update so the scrollspeed updates with obstacle speed
        //sets values for offset
        offset = new Vector2(scrollSpeed, 0f);

        //constantly changes material's offset by "offset".
        material.mainTextureOffset += offset * Time.deltaTime;
    }

    //method to stop script
    public void Stop()
    {
        //disables script
        enabled = false;
    }
}
