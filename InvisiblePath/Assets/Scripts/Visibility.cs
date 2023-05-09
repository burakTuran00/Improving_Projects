using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Visibility : MonoBehaviour
{
    private GameObject[] paths;

    public float visibletime = 5.0f;

    public float waitTime = 3.0f;

    private bool isActive = true;

    public int limit = 3;

    public Text limitText;

    private void Start()
    {
        PathCondition(false);
        limitText.text = limit.ToString();
    }

    private void Update()
    {
        StartCoroutine(Control());
    }

    private IEnumerator Control()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            PathCondition(true);

            Limit();

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

    private void Limit()
    {
        limit--;
        limitText.text = limit.ToString();

        if (limit <= 0)
        {
            isActive = false;
        }
    }
}
