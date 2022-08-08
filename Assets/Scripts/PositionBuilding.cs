using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PnTTechnicalInterviewTest
{
    public class PositionBuilding : MonoBehaviour
    {
        public GameObject Camera;
        public GameObject Marker;
        public GameObject ARObject;

        [SerializeField]
        private float _objectYOffset;
        [SerializeField]
        private float _objectAlignmentSpeed;
        [SerializeField]
        private float _objectRotationDegreesPerSecond;

        private float _currentObjectRotation;

        private void Start() {
            _currentObjectRotation = 0f;
        }

        void Update() {
            // Interpolate AR object position to above marker
            Vector3 targetBuildingPosition = Marker.transform.position + (Marker.transform.up * _objectYOffset);
            ARObject.transform.position = Vector3.Lerp(ARObject.transform.position, targetBuildingPosition, Time.deltaTime * _objectAlignmentSpeed);

            // Interpolate AR rotation to align with marker rotation (combining alignment and local rotation quaternions)
            ARObject.transform.rotation = Quaternion.Lerp(ARObject.transform.rotation, Quaternion.LookRotation(Marker.transform.forward, Marker.transform.up) * Quaternion.Euler(0f, _currentObjectRotation, 0f), Time.deltaTime * _objectAlignmentSpeed);

            // Rotate AR object by a given degrees per second
            _currentObjectRotation += (_objectRotationDegreesPerSecond * Time.deltaTime);
        }

        public void OnDeviceMotion( DeviceMotionEvent motionEvt ) {
        }
    }
}
