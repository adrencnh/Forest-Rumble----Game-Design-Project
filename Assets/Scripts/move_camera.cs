using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera : MonoBehaviour
{
        public Transform target;
        public float lerpSpeed = 1.5f;

        private Vector3 offset;

        private Vector3 targetPos;

        private void Start()
        {
            if (target == null){
                return;
            }

            offset = transform.position - target.position;
        }

        private void Update()
        {
            if (target == null) {
                return;
            }
            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }
}
