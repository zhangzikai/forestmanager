IF OBJECT_ID('T_STAT_03_JS_ZY')IS NOT NULL DROP VIEW T_STAT_03_JS_ZY
GO
CREATE VIEW T_STAT_03_JS_ZY AS 
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '2' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB IN ('021','022') AND SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))
	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '3' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB = '021'  AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '4' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021' and  Q_LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '5' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021'  AND Q_LIN_ZHONG in ( '230','231','232','233')
	AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))
	

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '6' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021' AND  Q_LIN_ZHONG='240'
	AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))
	

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '7' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021' AND Q_LIN_ZHONG in ('250','251','252','253','254','255')
	AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '8' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021'and Q_LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') AND Q_DL<>'0200'
	AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))
	
	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '9' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '10' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' and  Q_LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '11' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' AND Q_LIN_ZHONG in ( '230','231','232','233')
	AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '12' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022'  AND Q_LIN_ZHONG='240'
	AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '13' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' AND Q_LIN_ZHONG in ('250','251','252','253','254','255')
	AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	UNION ALL SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '14' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' and Q_LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') and Q_DL<>'0200'
	AND SEN_LIN_LB IN('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))
GO
IF OBJECT_ID('T_STAT_03_JS_ZC')IS NOT NULL DROP VIEW T_STAT_03_JS_ZC
GO
CREATE VIEW T_STAT_03_JS_ZC AS 
	
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '2' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB IN ('021','022') AND SEN_LIN_LB NOT IN ('021','022')
	
	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '3' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB = '021' AND SEN_LIN_LB NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '4' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021' and  Q_LIN_ZHONG  in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND SEN_LIN_LB NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '5' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021'  AND Q_LIN_ZHONG in ( '230','231','232','233')
	AND SEN_LIN_LB NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '6' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021'  and Q_LIN_ZHONG='240'
    AND SEN_LIN_LB NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '7' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021' AND Q_LIN_ZHONG in ('250','251','252','253','254','255')
	AND SEN_LIN_LB NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '8' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021' and Q_LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') and Q_DL<>'0200'
	AND SEN_LIN_LB NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '9' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' AND SEN_LIN_LB NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '10' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' and Q_LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND SEN_LIN_LB NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '11' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' AND Q_LIN_ZHONG in ( '230','231','232','233')
	AND SEN_LIN_LB NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '12' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022'  AND Q_LIN_ZHONG='240'
		AND SEN_LIN_LB NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '13' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' AND Q_LIN_ZHONG in ('250','251','252','253','254','255')
	AND SEN_LIN_LB NOT IN ('021','022')

	UNION ALL SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '14' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' and Q_LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') and Q_DL<>'0200'
	AND SEN_LIN_LB NOT IN ('021','022');
GO
IF OBJECT_ID('T_STAT_03_NX')IS NOT NULL DROP VIEW T_STAT_03_NX
GO
CREATE VIEW T_STAT_03_NX AS 
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '2' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '3' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='021'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '4' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='021'  and LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')


	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '5' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='021' and LIN_ZHONG in ( '230','231','232','233')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '6' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='021' and LIN_ZHONG='240'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '7' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='021' and LIN_ZHONG in ('250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '8' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='021'and LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') and DL<>'0200'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '9' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '10' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022' and LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '11' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022'  and LIN_ZHONG in ( '230','231','232','233')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '12' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022'   and LIN_ZHONG='240'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '13' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022'  and LIN_ZHONG in ('250','251','252','253','254','255')


	UNION ALL SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '14' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022' and LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') and DL<>'0200'
