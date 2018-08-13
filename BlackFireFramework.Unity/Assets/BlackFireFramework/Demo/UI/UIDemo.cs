//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class UIDemo : MonoBehaviour
    {
        private IEnumerator Start()
        {
            BlackFire.Resource.LoadAsync(
                new ResourceAssetInfo("UI/MessageBoxWindow",typeof(UIWindow)), e =>
                {
                    
                    var windowTpl = e.AssetAgency.AcquireAsset(this) as UIWindow;
                    var window = BlackFire.UI.CreateWindow(windowTpl,1L,"System MessageBox","Default");
                    e.AssetAgency.RestoreAsset(this);
                    
                    Log.Debug(window.Logic==null);
                    window.Open();

                    if (window.Logic is IMessageBoxWindowLogic)
                    {
                        (window.Logic as IMessageBoxWindowLogic).SetContent("@~@");
                    }
                    
                    if (window.Logic is IColourfulMessageBoxWindowLogic)
                    {
                        (window.Logic as IColourfulMessageBoxWindowLogic).UseColourful();
                    }
                    
                    if (window.Logic is IShakeMessageBoxWindowLogic)
                    {
                        (window.Logic as IShakeMessageBoxWindowLogic).Shake();
                    }

                });
            
            yield return new WaitForSeconds(5f);

            BlackFire.UI.DestroyUIWindow(1L);
            Debug.Log("DestroyWindow Id:"+1L);
        }
    }
}