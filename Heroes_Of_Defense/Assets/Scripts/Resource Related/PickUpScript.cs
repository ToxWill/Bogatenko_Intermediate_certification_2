using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    [SerializeField] AudioSource pickup_sound;
     
    void OnMouseDown()
    {
        if (this.tag == "Stone")
        {
            pickup_sound.volume = GameSettings.soundVolume;
            pickup_sound.Play();

            ResourceManager.Instance.CollectResource(ResourceType.STONE, Random.Range(8, 15));
            ResourceManager.Instance.ReturnResource(ResourceType.STONE, this.gameObject);
        }
    }
}
