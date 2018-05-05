//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace BlackFireFramework.Editor
{
    public sealed class PackageWindow : EditorWindowBase<PackageWindow>
    {
        private Vector2 m_ScrollPosition;
        
        private Dictionary<string, bool> m_FoldOutDic = new Dictionary<string, bool>();

        private Dictionary<string,List<Item>> m_ItemDic = new Dictionary<string,List<Item>>();

        private string m_ServerAPIUrl = "http://localhost/packages/api.json";



        private void DrawFoldOut(string text,Action callback)
        {
            if (!m_FoldOutDic.ContainsKey(text))
            {
                m_FoldOutDic.Add(text,false);
            }
            if (m_FoldOutDic[text] = BlackFireEditorGUI.FoldOut(text,m_FoldOutDic[text]))
            {
                if (null!= callback)
                {
                    callback.Invoke();
                }
            }
        }

        private void AddPackegInfo(string classify,List<ItemData> list)
        {
            if (!m_ItemDic.ContainsKey(classify))
            {
                ExistsOrCreateFolder(BlackFireEditor.PackagePath+classify);
                m_ItemDic.Add(classify, new List<Item>());
            }

            for (int i = 0; i < list.Count; i++)
            {
                var item = new Item(classify,"Get", 50, Color.white,list[i]);
                item.OnGetButtonClickCallback = Item_OnClickCallback;
                m_ItemDic[classify].Add(item);
            }

        }




        #region Behaviour

        private void OnEnable()
        {
            RequestServerAPI();
        }


        protected override void OnDrawWindow()
        {
            m_ScrollPosition = GUILayout.BeginScrollView(m_ScrollPosition);

            #region 导航项

            BlackFireEditorGUI.BoxHorizontalLayout(()=> {

                #region 导航栏目按钮

                BlackFireEditorGUI.BoxHorizontalLayout(() => {

                    BlackFireEditorGUI.Button("Fold", Color.white, 70, () => {

                        List<string> mdfList = new List<string>();
                        foreach (var kv in m_FoldOutDic)
                        {
                            mdfList.Add(kv.Key);
                        }
                        for (int i = 0; i < mdfList.Count; i++)
                        {
                            m_FoldOutDic[mdfList[i]] = false;
                        }

                    });
                    BlackFireEditorGUI.Button("Unfold", Color.white, 70, () => {

                        List<string> mdfList = new List<string>();
                        foreach (var kv in m_FoldOutDic)
                        {
                            mdfList.Add(kv.Key);
                        }
                        for (int i = 0; i < mdfList.Count; i++)
                        {
                            m_FoldOutDic[mdfList[i]] = true;
                        }

                    });
                    BlackFireEditorGUI.Button("Update", Color.white, 70, () => {

                        foreach (var kv in m_ItemDic)
                        {
                            foreach (var item in kv.Value)
                            {
                                if (null != item.HttpDownloader)
                                {
                                    item.HttpDownloader.StopDownload();
                                }
                            }
                        }

                        m_ItemDic.Clear();
                        //请求服务器接口地址。

                        RequestServerAPI();

                    });

                });
               


                #endregion

                #region 服务器接口地址
                BlackFireEditorGUI.Label("◉",Color.green,20,21);
                BlackFireEditorGUI.Label(string.Format("Server: {0}", m_ServerAPIUrl), Color.grey,19);
                #endregion
            });

            BlackFireEditorGUI.BoxHorizontalLayout(() => {

                #region 搜索栏

                BlackFireEditorGUI.HorizontalLayout(()=> {

                    GUILayout.TextField(string.Empty);

                    BlackFireEditorGUI.Button("Search", Color.white, 70);
                    BlackFireEditorGUI.Button("Clear", Color.white, 70);

                });

                    #endregion

            });

            BlackFireEditorGUI.BoxHorizontalLayout(() => {

                #region 搜索结果栏
                BlackFireEditorGUI.BoxHorizontalLayout(()=> {

                    BlackFireEditorGUI.HorizontalLayout(() => {
                        BlackFireEditorGUI.Label("Result:", Color.white, 52, 13);
                        BlackFireEditorGUI.Label("11 ", Color.green, 20, 13);
                        BlackFireEditorGUI.Label("Records", Color.white, 70, 13);
                    });

                });

                #endregion
            });

            BlackFireEditorGUI.BoxVerticalLayout(() =>
            {
                BlackFireEditorGUI.BoxHorizontalLayout(() => {
                    BlackFireEditorGUI.Label("Result............");
                });

                BlackFireEditorGUI.BoxHorizontalLayout(() => {
                    BlackFireEditorGUI.Label("Result............");
                });

                BlackFireEditorGUI.BoxHorizontalLayout(() => {
                    BlackFireEditorGUI.Label("Result............");
                });
            });

            #endregion

            #region 包选项

            if (0<m_ItemDic.Count)
                BlackFireEditorGUI.BoxVerticalLayout(()=> {

                foreach (var kv in m_ItemDic)
                {
                    DrawFoldOut(kv.Key, () =>
                    {
                        for (int i = 0; i < kv.Value.Count; i++)
                        {
                            kv.Value[i].OnDraw();
                        }

                    });
                }

            });
            
            #endregion

            GUILayout.EndScrollView();

        }


        #endregion


        private void Item_OnClickCallback(Item item)
        {
            if (!item.Lock)
            {
                item.SetButton("Get",Color.white, 50);
            }

            DownloadPackage(item); //下载
        }

        private void DownloadPackage(Item item)
        {
            item.Lock = true;
            item.SetButton("↓...", Color.black,100);

            var saveDir = BlackFireEditor.PackageTempPath + item.ItemData.Name; //保存zip跟tmp文件的路径
            var extractPath = BlackFireEditor.PackagePath + item.Classify; //解压路径
            ExistsOrCreateFolder(saveDir);
            ExistsOrCreateFolder(extractPath);

            var savePath = saveDir + "/." + item.ItemData.Name + "_" + item.ItemData.Version + ".zip";
         
            //如果下载文件已经存在
            if (File.Exists(savePath))
            {
                item.Lock = false;
                item.SetButton("Get", Color.white, 50);
                Extract(item, savePath, extractPath); //继续解压。
                return;
            }

            //下载
            ThreadPool.QueueUserWorkItem(state=> {
                item.HttpDownloader = new HttpDownloader(new HttpDownloadInfo()
                {
                    Url = item.ItemData.Url,
                    DownloadBufferUnit = 1024 * 3,
                    TempFileExtension = ".tmp",
                    SavePath = savePath
                }
                );

                item.HttpDownloader.OnDownloadProgress += (sender, args) => {  item.ButtonName = string.Format("↓ {0:00.00}%", args.DownloadProgress * 100f); };
                item.HttpDownloader.OnDownloadSuccess += (sender, args) =>  {  Extract(item,savePath,extractPath); };
                item.HttpDownloader.OnDownloadFailure += (sender, args) =>  {  item.ButtonColor = Color.red; item.ButtonName = "Failure"; item.Lock = false; };
                item.HttpDownloader.StartDownload();
            });

        }

        private void Extract(Item item,string sourcePath,string targetExtractPath)
        {
            item.SetButton("❖...", Color.gray, 100);

            Utility.Zip.UnZipFile(sourcePath, targetExtractPath + "/." + item.ItemData.Name, (sender, args) =>
            {
                item.ButtonName = string.Format("❖ {0:00.00}%", args.UnZipProgress * 100f);

            },(sender,args)=> {

                item.ButtonColor = Color.green; item.ButtonName = "Success"; item.Lock = false;
                if (Directory.Exists(targetExtractPath + "/" + item.ItemData.Name))
                {
                    Directory.Delete(targetExtractPath + "/" + item.ItemData.Name,true);
                }
                else
                {
                    DirectoryInfo info = new DirectoryInfo(targetExtractPath + "/." + item.ItemData.Name);
                    info.MoveTo(targetExtractPath + "/" + item.ItemData.Name);
                }
               // RefreshAssets();
            });

        }

        private void ExistsOrCreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void RefreshAssets()
        {
            m_RefreshFlag = true;
        }

        private bool m_RefreshFlag;

        private void UpdateRefreshAssetsInstruction()
        {
            if (m_RefreshFlag)
            {
                m_RefreshFlag = false;
                AssetDatabase.Refresh();
            }
            
        }

        private Job.Token m_Token = new Job.Token();

        /// <summary>
        /// 请求服务器。
        /// </summary>
        private void RequestServerAPI()
        {
            ThreadPool.QueueUserWorkItem(token=> {

                Debug.Log("QueueUserWorkItem...");

                var json = BlackFireFramework.Utility.Http.Get(m_ServerAPIUrl,string.Empty);

                Debug.Log(json);

            },m_Token);

            AddPackegInfo("AI",
                new List<ItemData>()
                {
                        new ItemData("1.0.2", "Test", "http://p5gxertb0.bkt.clouddn.com/TestPackage.zip"),
                        new ItemData("1.0.0", "Test1", "http://p5gxertb0.bkt.clouddn.com/1.0.0.zip"),
                        new ItemData("1.0.0", "Test1", "http://p5gxertb0.bkt.clouddn.com/1.0.0.zip"),
                        new ItemData("1.0.0", "Test1", "http://p5gxertb0.bkt.clouddn.com/1.0.0.zip"),
                        new ItemData("1.0.0", "Test1", "http://p5gxertb0.bkt.clouddn.com/1.0.0.zip"),
                        new ItemData("1.0.0", "Test1", "http://p5gxertb0.bkt.clouddn.com/1.0.0.zip"),
                        new ItemData("1.0.0", "Test1", "http://p5gxertb0.bkt.clouddn.com/1.0.0.zip"),
                        new ItemData("1.0.0", "Test1", "http://p5gxertb0.bkt.clouddn.com/1.0.0.zip"),
                        new ItemData("1.0.0", "Test1", "http://p5gxertb0.bkt.clouddn.com/1.0.0.zip"),

                });

            AddPackegInfo("UI",
                new List<ItemData>()
                {
                        new ItemData("1.0.2", "Test", "http://p5gxertb0.bkt.clouddn.com/TestPackage.zip"),
                        new ItemData("1.0.0", "Test1", "http://p5gxertb0.bkt.clouddn.com/1.0.0.zip"),

                });

            AddPackegInfo("Json",
                new List<ItemData>()
                {
                        new ItemData("1.0.2", "Test", "http://p5gxertb0.bkt.clouddn.com/TestPackage.zip"),
                        new ItemData("1.0.0", "Test1", "http://p5gxertb0.bkt.clouddn.com/1.0.0.zip"),

                });

        }


        #region Build-in Type


        private sealed class ItemData
        {
            public ItemData(string version, string name, string url) 
            {
                Version = version;
                Name = name;
                Url = url;
            }

            public string Version { get; private set; }

            public string Name { get; private set; }

            public string Url { get; private set; }

           
        }

        private sealed class Item
        {
            public const string ItemContentFormat = "Name: {0} Version:{1} Url:{2}";
            public bool Lock { get; set; }

            public string Classify { get; private set; }

            public string ButtonName { get; set; }

            public int ButtonWidth { get; set; }

            public Color ButtonColor { get; set; }

            public string Content { get; private set; }

            public ItemData ItemData { get; private set; }

            public HttpDownloader HttpDownloader { get; set; }


            public Action<Item> OnGetButtonClickCallback;
            public Action<Item> OnMoreButtonClickCallback;


            public Item(string classify,string buttonName,int buttonWidth,Color buttonColor,ItemData itemData)
            {
                Classify = classify;
                ButtonName = buttonName;
                ButtonWidth = buttonWidth;
                ButtonColor = buttonColor;
                ItemData = itemData;
                Content = string.Format(ItemContentFormat,itemData.Name,itemData.Version, itemData.Url);
            }


            public void OnDraw()
            {
                BlackFireEditorGUI.BoxHorizontalLayout(() => {

                    BlackFireEditorGUI.BoxHorizontalLayout(()=> {

                        BlackFireEditorGUI.Button(ButtonName, ButtonColor, ButtonWidth, () => {

                            if (!Lock && null != OnGetButtonClickCallback)
                            {
                                OnGetButtonClickCallback.Invoke(this);
                            }

                        });

                        BlackFireEditorGUI.Button("More", Color.white, ButtonWidth, () => {

                            if (!Lock && null != OnMoreButtonClickCallback)
                            {
                                OnMoreButtonClickCallback.Invoke(this);
                            }

                        });

                    });


                    BlackFireEditorGUI.Label(Content, Color.cyan);

                    BlackFireEditorGUI.Space(1);
                });
            }

            public void SetButton(string name,Color color,int width)
            {
                ButtonName = name;
                ButtonColor = color;
                ButtonWidth = width;
            }
        }


        #endregion


    }
}
