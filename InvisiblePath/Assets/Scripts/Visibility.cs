using System.Collections;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    private GameObject[] paths;

    public float visibletime = 5.0f;

    public float waitTime = 3.0f;

    private bool isActive = true;

    private void Start()
    {
        PathCondition(false);
    }

    private void Update()
    {
        StartCoroutine(Control());
    }

    private IEnumerator Control()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            PathCondition(true);

            yield return new WaitForSeconds(visibletime);

            PathCondition(false);
            isActive = false;
        }
        else if (!isActive)
        {
            StartCoroutine(WaitForVisible());
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

    private IEnumerator WaitForVisible()
    {
        yield return new WaitForSeconds(waitTime);
        isActive = true;
    }
}
