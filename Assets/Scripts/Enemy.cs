using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    float health;
    bool isLive;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Awake()
    { 
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.linearVelocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        health = 100;
        isLive = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Arrow"))
            return;

        health -= collision.GetComponent<Arrow>().damage;
        if(health > 0)
        {

        }
        else
        {
            Dead();
        }
    }

    void Dead()
    {
        isLive = false;
        gameObject.SetActive(false);
    }
}
