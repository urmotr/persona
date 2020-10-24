using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persona : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Render_Colored_Rectangle(50, 50, 50, 50, 10, 10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Render_Colored_Rectangle(int x, int y, int w, int h, float r, float g, float b)
    {
        Texture2D rgb_texture = new Texture2D(w, h);
        Color rgb_color = new Color(r, g, b);
        int i, j;
        for (i = 0; i < w; i++)
        {
            for (j = 0; j < h; j++)
            {
                rgb_texture.SetPixel(i, j, rgb_color);
            }
        }
        rgb_texture.Apply();
        GUIStyle generic_style = new GUIStyle();
        GUI.skin.box = generic_style;
        GUI.Box(new Rect(x, y, w, h), rgb_texture);
    }
}
