using UnityEngine;
using com.ootii.Helpers;
using com.ootii.Input;
using com.ootii.Cameras;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Enables/disables the camera controller script. ")]
    public class EnableCameraController : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraController))]
        [Tooltip("The owner")]
        public FsmOwnerDefault gameObject;
        public FsmBool enabled;
        public FsmBool everyFrame;
        CameraController script;

        public override void Reset()
        {
            gameObject = null;
            enabled = null;
            everyFrame = true;


        }

        public override void OnEnter()
        {
            if (!everyFrame.Value)
            {
                DoEnableAdvCam();
                Finish();
            }

        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                DoEnableAdvCam();
            }
        }

        void DoEnableAdvCam()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {

                return;
            }

            script = go.GetComponent<CameraController>();
            script.enabled = enabled.Value;
        }

    }
}