using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public Texture foregroundTexture;
    public Texture backgroundTexture;
    public Texture2D damageTexture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 오른쪽 상단쪽에 체력 바 생성, 체력바의 크기는 체력에 비례하게 설정.
    void OnGUI()
    {
        Rect rect = new Rect(10, 6, Screen.width/2-20, backgroundTexture.height);

        GUI.DrawTexture(rect, backgroundTexture);

        float health = Player.health;
        rect.width *= health;

        GUI.color = damageTexture.GetPixelBilinear(health, 0.5f);
        GUI.DrawTexture(rect, foregroundTexture);

        GUI.color = Color.white;
    }
}
