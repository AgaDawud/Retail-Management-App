-- MariaDB dump 10.19  Distrib 10.4.32-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: retail_management
-- ------------------------------------------------------
-- Server version	10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tb_detail_transaksi`
--

DROP TABLE IF EXISTS `tb_detail_transaksi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_detail_transaksi` (
  `id_detail_transaksi` char(6) NOT NULL,
  `id_transaksi` char(6) NOT NULL,
  `id_produk` char(7) NOT NULL,
  `qty` int(2) NOT NULL,
  `subtotal` decimal(8,0) NOT NULL,
  PRIMARY KEY (`id_detail_transaksi`),
  KEY `id_transaksi` (`id_transaksi`),
  KEY `id_produk` (`id_produk`),
  CONSTRAINT `tb_detail_transaksi_ibfk_2` FOREIGN KEY (`id_transaksi`) REFERENCES `tb_transaksi` (`id_transaksi`),
  CONSTRAINT `tb_detail_transaksi_ibfk_3` FOREIGN KEY (`id_produk`) REFERENCES `tb_produk` (`id_produk`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_detail_transaksi`
--

LOCK TABLES `tb_detail_transaksi` WRITE;
/*!40000 ALTER TABLE `tb_detail_transaksi` DISABLE KEYS */;
INSERT INTO `tb_detail_transaksi` VALUES ('DT0001','TR0001','PR.0001',2,11000),('DT0002','TR0001','PR.0011',1,3500),('DT0003','TR0001','PR.0012',1,13500),('DT0004','TR0001','PR.0003',1,10000),('DT0005','TR0002','PR.0004',3,9000),('DT0006','TR0002','PR.0010',4,12000),('DT0007','TR0002','PR.0013',1,13000),('DT0008','TR0002','PR.0001',1,5500),('DT0009','TR0003','PR.0010',3,9000),('DT0010','TR0003','PR.0007',1,3500),('DT0011','TR0003','PR.0001',2,11000),('DT0012','TR0003','PR.0002',2,7000),('DT0013','TR0003','PR.0014',1,7500),('DT0014','TR0003','PR.0009',1,6000),('DT0015','TR0003','PR.0013',1,13000),('DT0016','TR0004','PR.0012',1,13500),('DT0017','TR0004','PR.0013',1,13000),('DT0018','TR0004','PR.0004',2,6000),('DT0019','TR0004','PR.0001',1,5500),('DT0020','TR0004','PR.0009',1,6000),('DT0021','TR0004','PR.0008',1,10500),('DT0022','TR0004','PR.0003',1,10000),('DT0023','TR0005','PR.0009',1,6000),('DT0024','TR0005','PR.0004',4,12000),('DT0025','TR0005','PR.0003',1,10000),('DT0026','TR0005','PR.0013',1,13000),('DT0027','TR0006','PR.0012',1,13500),('DT0028','TR0006','PR.0009',1,6000),('DT0029','TR0006','PR.0001',1,5500),('DT0030','TR0007','PR.0007',1,3500),('DT0031','TR0007','PR.0015',1,8500),('DT0032','TR0007','PR.0005',1,8500),('DT0033','TR0007','PR.0011',2,7000),('DT0034','TR0007','PR.0006',1,8000),('DT0035','TR0008','PR.0007',1,3500),('DT0036','TR0008','PR.0004',4,12000),('DT0037','TR0008','PR.0011',2,7000),('DT0038','TR0008','PR.0002',2,7000),('DT0039','TR0008','PR.0013',1,13000),('DT0040','TR0009','PR.0007',1,3500),('DT0041','TR0009','PR.0003',1,10000),('DT0042','TR0009','PR.0011',2,7000),('DT0043','TR0009','PR.0009',1,6000),('DT0044','TR0009','PR.0013',1,13000),('DT0045','TR0009','PR.0012',1,13500),('DT0046','TR0009','PR.0008',1,10500);
/*!40000 ALTER TABLE `tb_detail_transaksi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_pegawai`
--

DROP TABLE IF EXISTS `tb_pegawai`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_pegawai` (
  `id_pegawai` char(6) NOT NULL,
  `nama_pegawai` varchar(60) NOT NULL,
  `jenis_kelamin` enum('Laki-laki','Perempuan') NOT NULL,
  `tgl_lahir` date NOT NULL,
  `tempat_lahir` varchar(50) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `level` enum('admin','kasir') NOT NULL,
  PRIMARY KEY (`id_pegawai`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_pegawai`
--

LOCK TABLES `tb_pegawai` WRITE;
/*!40000 ALTER TABLE `tb_pegawai` DISABLE KEYS */;
INSERT INTO `tb_pegawai` VALUES ('PG.001','David Firmansah','Laki-laki','2025-02-06','Malang','david_101','d_101','admin'),('PG.002','Adi Maulana','Laki-laki','2008-07-10','Probolinggo','adi_102','a_102','kasir'),('PG.003','Salam Sarifudin','Laki-laki','2008-06-11','Probolinggo','salam_201','s_201','kasir'),('PG.004','Siti Fatimah','Perempuan','2008-07-18','Probolinggo','siti_202','s_202','kasir'),('PG.005','Riska Putri Andriani','Perempuan','2008-04-26','Probolinggo','riska_203','r_203','kasir'),('PG.006','Sakila Asbaul Khusna','Perempuan','2008-03-07','Probolinggo','ila_204','i_204','kasir');
/*!40000 ALTER TABLE `tb_pegawai` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_produk`
--

DROP TABLE IF EXISTS `tb_produk`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_produk` (
  `id_produk` char(7) NOT NULL,
  `nama_produk` varchar(60) NOT NULL,
  `harga_produk` int(8) NOT NULL,
  `kategori_produk` varchar(50) NOT NULL,
  PRIMARY KEY (`id_produk`),
  KEY `id_kategori_produk` (`kategori_produk`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_produk`
--

LOCK TABLES `tb_produk` WRITE;
/*!40000 ALTER TABLE `tb_produk` DISABLE KEYS */;
INSERT INTO `tb_produk` VALUES ('PR.0001','Wafer Nabati Cklt 110g',5500,'Makanan'),('PR.0002','Teh Gelas btl 220ml',3500,'Minuman'),('PR.0003','Oreo cklt 110g',10000,'Makanan'),('PR.0004','Mie Grg Sedaap 90g',3000,'Makanan'),('PR.0005','So Klin Rapika luxury gold 250ml',8500,'Pewangi Pakaian'),('PR.0006','Pasta Gigi Pepsodent 235g',8000,'Pasta Gigi'),('PR.0007','Snowman V5 Ballpoint Pen',3500,'Alat Tulis'),('PR.0008','Roma Biskuit Kelapa 300g',10500,'Makanan'),('PR.0009','Good Time Double Choc 77g',6000,'Makanan'),('PR.0010','Indomie mie grg 85g',3000,'Makanan'),('PR.0011','Air btl Aqua 600ml',3500,'Minuman'),('PR.0012','Chitato Hangout pck sapi panggang 120g',13500,'Makanan'),('PR.0013','Chitato lite hangout pck rmpt laut 120g',13000,'Makanan'),('PR.0014','Obt Nymk Cap King Kong',7500,'Obat Nyamuk'),('PR.0015','Lem Tikus Cap Gajah 100ml',8500,'Lem');
/*!40000 ALTER TABLE `tb_produk` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_transaksi`
--

DROP TABLE IF EXISTS `tb_transaksi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_transaksi` (
  `id_transaksi` char(6) NOT NULL,
  `tgl_transaksi` date NOT NULL,
  `total_harga` decimal(11,0) NOT NULL,
  `total_bayar` decimal(11,0) NOT NULL,
  `kembalian` decimal(11,0) NOT NULL,
  PRIMARY KEY (`id_transaksi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_transaksi`
--

LOCK TABLES `tb_transaksi` WRITE;
/*!40000 ALTER TABLE `tb_transaksi` DISABLE KEYS */;
INSERT INTO `tb_transaksi` VALUES ('TR0001','2025-03-08',38000,50000,12000),('TR0002','2025-03-08',39500,50000,10500),('TR0003','2025-03-08',57000,100000,43000),('TR0004','2025-03-08',64500,100000,35500),('TR0005','2025-03-08',41000,50000,9000),('TR0006','2025-03-08',25000,30000,5000),('TR0007','2025-03-08',35500,40000,4500),('TR0008','2025-03-09',42500,100000,57500),('TR0009','2025-03-09',63500,100000,36500);
/*!40000 ALTER TABLE `tb_transaksi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `vtransaksi`
--

DROP TABLE IF EXISTS `vtransaksi`;
/*!50001 DROP VIEW IF EXISTS `vtransaksi`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vtransaksi` AS SELECT
 1 AS `id_detail_transaksi`,
  1 AS `nama_produk`,
  1 AS `qty`,
  1 AS `subtotal`,
  1 AS `id_transaksi`,
  1 AS `tgl_transaksi`,
  1 AS `total_harga`,
  1 AS `total_bayar`,
  1 AS `kembalian` */;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `vtransaksi`
--

/*!50001 DROP VIEW IF EXISTS `vtransaksi`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_unicode_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vtransaksi` AS select `dt`.`id_detail_transaksi` AS `id_detail_transaksi`,`p`.`nama_produk` AS `nama_produk`,`dt`.`qty` AS `qty`,`dt`.`subtotal` AS `subtotal`,`t`.`id_transaksi` AS `id_transaksi`,`t`.`tgl_transaksi` AS `tgl_transaksi`,`t`.`total_harga` AS `total_harga`,`t`.`total_bayar` AS `total_bayar`,`t`.`kembalian` AS `kembalian` from ((`tb_produk` `p` join `tb_detail_transaksi` `dt` on(`dt`.`id_produk` = `p`.`id_produk`)) join `tb_transaksi` `t` on(`dt`.`id_transaksi` = `t`.`id_transaksi`)) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-09 15:02:17
