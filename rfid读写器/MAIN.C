#include "lpcreg.h"
#include "main.h"
#include "mfrc522.h"
#include "12864.h"
#include <nokia5110.h>
#include <stdio.h>
#include <string.h>

#define uchar unsigned char // �����޷����ַ�����
#define MAX_LEN 16          // ������󳤶�
#define FIRST_ROW 0
#define SECOND_ROW 2
#define THIRD_ROW 4

uchar Char;                   // �����ַ�����Char
uchar flag;                   // �����־λ����flag
uchar received_data[MAX_LEN]; // �洢���յ�������
uchar data_index = 0;         // ��������
// ǰ��λcqust   �м�10λѧ������
uchar stu_id[16] = {0x63, 0x71, 0x75, 0x73, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x23}; // �洢ѧ�Ÿ�ʽ

// ��1λd ��10λѧ�� ��4λ��ַ
uchar response_array[16] = {0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x23}; // ����Ӧ����֡

// ǰ��λ ok  �м�ʮλѧ������
uchar write_ok[16] = {0x6F, 0x6B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x23}; // �ɹ���Ӧ����

// ǰ��λ cardid �м�8λ ��ǩ����
uchar card_id[16] = {0x63, 0x61, 0x72, 0x64, 0x69, 0x64, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x23}; // ��Ƭid��Ӧ����

// ����Ӧ����

unsigned char g_ucTempbuf[16];
unsigned char code DefaultKey[6] = {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF};

uchar i;

// �Ƿ��������־ 0δ�� 1����
uchar is_card_read = 0;
// ����ģʽ��־λ 0���� 1д��
uchar run_mode = 0;
// �Ƿ���յ�����
uchar is_read_data = 0;

void delay1(unsigned int z)
{
    unsigned int x, y;
    for (x = z; x > 0; x--)
        for (y = 110; y > 0; y--)
            ;
}

// UART����һ���ֽں���
void UART_sendbyte(uchar Byte)
{
    SBUF = Byte;
    while (TI == 0)
        ;
    TI = 0;
}

// תasc
uchar nibble_to_ascii(uchar nibble)
{
    if (nibble < 10)
    {
        return '0' + nibble;
    }
    else
    {
        return 'A' + (nibble - 10);
    }
}

void clear_row(uchar row)
{
    for (i = 0; i < 15; i++)
    {
        LCD_write_shu(i, row, 37);
    }
}

void display_title(uchar row)
{
    // cqust����ϵͳ
    LCD_write_shu(0, row, 12);
    LCD_write_shu(1, row, 26);
    LCD_write_shu(2, row, 30);
    LCD_write_shu(3, row, 28);
    LCD_write_shu(4, row, 29);

    LCD_write_shu(5, row, 37);

    LCD_write_hanzi(6, row, 0);
    LCD_write_hanzi(8, row, 1);
    LCD_write_hanzi(10, row, 2);
    LCD_write_hanzi(12, row, 3);
}

void display_sno(uchar row)
{
    // ѧ��
    LCD_write_hanzi(0, row, 8);
    LCD_write_hanzi(2, row, 9);
    for (i = 0; i < 10; i++)
    {
        LCD_write_shu(i+4, row, g_ucTempbuf[5 + i] - '0');
    }
}


void display_bang_ding_chen_gong(uchar row)
{
    // �󶨳ɹ�
    LCD_write_hanzi(2, row, 10);
    LCD_write_hanzi(4, row, 11);
    LCD_write_hanzi(6, row, 6);
    LCD_write_hanzi(8, row, 7);
}

void display_kao_qing_shi_bai(uchar row)
{
    // ����ʧ��
    LCD_write_hanzi(3, row, 0);
    LCD_write_hanzi(5, row, 1);
    LCD_write_hanzi(7, row, 16);
    LCD_write_hanzi(9, row, 17);
}

void display_bu_zai_kao_qing_shi_jian(uchar row)
{
    // ���ڿ���ʱ��
    LCD_write_hanzi(0, row, 12);
    LCD_write_hanzi(2, row, 13);
    LCD_write_hanzi(4, row, 0);
    LCD_write_hanzi(8, row, 1);
    LCD_write_hanzi(10, row, 14);
    LCD_write_hanzi(12, row, 15);
}

