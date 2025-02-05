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
            //敵にRespawnタグをつけて当たり判定
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
            //Eを押してないとき判定
            anim.SetBool("is_attack", false);
        }
    }

    void DestroyPlayerIfNotAttacking()
    {
        if(touchingRespawn && !Input.GetKey(KeyCode.E))
        {
            //Eを押してないかつ敵に当たった時やられる
            Destroy(gameObject);
            GameController.GameOver();
        }
    }
}
