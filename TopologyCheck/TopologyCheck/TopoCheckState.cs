namespace TopologyCheck
{
    using System;
    using TaskManage;

    public static class TopoCheckState
    {
        private static bool m_EditedState = false;
        private static bool m_MultiState = false;
        private static bool m_SingleState = false;
        private static int m_StateKind = 3;

        private static void SetTopoState()
        {
            if (m_StateKind == 1)
            {
                if (SingleState)
                {
                    EditTask.ToplogicChkState = ToplogicCheckState.Success;
                }
                else
                {
                    EditTask.ToplogicChkState = ToplogicCheckState.Failure;
                }
            }
            else if (m_StateKind == 2)
            {
                if (m_EditedState && m_SingleState)
                {
                    EditTask.ToplogicChkState = ToplogicCheckState.Success;
                }
                else
                {
                    EditTask.ToplogicChkState = ToplogicCheckState.Failure;
                }
            }
            else if (m_StateKind == 3)
            {
                if ((m_EditedState && m_SingleState) && m_MultiState)
                {
                    EditTask.ToplogicChkState = ToplogicCheckState.Success;
                }
                else
                {
                    EditTask.ToplogicChkState = ToplogicCheckState.Failure;
                }
            }
            else
            {
                EditTask.ToplogicChkState = ToplogicCheckState.Failure;
            }
        }

        public static bool EditedState
        {
            get
            {
                return m_EditedState;
            }
            set
            {
                m_EditedState = value;
                SetTopoState();
            }
        }

        public static bool MultiState
        {
            get
            {
                return m_MultiState;
            }
            set
            {
                m_MultiState = value;
                SetTopoState();
            }
        }

        public static bool SingleState
        {
            get
            {
                return m_SingleState;
            }
            set
            {
                m_SingleState = value;
                SetTopoState();
            }
        }

        public static int StateKind
        {
            get
            {
                return m_StateKind;
            }
            set
            {
                m_StateKind = value;
            }
        }
    }
}

