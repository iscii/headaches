using System.Collections;
using UnityEngine;

public class Booster_Collected : MonoBehaviour
{
    //reference to sugar behavior script
    public GameObject booster;

    //start is called before the first frame update
    public void Start()
    {
        //refer to sugar behavior script
        booster = GameObject.Find("Booster");
    }

    //reference function to sugar's SugarSpawn() function
    public void GoToBooster()
    {
        //teleport to sugar after 2 seconds
        IEnumerator GoToBooster(float time)
        {
            yield return new WaitForSeconds(time);

            transform.position = new Vector3(booster.transform.position.x, booster.transform.position.y + 1, 0f);
        }
        StartCoroutine(GoToBooster(1));
    }

    public void BoosterGone()
    {
        booster.GetComponent<Booster_Behavior>().LeaveScene();
    }
}