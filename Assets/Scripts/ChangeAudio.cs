using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip backgroundMusic;

    [SerializeField]
    private AudioClip fightMusic;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = backgroundMusic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMusic(string name)
    {
        if(name.Equals("background"))
        {
            GetComponent<AudioSource>().clip = backgroundMusic;

            GetComponent<AudioSource>().PlayOneShot(backgroundMusic);
        }
        else if(name.Equals("fight"))
        {
            GetComponent<AudioSource>().clip = fightMusic;
            Debug.Log("aaaaaa");
        }

    }
}
