using UnityEngine;
using com.ootii.Cameras;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Sets the camera anchor for the camera controller script. ")]
    public class SetCameraAnchorGameObject : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraController))]
        [Tooltip("The owner")]
        public FsmOwnerDefault gameObject;
        public FsmGameObject anchor;
        private Transform ankTR;
        public FsmBool everyFrame;
        CameraController ank;

        public override void Reset()
        {
            gameObject = null;

            everyFrame = true;


        }

        public override void OnEnter()
        {
            if (!everyFrame.Value)
            {
                DoSetCamAnchorGame();
                Finish();
            }

        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                DoSetCamAnchorGame();
            }
        }

        void DoSetCamAnchorGame()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                Debug.Log("NOT RUNNING");
                return;
            }


            ank = go.GetComponent<CameraController>();
            Transform thisTR = anchor.Value.gameObject.transform;
            ankTR = thisTR.transform;
            ank.Anchor = ankTR;
            ank._Anchor = ankTR;

        }

    }
}