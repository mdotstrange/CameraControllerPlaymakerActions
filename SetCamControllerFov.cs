using UnityEngine;
using com.ootii.Cameras;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Sets the target FOV for the camera controller ")]
    public class SetCamControllerFov : FsmStateAction
    {
        [RequiredField]

        [CheckForComponent(typeof(CameraController))]
        [Tooltip("The owner")]
        public FsmOwnerDefault gameObject;
        public FsmFloat targetFOV;
        public FsmBool everyFrame;
        CameraController camcon;



        public override void Reset()
        {
            gameObject = null;

            everyFrame = true;


        }

        public override void OnEnter()
        {
            if (!everyFrame.Value)
            {
                DoSetFov();
                Finish();
            }

        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                DoSetFov();
            }
        }

        void DoSetFov()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                Debug.Log("NOT RUNNING");
                return;
            }


            camcon = go.GetComponent<CameraController>();

            camcon.TargetFOV = targetFOV.Value;
        
           



        }



    }
}