#include <reg51.h>
#include <nokia5110.h>
#include "intrins.h"
extern unsigned char g_ucTempbuf[20]; 
unsigned char code shuzi_nokia[]={
0xF8,0x04,0x04,0x04,0xF8,0x00,0x01,0x02,0x02,0x02,0x01,0x00,/*"0",0*/

0x00,0x08,0xFC,0x00,0x00,0x00,0x00,0x02,0x03,0x02,0x00,0x00,/*"1",1*/

0x18,0x84,0x44,0x24,0x18,0x00,0x03,0x02,0x02,0x02,0x02,0x00,/*"2",2*/

0x08,0x04,0x24,0x24,0xD8,0x00,0x01,0x02,0x02,0x02,0x01,0x00,/*"3",3*/

0x40,0xB0,0x88,0xFC,0x80,0x00,0x00,0x00,0x00,0x03,0x02,0x00,/*"4",4*/

0x3C,0x24,0x24,0x24,0xC4,0x00,0x01,0x02,0x02,0x02,0x01,0x00,/*"5",5*/

0xF8,0x24,0x24,0x2C,0xC0,0x00,0x01,0x02,0x02,0x02,0x01,0x00,/*"6",6*/

0x0C,0x04,0xE4,0x1C,0x04,0x00,0x00,0x00,0x03,0x00,0x00,0x00,/*"7",7*/

0xD8,0x24,0x24,0x24,0xD8,0x00,0x01,0x02,0x02,0x02,0x01,0x00,/*"8",8*/

0x38,0x44,0x44,0x44,0xF8,0x00,0x00,0x03,0x02,0x02,0x01,0x00,/*"9",9*/

0x00,0xE0,0x9C,0xF0,0x80,0x00,0x02,0x03,0x00,0x00,0x03,0x02,/*"A",10*/

0x04,0xFC,0x24,0x24,0xD8,0x00,0x02,0x03,0x02,0x02,0x01,0x00,/*"B",11*/

0xF8,0x04,0x04,0x04,0x0C,0x00,0x01,0x02,0x02,0x02,0x01,0x00,/*"C",12*/

0x04,0xFC,0x04,0x04,0xF8,0x00,0x02,0x03,0x02,0x02,0x01,0x00,/*"D",13*/

0x04,0xFC,0x24,0x74,0x0C,0x00,0x02,0x03,0x02,0x02,0x03,0x00,/*"E",14*/

0x04,0xFC,0x24,0x74,0x0C,0x00,0x02,0x03,0x02,0x00,0x00,0x00,/*"F",15*/


0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x00,/*".",16*/

0x00,0x00,0x10,0x00,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,/*":",17*/

};


