
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    /// <summary>多段ジャンプできる回数</summary>
    [SerializeField] int maxJumpCount = 2;
    int jumpCount = 0;
    /// <summary>地面と判定される最大の角度</summary>
    [SerializeField] float groundAngleLimit = 30;
    [SerializeField] float jumpPower = 10f;
    Rigidbody rb;
    Vector3 clickPosition;
    /// <summary>ジャンプ可否フラグ</summary>
    bool canJump = false;
    AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ドラッグ開始位置（スクリーン空間の座標）を保存する
            clickPosition = Input.mousePosition;
        }   // マウス左ボタン(0)がプレス（押下）されたことを検出する
        else if (canJump && Input.GetMouseButtonUp(0))
        {
            Debug.Log(jumpCount);
            if (jumpCount < maxJumpCount)
            {
                // ドラッグと逆方向のベクトルを計算する
                Vector3 dragVector = clickPosition - Input.mousePosition;
                // ドラッグのベクトルの距離を求める
                float size = dragVector.magnitude;
                // ジャンプする
                rb.velocity = dragVector.normalized * jumpPower;
                jumpCount++;
                Debug.Log(jumpCount);
                audio.Play();
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // 衝突面の角度によってジャンプ可能か判定する
        //Vector3 normal = collision.contacts[0].normal;  // 法線をとってくる
        //canJump = CanJump(normal);
    }

    private void OnCollisionExit(Collision collision)
    {
        //canJump = false;
        //Debug.Log("離れた");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突面の角度によってジャンプ可能か判定する
        Vector3 normal = collision.contacts[0].normal;  // 法線をとってくる
        canJump = CanJump(normal);
        //Debug.Log(collision.gameObject.name + " と衝突した");
    }

    /// <summary>
    /// 衝突時に、ジャンプ可能か判定する
    /// </summary>
    /// <param name="normal">接触箇所の法線ベクトル</param>
    /// <returns>ジャンプ可能な時は true</returns>
    bool CanJump(Vector3 normal)
    {
        float angle = Vector3.Angle(normal, Vector3.up);

        if (angle < groundAngleLimit)
        {
            Debug.Log("jumpCount をリセットする");
            jumpCount = 0;
            return true; // ジャンプ可能
        }

        return false;
    }
}
