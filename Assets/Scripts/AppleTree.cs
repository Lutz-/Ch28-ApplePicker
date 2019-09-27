using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 20f;

    public float chanceToChangeDirections = 0.1f;

    public float secondsBetweenAppleDrops = 1f;

    private void Start()
    {
        //drop apples ever second
        Invoke("DropApple", 2f);
    }

    private void Update()
    {
        //movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //direction
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
        
    }

    private void FixedUpdate()
    {
        //random direction changes
        if (Random.value < chanceToChangeDirections)
            speed *= -1;
    }

    private void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
}
