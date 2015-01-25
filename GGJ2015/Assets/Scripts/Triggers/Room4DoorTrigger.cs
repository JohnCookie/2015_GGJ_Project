using UnityEngine;
using System.Collections;

public class Room4DoorTrigger : MonoBehaviour
{
	public GameObject door;
	public GameObject prefabParticle;
	public GameObject particleRoot;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom4Key1 && PlayerInfo.getInstance().hasRoom4Key2){
				Destroy(door,2);
				GameObject particle = (GameObject) Instantiate(prefabParticle);
				particle.transform.parent=particleRoot.transform;
				particle.transform.localPosition=new Vector3(6545,0,4530);
				particle.transform.localRotation= Quaternion.Euler(90,-90,0);
				particle.transform.localScale=new Vector3(360,360,360);
				ParticleSystem system = particle.GetComponent<ParticleSystem>();
				system.Play(true);

				PlayerInfo.getInstance().changePlayerMat(3);
				AudioControler.getInstance().playOpenDoor();
			}else{
				HintMgr.getInstance().showHint("Speed up!");
			}
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom4Key1 && PlayerInfo.getInstance().hasRoom4Key2){
				Destroy(gameObject);
			}
			HintMgr.getInstance().hideHint();
		}
	}
}

