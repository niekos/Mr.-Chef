using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Timer {

    class Counter : MonoBehaviour {
        
        private TextMesh _textMesh;
        private bool _isRunning;
        public float _elapsedSeconds;
        
        public void Start() {
            _textMesh = gameObject.GetComponentInChildren<TextMesh>();
            StartTimer();
        }
        

        void Update() {
            if (!_isRunning) return;

            _elapsedSeconds += Time.deltaTime;
            var timeSpan = TimeSpan.FromSeconds(_elapsedSeconds);

            string format = "";
            if (timeSpan.Hours == 0) {
                format = string.Format("{0}:{1}", timeSpan.Minutes.ToString().PadLeft(2, '0'), timeSpan.Seconds.ToString().PadLeft(2, '0'));
            } else {
                format = string.Format("{0}:{1}:{2}", timeSpan.Hours.ToString().PadLeft(2, '0'), timeSpan.Minutes.ToString().PadLeft(2, '0'), timeSpan.Seconds.ToString().PadLeft(2, '0'));
            }

            _textMesh.text = format;
        }

        public void StartTimer() {
            _isRunning = true;
        }

        public void ResetTimer() {
            _elapsedSeconds = 0;
        }

        public void StopTimer() {
            _isRunning = false;
        }

    }
}
