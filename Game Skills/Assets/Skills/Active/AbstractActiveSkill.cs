using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractActiveSkill : AbstractSkill {

	// Use this for initialization
	void Start () {
        attributes.Add("Active");
	}

    abstract public Attack attack();
}
