using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputMove : MonoBehaviour {

    public float speed = 0.0f;

    private const float LIMIT_POS_X = 3.2f;
    private const float LIMIT_POS_Y = 4.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(h, v);

        transform.Translate(direction.normalized * speed * Time.deltaTime);

        Vector2 pos = transform.position;

        if (Mathf.Abs(pos.x) > LIMIT_POS_X)
        {
            pos.x = Mathf.Sign(pos.x) * LIMIT_POS_X;
        }

        if (Mathf.Abs(pos.y) > LIMIT_POS_Y)
        {
            pos.y = Mathf.Sign(pos.y) * LIMIT_POS_Y;
        }

        transform.position = pos;
    }
}
