using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Timer {

    class Counter : MonoBehaviour {

        public System.Timers.Timer timer;
        private TextMesh textMesh;

        public int time;
        public int hh;
        public int mm;
        public int ss;

        public void Awake() {
            this.timer = new System.Timers.Timer(1000);
            textMesh = gameObject.GetComponentInChildren<TextMesh>();
            timer.Elapsed += OnTimeEvent;
            startCounting();
        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e) {
            ss += 1;
            if (ss == 60) {
                ss = 0;
                mm += 1;
            }
            if (mm == 60) {
                mm = 0;
                hh += 1;
            }
        }

        public void Update() {
            string format = "";
            if (hh == 0) {
                 format = string.Format("{0}:{1}", mm.ToString().PadLeft(2, '0'), ss.ToString().PadLeft(2, '0'));
            }
            else {
                format = string.Format("{0}:{1}:{2}", hh.ToString().PadLeft(2, '0'), mm.ToString().PadLeft(2, '0'), ss.ToString().PadLeft(2, '0'));
            }

            textMesh.text = format;
        }

        public void setTime(int time) {
            
        }

        public void startCounting() {
            timer.Start();
        }


    }
}
