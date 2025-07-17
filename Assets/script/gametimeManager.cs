using System;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEngine;


//게임 내 시간 시스템
public class GameTime
{
    private int day;
    private float secClock;
    public bool is_daytime;
    private float clock_t;
    private float clock_m;
    

    public void time_initialize(){
        day = 0;
        secClock = 0f;
        clock_t = 0;
        is_daytime = true;
        Debug.Log("날짜가 초기화 되었습니다");
    }

    public int get_day(){
        return day;
    }
    
    public int sleeping(){
        day ++;
        secClock = 360;
        return day;
    }

    public string get_time(){
        string temp;
        if (is_daytime){
            temp = "낮";
        }else{
            temp = "밤";
        }
        
        return clock_t + "시 " + clock_m + "분" + " (" + temp + ")";
    }

    public bool is_sleepy(){
        if(clock_t >= 24){
            return true;
        }
        return false;
    }

    public void updateTime(float delta){
        secClock += delta;
        clock_t = (float)Math.Floor(secClock/60);
        clock_m = (float)Math.Floor(secClock%60/5)*5;
        // Debug.Log(get_time());
        if(clock_t>=6 && clock_t<=19){
            is_daytime = true;
        } else{
            is_daytime = false;
        }
        
    }


}