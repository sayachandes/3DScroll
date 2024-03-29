using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �J�������Ǐ]����Ώہi�L�����N�^�[�j
    public Vector3 offset;  // �Ώۂ���̃I�t�Z�b�g�i�L�����N�^�[����J�����̋�����ʒu�j
    public float smoothSpeed = 0.3f;//�Ǐ]�y�[�X���ɂ₩�ɂ���
    private Vector3 velocity = Vector3.zero;
    public GameObject Gameover;

    private bool gameover = false;

    void LateUpdate()
    {
        if (target != null && !gameover)
        {
            // �J�����̈ʒu��Ώۂ̈ʒu�ɃI�t�Z�b�g���������ʒu�ɐݒ�
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
        else if (Gameover != null && gameover)
        {
            Gameover.SetActive(true);
            Gameover.transform.position = new Vector3(Screen.width / 2,Screen.height / 2 , 0);
        }
    }

    void SetGameOver()
    {
        gameover = true;
    }
}