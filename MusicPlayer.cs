using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;
    private AudioSource audio;
    void Awake ()
    {

        audio = GameObject.FindObjectOfType<AudioSource>();
        audio.volume = PlayerPrefMgt.GetMasterVolume();

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        Debug.Log("Music Player Start " + GetInstanceID());
    }
	
}
