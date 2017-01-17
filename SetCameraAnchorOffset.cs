using UnityEngine;
using com.ootii.Cameras;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Sets the camera anchor offset for the camera script. ")]
    public class SetCameraAnchorOffset: FsmStateAction
    {
        [RequiredField]

        [CheckForComponent(typeof(CameraController))]
        [Tooltip("The owner")]
        public FsmOwnerDefault gameObject;
        public FsmFloat offset;
        public FsmBool everyFrame;
        CameraController cam;
        public override void Reset()
        {
            gameObject = null;
            everyFrame = true;


        }

        public override void OnEnter()
        {
            if (!everyFrame.Value)
            {
                DoSetAnchOffset();
                Finish();
            }

        }

        public override void OnUpdate()
        {
            if (everyFrame.Value)
            {
                DoSetAnchOffset();
            }
        }

        void DoSetAnchOffset()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
               
                return;
            }
            if(cam == null)
            {
                cam = go.GetComponent<CameraController>();
            }


            cam._AnchorOffset = new Vector3(0f, offset.Value, 0f);
          

          


        }

    }
}