unsigned char code hanzi[]={

0x88,0x68,0xFF,0x48,0x88,0x22,0xF2,0x2A,0xE6,0x22,0xE0,0x00,
0x00,0x00,0x0F,0x00,0x02,0x09,0x04,0x03,0x08,0x08,0x07,0x00,/*"杨",0*/

0xAE,0xA8,0xAF,0xA8,0xEE,0x00,0xFE,0x02,0xFE,0x00,0x00,0x00,
0x0F,0x08,0x04,0x04,0x0A,0x04,0x03,0x00,0x07,0x08,0x0E,0x00,/*"凯",1*/

0xFC,0x46,0x45,0x44,0xFC,0x10,0x08,0x27,0xC4,0x04,0xFC,0x00,
0x0F,0x04,0x04,0x04,0x0F,0x00,0x00,0x00,0x08,0x08,0x07,0x00,/*"的",2*/

0xFF,0x21,0x29,0x2D,0x57,0x55,0x95,0x2D,0x21,0x21,0xFF,0x00,
0x0F,0x04,0x04,0x05,0x05,0x06,0x06,0x04,0x04,0x04,0x0F,0x00,/*"图",3*/

0x40,0x44,0x44,0x44,0xFF,0x44,0x44,0x44,0x7D,0x42,0xC0,0x00,
0x00,0x00,0x00,0x00,0x0F,0x00,0x00,0x00,0x04,0x04,0x03,0x00,/*"书",4*/

0x08,0xE7,0x0C,0x00,0x0C,0xF4,0x54,0x55,0x56,0x74,0x0C,0x00,
0x00,0x0F,0x04,0x00,0x00,0x0F,0x05,0x05,0x05,0x05,0x0F,0x00,/*"馆",5*/

0x82,0x82,0xBA,0xAA,0xAA,0xAB,0xAA,0xAA,0xBA,0x82,0x82,0x00,
0x0F,0x00,0x00,0x0E,0x0A,0x0A,0x0A,0x0E,0x00,0x08,0x0F,0x00,/*"高",6*/

0x44,0x53,0x52,0x56,0x52,0x7C,0x53,0xD2,0x56,0x52,0x42,0x00,
0x01,0x01,0x03,0x05,0x01,0x09,0x09,0x0F,0x01,0x01,0x01,0x00,/*"等",7*/

0x48,0x2A,0x98,0x7F,0x28,0x4A,0x10,0xEF,0x08,0xF8,0x08,0x00,
0x09,0x0B,0x05,0x05,0x0B,0x00,0x08,0x05,0x02,0x05,0x08,0x00,/*"数",8*/

0x8C,0x85,0x96,0x94,0x95,0x96,0xD4,0xB4,0x96,0x85,0x8C,0x00,
0x00,0x00,0x00,0x08,0x08,0x0F,0x00,0x00,0x00,0x00,0x00,0x00,/*"学",9*/

0x98,0xD4,0xB3,0x88,0x00,0x48,0x48,0xFF,0x24,0xA5,0x26,0x00,
0x04,0x04,0x02,0x02,0x08,0x08,0x04,0x03,0x05,0x08,0x0E,0x00,/*"线",10*/

0x78,0x00,0xFF,0x08,0x20,0x9C,0x88,0xFF,0x88,0x88,0x00,0x00,
0x00,0x00,0x0F,0x00,0x08,0x08,0x08,0x0F,0x08,0x08,0x08,0x00,/*"性",11*/

0x20,0x10,0xFC,0x03,0x10,0x10,0xFF,0x10,0x09,0x0A,0x08,0x00,
0x00,0x00,0x0F,0x00,0x00,0x00,0x00,0x01,0x02,0x04,0x0F,0x00,/*"代",12*/

0x48,0x2A,0x98,0x7F,0x28,0x4A,0x10,0xEF,0x08,0xF8,0x08,0x00,
0x09,0x0B,0x05,0x05,0x0B,0x00,0x08,0x05,0x02,0x05,0x08,0x00,/*"数",13*/

0x04,0x88,0xFF,0x00,0x10,0x10,0xD0,0x3F,0xD0,0x12,0x14,0x00,
0x01,0x00,0x0F,0x00,0x08,0x06,0x01,0x00,0x01,0x06,0x08,0x00,/*"状",14*/

0x44,0x44,0x24,0x14,0x0C,0xA7,0x4C,0x14,0x24,0x44,0x44,0x00,
0x04,0x03,0x00,0x07,0x08,0x08,0x0B,0x08,0x0C,0x01,0x06,0x00,/*"态",15*/

0x00,0xF2,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x7E,0x00,0x00,
0x00,0x07,0x08,0x08,0x08,0x08,0x08,0x08,0x08,0x08,0x0E,0x00,/*"已",16*/

0x10,0xFC,0x03,0x10,0xD4,0x5F,0x54,0x54,0x5F,0xD4,0x10,0x00,
0x00,0x0F,0x00,0x00,0x0F,0x05,0x05,0x05,0x05,0x0F,0x00,0x00,/*"借",17*/

0xF9,0x02,0xF0,0x95,0x99,0x91,0x99,0x95,0xF1,0x01,0xFF,0x00,
0x0F,0x00,0x04,0x02,0x01,0x00,0x03,0x04,0x06,0x08,0x0F,0x00,/*"阅",18*/

0x20,0x24,0x24,0xA4,0x64,0xFF,0x64,0xA4,0x24,0x24,0x20,0x00,
0x02,0x02,0x01,0x00,0x00,0x0F,0x00,0x00,0x01,0x02,0x02,0x00,/*"未",19*/

0x88,0x68,0xFF,0x48,0x02,0xFA,0xAF,0xAA,0xAF,0xFA,0x02,0x00,
0x00,0x00,0x0F,0x00,0x0A,0x0A,0x06,0x03,0x06,0x0A,0x0A,0x00,/*"模",20*/

0x08,0x48,0x48,0xC8,0x48,0x48,0x08,0xFF,0x08,0x09,0x0A,0x00,
0x08,0x08,0x08,0x07,0x04,0x04,0x04,0x00,0x03,0x04,0x0E,0x00,/*"式",21*/

0x40,0x44,0x44,0x44,0xFF,0x44,0x44,0x44,0x7D,0x42,0xC0,0x00,
0x00,0x00,0x00,0x00,0x0F,0x00,0x00,0x00,0x04,0x04,0x03,0x00,/*"书",22*/

0x12,0x12,0xEA,0xA6,0xA2,0xBF,0xA2,0xA6,0xEA,0x12,0x12,0x00,
0x08,0x08,0x0B,0x0A,0x0A,0x0A,0x0A,0x0A,0x0B,0x08,0x08,0x00,/*"查",23*/

0x11,0xF2,0x08,0x04,0xFB,0x4A,0x4A,0x4A,0xFA,0x02,0xFE,0x00,
0x00,0x07,0x02,0x00,0x07,0x02,0x02,0x02,0x0B,0x08,0x07,0x00,/*"询",24*/


0xFC,0x00,0x00,0xFF,0x00,0x02,0x22,0x22,0x22,0x22,0xFE,0x00,
0x01,0x08,0x06,0x01,0x00,0x04,0x04,0x04,0x04,0x04,0x0F,0x00,/*"归",25*/

0x10,0x11,0xF2,0x00,0x42,0x22,0x12,0xFA,0x06,0x12,0x62,0x00,
0x08,0x04,0x03,0x04,0x08,0x08,0x08,0x0B,0x08,0x08,0x08,0x00,/*"还",26*/

};

