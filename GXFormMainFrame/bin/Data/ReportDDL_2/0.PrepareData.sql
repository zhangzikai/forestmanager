CREATE PROCEDURE PrepareSTATData(@LindDataTable varchar(50),@LindBHTable varchar(50),@BHFilter varchar(250))
AS 
	declare @cerror int,@tc int,@ErrorMessage NVARCHAR(4000),@ErrorSeverity INT,@ErrorState INT
BEGIN
	BEGIN TRY
		SET @cerror=0
		IF OBJECT_ID('T_STAT_XZ')IS NOT NULL DROP VIEW T_STAT_XZ
		EXEC('CREATE VIEW T_STAT_XZ AS 
			SELECT SHENG, SUBSTRING(XIAN,3,2) AS SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , ROUND(MIAN_JI,2) AS MIAN_JI,DI_MAO,
			(case
			  when LD_QS  IS   NULL  then ''90''
			  when LD_QS  =   ''''   then ''91''
			  when LD_QS  =   '' ''  then ''92''
			  when LD_QS IS NOT NULL then LD_QS END)  AS LD_QS,
			(case
			  when SEN_LIN_LB  IS   NULL  then ''990''
			  when SEN_LIN_LB  =   ''''   then ''991''
			  when SEN_LIN_LB  =   '' ''  then ''992''
			  when SEN_LIN_LB IS NOT NULL then SEN_LIN_LB END)  AS SEN_LIN_LB,
			(case
			  when SHI_QUAN_D  IS   NULL  then ''90''
			  when SHI_QUAN_D  =   ''''   then ''91''
			  when SHI_QUAN_D  =   '' ''  then ''92''
			  when SHI_QUAN_D IS NOT NULL then SHI_QUAN_D END)  AS SHI_QUAN_D,
			  
			(case
			  when LIN_ZHONG  IS   NULL  then ''990''
			  when LIN_ZHONG  =   ''''  then ''991''
			  when LIN_ZHONG  =   '' ''  then ''992''
			  when LIN_ZHONG IS NOT NULL then LIN_ZHONG END)  AS LIN_ZHONG,
			(case
			  when DI_LEI  =  ''0111'' then ''0111''
			  when DI_LEI  =  ''0112'' then ''0112''
			  when DI_LEI  =  ''0113'' then ''0113''
			  when DI_LEI  =  ''0120'' then ''0120''
			  when DI_LEI  =  ''0131'' then ''0131''
			  when DI_LEI  =  ''0132'' then ''0132''
			  when DI_LEI in (''0140'',''0141'',''0142'') then ''0140''
			  when DI_LEI  =  ''0150'' then ''0150''
			  when DI_LEI in (''0160'',''0161'',''0162'',''0163'',''1631'',''1632'',''1633'',''1634'') then ''0160''
			  when DI_LEI in (''0170'',''0171'',''0172'',''0173'') then ''0170''
			  when DI_LEI  =  ''0180'' then ''0180''
			  when DI_LEI NOT IN (''0110'',''0130'',''0111'',''0112'',
			  ''0113'',''0120'',''0131'',''0132'',''0140'',''0141'',''0142'',''0150'', ''0160'',''0161'',''0162'',''0163'',''1631'',''1632'',''1633'',''1634'', ''0170'',''0171'',''0172'',''0173'',''0180'') then ''0200'' END)  AS DL
			FROM '+@LindDataTable)
		IF OBJECT_ID('T_STAT_BH')IS NOT NULL DROP VIEW T_STAT_BH
		--创建变化数据视图，并调整代码数据
		EXEC('CREATE VIEW T_STAT_BH AS 
			SELECT SHENG, SUBSTRING(XIAN,3,2) AS SHI, XIAN, XIANG, CUN, LIN_YE_JU ,LIN_CHANG ,LIN_BAN , BHYY, ROUND(MIAN_JI,2) AS MIAN_JI,BH_DJ,Q_BH_DJ,
			(case
			  when LD_QS  IS   NULL  then ''90''  --未填写权属代码调整为90
			  when LD_QS  =   ''''   then ''91''    --权属为空调整为91
			  when LD_QS  =   '' ''  then ''92''	--权属为空调整为92
			  when LD_QS IS NOT NULL then LD_QS END) AS LD_QS, --填有权属则仍按原权属
			(case
			  when SEN_LIN_LB  IS   NULL  then ''990''
			  when SEN_LIN_LB  =   ''''   then ''991''
			  when SEN_LIN_LB  =   '' ''  then ''992''
			  when SEN_LIN_LB IS NOT NULL then SEN_LIN_LB END)  AS  SEN_LIN_LB,
			(case
			  when SHI_QUAN_D  IS   NULL  then ''90''
			  when SHI_QUAN_D  =   ''''   then ''91''
			  when SHI_QUAN_D  =   '' ''  then ''92''
			  when SHI_QUAN_D IS NOT NULL then SHI_QUAN_D END) AS  SHI_QUAN_D,
			  
			(case
			  when LIN_ZHONG  IS   NULL  then ''990''
			  when LIN_ZHONG  =   ''''   then ''991''
			  when LIN_ZHONG  =   '' ''  then ''992''
			  when LIN_ZHONG IS NOT NULL then LIN_ZHONG END) AS  LIN_ZHONG,
			(case
			  when Q_LD_QS  IS   NULL  then ''90''
			  when Q_LD_QS  =   ''''  then ''91''
			  when Q_LD_QS  =   '' ''  then ''92''
			  when Q_LD_QS IS NOT NULL then Q_LD_QS END) AS  Q_LD_QS,
			(case
			  when Q_SEN_LB  IS   NULL  then ''990''
			  when Q_SEN_LB  =   ''''  then ''991''
			  when Q_SEN_LB  =   '' ''  then ''992''
			  when Q_SEN_LB IS NOT NULL then Q_SEN_LB END) AS  Q_SEN_LIN_LB,
			(case
			  when Q_SQ_D  IS   NULL  then ''90''
			  when Q_SQ_D  =   ''''  then ''91''
			  when Q_SQ_D  =   '' ''  then ''92''
			  when Q_SQ_D IS NOT NULL then Q_SQ_D END) AS  Q_SHI_QUAN_D,
			(case
			  when Q_L_Z  IS   NULL  then ''990''
			  when Q_L_Z  =   ''''  then ''991''
			  when Q_L_Z  =   '' ''  then ''992''
			  when Q_L_Z IS NOT NULL then Q_L_Z END) AS  Q_LIN_ZHONG,
			(case
			  when DI_LEI  =  ''0111'' then ''0111''					--乔木林
			  when DI_LEI  =  ''0112'' then ''0112''					--红树林
			  when DI_LEI  =  ''0113'' then ''0113''					--竹林
			  when DI_LEI  =  ''0120'' then ''0120''					--红树林地
			  when DI_LEI  =  ''0131'' then ''0131''					--国家特规
			  when DI_LEI  =  ''0132'' then ''0132''					--其他灌木
			  when DI_LEI in (''0140'',''0141'',''0142'') then ''0140''		--未成林地
			  when DI_LEI  =  ''0150'' then ''0150''					--苗圃
			  when DI_LEI in (''0160'',''0161'',''0162'',''0163'',''1631'',''1632'',''1633'',''1634'') then ''0160'' --无立木
			  when DI_LEI in (''0170'',''0171'',''0172'',''0173'') then ''0170'' --宜林地
			  when DI_LEI  =  ''0180'' then ''0180''						--林业辅助地
			  when DI_LEI NOT IN (''0110'',''0130'',''0111'',''0112'',''0113'',''0120'',''0131'',''0132'',''0140'',
				''0141'',''0142'',''0150'', ''0160'',''0161'',''0162'',''0163'',''1631'',''1632'',''1633'',''1634'', 
				''0170'',''0171'',''0172'',''0173'',''0180'') then ''0200''  --非林
			  END) AS  DL,
			(case
			  when Q_DI_LEI  =  ''0111'' then ''0111''
			  when Q_DI_LEI  =  ''0112'' then ''0112''
			  when Q_DI_LEI  =  ''0113'' then ''0113''
			  when Q_DI_LEI  =  ''0120'' then ''0120''
			  when Q_DI_LEI  =  ''0131'' then ''0131''
			  when Q_DI_LEI  =  ''0132'' then ''0132''
			  when Q_DI_LEI in (''0140'',''0141'',''0142'') then ''0140''
			  when Q_DI_LEI  =  ''0150'' then ''0150''
			  when Q_DI_LEI in (''0160'',''0161'',''0162'',''0163'',''1631'',''1632'',''1633'',''1634'') then ''0160'' --将无立木统一为0160
			  when Q_DI_LEI in (''0170'',''0171'',''0172'',''0173'') then ''0170''
			  when Q_DI_LEI  =  ''0180'' then ''0180''
			  when Q_DI_LEI NOT IN (''0110'',''0130'',''0111'',''0112'',''0113'',''0120'',''0131'',''0132'',''0140'',
			  ''0141'',''0142'',''0150'', ''0160'',''0161'',''0162'',''0163'',''1631'',
			  ''1632'',''1633'',''1634'', ''0170'',''0171'',''0172'',''0173'',''0180'') then ''0200'' END)  AS  Q_DL
			FROM ' +@LindBHTable +' where '+@BHFilter);
	END TRY
	begin catch
		set @cerror=@cerror+1
		SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();
	end catch
	if(@cerror>0)
	  BEGIN
		  RAISERROR(@ErrorMessage,@ErrorSeverity,@ErrorState);
	  END
end
