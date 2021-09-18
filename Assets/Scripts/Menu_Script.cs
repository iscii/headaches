using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    //load game scene
    public void StartGame()
    {
        IEnumerator LoadAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            //load scene 1
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        StartCoroutine(LoadAfterSeconds(0.5f));
    }

    //exit application
    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
 