using UnityEngine;
using System.Collections;

public class Room3DoorTrigger : MonoBehaviour
{
	public GameObject door;
	public GameObject prefabParticle;
	public GameObject particleRoot;

	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			Destroy(door,2);
			GameObject particle = (GameObject) Instantiate(prefabParticle);
			particle.transform.parent=particleRoot.transform;
			particle.transform.localPosition=new Vector3(3893,0,4362);
			particle.transform.localRotation= Quaternion.Euler(90,-90,0);
			particle.transform.localScale=new Vector3(360,360,360);
			ParticleSystem system = particle.GetComponent<ParticleSystem>();
			system.Play(true);
			AudioControler.getInstance().playOpenDoor();
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			HintMgr.getInstance().hideHint();
			Destroy(gameObject);
		}
	}
}

