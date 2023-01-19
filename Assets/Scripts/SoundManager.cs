using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;


[Serializable]
public class ItemLists
{
    public string type;
    public AudioClip audioSelected;
    public AudioMixerGroup mixed;
    [Range(0, 1)]
    public float volume;
    public float pitch;

}
public class SoundManager : MonoBehaviour
{
    public List<ItemLists> audioTypes = new List<ItemLists>();
    [SerializeField]
    private List<AudioSource> audioControllers = new List<AudioSource>();

    private Dictionary<string, ItemLists> audios;

    private static SoundManager _instance;
    public static SoundManager Instance => _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }

        audios = new Dictionary<string, ItemLists>();
        for(int i = 0; i < audioTypes.Count; i ++)
        {
            audios.Add(audioTypes[i].type, audioTypes[i]);
        }
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            audioControllers.Add(gameObject.transform.GetChild(i).GetComponent<AudioSource>());
        }

    }

    public void PlayeSound(string name, bool loop)
    {
        if (audios.ContainsKey(name))
        {
            for(int i=0; i<audioControllers.Count; i++)
            {
                if(audioControllers[i].clip==null || !audioControllers[i].isPlaying)
                {
                    audioControllers[i].clip = audios[name].audioSelected;
                    audioControllers[i].volume = audios[name].volume;
                    audioControllers[i].loop = loop;
                    audioControllers[i].pitch = audios[name].pitch;
                    audioControllers[i].outputAudioMixerGroup = audios[name].mixed;
                    audioControllers[i].Play();
                    break;
                }
            }
        }
    }


    public void StopSounds()
    {

            for (int i = 0; i < audioControllers.Count; i++)
            {

                audioControllers[i].Stop();
                
            }
        
    }


}
