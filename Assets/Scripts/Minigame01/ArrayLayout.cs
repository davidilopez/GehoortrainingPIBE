using UnityEngine;
using System.Collections;

[System.Serializable]
public class ArrayLayout  {

	[System.Serializable]
	public struct lettersData{
		public AudioClip[] clips;
	}

	public lettersData[] pairs = new lettersData[8]; 
}
