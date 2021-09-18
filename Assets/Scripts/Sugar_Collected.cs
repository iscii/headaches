using System.Collections;
using UnityEngine;

public class Sugar_Collected : MonoBehaviour
{
    //reference to sugar behavior script
    public GameObject sugar;

    //start is called before the first frame update
    public void Start()
    {
        //refer to sugar behavior script
        sugar = GameObject.Find("Sugar");
    }

    //reference function to sugar's SugarSpawn() function
    public void SugarSpawn()
    {
        //refer to SugarSpawn()
        sugar.GetComponent<Sugar_Behavior>().SugarSpawn();

        //teleport to sugar after 2 seconds
        IEnumerator GoToSugar(float time)
        {
            yield return new WaitForSeconds(time);

            transform.position = new Vector3(sugar.transform.position.x, sugar.transform.position.y + 1, 0f);
        }
        StartCoroutine(GoToSugar(2));
    }
}

