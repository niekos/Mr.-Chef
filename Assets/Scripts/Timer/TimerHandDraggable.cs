using HoloToolkit.Unity.InputModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Timer {
    class TimerHandDraggable : HandDraggable {

        public Color primaryColor;
        public Color highlightedColor;
        private Renderer renderer;
        private Material material;
        private TextMesh textMesh;

        public void Awake() {
            textMesh = gameObject.GetComponentInChildren<TextMesh>();
            renderer = gameObject.GetComponent<Renderer>();
            material = renderer.material;
        }
        

        public override void OnFocusEnter() {
            base.OnFocusEnter();

            Debug.Log("Timer is focussed on!");
            material.color = highlightedColor;
        }

        public override void OnFocusExit() {
            base.OnFocusExit();

            Debug.Log("Timer is exited!");
            material.color = primaryColor;
        }

        private void onDestroy() {
            Destroy(material);
        }
    }
}