void delayms(unsigned  int ii)//1ms延时函数
{
	unsigned int i,x;
	for (x=0;x<ii;x++)
	{
	for (i=0;i<200;i++);
	}
;
}

/*--------------------------------------------
LCD_write_byte: 使用SPI接口写数据到LCD
输入参数：dt：写入的数据；
command ：写数据/命令选择；
编写日期：20080918 
----------------------------------------------*/
void LCD_write_byte(unsigned char dt, unsigned char command)
{
	unsigned char i; 
	sce=0;	
	dc=command;	
	for(i=0;i<8;i++)
	{ 
		if(dt&0x80)
		sdin=1;	
		else
			sdin=0;
		dt=dt<<1;		
		sclk=0; 		
		sclk=1; 
	}	
	dc=1;	
	sce=1;	
	sdin=1;
}
/*---------------------------------------
LCD_init: 3310LCD初始化
编写日期：20080918 
-----------------------------------------  */
void LCD_init(void)
{
	res=0;  	
  	delayms(10);
  	res=1;  
	LCD_write_byte(0x21,0);//初始化Lcd,功能设定使用扩充指令
	LCD_write_byte(0xCD,0);//设定液晶偏置电压
	LCD_write_byte(0x20,0);//使用基本指令
	LCD_write_byte(0x0C,0);//设定显示模式，正常显示,普通显示
}
/*-------------------------------------------
LCD_set_XY: 设置LCD坐标函数
输入参数：X：0－83  Y：0－5
编写日期：20080918 
---------------------------------------------*/
void LCD_set_XY(unsigned char X, unsigned char Y)
{
	LCD_write_byte(0x40 | Y, 0);// column设置y地址命令字
	LCD_write_byte(0x80 | X, 0);// row设置x地址命令字
} 
/*------------------------------------------
LCD_clear: LCD清屏函数
编写日期：20080918 
--------------------------------------------*/
void LCD_clear(void)
{
	unsigned char t;
	unsigned char k;
	LCD_set_XY(0,0);
	for(t=0;t<6;t++)
	{ 
		for(k=0;k<84;k++)
		{ 
			LCD_write_byte(0x00,1);
				
		} 
	}
}
/*---------------------------------------------
LCD_write_shu: 显示6（宽）*16（高）点阵列数字字母符号等半角类
输入参数：c：显示的字符；
编写日期：20080918 
-----------------------------------------------*/
void LCD_write_shu(unsigned char row, unsigned char page,unsigned char c) //row:列 page:页 dd:字符
{
	unsigned char i;  	
	
	LCD_set_XY(row*6, page);// 列，页 
	for(i=0; i<6;i++) 
	{
		LCD_write_byte(shuzi_nokia[c*12+i],1); 
	}
	
    LCD_set_XY(row*6, page+1);// 列，页 
	for(i=6; i<12;i++) 
	{
		LCD_write_byte(shuzi_nokia[c*12+i],1);
	}	 	
}
/*---------------------------------------------
LCD_write_hanzi: 显示12（宽）*16（高）点阵列汉字等半角类
输入参数：c：显示的字符；
编写日期：20080918 
-----------------------------------------------*/
void LCD_write_hanzi(unsigned char row, unsigned char page,unsigned char c) //row:列 page:页 dd:字符
{
	unsigned char i;  	
	
	LCD_set_XY(row*6, page);// 列，页 
	for(i=0; i<12;i++) 
	{
		LCD_write_byte(hanzi[c*24+i],1); 
	}
	
    LCD_set_XY(row*6, page+1);// 列，页 
	for(i=12; i<24;i++) 
	{
		LCD_write_byte(hanzi[c*24+i],1);
	}	
}

