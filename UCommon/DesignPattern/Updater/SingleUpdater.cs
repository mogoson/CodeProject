/*************************************************************************
 *  Copyright © 2018-2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleUpdater.cs
 *  Description  :  Single updater.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  04/11/2020
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.DesignPattern;
using System.Collections;
using UnityEngine;

namespace MGS.UCommon.DesignPattern
{
    /// <summary>
    /// Single updater.
    /// </summary>
    public abstract class SingleUpdater<T> : Singleton<T>, IMonoUpdater where T : class
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
        protected SingleUpdater()
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

            IsTurnOn = true;
            SingleBehaviour.Instance.StartCoroutine(updater);
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

            IsTurnOn = false;
            SingleBehaviour.Instance.StopCoroutine(updater);
        }
        #endregion
    }
}