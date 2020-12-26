/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleUpdater.cs
 *  Description  :  Mono updater.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  04/11/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using UnityEngine;

namespace MGS.DesignPattern
{
    /// <summary>
    /// Mono updater.
    /// </summary>
    public abstract class MonoUpdater : IMonoUpdater
    {
        #region Field and Property
        /// <summary>
        /// Updater is turn on?
        /// </summary>
        public bool IsTurnOn { protected set; get; }

        /// <summary>
        /// Yield instruction.
        /// </summary>
        public object YieldInstruction { set; get; } = new WaitForEndOfFrame();

        /// <summary>
        /// Updater to update.
        /// </summary>
        protected IEnumerator updater;
        #endregion

        #region Protected Method
        /// <summary>
        /// Constructor.
        /// </summary>
        protected MonoUpdater()
        {
            updater = Update();
        }

        /// <summary>
        /// Processor update.
        /// </summary>
        protected IEnumerator Update()
        {
            while (IsTurnOn)
            {
                OnUpdate();
                yield return YieldInstruction;
            }
        }

        /// <summary>
        /// On update.
        /// </summary>
        protected abstract void OnUpdate();
        #endregion

        #region Public Method
        /// <summary>
        /// Turn on processor.
        /// </summary>
        public void TurnOn()
        {
            if (IsTurnOn)
            {
                return;
            }

            SingleBehaviour.Instance.StartCoroutine(updater);
            IsTurnOn = true;
        }

        /// <summary>
        /// Turn off processor.
        /// </summary>
        public void TurnOff()
        {
            if (!IsTurnOn)
            {
                return;
            }

            SingleBehaviour.Instance.StopCoroutine(updater);
            IsTurnOn = false;
        }
        #endregion
    }
}