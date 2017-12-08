using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractSkill : MonoBehaviour {

    public List<string> attributes = new List<string>();
    public float exp = 0;

	// Use this for initialization
	void Start () {
		
	}

    abstract public void useSkill();
}
