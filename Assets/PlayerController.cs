using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;//점프의 힘
    private Rigidbody2D rb;//해당 오브젝트에 물리를 적용
    private bool isGruond = true;//바닥에 닿아 있는지를 체크
    private Vector3 origianlScale = Vector3.one;//캐릭터의 원래 크기
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation= true;
        origianlScale = transform.localScale;
        anim = GetComponentInChildren<Animator>();
       
    }

      private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)&& isGruond)
        {
            rb.velocity = new Vector2(0f, jumpForce);      //벨로시티는 방향과 속도를 합쳐진개념
            isGruond=false;//여러번 점프가 되지않도록 방지.
            
        }
        anim.SetBool("jumping", !isGruond);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gruond"))
        {
            isGruond = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("게임 오버");
            Time.timeScale = 0f;//timeScale 게임의 진행 속도(시간의 흐름) 조절해줄수있는것 기본값은 1, 2배속은 2, 느리게원하면 0에가깝게 해주면됨
            
         }
    }
}
