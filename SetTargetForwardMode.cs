using UnityEngine;
using com.ootii.Cameras;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Sets the camera controller into setTargetForward mode. ")]
    public class SetTargetForwardMode : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraController))]
        [Tooltip("The owner")]
        public FsmGameObject gameObject;
        public FsmVector3 target;
        public FsmFloat targetSpeed;

        CameraController script;
        public override void Reset()
        {
            gameObject = null;
            target = null;
        }

        public override void OnUpdate()
        {
            DoCamTargetMode();
          

        }



        void DoCamTargetMode()
        {
            if (script == null)
            {
                script = gameObject.Value.gameObject.GetComponent<CameraController>();
            }

            var heading = target.Value - gameObject.Value.gameObject.transform.position;

            script.SetTargetForward( heading, targetSpeed.Value);

         

         

          


        }

    }
}