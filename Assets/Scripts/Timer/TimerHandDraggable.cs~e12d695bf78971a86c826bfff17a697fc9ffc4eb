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
        private Canvas buttonsCanvas;

        public void Awake() {
            textMesh = gameObject.GetComponentInChildren<TextMesh>();
            renderer = gameObject.GetComponent<Renderer>();
            material = renderer.material;
            buttonsCanvas = (Canvas) gameObject.GetComponentsInChildren<Canvas>(true).GetValue(1);
        }
        
        public override void OnFocusEnter() {
            base.OnFocusEnter();

            Debug.Log("Timer is focussed on!");
            material.color = highlightedColor;

            buttonsCanvas.gameObject.SetActive(true);
        }

        public override void OnFocusExit() {
            base.OnFocusExit();
            
            Debug.Log("Timer has been exitted!");
            material.color = primaryColor;

            buttonsCanvas.gameObject.SetActive(false);
        }

        private void onDestroy() {
            Destroy(material);
        }
    }
}