GO
IF OBJECT_ID('T_STAT_03_XZ_ZY')IS NOT NULL DROP VIEW T_STAT_03_XZ_ZY
GO
CREATE VIEW T_STAT_03_XZ_ZY AS 
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '2' AS DYG
	FROM T_STAT_BH 
	where SEN_LIN_LB IN ('021','022') AND Q_SEN_LIN_LB  IN ('021','022') 
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))
	

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '3' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021'  AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '4' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021'  AND LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '5' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND LIN_ZHONG in ( '230','231','232','233')
	AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '6' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND LIN_ZHONG='240'
	 AND Q_SEN_LIN_LB  IN ('021','022')
	 and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '7' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND LIN_ZHONG in ('250','251','252','253','254','255')
	AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '8' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021'and LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') AND DL<>'0200'
	AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '9' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022'  AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))
	

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '10' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022'  AND LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '11' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022' AND LIN_ZHONG in ( '230','231','232','233')
	AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))
	
	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '12' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022'  AND LIN_ZHONG='240'
	AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '13' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022'and  LIN_ZHONG in ('250','251','252','253','254','255')
	AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

	UNION ALL SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '14' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022' and  LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') AND DL<>'0200'
	AND Q_SEN_LIN_LB  IN ('021','022')
	and ((Q_SEN_LIN_LB=SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG) or (Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG=LIN_ZHONG) or(Q_SEN_LIN_LB<> SEN_LIN_LB and Q_LIN_ZHONG<>LIN_ZHONG))

GO
IF OBJECT_ID('T_STAT_03_XZ_ZR')IS NOT NULL DROP VIEW T_STAT_03_XZ_ZR
GO
CREATE VIEW T_STAT_03_XZ_ZR AS 
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '2' AS DYG
	FROM T_STAT_BH 
	where SEN_LIN_LB IN ('021','022') AND Q_SEN_LIN_LB  NOT IN ('021','022') 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '3' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND Q_SEN_LIN_LB  NOT IN ('021','022') 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '4' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021'  AND LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND Q_SEN_LIN_LB  NOT IN ('021','022') 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '5' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND LIN_ZHONG in ( '230','231','232','233')
	AND Q_SEN_LIN_LB  NOT IN ('021','022') 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '6' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND LIN_ZHONG='240'
	and  Q_SEN_LIN_LB <> '021' AND Q_LIN_ZHONG <> '240' AND Q_SEN_LIN_LB  IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '7' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND LIN_ZHONG in ('250','251','252','253','254','255')
	AND Q_SEN_LIN_LB  NOT IN ('021','022') 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '8' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021'and LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') AND DL<>'0200'
	AND Q_SEN_LIN_LB  NOT IN ('021','022') 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '9' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022' AND Q_SEN_LIN_LB <> '022' AND Q_SEN_LIN_LB  NOT IN ('021','022')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '10' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022'  AND LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND Q_SEN_LIN_LB  NOT IN ('021','022') 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '11' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022' AND LIN_ZHONG in ( '230','231','232','233')
	AND Q_SEN_LIN_LB  NOT IN ('021','022') 
	
	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '12' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022'  AND LIN_ZHONG='240'
	AND Q_SEN_LIN_LB  NOT IN ('021','022') 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '13' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022'and  LIN_ZHONG in ('250','251','252','253','254','255')
	AND Q_SEN_LIN_LB  NOT IN ('021','022') 

	UNION ALL SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '14' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022' and  LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') AND DL<>'0200'
	AND Q_SEN_LIN_LB  NOT IN ('021','022') 
GO
IF OBJECT_ID('T_STAT_03_JZ')IS NOT NULL DROP VIEW T_STAT_03_JZ
GO
CREATE VIEW T_STAT_03_JZ AS 
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, DYG
	FROM T_STAT_03_XZ_ZR

	UNION ALL SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , -abs(MIAN_JI), DYG
	FROM T_STAT_03_JS_ZC
