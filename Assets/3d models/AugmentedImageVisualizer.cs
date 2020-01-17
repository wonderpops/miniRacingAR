//-----------------------------------------------------------------------
// <copyright file="AugmentedImageVisualizer.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;

    /// <summary>
    /// Uses 4 frame corner objects to visualize an AugmentedImage.
    /// </summary>
    public class AugmentedImageVisualizer : MonoBehaviour
    {
    public enum  roads 
    { 
        begin = 0,
        forward = 1,
        right= 2,
        left = 3,
        loopup = 4,
        loopdown = 5,
    }
        /// <summary>
        /// The AugmentedImage to visualize.
        /// </summary>
        public AugmentedImage Image;
        public GameObject cnstr;

        /// <summary>
        /// A model for the lower left corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject FrameLowerLeft;
        public roads type = roads.begin;
        public int myNum;
        public bool isConnected = false;

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Start() {
            cnstr = GameObject.Find("EventSystem");
            var figures = cnstr.GetComponent<constructor>().objects;
            myNum = figures.Count-1;
        }
        public void Update()
        {
            var figures = cnstr.GetComponent<constructor>().objects;
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                FrameLowerLeft.SetActive(false);
                myNum = figures.Count-1;
                return;
            }

            
            
            var previousFigure = figures[myNum].transform.GetChild(0);
            var angle = cnstr.GetComponent<constructor>().angle;

            if ((Math.Abs(FrameLowerLeft.transform.position.x - previousFigure.transform.position.x) < 0.05f) && (Math.Abs(FrameLowerLeft.transform.position.y - previousFigure.transform.position.y) < 0.05)){
                if (!isConnected){
                    //cnstr.GetComponent<constructor>().placeNext(, FrameLowerLeft.angle);
                    //FrameLowerLeft.transform.position = previousFigure.transform.position;
                    //FrameLowerLeft.transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    cnstr.GetComponent<constructor>().placeNext((int)type);
                    //right = FrameLowerLeft;
                    //FrameLowerLeft = null;
                    FrameLowerLeft.GetComponentInChildren<MeshRenderer>().enabled = false;
                    isConnected = true;
                }
            } 
            //previousFigure = figures[myNum - 2].transform.GetChild(0);
            if ((Math.Abs(FrameLowerLeft.transform.position.x - previousFigure.transform.position.x) > 0.05f) || (Math.Abs(FrameLowerLeft.transform.position.y - previousFigure.transform.position.y) > 0.05)) {
                if (isConnected){
                    for (int i=myNum+1; i<figures.Count; i++){
                        cnstr.GetComponent<constructor>().del();
                    }
                    //Destroy(cnstr.GetComponent<constructor>().objects[myNum+1]);
                    //cnstr.GetComponent<constructor>().objects.RemoveAt(myNum+1);
                    
                    isConnected = false;
                    FrameLowerLeft.GetComponentInChildren<MeshRenderer>().enabled = true;
                }
                
            }
            FrameLowerLeft.SetActive(true);
        }
           
    }
}
