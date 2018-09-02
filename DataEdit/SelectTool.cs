namespace DataEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.SystemUI;
    using System;
    using System.Collections;
    using System.Windows.Forms;

    public class SelectTool : BaseTool
    {
        private ArrayList mArrayLayer;
        private ArrayList mArraySelect;
        private const string mClassName = "PointTool";
        private IFeatureLayer mFeatureLayer;
        private IHookHelper mHookHelper;
        private UserControlInputData mMyParent;
        private ICommand pCom;
        private ITool pTool;

        public SelectTool(IFeatureLayer pLayer, object pParent)
        {
            try
            {
                this.mHookHelper = new HookHelperClass();
                this.mFeatureLayer = pLayer;
                this.mMyParent = pParent as UserControlInputData;
                base.m_caption = "选择要素";
                base.m_name = "SelectTool";
            }
            catch (Exception)
            {
            }
        }

        public override void OnClick()
        {
            try
            {
                this.pCom.OnClick();
            }
            catch (Exception)
            {
            }
        }

        public override void OnCreate(object hook)
        {
            try
            {
                if (this.mHookHelper == null)
                {
                    this.mHookHelper = new HookHelperClass();
                }
                this.mHookHelper.Hook = hook;
                if (hook == null)
                {
                    base.m_enabled = false;
                }
                else
                {
                    base.m_enabled = true;
                }
                this.pTool = new ControlsSelectFeaturesToolClass();
                this.pCom = this.pTool as ICommand;
                this.pCom.OnCreate(hook);
            }
            catch (Exception)
            {
            }
        }

        public override void OnKeyDown(int keyCode, int shift)
        {
            try
            {
                this.pTool.OnKeyDown(keyCode, shift);
            }
            catch (Exception)
            {
            }
        }

        public override void OnKeyUp(int keyCode, int shift)
        {
            try
            {
                this.pTool.OnKeyUp(keyCode, shift);
            }
            catch (Exception)
            {
            }
        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
            try
            {
                this.pTool.OnMouseDown(button, shift, x, y);
            }
            catch (Exception)
            {
            }
        }

        public override void OnMouseMove(int button, int shift, int x, int y)
        {
            try
            {
                this.pTool.OnMouseMove(button, shift, x, y);
            }
            catch (Exception)
            {
            }
        }

        public override void OnMouseUp(int button, int shift, int x, int y)
        {
            try
            {
                this.pTool.OnMouseUp(button, shift, x, y);
                if (this.mHookHelper.FocusMap.SelectionCount > 0)
                {
                    this.mMyParent.simpleButtonConvert.Enabled = true;
                }
                else
                {
                    this.mMyParent.simpleButtonConvert.Enabled = false;
                }
                this.mMyParent.SetSelectPoints();
            }
            catch (Exception)
            {
            }
        }

        private void SetList()
        {
            try
            {
                this.mHookHelper.FocusMap.ClearSelection();
                this.mArrayLayer.Clear();
                this.mArraySelect.Clear();
                IEnumLayer layer = null;
                try
                {
                    UID uid = new UIDClass();
                    uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";
                    layer = this.mHookHelper.FocusMap.get_Layers(uid, true);
                }
                catch (Exception)
                {
                    return;
                }
                layer.Reset();
                IFeatureLayer layer2 = null;
                int num = 0;
                ILayer layer3 = null;
                for (layer3 = layer.Next(); layer3 != null; layer3 = layer.Next())
                {
                    if (layer3 is IFeatureLayer)
                    {
                        layer2 = layer3 as IFeatureLayer;
                        this.mArrayLayer.Add(layer2);
                        this.mArraySelect.Add(layer2.Selectable);
                        layer2.Selectable = false;
                        num++;
                    }
                }
                this.mFeatureLayer.Selectable = true;
            }
            catch (Exception)
            {
            }
        }

        public override bool Enabled
        {
            get
            {
                try
                {
                    if (this.mHookHelper == null)
                    {
                        return false;
                    }
                    if (this.mHookHelper.FocusMap == null)
                    {
                        return false;
                    }
                    if (this.mHookHelper.FocusMap.LayerCount == 0)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public UserControl ParentForm
        {
            set
            {
                this.mMyParent = value as UserControlInputData;
            }
        }
    }
}

