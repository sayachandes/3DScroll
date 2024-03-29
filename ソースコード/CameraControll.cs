using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // カメラが追従する対象（キャラクター）
    public Vector3 offset;  // 対象からのオフセット（キャラクターからカメラの距離や位置）
    public float smoothSpeed = 0.3f;//追従ペースを緩やかにする
    private Vector3 velocity = Vector3.zero;
    public GameObject Gameover;

    private bool gameover = false;

    void LateUpdate()
    {
        if (target != null && !gameover)
        {
            // カメラの位置を対象の位置にオフセットを加えた位置に設定
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