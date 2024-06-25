using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class CoroutineTimer
    {
        private int _time;
        private Action _actionForStopTimer;
        public CoroutineTimer(int time, Action a)
        {
            _time = time;
            _actionForStopTimer = a;
        }

        public IEnumerator Timer()
        {
            yield return new WaitForSeconds(_time);
            _actionForStopTimer();
        }
    }
}
