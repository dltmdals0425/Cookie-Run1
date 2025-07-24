using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Vector3 pointA = new Vector3(-3f, 0f, 0f);
    public Vector3 pointB = new Vector3(3f, 0f, 0f);
    public float moveSpeed = 2f;

    private Vector3 target;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        transform.position = pointA;
        target = pointB;

        // SpriteRenderer ��������
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            Debug.LogWarning("SpriteRenderer ������Ʈ�� �����ϴ�!");

        // ���� ���� (A�������� ����)
        if (spriteRenderer != null)
            spriteRenderer.color = Color.red;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        // ��ǥ�� �����ߴ��� Ȯ��
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            // ���� ��ǥ ����
            if (target == pointA)
            {
                target = pointB;
                if (spriteRenderer != null)
                    spriteRenderer.color = Color.yellow;  // B���� ����: �����
            }
            else
            {
                target = pointA;
                if (spriteRenderer != null)
                    spriteRenderer.color = Color.red;     // A���� ����: ������
            }
        }
    }
}
