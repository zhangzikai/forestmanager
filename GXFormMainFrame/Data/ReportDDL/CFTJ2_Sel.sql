﻿select XIANNAME,XIANGNAME,CUNNAME,case substring(LBNAME,1,1) when '0' then substring(LBNAME,2,1) else substring(LBNAME,1,2) end as LBNAME,ISNULL(DCBNAME,'')+CASE WHEN ZYXBNAME IS NULL THEN '' ELSE '.' END+ISNULL(ZYXBNAME,'') AS DCBNAME,BZDH,BZMJ,SZNAME,JJ,JCLXNAME,CAST(PJXJ AS numeric(38,1)),CAST(PJSG AS numeric(38,1)),case ISNULL(YCSJCZS,0)+ISNULL(BYCSJCZS,0)+ISNULL(XCSJCZS,0) when 0 then null else ISNULL(YCSJCZS,0)+ISNULL(BYCSJCZS,0)+ISNULL(XCSJCZS,0) end,YCSJCZS,BYCSJCZS,XCSJCZS,case ISNULL(YCSXJL,0)+ISNULL(BYCSXJL,0)+ISNULL(XCSXJL,0) when 0 then null else ISNULL(YCSXJL,0)+ISNULL(BYCSXJL,0)+ISNULL(XCSXJL,0) end,YCSXJL,BYCSXJL,XCSXJL,round((ISNULL(GGCCCL,0)+ISNULL(XCCCL,0))/case PARAMS when '0' then (case ISNULL(YCSXJL,0)+ISNULL(BYCSXJL,0)+ISNULL(XCSXJL,0) when 0 then null else ISNULL(YCSXJL,0)+ISNULL(BYCSXJL,0)+ISNULL(XCSXJL,0) end) else null end,3)*100,ISNULL(GGCCCL,0)+ISNULL(XCCCL,0),PARAMS from T_STAT_CF_LMXJCC order by xian,xiang,cun,lb,dcb,zyxb,bzdh,sz,PARAMS