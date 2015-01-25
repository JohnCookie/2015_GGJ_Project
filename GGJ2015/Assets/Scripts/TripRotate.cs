using UnityEngine;
using System.Collections;

public class TripRotate : MonoBehaviour
{
		// Update is called once per frame
		void Update ()
		{
			transform.Rotate(0,Time.deltaTime*30, 0);
		}
}

