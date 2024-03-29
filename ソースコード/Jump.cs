using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(Input.GetKey(KeyCode.Space) && IsGrounded())//スペースキーが押されて地面に足がついているとき
        {
            JumpAction();
        }
        else
        {
            anim.SetBool("is_Jump", false);
        }
    }
    void JumpAction()
    {
        anim.SetBool("is_Jump", true);
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        float distance = 0.1f;//ほぼ床についてるとき
        Vector3 dir = Vector3.down;

        if(Physics.Raycast(transform.position,dir,out hit,distance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
