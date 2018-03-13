using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZombie2State {

	void Execute();
	void Enter(Zombie1 zombie1);
	void Exit();
	void OnTriggerEnter(Collider2D other);
}
