using UnityEngine;
using System.Collections;

public class AudioEx : MonoBehaviour
{
	public static AudioEx Instance = null;

	public AudioSource Music;

    //[SerializeField]
	//public static AudioSource Music = null;

    //[SerializeField]
	//public static AudioClip background_music = null;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

    void Start()
    {
		//m_Audio.clip = background_music;
		//m_Audio.loop = true;
		//m_Audio.Play ();

    }

	public void setMusicSound(float num)
	{
		//Debug.Log ("play sound:" + num);
		Music.volume = num;
	}
}
