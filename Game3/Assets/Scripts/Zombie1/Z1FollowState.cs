using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z1FollowState : IZombie1State
{
    private Zombie1 zombie;

    public void Enter(Zombie1 zombie1)
    {
        this.zombie = zombie1;
    }

    public void Execute()
    {
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

    }

    private void Follow()
    {

    }
}
