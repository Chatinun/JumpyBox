using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Animator anim;
    public bool isBackward = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBackward)
        {
            anim.SetBool("Backward", true);
        }
        else
        {
            anim.SetBool("Backward", false);
        }
    }
}
