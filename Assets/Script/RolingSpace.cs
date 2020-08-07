using UnityEngine;

public class RolingSpace : MonoBehaviour
{
    // Scroll main texture based on time

    public float scrollSpeed = 0.04f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer> ();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
