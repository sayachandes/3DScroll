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
            //Playerに当たり、ゲームオーバーでない（Eを押している）ときやられた判定
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
            //Playerが敵を倒したときやられるかつGameControllerのスコアが減るように
            Destroy(gameObject);
            GameController.AddScore(1);
        }

        transform.position -= new Vector3(Time.deltaTime, 0f, 0f);
        //移動
    }

}
