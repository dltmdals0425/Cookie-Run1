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

        // SpriteRenderer 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            Debug.LogWarning("SpriteRenderer 컴포넌트가 없습니다!");

        // 시작 색상 (A지점에서 시작)
        if (spriteRenderer != null)
            spriteRenderer.color = Color.red;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        // 목표에 도달했는지 확인
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            // 다음 목표 설정
            if (target == pointA)
            {
                target = pointB;
                if (spriteRenderer != null)
                    spriteRenderer.color = Color.yellow;  // B지점 도달: 노란색
            }
            else
            {
                target = pointA;
                if (spriteRenderer != null)
                    spriteRenderer.color = Color.red;     // A지점 도달: 빨간색
            }
        }
    }
}
