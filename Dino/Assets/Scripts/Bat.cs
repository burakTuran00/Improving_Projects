using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public float bat_Speed = 5f;
    private Vector2 bat_Direction;
    

    void RandomPostition()
    {
        float y = Random.Range(2.5f, 4.4f);
        this.transform.position = new Vector2(10f, y);
    }
    private void Awake()
    {
        RandomPostition();
        bat_Direction = Vector2.left;
    }
    private void Update()
    {
        this.transform.position -= new Vector3(Mathf.Round(this.transform.position.x) + bat_Direction.x, 0, 0) * bat_Speed * Time.deltaTime;
    }


}
