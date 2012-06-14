/*
SQLyog Enterprise - MySQL GUI v8.1 
MySQL - 5.5.16 : Database - tcgn
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`tcgn` /*!40100 DEFAULT CHARACTER SET latin1 */;

/*Data for the table `battle` */

/*Data for the table `tipe` */

insert  into `tipe`(TIPE_ID,TIPE_NAME) values (1,'Karakter'),(2,'Benteng'),(3,'Senjata'),(4,'Magic');

/*Data for the table `card` */

insert  into `card`(CARD_ID,CARD_NAME,CARD_DESCRIPTION,CARD_STRENGTH,CARD_DEFENSE,CARD_HP,CARD_LEVEL,CARD_TIPE,CARD_MAGIC_NUMBER,ENCHANT_STRENGTH,ENCHANT_DEFENSE,ENCHANT_HP,CARD_PRICE) values (1,'gajah mada','penjelasan',12,10,0,3,1,0,0,0,0,'10000'),(2,'anusapati','penjelasan',7,8,0,2,1,0,0,0,0,'3000'),(3,'jaya wisnu wardhana','penjelasan',3,2,0,1,1,0,0,0,0,'1000'),(4,'benteng biting','penjelasan',0,0,30,0,2,0,0,0,0,'2000'),(5,'canggu lor','penjelasan',0,0,28,0,2,0,0,0,0,'2000'),(6,'ken angrok',NULL,9,8,0,2,1,0,0,0,0,'8000'),(7,'ken dedes',NULL,4,6,0,2,1,0,0,0,0,'5000'),(9,'surya majapahit',NULL,0,0,0,0,4,0,0,0,10,'9000');

/*Data for the table `player` */

insert  into `player`(PLAYER_ID,PLAYER_NAME,PLAYER_PASSWORD,PLAYER_WIN,PLAYER_LOSE,PLAYER_MONEY) values (1,'s','1',2,0,'4200'),(2,'username','password',0,0,'0'),(3,'mumu','mumu',0,0,'0'),(4,'ararenja','alase21',0,0,'2000'),(23,'1','2',0,0,'0');

/*Data for the table `player_card` */

insert  into `player_card`(PLAYER_CARD_ID,CARD_ID,PLAYER_ID,PLAYER_CARD_ACTIVE) values (1,1,1,1),(2,2,1,0),(3,3,1,0),(4,4,1,0),(5,5,1,0),(7,3,1,0),(8,2,4,1),(9,3,4,1),(10,3,4,1),(11,1,4,1),(12,2,4,1),(13,3,4,1),(14,4,4,0),(15,5,4,0),(16,1,4,1),(17,2,4,1),(18,3,4,1),(20,5,4,0),(21,1,4,1),(22,2,4,1),(23,3,4,1),(24,4,4,0),(25,5,4,0),(26,1,4,1),(27,2,4,1),(28,3,4,1),(29,4,4,1),(30,5,4,1),(31,1,4,1),(32,2,4,1),(33,3,4,1),(34,4,4,1),(35,5,4,1),(36,1,4,1),(37,2,4,1),(38,3,4,1),(39,4,4,1),(40,5,4,1),(41,1,4,1),(42,2,4,1),(43,3,4,1),(44,4,4,1),(45,5,4,1),(46,2,4,1),(47,3,4,1),(48,1,4,1),(49,2,4,1),(50,3,4,1),(51,4,4,0),(52,5,4,0),(53,1,4,1),(54,2,4,1),(55,3,4,1),(56,4,4,0),(57,5,4,0);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;