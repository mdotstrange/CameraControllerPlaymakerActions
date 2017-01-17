using UnityEngine;
using com.ootii.Cameras;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Sets the camera controller distance. ")]
    public class SetCameraDistance : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraController))]
        [Tooltip("The camera owner")]
        public FsmOwnerDefault gameObject;
        public FsmString modeToModify;
        public FsmFloat CameraDistance;
        [Tooltip("If false it will get the value")]
        public FsmBool set;
        public bool everyFrame;

        CameraController script;
        public override void Reset()
        {
            gameObject = null;
         
        }

        public override void OnEnter()
        {
            if(everyFrame == false)
            {
                DoSetCameraDistance();
                Finish();
            }        
        }

        public override void OnUpdate()
        {
            if(everyFrame == true)
            {
                DoSetCameraDistance();
            }       
        }

        void DoSetCameraDistance()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            script = go.GetComponent<CameraController>();

            CameraMotor motor = script.GetMotor(modeToModify.Value);

            if(set.Value == true)
            {
                motor.Distance = CameraDistance.Value;
             
            }

           else
            {
                CameraDistance.Value = motor.Distance;
             
            }
        }

    }
}