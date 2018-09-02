namespace gylandzzytj
{
    using System;

    public static class ForestConditions
    {
        private static ForestConditionCollection _Conditions = new ForestConditionCollection();

        static ForestConditions()
        {
            _Conditions.Add(new ForestCondition("有林地", "(left(DI_LEI, 1) = '1')"));
            _Conditions.Add(new ForestCondition("疏林地", "(left(DI_LEI, 1) = '2')"));
            _Conditions.Add(new ForestCondition("灌木林地", "(left(DI_LEI, 1) = '3')"));
            _Conditions.Add(new ForestCondition("未成林地", "(left(DI_LEI, 1) = '4')"));
            _Conditions.Add(new ForestCondition("苗圃地", "(left(DI_LEI, 1) = '5')"));
            _Conditions.Add(new ForestCondition("无立木林地", "(left(DI_LEI, 1) = '6')"));
            _Conditions.Add(new ForestCondition("宜林地", "(left(DI_LEI, 1) = '7')"));
            _Conditions.Add(new ForestCondition("林业辅助生产林地", "(DI_LEI = '800')"));
            _Conditions.Add(new ForestCondition("公益林", "(left(SEN_LIN_LB, 1) = '1')"));
            _Conditions.Add(new ForestCondition("商品林", "(left(SEN_LIN_LB, 1) = '2')"));
            _Conditions.Add(new ForestCondition("重点公益林", "(SEN_LIN_LB = '11')"));
            _Conditions.Add(new ForestCondition("一般公益林", "(SEN_LIN_LB = '12')"));
            _Conditions.Add(new ForestCondition("重点商品林", "(SEN_LIN_LB = '21')"));
            _Conditions.Add(new ForestCondition("一般商品林", "(SEN_LIN_LB = '22')"));
            _Conditions.Add(new ForestCondition("防护林", "(left(LIN_ZHONG, 2) = '11')"));
            _Conditions.Add(new ForestCondition("水源涵养林", "(LIN_ZHONG = '111')"));
            _Conditions.Add(new ForestCondition("水土保持林", "(LIN_ZHONG = '112')"));
            _Conditions.Add(new ForestCondition("防风固沙林", "(LIN_ZHONG = '113')"));
            _Conditions.Add(new ForestCondition("农田牧场防护林", "(LIN_ZHONG = '114')"));
            _Conditions.Add(new ForestCondition("护岸林", "(LIN_ZHONG = '115')"));
            _Conditions.Add(new ForestCondition("护路林", "(LIN_ZHONG = '116')"));
            _Conditions.Add(new ForestCondition("其它防护林", "(LIN_ZHONG = '117')"));
            _Conditions.Add(new ForestCondition("特用林", "(left(LIN_ZHONG, 2) = '12')"));
            _Conditions.Add(new ForestCondition("国防林", "(LIN_ZHONG = '121')"));
            _Conditions.Add(new ForestCondition("实验林", "(LIN_ZHONG = '122')"));
            _Conditions.Add(new ForestCondition("母树林", "(LIN_ZHONG = '123')"));
            _Conditions.Add(new ForestCondition("环境保护林", "(LIN_ZHONG = '124')"));
            _Conditions.Add(new ForestCondition("风景林", "(LIN_ZHONG = '125')"));
            _Conditions.Add(new ForestCondition("名胜古迹和纪念林", "(LIN_ZHONG = '126')"));
            _Conditions.Add(new ForestCondition("自然保护林", "(LIN_ZHONG = '127')"));
        }

        public static ForestCondition GetCondition(string name)
        {
            return _Conditions[name];
        }
    }
}

