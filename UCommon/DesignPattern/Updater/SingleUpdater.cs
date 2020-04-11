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

namespace MGS.UCommon.DesignPattern
{
    /// <summary>
    /// Single updater.
    /// </summary>
    public abstract class SingleUpdater : Singleton<SingleUpdater>, IMonoUpdater
    {
        #region Field and Property
        /// <summary>
        /// Updater is turn on?
        /// </summary>
        public bool IsTurnOn { protected set; get; }

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
        protected abstract IEnumerator Update();
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