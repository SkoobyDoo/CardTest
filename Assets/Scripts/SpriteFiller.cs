using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFiller : MonoBehaviour
{
    // helper script resizes attached gameObject's scale so that the SpriteRenderer fills the parent RectTransform
    private SpriteRenderer spriteRenderer;
    private RectTransform rectTransform;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rectTransform = transform.parent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Start()
    {

        float parent_width = rectTransform.rect.width;
        float parent_height = rectTransform.rect.height;

        float width_scale = parent_width / spriteRenderer.sprite.bounds.size.x;
        float height_scale = parent_height / spriteRenderer.sprite.bounds.size.y;

        transform.localScale = new Vector3(width_scale, height_scale, 1);

    }
}