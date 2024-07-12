﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Model
{
    protected View _view;

    protected List<SlotStates> _field;
    protected Queue<int> _queueCirclesID;
    protected Queue<int> _queueCrossesID;

    protected bool _isWinCircle;
    protected bool _isWinCross;

    protected int _countWinsCircle;
    protected int _countWinsCross;

    public int LIMIT_QUEUE_ID = 3;
    public int SLOTS_COUNT = 9;

    public List<SlotStates> SlotsStates => _field;
    public Queue<int> QueueCircleID => _queueCirclesID;
    public Queue<int> QueueCrossID => _queueCrossesID;
    public int CountWinsCircle => _countWinsCircle;
    public int CountWinsCross => _countWinsCross;

    public Model(View view)
    {
        _view = view;
        _queueCirclesID = new Queue<int>();
        _queueCrossesID = new Queue<int>();
        _field = new List<SlotStates>();

        for (int i = 0; i < SLOTS_COUNT; i++)
            _field.Add(SlotStates.Empty);
    }
    public bool isGameOn()
        => _isWinCircle == false && _isWinCross == false;

    public void SetState(List<SlotStates> Field)
    {
        _field = Field;
    }

    public void SetStateWin(SlotStates State)
    {
        if (State == SlotStates.Circle)
        {
            _countWinsCircle++;
            _isWinCircle = true;
            _isWinCross = false;
        }
        else if (State == SlotStates.Cross)
        {
            _countWinsCross++;
            _isWinCross = true;
            _isWinCircle = false;
        }
        else if (State == SlotStates.Empty)
        {
            _isWinCircle = false;
            _isWinCross = false;
        }
    }

    public void ClearField()
    {
        _queueCirclesID = new Queue<int>();
        _queueCrossesID = new Queue<int>();
        _field = new List<SlotStates>();

        for (int i = 0; i < SLOTS_COUNT; i++)
            _field.Add(SlotStates.Empty);

        _isWinCircle = false;
        _isWinCross = false;
    }
}
