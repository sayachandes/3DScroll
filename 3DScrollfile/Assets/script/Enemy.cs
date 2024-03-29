using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool touchingObject = false;
    Animator anim;
    private GameController GameController;
    private bool isGameOver = false;

    void Start()
    {
        GameController = GameObject
            .FindWithTag("GameController")
            .GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isGameOver )
        {
            //Player�ɓ�����A�Q�[���I�[�o�[�łȂ��iE�������Ă���j�Ƃ����ꂽ����
            touchingObject = true;  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            touchingObject = false;
        }
    }

    void Update()
    { 
        if (touchingObject) 
        {
            //Player���G��|�����Ƃ�����邩��GameController�̃X�R�A������悤��
            Destroy(gameObject);
            GameController.AddScore(1);
        }

        transform.position -= new Vector3(Time.deltaTime, 0f, 0f);
        //�ړ�
    }

}
