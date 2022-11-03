using UnityEngine;

public class DrumController : MonoBehaviour
{
   [SerializeField] private HingeJoint _hingeJoint;
   [SerializeField] private float _velocity;

   private bool _isActive;
   private bool _isForward;
   private bool _isReverse;

   public void StartDrumRotation()
   {
      if (_isReverse && !_isActive)
      {
         SetVelocity(-_velocity);
         _isForward = false;
         _isActive = true;
         return;
      }

      if (!_isActive)
      {
         SetVelocity(_velocity);
         _isActive = true;
         _isForward = true;
      }
      
   }

   public void ReverseDrumRotation()
   {
      if (_isForward)
      {
         _isForward = false;
         _isReverse = true;
         if (_isActive)
         {
           SetVelocity(-_velocity);
         }
        
      }
      else
      {
         _isReverse = false;
         _isForward = true;
         if (_isActive)
         {
            SetVelocity(_velocity);
         }
         
      }
   }

   public void StopDrumRotation()
   {
      SetVelocity(0);
      _isActive = false;
   }
   private void SetVelocity(float velocity)
   {
      var hingeJointMotor = _hingeJoint.motor;
      hingeJointMotor.targetVelocity = velocity;
      _hingeJoint.motor = hingeJointMotor;
   }
   
   

   
   
}
