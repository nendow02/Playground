using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oculus.Interaction.Samples {
    public class GestureDetection : MonoBehaviour
    {
        private bool isThumbup = false;
        private bool isThumbdown = false;
        [SerializeField] private ActiveStateSelector thumbup;
        [SerializeField] private ActiveStateSelector thumbdown;
        [SerializeField] private GameObject cube;

        private Vector3 scale_inc = new Vector3(0.01f,0.01f,0.01f);
        // Start is called before the first frame update
        void Start()
        {
            thumbup.WhenSelected += () => {isThumbup = true;};
            thumbup.WhenUnselected += () => {isThumbup = false;};
            thumbdown.WhenSelected += () => {isThumbdown = true;};
            thumbdown.WhenUnselected += () => {isThumbdown = false;};
        }

        // Update is called once per frame
        void Update()
        {
         if(isThumbup) SizeUp();
         if(isThumbdown) SizeDown();   
        }

        private void SizeUp() {
            cube.transform.localScale += scale_inc;
            Debug.Log("thumb up detected");
        }

        private void SizeDown() {
            if(cube.transform.localScale.y > 0) {
                cube.transform.localScale -= scale_inc;
            }
            Debug.Log("thumb down detected");
        }
    }
}