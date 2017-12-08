using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractBuffSkill : AbstractSkill {

	// Use this for initialization
	void Start () {
        attributes.Add("Buff");
	}

    abstract public AbstractBuff addBuff();
    abstract public void removeBuff();
}
