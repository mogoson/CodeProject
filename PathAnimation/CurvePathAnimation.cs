/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CurvePathAnimation.cs
 *  Description  :  Define animation base on curve path.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/28/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.CurvePath;
using MGS.UCommon.UAnimation;
using UnityEngine;

namespace MGS.PathAnimation
{
    /// <summary>
    /// Animation base on curve path.
    /// </summary>
    [AddComponentMenu("MGS/PathAnimation/CurvePathAnimation")]
    public class CurvePathAnimation : MonoAnimation, IPathAnimation
    {
        #region Field and Property
        /// <summary>
        /// Path of animation.
        /// </summary>
        [Tooltip("Path of animation.")]
        [SerializeField]
        protected MonoCurvePath curvePath;

        /// <summary>
        /// Keep up mode on play animation.
        /// </summary>
        [HideInInspector]
        public KeepUpMode keepUp = KeepUpMode.WorldUp;

        /// <summary>
        /// Keep up reference transform.
        /// </summary>
        [HideInInspector]
        public Transform reference;

        /// <summary>
        /// Path for animation base on.
        /// </summary>
        public virtual ICurvePath Path { set; get; }

        /// <summary>
        /// Timer of animation.
        /// </summary>
        protected float timer = 0;

        /// <summary>
        /// Delta to calculate tangent.
        /// </summary>
        protected const float Delta = 0.05f;

        /// <summary>
        /// Direction of timer.
        /// </summary>
        protected int TimerDirection { get { return timer < 0 ? -1 : 1; } }

        /// <summary>
        /// Direction of speed.
        /// </summary>
        protected int SpeedDirection { get { return speed < 0 ? -1 : 1; } }
        #endregion

        #region Protected Method
        /// <summary>
        /// Awake animation.
        /// </summary>
        protected virtual void Awake()
        {
            Path = curvePath;
        }

        /// <summary>
        /// Update animation.
        /// </summary>
        protected virtual void Update()
        {
            timer += speed * Time.deltaTime;
            if (timer < 0 || timer > Path.Length)
            {
                switch (loop)
                {
                    case LoopMode.Once:
                        Stop();
                        return;

                    case LoopMode.Loop:
                        timer -= Path.Length * TimerDirection;
                        break;

                    case LoopMode.PingPong:
                        speed = -speed;
                        timer = Mathf.Clamp(timer, 0, Path.Length);
                        break;
                }
            }
            TowTransformOnPath(timer * Path.MaxKey / Path.Length);
        }

        /// <summary>
        /// Tow this transform base on path.
        /// </summary>
        /// <param name="key">Key of curve.</param>
        protected virtual void TowTransformOnPath(float key)
        {
            var timePos = Path.GetPointAt(key);
            var deltaPos = Path.GetPointAt(key + Delta * SpeedDirection);

            var worldUp = Vector3.up;
            switch (keepUp)
            {
                case KeepUpMode.TransformUp:
                    worldUp = transform.up;
                    break;

                case KeepUpMode.ReferenceForward:
                    if (reference)
                    {
                        worldUp = reference.forward;
                    }
                    break;

                case KeepUpMode.ReferenceForwardAsNormal:
                    if (reference)
                    {
                        var tangent = (deltaPos - timePos).normalized;
                        worldUp = Vector3.Cross(tangent, reference.forward);
                    }
                    break;
            }

            //Update position and look at tangent.
            transform.position = timePos;
            transform.LookAt(deltaPos, worldUp);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Rewind animation.
        /// </summary>
        /// <param name="progress">Progress of animation in the range[0~1]</param>
        public override void Rewind(float progress = 0)
        {
            progress = Mathf.Clamp01(progress);
            timer = Path.Length * progress;
            TowTransformOnPath(timer);
        }
        #endregion
    }
}