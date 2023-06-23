using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverGrow : MonoBehaviour
{
    private Vector2 targetScale = new Vector2(1f, 1f);
    public Vector2 GrowScale = new Vector2(2f, 2f);
    private static Vector2 NormalScale = new Vector2(1f, 1f);
    public float GrowSpeed = 20f;
    public float ShrinkSpeed = 5f;
    private bool currentlyGrowing = false;

    private void OnMouseOver()
    {
        targetScale = GrowScale;
        currentlyGrowing = true;
        Vector3 pos = gameObject.transform.localPosition;
        gameObject.transform.localPosition = new Vector3(pos.x, pos.y, -5f);
    }
    void OnMouseExit()
    {
        targetScale = NormalScale;
        currentlyGrowing = false;
        Vector3 pos = gameObject.transform.localPosition;
        gameObject.transform.localPosition = new Vector3(pos.x, pos.y, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector2.Lerp(transform.localScale, targetScale, Time.deltaTime * (currentlyGrowing?GrowSpeed:ShrinkSpeed));
    }
}
