#include "lpcreg.h"
#include "main.h"
#include "mfrc522.h"
#include "12864.h"
#include <nokia5110.h>
#include <stdio.h>
#include <string.h>

#define uchar unsigned char  // 定义无符号字符类型
#define MAX_LEN 16  // 数据最大长度
#define FIRST_ROW 0
#define SECOND_ROW 2
#define THIRD_ROW 4

uchar Char;  // 定义字符变量Char
uchar flag;  // 定义标志位变量flag
uchar received_data[MAX_LEN];  // 存储接收到的数据
uchar data_index = 0;  // 数据索引
//前五位cqust   中间10位学生卡号
uchar response_array[16] = {0x63, 0x71, 0x75, 0x73, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x23};  // 响应数组

//前两位 ok  中间十位学生卡号
uchar write_ok[16] = {0x6F, 0x6B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x23};  // 成功响应数组

//前六位 cardid 中间8位 标签卡号
uchar card_id[16] = {0x63, 0x61, 0x72, 0x64, 0x69, 0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x23};  // 卡片id响应数组




unsigned char g_ucTempbuf[16];
unsigned char code DefaultKey[6] = { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

uchar i;




//是否读到卡标志 0未读 1读卡
uchar is_card_read = 0;
//运行模式标志位 0读卡 1写卡
uchar run_mode = 0;
//是否接收到数据
uchar is_read_data = 0;



void delay1(unsigned int z) {
    unsigned int x, y;
    for (x = z; x > 0; x--)
        for (y = 110; y > 0; y--);
}

// UART发送一个字节函数
void UART_sendbyte(uchar Byte) {
    SBUF = Byte; 
    while (TI == 0); 
    TI = 0;  
}

//转asc
uchar nibble_to_ascii(uchar nibble) {
    if (nibble < 10) {
        return '0' + nibble;
    } else {
        return 'A' + (nibble - 10);
    }
}


void clear_row(uchar row){
	for(i=0;i<15;i++){
		LCD_write_shu(i,row,37);
		
	}
}

void write_title(uchar row){
		//cqust考勤系统
		LCD_write_shu(0,row,12);
		LCD_write_shu(1,row,26);
		LCD_write_shu(2,row,30);
		LCD_write_shu(3,row,28);
	  LCD_write_shu(4,row,29);
	
	  LCD_write_shu(5,row,37);
	
		LCD_write_hanzi(6,row,0);
		LCD_write_hanzi(8,row,1);
		LCD_write_hanzi(10,row,2);
		LCD_write_hanzi(12,row,3);
	
}

void write_sno(uchar row){
			//学号
			LCD_write_hanzi(0,row,8);
			LCD_write_hanzi(2,row,9);
      for (i = 0; i < 10; i++) {
            LCD_write_shu(i+4,row,received_data[1 + i]-'0');            
        }
			
}

void write_bang_ding_chen_gong(uchar row){
		
			LCD_write_hanzi(2,row,10);
			LCD_write_hanzi(4,row,11);
			LCD_write_hanzi(6,row,6);
			LCD_write_hanzi(8,row,7);

}

void display_cardnum(uchar row)
{
	unsigned char first,second; 
	//卡号:
	LCD_write_hanzi(0,row,5);
    LCD_write_hanzi(2,row,9); 
	 LCD_write_shu(4,row,36); 
	first=(g_ucTempbuf[0]&0xf0)>>4;
	LCD_write_shu(5,row,first);//写数字
    second=g_ucTempbuf[0]&0x0f;
	LCD_write_shu(6,row,second);//写数字

    first=(g_ucTempbuf[1]&0xf0)>>4;
	LCD_write_shu(7,row,first);//写数字
    second=g_ucTempbuf[1]&0x0f;
	LCD_write_shu(8,row,second);//写数字
    
    first=(g_ucTempbuf[2]&0xf0)>>4;
	LCD_write_shu(9,row,first);//写数字
    second=g_ucTempbuf[2]&0x0f;
	LCD_write_shu(10,row,second);//写数字

    first=(g_ucTempbuf[3]&0xf0)>>4;
	LCD_write_shu(11,row,first);//写数字
    second=g_ucTempbuf[3]&0x0f;
	LCD_write_shu(12,row,second);//写数字
	 LCD_write_shu(13,row,37);
}

// 主函数
void main() {
    unsigned char status;
    unsigned int temp;

    LCD_init();
    LCD_clear();
		write_title(FIRST_ROW);
    InitializeSystem();
    PcdReset();
    PcdAntennaOff();
    PcdAntennaOn();
	
while (1) {

    status = PcdRequest(PICC_REQALL, g_ucTempbuf); // 寻卡
    if (status != MI_OK)
    {
      
       write_title(FIRST_ROW);
				clear_row(SECOND_ROW );
				clear_row(THIRD_ROW );
        continue;
    }

    status = PcdAnticoll(g_ucTempbuf); // 防冲撞
    if (status != MI_OK)
    {
    
        continue;
    }

    // 转换卡片发送
    for (i = 0; i < 4; i++)
    {
        uchar high_nibble = (g_ucTempbuf[i] >> 4) & 0x0F;  // 高4位
        uchar low_nibble = g_ucTempbuf[i] & 0x0F;          // 低4位
        
        card_id[6 + 2*i] = nibble_to_ascii(high_nibble);   // 高4位转换为 ASCII
        card_id[7 + 2*i] = nibble_to_ascii(low_nibble);    // 低4位转换为 ASCII
    }
    
    for (i = 0; i < 16; i++) {
        UART_sendbyte(card_id[i]);
    }

	
    display_cardnum(FIRST_ROW );
    status = PcdSelect(g_ucTempbuf); // 选定卡片
    if (status != MI_OK)
    {
			
        continue;
    }

    status = PcdAuthState(PICC_AUTHENT1A, 1, DefaultKey, g_ucTempbuf); // 验证卡片密码
    if (status != MI_OK)
    {
			
        continue;
    }

    // 写卡
    if (received_data[0] == 'w') { 
        for (i = 0; i < 10; i++) {
            response_array[5 + i] = received_data[1 + i];
            write_ok[2 + i] = received_data[1 + i];
        }
        status = PcdWrite(2, response_array);  // 写数据
        if (status != MI_OK) {

            continue;
        }
        // 返回成功响应
        for (i = 0; i < 16; i++) {
            UART_sendbyte(write_ok[i]);
        }
				//显示绑定
			write_sno(SECOND_ROW );
				//显示绑定成功
				write_bang_ding_chen_gong(THIRD_ROW);
				//清除标志位
        received_data[0] = 0;

    // 读取卡片数据
    } else if (received_data[0] == 'r') {
        status = PcdRead(2, g_ucTempbuf);
        if (status != MI_OK) {
            continue;
        }
        for (i = 0; i < 16; i++) {
            UART_sendbyte(g_ucTempbuf[i]);
        }
    }

    PcdHalt();
}
}

// 系统初始化
void InitializeSystem() {
          // I/O 端口配置
    P0M1 = 0x0; P0M2 = 0x0;
    P1M1 = 0x0; P1M2 = 0x0;
    P3M1 = 0x0; P3M2 = 0xFF;
    P0 = 0xFF; P1 = 0xFF; P3 = 0xFF; P2 = 0xFF;

    // 串口配置
    SCON = 0x50; // 串行通信模式1，8位数据，允许接收

    // 定时器配置
    TMOD = 0x20; // T1为方式2（8位自动重装）

    // 设置定时器初值
    TH1 = 0xFA;  // 设置波特率为4800bps
    TL1 = 0xFA;

    // 启动定时器1
    TR1 = 1;    // 启动定时器1

    // 中断配置
    ES = 1;      // 允许串行中断
    EA = 1;      // 开启总中断

    // 设置标志
    TI = 1;
    
   

}

// UART接收中断服务函数
void UART_R() interrupt 4 {
    if (RI == 1) {  // 如果接收到数据
        Char = SBUF;  // 读取接收到的数据到Char变量

        RI = 0;  // 清除接收标志位
        if (Char == '#') {  // 检测到结束符
            is_read_data = 1;

            data_index = 0;  
        } else {
            if (data_index <= MAX_LEN - 1) {  // 防止数组越界
                received_data[data_index++] = Char;
            }
        }
    }
}
