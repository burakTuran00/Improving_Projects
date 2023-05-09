using System.Collections;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    private GameObject[] paths;

    public float visibletime = 5.0f;

    public float waitTime = 3.0f;

    private void Start()
    {
        PathCondition(false);
    }

    private void Update()
    {
        StartCoroutine(Control(true));
    }

    private IEnumerator Control(bool isActive)
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            PathCondition(true);
            isActive = false;

            yield return new WaitForSeconds(visibletime);
            
            PathCondition(false);
            isActive = true;
        }
    }

    private void PathCondition(bool condition)
    {
        paths = GameObject.FindGameObjectsWithTag("Area");

        foreach (GameObject path in paths)
        {
            SpriteRenderer spriteRenderer = path.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = condition;
        }
    }

    private void PlayerWait()
    {

    }
}
