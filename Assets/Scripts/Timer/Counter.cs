using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Timer {

    class Counter : MonoBehaviour {

        private TextMesh counterText;
        private Renderer renderer;

        public Color finishedColor = new Color(212, 75, 72);

        private bool isRunning = false;
        private float elapsedSeconds;
        public float totalRunningSeconds;

        public void Awake() {
            counterText = gameObject.GetComponentInChildren<TextMesh>();
            renderer = gameObject.GetComponent<Renderer>();
        }


        void Update() {
            if (timeReached()) {
                isRunning = false;
                renderer.material.color = finishedColor;
            }

            if (!isRunning) return;

            elapsedSeconds += Time.deltaTime;
            var timeSpan = TimeSpan.FromSeconds(elapsedSeconds);

            string format = "";
            if (timeSpan.Hours == 0) {
                format = string.Format("{0}:{1}", timeSpan.Minutes.ToString().PadLeft(2, '0'), timeSpan.Seconds.ToString().PadLeft(2, '0'));
            } else {
                format = string.Format("{0}:{1}:{2}", timeSpan.Hours.ToString().PadLeft(2, '0'), timeSpan.Minutes.ToString().PadLeft(2, '0'), timeSpan.Seconds.ToString().PadLeft(2, '0'));
            }

            counterText.text = format;
        }

        public Boolean timeReached() {
            return elapsedSeconds >= totalRunningSeconds;
        }

        public void setTimer(int hours, int minutes, int seconds) {
            Debug.Log(string.Format("{0}:{1}:{2}", hours, minutes, seconds));
            int totalSeconds = 0;

            if (hours > 0 && hours <= 60) {
                totalSeconds += (hours * 3600);
            }

            if (minutes > 0 && minutes <= 60) {
                totalSeconds += (minutes * 60);
            }

            if (seconds > 0 && seconds <= 60) {
                totalSeconds += seconds;
            }

            totalRunningSeconds = totalSeconds;
        }

        public void StartTimer() {
            if (!timeReached()) {
                isRunning = true;
            }
        }

        public void ResetTimer() {
            elapsedSeconds = 0;
        }

        public void StopTimer() {
            isRunning = false;
        }


        public void StartStopTimer() {
            if (isRunning) {
                StopTimer();
            }
            else {
                StartTimer();
            }
        }

        public void DeleteTimer() {
            Destroy(gameObject.transform.root.gameObject);
        }

    }
}
