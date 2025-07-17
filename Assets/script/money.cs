using System;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEditor.VersionControl;
using UnityEngine;

public class Money
{
    private int money;

    public int get_money(){
        return money;
    }
    public int update_money(int deltaMoney){
        money += deltaMoney;
        return money;
    }
    public int setmoney(int set){
        money = set;
        return 0;
    }
}