using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] GameObject highlighter;

    GameObject currentTarget;


    public void Highlight(GameObject target)
    {
        if(currentTarget == target)
        {
            return;
        }
        currentTarget = target;
        Vector3 position = target.transform.position;
        Highlight(position);
    }
    public void Highlight(Vector3 position)
    {
        highlighter.SetActive(true);
        highlighter.transform.position = position+ Vector3.up * 0.8f;

    }
    public void Hide()
    {
        currentTarget = null;
        highlighter.SetActive(false);
    }
}
