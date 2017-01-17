using UnityEngine;
using com.ootii.Cameras;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Adds shake to camera controller ")]
    public class CameraControllerShake : FsmStateAction
    {
        [RequiredField]

        [CheckForComponent(typeof(CameraController))]



        [Tooltip("The owner")]
        public FsmOwnerDefault gameObject;

        public FsmFloat range;
        public FsmFloat strengthX;
        public FsmFloat strengthY;
        public FsmFloat duration;


 


        public FsmBool everyFrame;

        CameraController script;


        public override void Reset()
        {
            gameObject = null;

            everyFrame = true;


        }

        public override void OnEnter()
        {
            if (!everyFrame.Value)
            {
                DoCamShake();
                Finish();
            }

        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                DoCamShake();
            }
        }

        void DoCamShake()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                Debug.Log("NOT RUNNING");
                return;
            }




            script = go.GetComponent<CameraController>();

            script.Shake(range.Value, strengthX.Value, strengthY.Value, duration.Value);




        }

    }
}