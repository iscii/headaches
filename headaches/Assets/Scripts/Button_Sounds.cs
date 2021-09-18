using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Button_Sounds : MonoBehaviour, IPointerEnterHandler
{
    //refer to audiosource
    private AudioSource buttonAudio;

    //create audioclip instances
    public AudioClip button_highlighted;

    //start is called before the first frame update
    private void Start()
    {
        //refer to audiosource
        buttonAudio = gameObject.GetComponent<AudioSource>();
    }

    //update is called every frame update
    public void OnPointerEnter(PointerEventData highlighted)
    {
        buttonAudio.clip = button_highlighted;
        buttonAudio.Play();
    }
}
