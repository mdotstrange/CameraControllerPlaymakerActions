using UnityEngine;
using com.ootii.Cameras;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Resets the cam controller Yaw and Pitch ")]
    public class ResetCamController : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraController))]
        [Tooltip("The owner")]
        public FsmOwnerDefault gameObject;
        public FsmFloat targetPitch;
        public FsmFloat targetYaw;
        CameraController camcon;

        public override void Reset()
        {
            gameObject = null;       

        }

        public override void OnEnter()
        {
           
                DoResetCamCon();
                Finish();         

        }

      
        void DoResetCamCon()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                Debug.Log("NOT RUNNING");
                return;
            }


            camcon = go.GetComponent<CameraController>();

            camcon.SetTargetYawPitch(targetYaw.Value, targetPitch.Value, 0.5f, true);
          

        }



    }
}