using UnityEngine;
using com.ootii.Cameras;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.ScriptControl)]
    [Tooltip("Activates a camera motor ")]
    public class ActivateCameraMotor : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(CameraController))]
        [Tooltip("The owner")]
        public FsmOwnerDefault gameObject;
        [Tooltip("Name of motor to activate")]
        public FsmString modeToActivate;

        CameraController script;
        public override void Reset()
        {
            gameObject = null;
         
          
        }

        public override void OnEnter()
        {
                DoActivateMotor();
                Finish();
            
        }

      

        void DoActivateMotor()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            script = go.GetComponent<CameraController>();

            CameraMotor motor = script.GetMotor(modeToActivate.Value);

            script.ActivateMotor(motor);

                 
            return;


        }

    }
}