using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        if (h != 0.0f || v != 0.0f)
        {
            Vector3 dir = new Vector3(h, 0, v).normalized; // 방향 벡터 정규화
            Quaternion rotation = Quaternion.LookRotation(dir);
            transform.rotation = rotation;

            // Rigidbody를 사용하여 이동
            rb.MovePosition(transform.position + dir * moveSpeed * Time.deltaTime);

            GetComponent<Animator>().SetBool("bMove", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("bMove", false);
        }
    }
}
