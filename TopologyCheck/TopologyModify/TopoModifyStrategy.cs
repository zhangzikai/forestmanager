namespace TopologyCheck.TopologyModify
{
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.SystemUI;
    using System;
    using System.Collections.Generic;

    public class TopoModifyStrategy
    {
        private IMapControl4 _mapControl;
        private int _strategyIndex;
        protected string[] _strategyNames;
        protected List<ITool> _tools;

        public TopoModifyStrategy()
        {
        }

        public TopoModifyStrategy(IMapControl4 pControl)
        {
            this._mapControl = pControl;
        }

        protected void SetCommand(int pIndex)
        {
            ITool tool = null;
            if ((this._tools != null) && (this._tools.Count >= (pIndex + 1)))
            {
                tool = this._tools[pIndex];
            }
            if (tool != null)
            {
                ((ICommand) tool).OnCreate(this._mapControl);
                this._mapControl.CurrentTool = tool;
            }
        }

        public IMapControl4 MapControl
        {
            get
            {
                return this._mapControl;
            }
            set
            {
                this._mapControl = value;
            }
        }

        public int StrategyIndex
        {
            set
            {
                this._strategyIndex = value;
                this.SetCommand(this._strategyIndex);
            }
        }

        public string[] StrategyNames
        {
            get
            {
                return this._strategyNames;
            }
        }

        public List<ITool> Tools
        {
            get
            {
                return this._tools;
            }
            set
            {
                this._tools = value;
            }
        }
    }
}

