/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuForm.cs
 *  Description  :  Interface of custom context menu form.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  4/12/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.UGUI
{
    /// <summary>
    /// Interface of custom context menu form.
    /// </summary>
    public interface IContextMenuForm : IForm
    {
        #region Property
        /// <summary>
        /// Handler of contex menu form.
        /// </summary>
        IContextMenuFormHandler Handler { set; get; }
        #endregion

        #region Method
        /// <summary>
        /// Refresh the elements of menu base on element datas.
        /// </summary>
        /// <param name="elementDatas">Data of menu elements.</param>
        void RefreshElements(IEnumerable<ContextMenuElementData> elementDatas);

        /// <summary>
        /// Disable menu items by tags.
        /// </summary>
        /// <param name="tags">Tags of menu items.</param>
        void DisableItems(IEnumerable<string> tags);
        #endregion
    }
}