using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    Collider attackCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (anim == null)
        {
            Debug.LogError("Animator component not found!");
        }
    }

    void Update()
    {
        Vector3 scale = transform.localScale;
        if (anim != null)
        {
            // �L�[�ňړ�
            float dx = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                anim.SetBool("is_RightWalking", true);
                anim.SetBool("is_LeftWalking", false);
                //scale.x = 1;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                anim.SetBool("is_RightWalking", false);
                anim.SetBool("is_LeftWalking", true);
                //scale.x = -1;
            }
            else
            {
                anim.SetBool("is_RightWalking", false);
                anim.SetBool("is_LeftWalking", false);
            }

            // �L�����N�^�[���ړ�������
            float moveSpeed = Input.GetAxisRaw("Horizontal") > 0 ? 5f : 2f; // �E�Ɉړ�����Ƃ���5�{�̑��x�A���Ɉړ�����Ƃ���2�{�̑��x
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + dx * moveSpeed, -8f, 8f), 0f, 0f);
        }
    }

    void OffColliderAttack()
    {
        attackCollider.enabled = false;
    }
    void OnColliderAttack()
    {
        attackCollider.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Damage damage = other.GetComponent<Damage>();
        if(damage != null)
        {
            anim.SetTrigger("Damage");
        }
    }
}
