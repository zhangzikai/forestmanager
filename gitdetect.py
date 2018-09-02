import os
from os.path import join,getsize
workspacePath ='E:\\BaiduNetdiskDownload\\吕梁项目\\lvliang_cs'
logFile = workspacePath+ r'\log.txt'
def process(fileName):
        print(fileName,'->',fileSize,'mb')
        # os.system('git rm --cached '+fileName)
        # try:
        #     os.remove(fileName)
        # except:
        #     pass
        # fileName= fileName.replace(workspacePath+'\\','')
        order ="git filter-branch -f --index-filter  \"git rm --cached --ignore-unmatch  "+fileName+"\""
        out.write(fileName+'\r\n')
        # os.system(order)
        out.write(order+'\r\n')
with open(logFile,'w') as out:
    for root,dirs,files in os.walk(R'E:\BaiduNetdiskDownload\吕梁项目\lvliang_cs'):
        for file in files:
            fileName = join(root,file)
            fileSize =getsize(fileName)/1000/1000
            if fileSize>100:
                process(fileName)

# print(r'E:\BaiduNetdiskDownload\吕梁项目\lvliang_cs\AttributesEdit\bin\Release')