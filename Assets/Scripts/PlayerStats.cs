using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int money;
    public int startMoney = 400;

    public static int Lives = 10;
    public int startLives;

	void Start () {
        money = startMoney;
        startLives = Lives;
	}
	

}