void display_ben_shi_jian_dun_wu_ke(uchar row)
{
    // ��ʱ����޿�
    LCD_write_hanzi(1, row, 18);
    LCD_write_hanzi(3, row, 14);
    LCD_write_hanzi(5, row, 15);
    LCD_write_hanzi(7, row, 19);
    LCD_write_hanzi(9, row, 20);
    LCD_write_hanzi(11, row, 21);
}

void display_ben_jie_ke_yi_da_ka(uchar row)
{
    // ���ڿ��Ѵ�
    LCD_write_hanzi(1, row, 18);
    LCD_write_hanzi(3, row, 22);
    LCD_write_hanzi(5, row, 21);
    LCD_write_hanzi(7, row, 23);
    LCD_write_hanzi(9, row, 4);
    LCD_write_hanzi(11, row, 5);
}
void dispaly_kao_qing_cheng_gong(uchar row, uchar state)
{
    // ���ڣ�
    LCD_write_hanzi(2, row, 0);
    LCD_write_hanzi(4, row, 1);
    LCD_write_shu(6, row, 36);
    if (state == '0')
    { // ����
        LCD_write_hanzi(7, row, 26);
        LCD_write_hanzi(9, row, 27);
    }
    if (state == '1')
    { // �ٵ�
        LCD_write_hanzi(7, row, 28);
        LCD_write_hanzi(9, row, 29);
    }
    if (state == '2')
    {
        // ȱ��
        LCD_write_hanzi(7, row, 30);
        LCD_write_hanzi(9, row, 1);
    }
}



void display_cardnum(uchar row)
{
    unsigned char first, second;
    // ����:
    LCD_write_hanzi(0, row, 5);
    LCD_write_hanzi(2, row, 9);
    LCD_write_shu(4, row, 36);
    first = (g_ucTempbuf[0] & 0xf0) >> 4;
    LCD_write_shu(5, row, first); // д����
    second = g_ucTempbuf[0] & 0x0f;
    LCD_write_shu(6, row, second); // д����

    first = (g_ucTempbuf[1] & 0xf0) >> 4;
    LCD_write_shu(7, row, first); // д����
    second = g_ucTempbuf[1] & 0x0f;
    LCD_write_shu(8, row, second); // д����

    first = (g_ucTempbuf[2] & 0xf0) >> 4;
    LCD_write_shu(9, row, first); // д����
    second = g_ucTempbuf[2] & 0x0f;
    LCD_write_shu(10, row, second); // д����

    first = (g_ucTempbuf[3] & 0xf0) >> 4;
    LCD_write_shu(11, row, first); // д����
    second = g_ucTempbuf[3] & 0x0f;
    LCD_write_shu(12, row, second); // д����
    LCD_write_shu(13, row, 37);
}

