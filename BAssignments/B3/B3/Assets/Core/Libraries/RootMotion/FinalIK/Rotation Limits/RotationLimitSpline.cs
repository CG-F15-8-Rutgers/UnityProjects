using UnityEngine;
using System.Collections;

namespace RootMotion.FinalIK {

	/// <summary>
	/// Using a spline to limit the range of rotation on universal and ball-and-socket joints. 
	/// Reachable area is defined by an AnimationCurve orthogonally mapped onto a sphere.
	/// </summary>
	[AddComponentMenu("Scripts/RootMotion/Rotation Limits/Spline")]
	public class RotationLimitSpline : RotationLimit {
		
		#region Main Interface
		
		/// <summary>
		/// Limit of twist rotation around the main axis.
		/// </summary>
		public float twistLimit = 180;
		
		/// <summary>
		/// Set the spline keyframes.
		/// </summary>
		/// <param name='keyframes'>
		/// Keyframes.
		/// </param>
		public void SetSpline(Keyframe[] keyframes) {
			spline.keys = keyframes;
		}
		
		/*
		 * The AnimationCurve orthogonally mapped onto a sphere that defines the swing limits
		 * */
		[SerializeField][HideInInspector] public AnimationCurve spline;
		
		#endregion Main Interface
		
		/*
		 * Limits the rotation in the local space of this instance's Transform.
		 * */
		protected override Quaternion LimitRotation(Quaternion rotation) {		
			// Subtracting off-limits swing
			Quaternion swing = LimitSwing(rotation);
			
			// Apply twist limits
			return LimitTwist(swing, axis, secondaryAxis, twistLimit);
		}
		
		/*
		 * Apply the swing rotation limits
		 * */
		public Quaternion LimitSwing(Quaternion rotation) {
			if (axis == Vector3.zero) return rotation; // Ignore with zero axes
			if (rotation == Quaternion.identity) return rotation; // Assuming initial rotation is in the reachable area
			
			// Get the rotation angle orthogonal to Axis
			Vector3 swingAxis = rotation * axis;
			float angle = GetOrthogonalAngle(swingAxis, secondaryAxis, axis);
			
			// Convert angle from 180 to 360 degrees representation
			float dot = Vector3.Dot(swingAxis, crossAxis);
			if (dot < 0) angle = 180 + (180 - angle);
			
			// Evaluate the limit for this angle
			float limit = spline.Evaluate(angle);
			
			// Get the limited swing axis
			Quaternion swingRotation = Quaternion.FromToRotation(axis, swingAxis);
			Quaternion limitedSwingRotation = Quaternion.RotateTowards(Quaternion.identity, swingRotation, limit);
			
			// Rotation from current(illegal) swing rotation to the limited(legal) swing rotation
			Quaternion toLimits = Quaternion.FromToRotation(swingAxis, limitedSwingRotation * axis);
			
			// Subtract the illegal rotation
			return toLimits * rotation;
		}
	}
}
