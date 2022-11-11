using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CarStats
{
    private float _steerAngle;
    private float _moveSpeed;
    
    public CarStats(float moveSpeed, float steerAngle)
    {
        _steerAngle = steerAngle;
        _moveSpeed = moveSpeed;
    }

    public float GetSteerAngle()
    {
        return _steerAngle;
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }
}
public class SwitchCar : MonoBehaviour
{
    private static readonly Dictionary<string, CarStats> _carStatsMap = new Dictionary<string, CarStats>
    {
        {"SlowCar", new CarStats(10f, 250f)},
        {"MidCar", new CarStats(13f, 280f)},
        {"FastCar", new CarStats(15f, 320f)},
    };
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!_carStatsMap.ContainsKey(col.tag))
            return;
        
        var sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<Driver>().SetMoveSpeed(_carStatsMap[col.tag].GetMoveSpeed());
        gameObject.GetComponent<Driver>().SetSteerAngle(_carStatsMap[col.tag].GetSteerAngle());
    }
}
