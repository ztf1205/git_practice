using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // 이동 속도를 조절하기 위한 변수
    public float moveSpeed = 5f;

    public int coin = 0;

    public TMP_Text coinText;

    // 이동할 목표 위치
    private Vector2 targetPosition;

    // 초기 설정
    void Start()
    {
        // 오브젝트의 현재 위치를 초기 목표 위치로 설정
        targetPosition = transform.position;
    }

    void Update()
    {
        // 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 위치를 월드 좌표로 변환하여 목표 위치로 설정
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        // 현재 위치에서 목표 위치로 이동
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        coin++;

        collision.gameObject.SetActive(false);

        Debug.Log("Coin:" + coin);

        coinText.text = "Coin : " + coin;
    }
}