GO
IF OBJECT_ID('T_STAT_03_HB')IS NOT NULL DROP VIEW T_STAT_03_HB
GO
CREATE VIEW T_STAT_03_HB AS 
	SELECT SHENG, SHI, XIAN, (XIAN + XIANG) AS XIANG, CUN, LIN_YE_JU ,(LIN_YE_JU + LIN_CHANG ) AS LIN_CHANG ,LIN_BAN , MIAN_JI, '1' AS STAT, '11'as STAT_N,DYG
	FROM T_STAT_03_NX

	UNION all
	SELECT SHENG, SHI, XIAN, (XIAN + XIANG) AS XIANG, CUN, LIN_YE_JU ,(LIN_YE_JU + LIN_CHANG ) AS LIN_CHANG ,LIN_BAN , MIAN_JI, '2' AS STAT,'21' AS STAT_N, DYG
	FROM T_STAT_03_XZ_ZY
	UNION all
	SELECT SHENG, SHI, XIAN, (XIAN + XIANG) AS XIANG, CUN, LIN_YE_JU ,(LIN_YE_JU + LIN_CHANG ) AS LIN_CHANG ,LIN_BAN , MIAN_JI, '2' AS STAT,'22' AS STAT_N, DYG
	FROM T_STAT_03_XZ_ZR

	UNION ALL
	SELECT SHENG, SHI, XIAN, (XIAN + XIANG) AS XIANG, CUN, LIN_YE_JU ,(LIN_YE_JU + LIN_CHANG ) AS LIN_CHANG ,LIN_BAN , MIAN_JI, '3' AS STAT,'31' AS STAT_N, DYG
	FROM T_STAT_03_JS_ZY
	UNION ALL
	SELECT SHENG, SHI, XIAN, (XIAN + XIANG) AS XIANG, CUN, LIN_YE_JU ,(LIN_YE_JU + LIN_CHANG ) AS LIN_CHANG ,LIN_BAN , MIAN_JI, '3' AS STAT,'32' AS STAT_N, DYG
	FROM T_STAT_03_JS_ZC

	UNION ALL SELECT SHENG, SHI, XIAN, (XIAN + XIANG) AS XIANG, CUN, LIN_YE_JU ,(LIN_YE_JU + LIN_CHANG ) AS LIN_CHANG ,LIN_BAN , MIAN_JI, '4' AS STAT,'41' AS STAT_N, DYG
	FROM T_STAT_03_JZ
GO
IF OBJECT_ID('T_STAT_03_TMP')IS NOT NULL DROP VIEW T_STAT_03_TMP
GO
CREATE VIEW T_STAT_03_TMP AS 
	SELECT
		CASE GROUPING(XIAN) WHEN 1 THEN '00' ELSE XIAN END AS XIAN,
		CASE GROUPING(XIANG) WHEN 1 THEN '00' ELSE XIANG END AS XIANG,
		CASE GROUPING(STAT) WHEN 1 THEN '00' ELSE STAT END AS STAT,
		CASE GROUPING(STAT_N) WHEN 1 THEN '00' ELSE STAT_N END AS STAT_N,
		CASE GROUPING(DYG) WHEN 1 THEN '00' ELSE DYG END AS DYG,	
		SUM(MIAN_JI) AS MIAN_JI
	  FROM T_STAT_03_HB 
	  GROUP BY XIAN,XIANG,STAT,STAT_N,DYG WITH  CUBE
GO
IF OBJECT_ID('T_STAT_03_DT')IS NOT NULL DROP VIEW T_STAT_03_DT
GO
CREATE VIEW T_STAT_03_DT AS 
	SELECT * FROM T_STAT_03_TMP WHERE XIAN<>'00' AND stat<>'00' AND DYG<>'00' AND STAT_N<>'00'

GO
IF OBJECT_ID('T_STAT_03')IS NOT NULL DROP VIEW T_STAT_03
GO
CREATE VIEW T_STAT_03 AS
  select 
	case XIANG when '00' then XIAN  ELSE XIANG end  AS FLD1,
	STAT as FLD2,
	case STAT_N when '11' then '��״' when '21' then 'ת��' when '22' then 'ת��' when '31' then 'ת��' when '32' then 'ת��' when '41' then 'ת��-ת��' else STAT_N end as FLD3,
	max(case DYG when '2' then mian_ji  end )as FLD4,
	max(case DYG when '3' then mian_ji  end )as FLD5,
	max(case DYG when '4' then mian_ji  end )as FLD6,
	max(case DYG when '5' then mian_ji  end )as FLD7,
	max(case DYG when '6' then mian_ji  end )as FLD8,
	max(case DYG when '7' then mian_ji  end )as FLD9,
	max(case DYG when '8' then mian_ji  end )as FLD10,
	max(case DYG when '9' then mian_ji  end )as FLD11,
	max(case DYG when '10' then mian_ji  end )as FLD12,
	max(case DYG when '11' then mian_ji  end) as FLD13,
	max(case DYG when '12' then mian_ji  end )as FLD14,
	max(case DYG when '13' then mian_ji  end )as FLD15,
	max(case DYG when '14' then mian_ji  end) as FLD16
  from T_STAT_03_DT
  group by XIAN,xiang,stat,STAT_N
