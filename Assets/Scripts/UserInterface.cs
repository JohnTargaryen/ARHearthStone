using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {
    public Text P1_HP;
    public Text P2_HP;
    public Text P1_Card;
    public Text P2_Card;
    public Text P1_MP;
    public Text P2_MP;
    public Button next_round;
    List<Hero> heros;
    List<Text> heros_info;

    // Use this for initialization
    void Start () {
        P1_HP.text = "HP:";
        P2_HP.text = "HP:";
        P1_MP.text = "MP:";
        P2_MP.text = "MP:";
        P1_Card.text = "Card:";
        P2_Card.text = "Card:";
        heros = new List<Hero>();
        heros_info = new List<Text>();
    }
	
	// 英雄信息UI跟随英雄
	void Update () {
		for (int i = 0; i < heros.Count; i++)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(heros[i].HeroModel.transform.position);
            heros_info[i].transform.position = screenPos + new Vector3(65, -17, 0);
        }
	}

    public void set_player_HP(int hp, Player player)
    {
        God god = God.getInstance();
        if (player == god.playerred)
        {
            P1_HP.text = "HP:" + hp.ToString();
        }
        else if (player == god.playeryellow)
        {
            P2_HP.text = "HP:" + hp.ToString();
        }
    }

    public void set_player_MP(int mp, Player player)
    {
        God god = God.getInstance();
        if (player == god.playerred)
        {
            P1_MP.text = "MP:" + mp.ToString();
        }
        else if (player == god.playeryellow)
        {
            P2_MP.text = "MP:" + mp.ToString();
        }
    }

    public void set_player_Cardnum(int num, Player player)
    {
        God god = God.getInstance();
        if (player == god.playerred)
        {
            P1_Card.text = "Card:" + num.ToString();
        }
        else if (player == god.playeryellow)
        {
            P2_Card.text = "Card:" + num.ToString();
        }
    }

    public void create_hero_info(int hp, int atk, Hero hero)
    {
        Text infoPrefab = Resources.Load<Text>("UI/hero_info_UI");
        Vector3 screenPos = Camera.main.WorldToScreenPoint(hero.HeroModel.transform.position);
        Text info = Instantiate(infoPrefab, screenPos + new Vector3(65, -17, 0), Quaternion.identity);
        info.text = "hp:" + hp.ToString() + "\n" + "atk:" + atk.ToString();
        info.transform.SetParent(GameObject.Find("Canvas").transform);
        heros.Add(hero);
        heros_info.Add(info);
    }

    public void set_hero_info(int hp, int atk, Hero hero)
    {
        for (int i = 0; i < heros.Count; i++)
        {
            if (heros[i] == hero)
            {
                heros_info[i].text = "hp:" + hp.ToString() + "\n" + "atk:" + atk.ToString();
                break;
            }
        }
    }

    public void destroy_hero_info(Hero hero)
    {
        for (int i = 0; i < heros.Count; i++)
        {
            if (heros[i] == hero)
            {
                Destroy(heros_info[i], 0.5f);
                heros.RemoveAt(i);
                heros_info.RemoveAt(i);
                break;
            }
        }
    }
}
