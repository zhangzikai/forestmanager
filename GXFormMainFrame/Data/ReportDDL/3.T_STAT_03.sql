IF OBJECT_ID('T_STAT_03_JS')IS NOT NULL DROP VIEW T_STAT_03_JS
GO
CREATE VIEW T_STAT_03_JS AS 
	
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '2' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB IN ('021','022') AND SEN_LIN_LB NOT IN ('021','022')
	
	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '3' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB = '021' AND SEN_LIN_LB <>'021'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '4' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021' and  Q_LIN_ZHONG  in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND SEN_LIN_LB <>'021' and  LIN_ZHONG  not in ( '230','231','232','233','240','250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '5' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021'  AND Q_LIN_ZHONG in ( '230','231','232','233')
	AND SEN_LIN_LB <>'021' AND LIN_ZHONG not  in ( '230','231','232','233')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '6' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021'  and Q_LIN_ZHONG='240'
	AND SEN_LIN_LB <>'021' and  LIN_ZHONG<>'240'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '7' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021' AND Q_LIN_ZHONG in ('250','251','252','253','254','255')
	AND SEN_LIN_LB <>'021' AND LIN_ZHONG not in ('250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '8' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='021' and Q_LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') and Q_DL<>'0200'
	AND SEN_LIN_LB <>'021' and LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	
	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '9' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' AND SEN_LIN_LB <>'022'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '10' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' and Q_LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND SEN_LIN_LB <>'022' and LIN_ZHONG not in ( '230','231','232','233','240','250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '11' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' AND Q_LIN_ZHONG in ( '230','231','232','233')
	AND SEN_LIN_LB <>'022' AND LIN_ZHONG not in ( '230','231','232','233')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '12' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022'  AND Q_LIN_ZHONG='240'
	AND SEN_LIN_LB <>'022' AND LIN_ZHONG<>'240'


	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '13' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' AND Q_LIN_ZHONG in ('250','251','252','253','254','255')
	AND SEN_LIN_LB <>'022' AND LIN_ZHONG not in ('250','251','252','253','254','255')


	UNION ALL SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '14' AS DYG
	FROM T_STAT_BH
	where Q_SEN_LIN_LB='022' and Q_LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') and Q_DL<>'0200'
	AND SEN_LIN_LB <>'022' and LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255');
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
	where SEN_LIN_LB='021' and  DL IN ('0111','0112','0113','0131') and LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')


	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '5' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='021'and DL in ('0110','0111','0112','0113','0131') and LIN_ZHONG in ( '230','231','232','233')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '6' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='021'and DL in ('0110','0111','0112','0113','0131')  and LIN_ZHONG='240'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '7' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='021'and DL in ('0110','0111','0112','0113','0131')  and LIN_ZHONG in ('250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '8' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='021'and DL in ('0140','0150','0160','0170','0180','0120','0132')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '9' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '10' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022' and  DL IN ('0111','0112','0113','0131') and LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '11' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022'and DL in ('0110','0111','0112','0113','0131')  and LIN_ZHONG in ( '230','231','232','233')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '12' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022' and DL in ('0110','0111','0112','0113','0131')  and LIN_ZHONG='240'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '13' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022'and DL in ('0110','0111','0112','0113','0131')  and LIN_ZHONG in ('250','251','252','253','254','255')


	UNION ALL SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '14' AS DYG
	FROM T_STAT_XZ
	where SEN_LIN_LB='022' and DL in ('0140','0150','0160','0170','0180','0120','0132')
GO
IF OBJECT_ID('T_STAT_03_XZ')IS NOT NULL DROP VIEW T_STAT_03_XZ
GO
CREATE VIEW T_STAT_03_XZ AS 
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '2' AS DYG
	FROM T_STAT_BH 
	where SEN_LIN_LB IN ('021','022') AND Q_SEN_LIN_LB  NOT IN ('021','022') 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '3' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND Q_SEN_LIN_LB <>'021' 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '4' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021'  AND LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND Q_SEN_LIN_LB <>'021' AND Q_LIN_ZHONG not in ( '230','231','232','233','240','250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '5' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND LIN_ZHONG in ( '230','231','232','233')
	AND Q_SEN_LIN_LB <>'021'  AND Q_LIN_ZHONG not in ( '230','231','232','233')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '6' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND LIN_ZHONG='240'
	and  Q_SEN_LIN_LB <> '021' AND Q_LIN_ZHONG <> '240' 

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '7' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' AND LIN_ZHONG in ('250','251','252','253','254','255')
	AND Q_SEN_LIN_LB <>'021' AND Q_LIN_ZHONG not in ('250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '8' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='021' and LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') AND DL<>'0200'
	AND Q_SEN_LIN_LB <>'021'  and Q_LIN_ZHONG  in ( '230','231','232','233','240','250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '9' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022' AND Q_SEN_LIN_LB <> '022'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '10' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022'  AND LIN_ZHONG in ( '230','231','232','233','240','250','251','252','253','254','255')
	AND Q_SEN_LIN_LB <> '022' AND Q_LIN_ZHONG  not  in ( '230','231','232','233','240','250','251','252','253','254','255')

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '11' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022' AND LIN_ZHONG in ( '230','231','232','233')
	AND Q_SEN_LIN_LB <> '022' AND Q_LIN_ZHONG  not in ( '230','231','232','233')
	
	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '12' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022'  AND LIN_ZHONG='240'
	AND Q_SEN_LIN_LB <> '022'  AND Q_LIN_ZHONG<>'240'

	union all
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '13' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022' and  LIN_ZHONG in ('250','251','252','253','254','255')
	AND Q_SEN_LIN_LB <> '022' and  Q_LIN_ZHONG not  in ('250','251','252','253','254','255')

	UNION ALL SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, '14' AS DYG
	FROM T_STAT_BH
	where SEN_LIN_LB='022' and  LIN_ZHONG NOT in ( '230','231','232','233','240','250','251','252','253','254','255') AND DL<>'0200'
	AND Q_SEN_LIN_LB <> '022' and  Q_LIN_ZHONG  in ( '230','231','232','233','240','250','251','252','253','254','255')
GO
IF OBJECT_ID('T_STAT_03_JZ')IS NOT NULL DROP VIEW T_STAT_03_JZ
GO
CREATE VIEW T_STAT_03_JZ AS 
	SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , MIAN_JI, DYG
	FROM T_STAT_03_XZ

	UNION ALL SELECT SHENG, SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , -abs(MIAN_JI), DYG
	FROM T_STAT_03_JS
GO
IF OBJECT_ID('T_STAT_03_HB')IS NOT NULL DROP VIEW T_STAT_03_HB
GO
CREATE VIEW T_STAT_03_HB AS 
	SELECT SHENG, SHI, XIAN, (XIAN + XIANG) AS XIANG, CUN, LIN_YE_JU ,(LIN_YE_JU + LIN_CHANG ) AS LIN_CHANG ,LIN_BAN , MIAN_JI, '1' AS STAT, DYG
	FROM T_STAT_03_NX

	UNION all
	SELECT SHENG, SHI, XIAN, (XIAN + XIANG) AS XIANG, CUN, LIN_YE_JU ,(LIN_YE_JU + LIN_CHANG ) AS LIN_CHANG ,LIN_BAN , MIAN_JI, '2' AS STAT, DYG
	FROM T_STAT_03_XZ

	UNION ALL
	SELECT SHENG, SHI, XIAN, (XIAN + XIANG) AS XIANG, CUN, LIN_YE_JU ,(LIN_YE_JU + LIN_CHANG ) AS LIN_CHANG ,LIN_BAN , MIAN_JI, '3' AS STAT, DYG
	FROM T_STAT_03_JS

	UNION ALL SELECT SHENG, SHI, XIAN, (XIAN + XIANG) AS XIANG, CUN, LIN_YE_JU ,(LIN_YE_JU + LIN_CHANG ) AS LIN_CHANG ,LIN_BAN , MIAN_JI, '4' AS STAT, DYG
	FROM T_STAT_03_JZ
GO
IF OBJECT_ID('T_STAT_03_TMP')IS NOT NULL DROP VIEW T_STAT_03_TMP
GO
CREATE VIEW T_STAT_03_TMP AS 
	SELECT
		CASE GROUPING(XIAN) WHEN 1 THEN '00' ELSE XIAN END AS XIAN,
		CASE GROUPING(XIANG) WHEN 1 THEN '00' ELSE XIANG END AS XIANG,
		CASE GROUPING(STAT) WHEN 1 THEN '00' ELSE STAT END AS STAT,
		CASE GROUPING(DYG) WHEN 1 THEN '00' ELSE DYG END AS DYG,	
		SUM(MIAN_JI) AS MIAN_JI
	  FROM T_STAT_03_HB 
	  GROUP BY XIAN,XIANG,STAT,DYG WITH  CUBE
GO
IF OBJECT_ID('T_STAT_03_DT')IS NOT NULL DROP VIEW T_STAT_03_DT
GO
CREATE VIEW T_STAT_03_DT AS 
	SELECT * FROM T_STAT_03_TMP WHERE XIAN<>'00' AND stat<>'00' AND DYG<>'00'

GO
IF OBJECT_ID('T_STAT_03')IS NOT NULL DROP VIEW T_STAT_03
GO
CREATE VIEW T_STAT_03 AS
  select 
	case XIANG when '00' then XIAN  ELSE XIANG end  AS FLD1,
	STAT as FLD2,
	max(case DYG when '2' then mian_ji  end )as FLD3,
	max(case DYG when '3' then mian_ji  end )as FLD4,
	max(case DYG when '4' then mian_ji  end )as FLD5,
	max(case DYG when '5' then mian_ji  end )as FLD6,
	max(case DYG when '6' then mian_ji  end )as FLD7,
	max(case DYG when '7' then mian_ji  end )as FLD8,
	max(case DYG when '8' then mian_ji  end )as FLD9,
	max(case DYG when '9' then mian_ji  end )as FLD10,
	max(case DYG when '10' then mian_ji  end )as FLD11,
	max(case DYG when '11' then mian_ji  end) as FLD12,
	max(case DYG when '12' then mian_ji  end )as FLD13,
	max(case DYG when '13' then mian_ji  end )as FLD14,
	max(case DYG when '14' then mian_ji  end) as FLD15 
  from T_STAT_03_DT
  group by XIAN,xiang,stat