using UnityEngine;
using System.Collections;

public class Room7DoorTrigger : MonoBehaviour
{
	public GameObject door;
	public GameObject door2;
	public GameObject prefabParticle;
	public GameObject particleRoot;
	
	void OnTriggerEnter (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom7Key1 && PlayerInfo.getInstance().hasRoom7Key2 && PlayerInfo.getInstance().hasRoom7Key3 && PlayerInfo.getInstance().hasRoom7Key4){
				Destroy(door,2);
				Destroy (door2,2);
				GameObject particle = (GameObject) Instantiate(prefabParticle);
				particle.transform.parent=particleRoot.transform;
				particle.transform.localPosition=new Vector3(4748,0,2056);
				particle.transform.localRotation= Quaternion.Euler(90,-90,0);
				particle.transform.localScale=new Vector3(360,360,360);
				ParticleSystem system = particle.GetComponent<ParticleSystem>();
				system.Play(true);

				PlayerInfo.getInstance().changePlayerMat(6);
				AudioControler.getInstance().playOpenDoor();
			}else{
				HintMgr.getInstance().showHint("Hurry Up!!!");
			}
		}
	}
	
	void OnTriggerExit (Collider collider){
		if(collider.tag.Equals("GamePlayer")){
			if(PlayerInfo.getInstance().hasRoom7Key1 && PlayerInfo.getInstance().hasRoom7Key2 && PlayerInfo.getInstance().hasRoom7Key3 && PlayerInfo.getInstance().hasRoom7Key4){
				Destroy(gameObject);
			}
			HintMgr.getInstance().hideHint();
		}
	}
}

