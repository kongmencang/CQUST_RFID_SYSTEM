/*
Navicat MySQL Data Transfer

Source Server         : aly
Source Server Version : 50740
Source Host           : 47.109.137.143:3306
Source Database       : CqustRfidSystem

Target Server Type    : MYSQL
Target Server Version : 50740
File Encoding         : 65001

Date: 2024-06-20 00:57:21
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for attendance_info
-- ----------------------------
DROP TABLE IF EXISTS `attendance_info`;
CREATE TABLE `attendance_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `addtime` varchar(255) DEFAULT NULL,
  `sno` char(10) DEFAULT NULL,
  `course_sections` char(255) DEFAULT NULL,
  `cno` char(12) DEFAULT NULL,
  `state` char(2) DEFAULT NULL,
  `place` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for class_info
-- ----------------------------
DROP TABLE IF EXISTS `class_info`;
CREATE TABLE `class_info` (
  `class_id` char(10) NOT NULL,
  `class_name` varchar(255) DEFAULT NULL,
  `subject_id` char(10) DEFAULT NULL,
  `counsellor_id` char(10) DEFAULT NULL,
  PRIMARY KEY (`class_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for course_base_info
-- ----------------------------
DROP TABLE IF EXISTS `course_base_info`;
CREATE TABLE `course_base_info` (
  `course_id` char(10) NOT NULL,
  `course_name` varchar(255) DEFAULT NULL,
  `department_id` char(10) DEFAULT NULL,
  PRIMARY KEY (`course_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for department_info
-- ----------------------------
DROP TABLE IF EXISTS `department_info`;
CREATE TABLE `department_info` (
  `department_id` char(10) NOT NULL,
  `department_name` varchar(255) DEFAULT NULL,
  `school_id` char(10) DEFAULT NULL,
  PRIMARY KEY (`department_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for rfid_info
-- ----------------------------
DROP TABLE IF EXISTS `rfid_info`;
CREATE TABLE `rfid_info` (
  `card_id` varchar(255) NOT NULL,
  `sno` char(10) NOT NULL,
  PRIMARY KEY (`card_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for scheduling_info
-- ----------------------------
DROP TABLE IF EXISTS `scheduling_info`;
CREATE TABLE `scheduling_info` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `scheduling_id` char(10) DEFAULT NULL,
  `weekday` int(1) DEFAULT NULL,
  `course_id` char(10) DEFAULT NULL,
  `teacher_id` char(10) DEFAULT NULL,
  `course_section` char(2) DEFAULT NULL,
  `place` varchar(255) DEFAULT NULL,
  `term_time` char(6) DEFAULT NULL,
  `state` char(2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for school_info
-- ----------------------------
DROP TABLE IF EXISTS `school_info`;
CREATE TABLE `school_info` (
  `school_id` char(10) NOT NULL,
  `school_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`school_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for stu_course_selection_info
-- ----------------------------
DROP TABLE IF EXISTS `stu_course_selection_info`;
CREATE TABLE `stu_course_selection_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sno` char(10) DEFAULT NULL,
  `course_id` char(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for student_info
-- ----------------------------
DROP TABLE IF EXISTS `student_info`;
CREATE TABLE `student_info` (
  `sno` char(10) NOT NULL,
  `name` varchar(50) NOT NULL,
  `sex` varchar(255) DEFAULT NULL,
  `birthday` varchar(255) DEFAULT NULL,
  `home` varchar(255) DEFAULT NULL,
  `telephone` varchar(255) DEFAULT NULL,
  `class_id` char(10) DEFAULT NULL,
  `subject_id` char(10) DEFAULT NULL,
  `school_id` char(10) DEFAULT NULL,
  PRIMARY KEY (`sno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for subject_info
-- ----------------------------
DROP TABLE IF EXISTS `subject_info`;
CREATE TABLE `subject_info` (
  `subject_id` char(10) NOT NULL,
  `subject_name` varchar(255) DEFAULT NULL,
  `department_id` char(10) DEFAULT NULL,
  PRIMARY KEY (`subject_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for teacher_info
-- ----------------------------
DROP TABLE IF EXISTS `teacher_info`;
CREATE TABLE `teacher_info` (
  `teacher_id` char(10) NOT NULL,
  `teacher_name` varchar(255) DEFAULT NULL,
  `teacher_age` varchar(255) DEFAULT NULL,
  `teacher_sex` varchar(255) DEFAULT NULL,
  `teacher_email` varchar(255) DEFAULT NULL,
  `teacher_school_id` varchar(255) DEFAULT NULL,
  `teacher_power` varchar(255) DEFAULT NULL,
  `teacher_state` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`teacher_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Table structure for user_info
-- ----------------------------
DROP TABLE IF EXISTS `user_info`;
CREATE TABLE `user_info` (
  `user_id` char(10) NOT NULL,
  `user_pwd` varchar(255) DEFAULT NULL,
  `user_email` varchar(255) DEFAULT NULL,
  `user_power` char(2) DEFAULT NULL,
  `state` char(2) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
