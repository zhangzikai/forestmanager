namespace MainFrameBase
{
    using System;

    public interface IMainFrame
    {
        void InitializeBaseButton();
        void InitializeButtonEditTool();
        void InitializeButtonPageLayout();
        void InitializeControlEvents();
        void InitializeEditValue();
        bool InitializeForm();
        void InitializeGISControls();
        void InitializeMapControl();
        void InitSynchronizer();
        void SetButtonEnabled();
        void SetButtonTooltip();
        void SetButtonVisible();
        void SetFormText();

        string EditCode { get; set; }

        string EditKind { get; set; }

        string EditKind2 { get; set; }
    }
}

