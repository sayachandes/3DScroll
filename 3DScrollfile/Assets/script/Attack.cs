using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anim;
    private bool touchingRespawn = false;
    private GameController GameController;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject
           .FindGameObjectWithTag("GameController")
           .GetComponent<GameController>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            //�G��Respawn�^�O�����ē����蔻��
            touchingRespawn = true;
            DestroyPlayerIfNotAttacking();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            touchingRespawn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("is_attack", true);
        }
        else
        {
            //E�������ĂȂ��Ƃ�����
            anim.SetBool("is_attack", false);
        }
    }

    void DestroyPlayerIfNotAttacking()
    {
        if(touchingRespawn && !Input.GetKey(KeyCode.E))
        {
            //E�������ĂȂ����G�ɓ��������������
            Destroy(gameObject);
            GameController.GameOver();
        }
    }
}
