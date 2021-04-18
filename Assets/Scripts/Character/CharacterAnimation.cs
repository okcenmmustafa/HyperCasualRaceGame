using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim=GetComponent<Animator>();
    }
    public void Run()
    {
        anim.SetInteger("movementMode", 2);
    }
    public void Walk()
    {
        anim.SetInteger("movementMode", 1);
    }
    public void Wait()
    {
        anim.SetInteger("movementMode", 0);

    }
}
