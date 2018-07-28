//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class UIDemo : MonoBehaviour
    {
        private void Start()
        {
            BlackFire.Resource.LoadAsync(
                new ResourceAssetInfo("UI/MessageBoxWindow",typeof(UIWindow)), e =>
                {
                    
                    var window = e.AssetAgency.AcquireAsset(this) as UIWindow;
                    window = Instantiate<UIWindow>(window);
                    e.AssetAgency.RestoreAsset(this);

                    BlackFire.UI.CreateWindow(window,new WindowInfo(1,"System MessageBox","Default"));
                    
                    Log.Debug(window.Logic==null);
                    if (window.Logic is MessageBoxWindowLogic)
                    {
                        (window.Logic as MessageBoxWindowLogic).SetContent("@~@");
                        window.Open();
                    }
                    
                });
        }
    }
}