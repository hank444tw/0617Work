# -*- coding: utf-8 -*-
"""
Created on Sat Jun  8 10:13:34 2019

@author: hank
"""

#---------------- 從cmd執行該程式，並帶入參數---------------------
import argparse 
p=argparse.ArgumentParser()
p.add_argument('--chooseDef',required=False,default='')
p.add_argument('--fileName',required=False,default='')
p.add_argument('--title',required=False,default='')
p.add_argument('--titleSize',required=False,default='')
p.add_argument('--xAxis',required=False,default='')
p.add_argument('--xTitle',required=False,default='')
p.add_argument('--xTitleSize',required=False,default='')
p.add_argument('--yTitle',required=False,default='')
p.add_argument('--yTitleSize',required=False,default='')
p.add_argument('--data',required=False,default='')
p.add_argument('--color',required=False,default='')
p.add_argument('--xyfontsize',required=False,default='')
p.add_argument('--legendSize',required=False,default='')
p.add_argument('--width',required=False,default='')
p.add_argument('--height',required=False,default='')
p.add_argument('--grid',required=False,default='')
args=p.parse_args()

chooseDef = args.chooseDef
fileName = args.fileName
title = args.title
titleSize = args.titleSize
xAxis = args.xAxis
xTitle = args.xTitle
xTitleSize = args.xTitleSize
yTitle = args.yTitle
yTitleSize = args.yTitleSize
data = args.data
color = args.color
xyfontsize = args.xyfontsize
legendSize = args.legendSize
width = args.width
height = args.height
grid = args.grid
#----------------------------------------------------------------

import pandas as pd
filepath=r'C:\Users\hankh\Desktop\ASP_NET_MVC\0617Work\0617Work\csvFile\0.csv'
pdstock=pd.read_csv(filepath,encoding='utf-8-sig')

def showIndex():
    for item in range(len(pdstock.columns)): 
        print('--分割--',pdstock.columns[item],'--分割--')

def showLineImage():
    x = False
    if grid == 'true':
        x = True
        
    fig= pdstock.plot(kind='line', #圖表種類(折線圖)
                 x=xAxis, #x軸
                 y=data.split(','), #Data
                 color=color.split(','), #設定線條顏色('blue' or '#0000FF')
                 fontsize=int(xyfontsize), #xy軸文字大小
                 title=title, #標題
                 figsize=(int(width),int(height)), #圖片長寬
                 grid=x #格線
                 )
    
    fig.axes.title.set_size(int(titleSize)) #標題文字大小
    fig.legend(fontsize=int(legendSize)) #圖示說明大小
    fig.set_xlabel(xTitle,fontsize=int(xTitleSize)) #x軸標題大小
    fig.set_ylabel(yTitle,fontsize=int(yTitleSize)) #y軸標題大小
    fig.figure.savefig('file.png') #儲存圖片
    
if chooseDef == '1':
    showIndex()
elif chooseDef == '2':
    showLineImage()


#-----------------------bar----------------------------
#filepath='bar.csv'
#pdstock=pd.read_csv(filepath,encoding='utf-8-sig')
#
#fig= pdstock.plot(kind='bar', #圖表種類(長條圖)
#                  x = ['科目科目'],
#                  y = ['Tyrion']
#             )

#fig.axes.title.set_size(20) #標題文字大小
#fig.legend(fontsize=14) #圖示說明大小
#fig.set_xlabel('日期',fontsize=16) #x軸標題大小
#fig.set_ylabel('數量',fontsize=16) #y軸標題大小
#fig.figure.savefig('file.png') #儲存圖片
#------------------------------------------------------

#----------------------matplotlib-----------------------
#import matplotlib.pyplot as plt
#
#x1=[2,6,8,11,13,16]
#y1=[15,50,80,40,70,50]
#plt.plot(x1,y1,label='圖示1')
#
#x2 = [1,5,7,9,13,16]
#y2 = [15,50,80,40,70,60]
#plt.plot(x2,y2,
#         color='red', #線條顏色(預設blue)
#         lw=3.0, #線條寬度(預設1.0)
#         ls='-.', #線條樣式，有'--'(虛線)、'-.'(虛點線)、':'(點線)，預設'-'(實線)
#         label='圖示2' #設定圖示名稱
#         )
#plt.legend(fontsize=14) #使用該方法，圖示才會顯示
#plt.title('折線圖',fontsize=16) #標題
#plt.xlabel('x座標標題',fontsize=16) #x軸標題
#plt.ylabel('y座標標題',fontsize=16) #y軸標題
#plt.xlim(1,20) #x座標範圍
#plt.xticks(fontsize=14) #x座標字體大小
#plt.ylim(10,90) #y座標範圍
#plt.yticks(fontsize=14) #y座標字體大小
#plt.show()
#-----------------------------------------------------