void display_type()//寻到卡后显示出该卡的类型
{
    unsigned char first,second;
    LCD_clear(); //清屏幕	     
    LCD_write_hanzi(0,0,19);  	
	LCD_write_hanzi(2,0,20);  
 	LCD_write_hanzi(4,0,21);  	
	LCD_write_hanzi(6,0,22);

    first=(g_ucTempbuf[0]&0xf0)>>4;
	LCD_write_shu(8,0,first);//写数字
    second=g_ucTempbuf[0]&0x0f;
	LCD_write_shu(9,0,second);//写数字
    first=(g_ucTempbuf[1]&0xf0)>>4;
	LCD_write_shu(10,0,first);//写数字
    second=g_ucTempbuf[1]&0x0f;
	LCD_write_shu(11,0,second);//写数字
}

void display_cardnum()
{
	unsigned char first,second;
    LCD_write_hanzi(0,2,19);  
	LCD_write_hanzi(2,2,23);  
    LCD_write_shu(4,2,17); 
  
	first=(g_ucTempbuf[0]&0xf0)>>4;
	LCD_write_shu(5,2,first);//写数字
    second=g_ucTempbuf[0]&0x0f;
	LCD_write_shu(6,2,second);//写数字

    first=(g_ucTempbuf[1]&0xf0)>>4;
	LCD_write_shu(7,2,first);//写数字
    second=g_ucTempbuf[1]&0x0f;
	LCD_write_shu(8,2,second);//写数字
    
    first=(g_ucTempbuf[2]&0xf0)>>4;
	LCD_write_shu(9,2,first);//写数字
    second=g_ucTempbuf[2]&0x0f;
	LCD_write_shu(10,2,second);//写数字

    first=(g_ucTempbuf[3]&0xf0)>>4;
	LCD_write_shu(11,2,first);//写数字
    second=g_ucTempbuf[3]&0x0f;
	LCD_write_shu(12,2,second);//写数字
}
void display_carddat()    //余额
{
	unsigned char first,second,num,i,yule[3];

    LCD_write_hanzi(0,4,24);  
	LCD_write_hanzi(2,4,25);  
    LCD_write_shu(4,4,17); 

    first=(g_ucTempbuf[3]&0xf0)>>4;
	//LCD_write_shu(7,4,first);//写数字
    second=g_ucTempbuf[3]&0x0f;
	//LCD_write_shu(8,4,second);//写数字
    
    num=first*16+second;        //十进制显示
    yule[0]=num/100;
    yule[1]=num%100/10;
    yule[2]=num%10;
    for(i=0;i<3;i++) 
    LCD_write_shu(7+i,4,yule[i]);//写数字

}
