using UnityEngine;
using System.Collections;

public class AudioControler : MonoBehaviour
{
	public AudioSource m_AudioMgr;
	public AudioSource m_effectMgr;
	public AudioClip m_clipBgm;
	public AudioClip m_clipOpenDoor;
	public AudioClip m_clipPick;
	public AudioClip m_clipWarning;

	private static AudioControler _instance;
	private AudioControler(){
	}
	public static AudioControler getInstance(){
		if(_instance==null){
			_instance=GameObject.Find("AudioMgr").GetComponent<AudioControler>();
		}
		return _instance;
	}

	public void playBGM(){
		m_AudioMgr.loop=true;
		m_AudioMgr.clip=m_clipBgm;
		m_AudioMgr.volume=3;
		m_AudioMgr.Play();
	}

	public void playOpenDoor(){
		m_effectMgr.clip=m_clipOpenDoor;
		m_effectMgr.volume=4;
		m_effectMgr.loop=false;
		m_effectMgr.PlayOneShot(m_clipOpenDoor);
	}

	public void playPick(){
		m_effectMgr.clip=m_clipPick;
		m_effectMgr.volume=4;
		m_effectMgr.loop=false;
		m_effectMgr.PlayOneShot(m_clipPick);
	}

	public void playWarning(){
		m_effectMgr.clip=m_clipWarning;
		m_effectMgr.volume=4;
		m_effectMgr.loop=true;
		m_effectMgr.PlayOneShot(m_clipWarning);
	}

	public void stopWarning(){
		m_effectMgr.Stop();
	}
}

