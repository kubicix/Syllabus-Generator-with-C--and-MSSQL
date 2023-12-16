-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: program
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ders`
--

DROP TABLE IF EXISTS `ders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ders` (
  `idders` int NOT NULL AUTO_INCREMENT,
  `dersad` varchar(45) NOT NULL,
  PRIMARY KEY (`idders`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ders`
--

LOCK TABLES `ders` WRITE;
/*!40000 ALTER TABLE `ders` DISABLE KEYS */;
INSERT INTO `ders` VALUES (1,'matematik'),(2,'fizik'),(3,'kimya'),(4,'biyoloji');
/*!40000 ALTER TABLE `ders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ders_programı`
--

DROP TABLE IF EXISTS `ders_programı`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ders_programı` (
  `idders_programı` int NOT NULL AUTO_INCREMENT,
  `ogretmen_idogretmen` int NOT NULL,
  `ders_idders` int NOT NULL,
  `günler_idgünler` int NOT NULL,
  `saat_idsaat` int NOT NULL,
  `sınıf_idsınıf` int NOT NULL,
  PRIMARY KEY (`idders_programı`),
  KEY `fk_ders_programı_ogretmen_idx` (`ogretmen_idogretmen`),
  KEY `fk_ders_programı_ders1_idx` (`ders_idders`),
  KEY `fk_ders_programı_günler1_idx` (`günler_idgünler`),
  KEY `fk_ders_programı_saat1_idx` (`saat_idsaat`),
  KEY `fk_ders_programı_sınıf1_idx` (`sınıf_idsınıf`),
  CONSTRAINT `fk_ders_programı_ders1` FOREIGN KEY (`ders_idders`) REFERENCES `ders` (`idders`),
  CONSTRAINT `fk_ders_programı_günler1` FOREIGN KEY (`günler_idgünler`) REFERENCES `günler` (`idgünler`),
  CONSTRAINT `fk_ders_programı_ogretmen` FOREIGN KEY (`ogretmen_idogretmen`) REFERENCES `ogretmen` (`idogretmen`),
  CONSTRAINT `fk_ders_programı_saat1` FOREIGN KEY (`saat_idsaat`) REFERENCES `saat` (`idsaat`),
  CONSTRAINT `fk_ders_programı_sınıf1` FOREIGN KEY (`sınıf_idsınıf`) REFERENCES `sınıf` (`idsınıf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ders_programı`
--

LOCK TABLES `ders_programı` WRITE;
/*!40000 ALTER TABLE `ders_programı` DISABLE KEYS */;
/*!40000 ALTER TABLE `ders_programı` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dersprogrami`
--

DROP TABLE IF EXISTS `dersprogrami`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dersprogrami` (
  `iddersprogrami` int NOT NULL AUTO_INCREMENT,
  `DersAdi` varchar(45) NOT NULL,
  `Ogretmen` varchar(45) NOT NULL,
  `Sinif` varchar(45) NOT NULL,
  `Saat` varchar(45) NOT NULL,
  `Gun` varchar(45) NOT NULL,
  PRIMARY KEY (`iddersprogrami`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dersprogrami`
--

LOCK TABLES `dersprogrami` WRITE;
/*!40000 ALTER TABLE `dersprogrami` DISABLE KEYS */;
INSERT INTO `dersprogrami` VALUES (1,'matematik','ahmet','1033','12:00','Pazartesi	');
/*!40000 ALTER TABLE `dersprogrami` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `günler`
--

DROP TABLE IF EXISTS `günler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `günler` (
  `idgünler` int NOT NULL AUTO_INCREMENT,
  `günlerad` varchar(15) NOT NULL,
  PRIMARY KEY (`idgünler`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `günler`
--

LOCK TABLES `günler` WRITE;
/*!40000 ALTER TABLE `günler` DISABLE KEYS */;
INSERT INTO `günler` VALUES (1,'Pazartesi'),(2,'Salı'),(3,'Carsmaba'),(4,'Persembe'),(5,'Cuma');
/*!40000 ALTER TABLE `günler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ogretmen`
--

DROP TABLE IF EXISTS `ogretmen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ogretmen` (
  `idogretmen` int NOT NULL AUTO_INCREMENT,
  `ogretmenad` varchar(45) NOT NULL,
  PRIMARY KEY (`idogretmen`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ogretmen`
--

LOCK TABLES `ogretmen` WRITE;
/*!40000 ALTER TABLE `ogretmen` DISABLE KEYS */;
INSERT INTO `ogretmen` VALUES (1,'ahmet'),(2,'mehmet'),(3,'ali'),(4,'veli'),(5,'ayşe');
/*!40000 ALTER TABLE `ogretmen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `saat`
--

DROP TABLE IF EXISTS `saat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `saat` (
  `idsaat` int NOT NULL AUTO_INCREMENT,
  `zaman` time NOT NULL,
  PRIMARY KEY (`idsaat`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `saat`
--

LOCK TABLES `saat` WRITE;
/*!40000 ALTER TABLE `saat` DISABLE KEYS */;
INSERT INTO `saat` VALUES (1,'09:00:00'),(2,'10:00:00'),(3,'11:00:00'),(4,'12:00:00'),(5,'13:00:00'),(6,'14:00:00'),(7,'15:00:00'),(8,'16:00:00');
/*!40000 ALTER TABLE `saat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sınıf`
--

DROP TABLE IF EXISTS `sınıf`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sınıf` (
  `idsınıf` int NOT NULL AUTO_INCREMENT,
  `sınıfad` varchar(25) NOT NULL,
  PRIMARY KEY (`idsınıf`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sınıf`
--

LOCK TABLES `sınıf` WRITE;
/*!40000 ALTER TABLE `sınıf` DISABLE KEYS */;
INSERT INTO `sınıf` VALUES (1,'1033'),(2,'1036'),(3,'1040'),(4,'1041'),(5,'1044');
/*!40000 ALTER TABLE `sınıf` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-16 19:31:48
