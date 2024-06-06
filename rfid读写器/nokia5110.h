
#ifndef	__NOKIA5110_H
#define	__NOKIA5110_H
sbit    sce = P0^0;  //片选
sbit    res = P0^1;  //复位,0复位
sbit    dc  = P0^2;  //1写数据，0写指令
sbit    sdin = P0^3;  //数据
sbit    sclk = P0^4;  //时钟

extern unsigned char code shuzi_nokia[];
extern unsigned char code hanzi[];
void LCD_write_byte(unsigned char dt, unsigned char command);
void LCD_init(void);
void LCD_set_XY(unsigned char X, unsigned char Y);
void LCD_clear(void);
void LCD_write_shu(unsigned char row, unsigned char page,unsigned char c) ;//row:列 page:页 dd:字符
void LCD_write_hanzi(unsigned char row, unsigned char page,unsigned char c); //row:列 page:页 dd:字符

void LCD_write_test(unsigned char row, unsigned char page,unsigned char c); //row:列 page:页 dd:字符

#endif
