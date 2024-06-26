# encoding=utf8

import email
import smtplib
from email.header import Header
from email.mime.text import MIMEText
from jinja2 import Environment, FileSystemLoader
import time
from conflig import *


class Email:
    def __init__(self, email_smtp, email_port, email_username, email_password, email_send_name):
        self.email_smtp = email_smtp
        self.email_port = email_port
        self.email_username = email_username
        self.email_password = email_password
        self.email_send_name = email_send_name
        self.server = None

    def __login(self):
        self.server = smtplib.SMTP_SSL(self.email_smtp, self.email_port)
        self.server.login(self.email_username, self.email_password)
        self.server.set_debuglevel(True)

    def send_email(self, rsv_email, subject_text, email_body):
        try:
            self.__login()
            message = MIMEText(str(email_body), 'plain', 'utf-8')
            message['To'] = email.utils.formataddr((str(Header(rsv_email, 'utf-8')), rsv_email))
            message['From'] = email.utils.formataddr((str(Header(self.email_send_name, 'utf-8')), self.email_username))
            message['Subject'] = Header(subject_text, 'utf-8')

            self.server.sendmail(self.email_username, [rsv_email], msg=message.as_string())
            print(f"向：{rsv_email}发送邮件：{message}")
            self.server.quit()
        except smtplib.SMTPException as e:
            print(f"发送邮件时出错: {e}")

        # finally:
        #     if self.server:
        #         self.server.quit()
        #         self.server = None

