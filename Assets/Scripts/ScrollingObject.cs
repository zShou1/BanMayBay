using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private float _scrollSpeed = -1f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = new Vector2(0f, _scrollSpeed);
    }
}
