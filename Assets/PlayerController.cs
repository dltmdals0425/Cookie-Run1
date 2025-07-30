using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;//점프의 힘
    private Rigidbody2D rb;//해당 오브젝트에 물리를 적용
    private bool isGruond = true;//바닥에 닿아 있는지를 체크
    private Vector3 origianlScale = Vector3.one;//캐릭터의 원래 크기
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation= true;
        origianlScale = transform.localScale;
    }

      private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)&& isGruond)
        {
            rb.velocity = new Vector2(0f, jumpForce);      //벨로시티는 방향과 속도를 합쳐진개념
            isGruond=false;//여러번 점프가 되지않도록 방지.
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gruond"))
        {
            isGruond = true;
        }
    }
}
