namespace GISControlsClass
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.SystemUI;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using Utilities;

    /// <summary>
    /// 控制的同步类
    /// </summary>
    public class ControlsSynchronizer
    {
        /// <summary>
        /// 封装各种地图的控件的ListView
        /// ArrayList：动态数组
        /// </summary>
        private ArrayList m_frameworkControls;
        /// <summary>
        /// 判断MapControl是否在控制当前视图
        /// </summary>
        private bool m_IsMapCtrlactive = true;
        /// <summary>
        /// ITool接口提供对定义工具的成员的访问。
        /// ITool类似于按钮，但它们也需要与应用程序的显示进行交互。放大命令是工具的一个很好的例子 - 您可以在重新绘制显示之前单击或拖动一个矩形在地图上，以更详细地显示地图内容。
        /// </summary>
        private ITool m_mapActiveTool;
        /// <summary>
        /// IMapControl4界面为使用键盘和鼠标导航MapControl的显示相关任务提供了额外的成员。
        /// IMapControl2接口是与MapControl相关的任何任务的起点，例如设置一般外观，设置地图和显示属性，添加和管理数据层和地图文档以及绘制和跟踪形状。
        /// </summary>
        private IMapControl4 m_mapControl;
        /// <summary>
        /// ITool接口提供对定义工具的成员的访问。
        /// ITool类似于按钮，但它们也需要与应用程序的显示进行交互。放大命令是工具的一个很好的例子 - 您可以在重新绘制显示之前单击或拖动一个矩形在地图上，以更详细地显示地图内容。
        /// </summary>
        private ITool m_pageLayoutActiveTool;
        /// <summary>
        /// IPageLayoutControl3接口为使用键盘和鼠标导航.
        /// IPageLayoutControl1是与PageLayoutControl相关的任何任务的起点，例如设置一般外观，设置页面和显示属性，添加和查找元素，加载地图文档和打印。
        /// 使用ITool界面查询内置工具的属性或创建自己的COM工具。
        /// 当您创建一个新的COM工具时，您需要在类代码中同时实现ICommand接口和ITool接口。使用ITool界面，您可以定义在鼠标移动，鼠标按钮按下/释放，键盘按键/释放，双击和右键单击等事件上发生的情况。
        /// </summary>
        private IPageLayoutControl3 m_pageLayoutControl;
        private const string mClassName = "GISControlsClass.ControlsSynchronizer";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        /// <summary>
        /// 控制的同步类的构造器：参数（IMapControl4，IPageLayoutControl3）
        /// </summary>
        /// <param name="mapControl"></param>
        /// <param name="pageLayoutControl"></param>
        public ControlsSynchronizer(IMapControl4 mapControl, IPageLayoutControl3 pageLayoutControl)
        {
            this.m_mapControl = mapControl;
            this.m_pageLayoutControl = pageLayoutControl;
            this.m_frameworkControls = new ArrayList();
        }

        /// <summary>
        /// 停用IPageLayoutControl，启用IMapControl4地图
        /// </summary>
        public void ActivateMap()
        {
            try
            {
                if ((this.m_pageLayoutControl == null) || (this.m_mapControl == null))
                {
                    throw new Exception("ControlsSynchronizer::ActivateMap:\r\nEither MapControl or PageLayoutControl are not initialized!");
                }//IPageLayoutControl3.CurrentTool属性当前为PageLayoutControl的活动工具。设置为无任何清除工具。
                //CurrentTool是用于交互的工具PageLayoutControl的显示。在将其设置为CurrentTool属性之前，请始终检查工具是否已启用，否则用户将能够使用实际禁用的工具。
                if (this.m_pageLayoutControl.CurrentTool != null)
                {
                    this.m_pageLayoutActiveTool = this.m_pageLayoutControl.CurrentTool;
                }//IActiveView.Deactivate方法另一个视图接管关联的窗口。
                //被称为停用当前活动视图。 例如，在自己关联的视图上调用Activate之前，查看命令停用（IActiveView :: Deactivate）当前视图（IMxDocument :: ActiveView）。
                this.m_pageLayoutControl.ActiveView.Deactivate();//停用IPageLayoutControl
                //调用将当前对象建立为活动视图。例如，在自己关联的视图上调用Activate之前，查看命令停用（IActiveView :: Deactivate）当前视图（IMxDocument :: ActiveView）。
                //当在MapDocument对象上使用IActiveView界面时，应始终先调用IActiveView :: Activate（），以正确初始化PageLayout或Map对象的显示。
                //在打开MXD之后，MxDocument和MapServer对象以及MapControl和PageLayoutControl都会自动初始化显示对象，但MapDocument不会这样做，所以在使用IActiveView的任何其他成员之前，您应该调用Activate（）。
                //如果您的应用程序有用户界面，则应使用应用程序客户区域的hWnd调用Activate（）。如果您的应用程序在后台运行并且没有Windows，您可以随时从GDI GetDesktopWindow（）函数（Win32 API的一部分）获取一个有效的hWnd。
                this.m_mapControl.ActiveView.Activate(this.m_mapControl.hWnd);//IMapControl4.hWnd属性处理与MapControl关联的窗口。操作环境通过分配一个句柄或hWnd来标识应用程序中的每个窗口，窗体和控件。 许多ArcObjects方法和Windows API调用需要hWnd作为参数。
                if (this.m_mapActiveTool != null)
                {
                    this.m_mapControl.CurrentTool = this.m_mapActiveTool;
                }
                this.m_IsMapCtrlactive = true;
                this.SetBuddies(this.m_mapControl.Object);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.ControlsSynchronizer", "ActivateMap", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void ActivatePageLayout()
        {
            try
            {
                if ((this.m_pageLayoutControl != null) && (this.m_mapControl != null))
                {
                    if (this.m_mapControl.CurrentTool != null)
                    {
                        this.m_mapActiveTool = this.m_mapControl.CurrentTool;
                    }
                    this.m_mapControl.ActiveView.Deactivate();
                    this.m_pageLayoutControl.ActiveView.Activate(this.m_pageLayoutControl.hWnd);
                    if (this.m_pageLayoutActiveTool != null)
                    {
                        this.m_pageLayoutControl.CurrentTool = this.m_pageLayoutActiveTool;
                    }
                    this.m_IsMapCtrlactive = false;
                    this.SetBuddies(this.m_pageLayoutControl.Object);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.ControlsSynchronizer", "ActivatePageLayout", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 将视图的各种容器（如AxMapControl、AxToolControl、AxPageLayerControl）添加进动态数组（ArrayList）m_frameworkControls
        /// </summary>
        /// <param name="control"></param>
        public void AddFrameworkControl(object control)
        {
            if (control == null)
            {
                throw new Exception("ControlsSynchronizer::AddFrameworkControl:\r\nAdded control is not initialized!");
            }//将视图的各种容器（如AxMapControl、AxToolControl、AxPageLayerControl）添加进动态数组m_frameworkControls
            this.m_frameworkControls.Add(control);
        }

        public void BindControls(bool activateMapFirst)
        {
            if ((this.m_pageLayoutControl == null) || (this.m_mapControl == null))
            {
                throw new Exception("ControlsSynchronizer::BindControls:\r\nEither MapControl or PageLayoutControl are not initialized!");
            }
            IMap map = new MapClass();
            map.Name = "Map";
            IMaps maps = new Maps();
            maps.Add(map);
            this.m_pageLayoutControl.PageLayout.ReplaceMaps(maps);
            this.m_mapControl.Map = map;
            this.m_pageLayoutActiveTool = null;
            this.m_mapActiveTool = null;
            if (activateMapFirst)
            {
                this.ActivateMap();
            }
            else
            {
                this.ActivatePageLayout();
            }
        }

        public void BindControls(IMapControl4 mapControl, IPageLayoutControl3 pageLayoutControl, bool activateMapFirst)
        {
            if ((mapControl == null) || (pageLayoutControl == null))
            {
                throw new Exception("ControlsSynchronizer::BindControls:\r\nEither MapControl or PageLayoutControl are not initialized!");
            }
            this.m_mapControl = this.MapControl;
            this.m_pageLayoutControl = pageLayoutControl;
            this.BindControls(activateMapFirst);
        }

        private bool CheckHas(string value, string[] str, out int i)
        {
            try
            {
                i = 0;
                while (i < str.Length)
                {
                    if (str[i].ToString() == value)
                    {
                        return true;
                    }
                    i++;
                }
                return false;
            }
            catch (Exception)
            {
                i = -1;
                return false;
            }
        }

        public void RemoveFrameworkControl(object control)
        {
            if (control == null)
            {
                throw new Exception("ControlsSynchronizer::RemoveFrameworkControl:\r\nControl to be removed is not initialized!");
            }
            this.m_frameworkControls.Remove(control);
        }

        public void RemoveFrameworkControlAt(int index)
        {
            if (this.m_frameworkControls.Count < index)
            {
                throw new Exception("ControlsSynchronizer::RemoveFrameworkControlAt:\r\nIndex is out of range!");
            }
            this.m_frameworkControls.RemoveAt(index);
        }

        public void ReplaceMap(IMap newMap)
        {
            if (newMap == null)
            {
                throw new Exception("ControlsSynchronizer::ReplaceMap:\r\nNew map for replacement is not initialized!");
            }
            if ((this.m_pageLayoutControl == null) || (this.m_mapControl == null))
            {
                throw new Exception("ControlsSynchronizer::ReplaceMap:\r\nEither MapControl or PageLayoutControl are not initialized!");
            }
            IMaps maps = new Maps();
            maps.Add(newMap);
            bool isMapCtrlactive = this.m_IsMapCtrlactive;
            this.ActivatePageLayout();
            this.m_pageLayoutControl.PageLayout.ReplaceMaps(maps);
            this.m_mapControl.Map = newMap;
            this.m_pageLayoutActiveTool = null;
            this.m_mapActiveTool = null;
            if (isMapCtrlactive)
            {
                this.ActivateMap();
                this.m_mapControl.ActiveView.Refresh();
            }
            else
            {
                this.ActivatePageLayout();
                this.m_pageLayoutControl.ActiveView.Refresh();
            }
        }

        /// <summary>
        /// 设置当前视图的伙伴控件
        /// </summary>
        /// <param name="buddy"></param>
        private void SetBuddies(object buddy)
        {
            try
            {
                if (buddy == null)
                {
                    throw new Exception("ControlsSynchronizer::SetBuddies:\r\nTarget Buddy Control is not initialized!");
                }
                foreach (object obj2 in this.m_frameworkControls)
                {//IToolbarControl接口提供对控制ToolbarControl(Esri工具栏控件)的成员的访问。
                    //IToolbarControl接口是与ToolBarControl相关的任何任务的起点，例如设置一般外观，设置好友控件，添加和删除命令，工具，工具控件，菜单和调色板以及自定义ToolbarControl的内容。
                    if (obj2 is IToolbarControl)
                    {
                        ((IToolbarControl)obj2).SetBuddyControl(buddy);
                    }//ITOCControl接口提供对控制TOCControl的成员的访问。
                    //ITOCControl接口是与TOCControl相关的任何任务的起始点，例如设置一般外观，设置好友控件，以及管理图层可视性和标签编辑。
                    else if (obj2 is ITOCControl)
                    {
                        ((ITOCControl)obj2).SetBuddyControl(buddy);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.ControlsSynchronizer", "SetBuddies", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetLegend(ILegend mapSurround)
        {
            try
            {
                ILegend legend = mapSurround;
                string str = "";
                if (this.m_mapControl.Map.Name.Contains("造林"))
                {
                    str = "ZaoLin";
                }
                else if (this.m_mapControl.Map.Name.Contains("采伐"))
                {
                    str = "CaiFa";
                }
                else if (this.m_mapControl.Map.Name.Contains("火灾"))
                {
                    str = "Fire";
                }
                else if (this.m_mapControl.Map.Name.Contains("征占用"))
                {
                    str = "ZZY";
                }
                else if (this.m_mapControl.Map.Name.Contains("灾害"))
                {
                    str = "ZRZH";
                }
                else if (this.m_mapControl.Map.Name.Contains("案件"))
                {
                    str = "AnJian";
                }
                else if (this.m_mapControl.Map.Name.Contains("变更小班"))
                {
                    str = "XB";
                }
                else if (this.m_mapControl.Map.Name.Contains("小班"))
                {
                    str = "XB2";
                }
                UtilFactory.GetConfigOpt().GetConfigValue("LegendLayer");
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue(str + "LegendLayer").Split(new char[] { ',' });
                string[] strArray2 = UtilFactory.GetConfigOpt().GetConfigValue(str + "LegendLayerNewColumn").Split(new char[] { ',' });
                UtilFactory.GetConfigOpt().GetConfigValue(str + "LegendLayerNewColumn").Split(new char[] { '1' });
                ArrayList list = new ArrayList();
                for (int i = 0; i < strArray.Length; i++)
                {
                    for (int j = 0; j < legend.ItemCount; j++)
                    {
                        if (legend.get_Item(j).Layer.Name == strArray[i])
                        {
                            list.Add(legend.get_Item(j));
                            if (strArray2[i] == "0")
                            {
                                if (legend.ItemCount > i)
                                {
                                    legend.get_Item(i).NewColumn = false;
                                }
                                else if ((strArray2[i] == "1") && (legend.ItemCount > i))
                                {
                                    legend.get_Item(i).NewColumn = true;
                                }
                            }
                            break;
                        }
                    }
                }
                if (list.Count > 0)
                {
                    legend.ClearItems();
                    for (int k = 0; k < list.Count; k++)
                    {
                        object obj1 = list[k];
                        legend.AddItem(list[k] as ILegendItem);
                    }
                }
                legend.AutoReorder = false;
                legend.AutoVisibility = false;
                int itemCount = legend.ItemCount;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.ControlsSynchronizer", "SetLegend", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public IMap SetMapOfMapToPagelayout()
        {
            try
            {
                if ((this.m_pageLayoutControl != null) && (this.m_mapControl != null))
                {
                    IGraphicsContainer graphicsContainer = this.m_pageLayoutControl.GraphicsContainer;
                    graphicsContainer.Reset();
                    IElement element = graphicsContainer.Next();
                    bool flag = false;
                    while (element != null)
                    {
                        if (element is IMapFrame)
                        {
                            IMapFrame frame = (IMapFrame)element;
                            frame.Map = this.m_mapControl.Map;
                            flag = true;
                        }
                        else if (!(element is IGraphicElement) && (element is IFrameElement))
                        {
                            IFrameElement element2 = element as IFrameElement;
                            if (element2 is IMapSurroundFrame)
                            {
                                IMapSurroundFrame frame2 = element2 as IMapSurroundFrame;
                                if (frame2.MapFrame != null)
                                {
                                    frame2.MapFrame.Map = this.m_mapControl.Map;
                                }
                                IMapSurround mapSurround = frame2.MapSurround;
                                mapSurround.Map = this.m_mapControl.Map;
                                if (mapSurround is IScaleBar)
                                {
                                    IScaleBar bar = (IScaleBar)mapSurround;
                                    bar.Map = this.m_mapControl.Map;
                                }
                                else if (mapSurround is IScaleText)
                                {
                                    IScaleText text = (IScaleText)mapSurround;
                                    text.Map = this.m_mapControl.Map;
                                }
                                else if (mapSurround is IScaleText2)
                                {
                                    IScaleText2 text1 = (IScaleText2)mapSurround;
                                }
                                else if (!(mapSurround is INorthArrow) && !(mapSurround is IDataGraphTElement))
                                {
                                    ILegend legend1 = mapSurround as ILegend;
                                }
                            }
                        }
                        element = graphicsContainer.Next();
                    }
                    if (flag)
                    {
                        return this.m_mapControl.Map;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GISControlsClass.ControlsSynchronizer", "SetMapOfMapToPagelayout", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        /// <summary>
        /// 设置PageLayOutControl1里的地图至MapControl中
        /// </summary>
        /// <returns></returns>
        public IMap SetMapOfPagelayoutToMap()
        {
            if ((this.m_pageLayoutControl != null) && (this.m_mapControl != null))
            {//IGraphicsContainer接口提供对控制图形容器的成员的访问。管理图形元素集合的对象实现此接口。例如，PageLayout，Map和FDOGraphicsLayer对象都实现了这个接口来提供对他们管理的图形元素的访问。
                //IPageLayoutControl3.GraphicsContainer属性PageLayoutControl包含的PageLayout对象的图形容器。
                //该属性将始终返回对PageLayout的GraphicsContainer的引用，而不是返回与Map相关联的任何GraphicsContainer。
                IGraphicsContainer graphicsContainer = this.m_pageLayoutControl.GraphicsContainer;
                graphicsContainer.Reset();//IGraphicsContainer.Reset方法重置内部游标，使Next返回第一个元素。
                //IElement接口提供对控制元素的成员的访问。
                //IElement是由所有Element对象（TextElement，PolygonElement，LineElement，MapSurroundFrame等）实现的通用接口。该界面提供对元素几何的访问，并包含用于绘制和执行命中测试的方法。
                //由IGraphicsContainer和IGraphicsContainerSelect对象获得并操纵的IElement对象。当开发人员想要操纵所选择的图形集时，最常使用IElement。
                //实现IElement的对象的几何类型根据元素的作用而有很大差异。实现IElement的每个对象的注释将列出对该特定元素有效的几何类型。
                for (IElement element = graphicsContainer.Next(); element != null; element = graphicsContainer.Next())//遍历容器中的元素
                {//IMapFrame接口提供对控制地图元素对象的成员的访问。
                    //IMapFrame是MapFrame对象的默认界面。界面的主要目的是让开发者访问存储在框架内的地图对象，并将其定位器矩形相关联。
                    if (element is IMapFrame)
                    {
                        IMapFrame frame = (IMapFrame)element;
                        this.m_mapControl.Map = frame.Map;//IMapFrame.Map属性相关地图。Map属性将返回框架中包含的地图对象。 当您想要获取地图时，请使用此界面。
                        return frame.Map;
                    }
                }
            }
            return null;
        }

        public object ActiveControl
        {
            get
            {
                if ((this.m_mapControl == null) || (this.m_pageLayoutControl == null))
                {
                    throw new Exception("ControlsSynchronizer::ActiveControl:\r\nEither MapControl or PageLayoutControl are not initialized!");
                }
                if (this.m_IsMapCtrlactive)
                {
                    return this.m_mapControl.Object;
                }
                return this.m_pageLayoutControl.Object;
            }
        }

        public string ActiveViewType
        {
            get
            {
                if (this.m_IsMapCtrlactive)
                {
                    return "MapControl";
                }
                return "PageLayoutControl";
            }
        }

        /// <summary>
        /// IMapControl4的构造器。
        /// 用于获取和设置IMapControl4的对象
        /// </summary>
        public IMapControl4 MapControl
        {
            get
            {
                return this.m_mapControl;
            }
            set
            {
                this.m_mapControl = value;
            }
        }


        /// <summary>
        /// IPageLayoutControl3的构造器。
        /// 用于获取和设置IPageLayoutControl3的对象
        /// </summary>
        public IPageLayoutControl3 PageLayoutControl
        {
            get
            {
                return this.m_pageLayoutControl;
            }
            set
            {
                this.m_pageLayoutControl = value;
            }
        }
    }
}

