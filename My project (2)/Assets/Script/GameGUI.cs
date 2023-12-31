using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{
    public Text guiMeter;
    // 이 미터는 다른 씬에서도 사용된다.
    public static int meter;
    public float timePrev;

    public Texture OilTexture;
    public Texture ReverseTexture;
    public Texture BulletTexture;
    public Texture HealthTexture;
    public Texture SlowTexture;
    public Texture MagnetTexture;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        meter = 0;
        timePrev = Time.time;

        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1초가 지날 때 마다 meter 에 1을 더해준다.
        if(Time.time - timePrev > 1.0f)
        {
            timePrev = Time.time;
            meter++;
        }
        // 미터 표기
        guiMeter.text = meter + "m";
    }

    // 2 * 3 크기로 왼쪽 상단에 먹은 아이템의 UI를 띄운다.
    void OnGUI()
    {
        float x;
        float y;
        float width = OilTexture.width / 3;
        float height = OilTexture.height / 3;

        GUI.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        
        if(player.bItemOil)
        {
            x = Screen.width - (10 + width);
            y = 6;
            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, OilTexture);
        }
        if (player.bItemReverse)
        {
            x = Screen.width - (10 + width) * 2;
            y = 6;
            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, ReverseTexture);
        }
        if (player.bItemBullet)
        {
            x = Screen.width - (10 + width);
            y = 6 + (height+10);
            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, BulletTexture);
        }
        if (player.bItemHealth)
        {
            x = Screen.width - (10 + width) * 2;
            y = 6 + (height + 10);
            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, HealthTexture);
        }
        if (player.bItemSlow)
        {
            x = Screen.width - (10 + width);
            y = 6 + (height + 10) * 2;
            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, SlowTexture);
        }
        if (player.bItemMagnet)
        {
            x = Screen.width - (10 + width) * 2;
            y = 6 + (height + 10) * 2;
            Rect rect = new Rect(x, y, width, height);
            GUI.DrawTexture(rect, MagnetTexture);
        }
        GUI.color = Color.white;
    }
}