// ������
void main()
{
    unsigned char status;
    unsigned int temp;

    LCD_init();
    LCD_clear();
    display_title(FIRST_ROW);
    InitializeSystem();
    PcdReset();
    PcdAntennaOff();
    PcdAntennaOn();

    while (1)
    {

        // д�������������ַ��
        if (received_data[0] == 's')
        {

            for (i = 0; i < 4; i++)
            {
                response_array[i + 11] = received_data[i + 1];
            }
            for (i = 0; i < 16; i++)
            {
                UART_sendbyte(write_ok[i]);
            }

            // ���سɹ���Ӧ
        }

        status = PcdRequest(PICC_REQALL, g_ucTempbuf); // Ѱ��
        if (status != MI_OK)
        {

            display_title(FIRST_ROW);
            clear_row(SECOND_ROW);
            clear_row(THIRD_ROW);
            continue;
        }

        status = PcdAnticoll(g_ucTempbuf); // ����ײ
        if (status != MI_OK)
        {

            continue;
        }

        // ת����Ƭ����
        for (i = 0; i < 4; i++)
        {
            uchar high_nibble = (g_ucTempbuf[i] >> 4) & 0x0F; // ��4λ
            uchar low_nibble = g_ucTempbuf[i] & 0x0F;         // ��4λ

            card_id[6 + 2 * i] = nibble_to_ascii(high_nibble); // ��4λת��Ϊ ASCII
            card_id[7 + 2 * i] = nibble_to_ascii(low_nibble);  // ��4λת��Ϊ ASCII
        }

        for (i = 0; i < 16; i++)
        {
            UART_sendbyte(card_id[i]);
        }

        display_cardnum(FIRST_ROW);
        status = PcdSelect(g_ucTempbuf); // ѡ����Ƭ
        if (status != MI_OK)
        {

            continue;
        }

        status = PcdAuthState(PICC_AUTHENT1A, 1, DefaultKey, g_ucTempbuf); // ��֤��Ƭ����
        if (status != MI_OK)
        {

            continue;
        }

        // д��
        if (received_data[0] == 'w')
        {
            for (i = 0; i < 10; i++)
            {
                stu_id[5 + i] = received_data[1 + i];
                write_ok[2 + i] = received_data[1 + i];
            }
            status = PcdWrite(2, stu_id); // д����
            if (status != MI_OK)
            {

                continue;
            }
            // ���سɹ���Ӧ
            for (i = 0; i < 16; i++)
            {
                UART_sendbyte(write_ok[i]);
            }
            // ��ʾ��
            display_sno(SECOND_ROW);
            // ��ʾ�󶨳ɹ�
            display_bang_ding_chen_gong(THIRD_ROW);
            // �����־λ
            received_data[0] = 0;

            // ��ȡ��Ƭ�󶨵�ѧ��
        }
        else if (received_data[0] == 'r')
        {
            status = PcdRead(2, g_ucTempbuf);
            if (status != MI_OK)
            {
                continue;
            }
            for (i = 0; i < 16; i++)
            {
                UART_sendbyte(g_ucTempbuf[i]);
            }
        }
        // ��ģʽ������ѧ��
        else if (received_data[0] == 'd')
        {
            status = PcdRead(2, g_ucTempbuf);
            if (status != MI_OK)
            {
                continue;
            }
            for (i = 0; i < 10; i++)
            {
                response_array[i + 1] = g_ucTempbuf[i + 5];
            }
            for (i = 0; i < 16; i++)
            {
                UART_sendbyte(response_array[i]);
            }
            if (received_data[1] == 'p')
            {
                display_sno(SECOND_ROW);
                if (received_data[2] == '1')
                    display_kao_qing_shi_bai(THIRD_ROW);
                if (received_data[2] == '2')
                    display_bu_zai_kao_qing_shi_jian(THIRD_ROW);
                if (received_data[2] == '3')
                    display_ben_shi_jian_dun_wu_ke(THIRD_ROW);
                if (received_data[2] == '4')
                    display_ben_jie_ke_yi_da_ka(THIRD_ROW);
                if (received_data[2] == '0')
                {
                    dispaly_kao_qing_cheng_gong(THIRD_ROW, received_data[3]);
                }
            }
        }
        //

        PcdHalt();
    }
}

// ϵͳ��ʼ��
void InitializeSystem()
{
    // I/O �˿�����
    P0M1 = 0x0;
    P0M2 = 0x0;
    P1M1 = 0x0;
    P1M2 = 0x0;
    P3M1 = 0x0;
    P3M2 = 0xFF;
    P0 = 0xFF;
    P1 = 0xFF;
    P3 = 0xFF;
    P2 = 0xFF;

    // ��������
    SCON = 0x50; // ����ͨ��ģʽ1��8λ���ݣ��������

    // ��ʱ������
    TMOD = 0x20; // T1Ϊ��ʽ2��8λ�Զ���װ��

    // ���ö�ʱ����ֵ
    TH1 = 0xFA; // ���ò�����Ϊ4800bps
    TL1 = 0xFA;

    // ������ʱ��1
    TR1 = 1; // ������ʱ��1

    // �ж�����
    ES = 1; // �������ж�
    EA = 1; // �������ж�

    // ���ñ�־
    TI = 1;
}

// UART�����жϷ�����
void UART_R() interrupt 4
{
    if (RI == 1)
    {                // ������յ�����
        Char = SBUF; // ��ȡ���յ������ݵ�Char����

        RI = 0; // ������ձ�־λ
        if (Char == '#')
        { // ��⵽������
            is_read_data = 1;

            data_index = 0;
        }
        else
        {
            if (data_index <= MAX_LEN - 1)
            { // ��ֹ����Խ��
                received_data[data_index++] = Char;
            }
        }
    }
}
