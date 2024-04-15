using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    static AudioPlayer instance;


//    forma desaconsejable de acceder a la clase a través de otras clases
//    public AudioPlayer GetInstance()
//    {
//        return instance;
//    }

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {

  //      2 maneras de crear un singleton: la primera buscando en la scene y la segunda a través de variable static
  //      la segunda manera nos ahorra tener que buscar en el scene (findobjects..) 
  //      int instanceCount = FindObjectsOfType(GetType()).Length;
  //      if(instanceCount > 1)
  
        if(instance != null){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 camperaPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, camperaPos, volume);
        }
    }
}
