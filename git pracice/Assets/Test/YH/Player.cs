using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    // �̵� �ӵ��� �����ϱ� ���� ����
    public float moveSpeed = 5f;

    public int coin = 0;

    public TMP_Text coinText;

    // �̵��� ��ǥ ��ġ
    private Vector2 targetPosition;

    // �ʱ� ����
    void Start()
    {
        // ������Ʈ�� ���� ��ġ�� �ʱ� ��ǥ ��ġ�� ����
        targetPosition = transform.position;
    }

    void Update()
    {
        // ���콺 Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ�Ͽ� ��ǥ ��ġ�� ����
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        // ���� ��ġ���� ��ǥ ��ġ�� �̵�
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
