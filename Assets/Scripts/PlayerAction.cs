using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed = 5f;

    private Rigidbody2D rigid;
    private float horizon;
    private float vertical;
    private bool isHorizonMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizon = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = (horizon != 0);
    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove
            ? new Vector2(horizon, 0)
            : new Vector2(0, vertical);

        rigid.linearVelocity = moveVec * Speed;
    }

}
