-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 09, 2019 at 11:45 PM
-- Server version: 5.7.17
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `game`
--
CREATE DATABASE IF NOT EXISTS `game` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `game`;

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE `accounts` (
  `id` int(10) UNSIGNED NOT NULL,
  `username` varchar(16) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `hash` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(128) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`id`, `username`, `email`, `hash`, `token`) VALUES
(12, 'seif1', 'seif2@yahoo.be', '$2y$10$cup7h.qwG3bflLSBpOFWhuAaQ/7pFNrk72.XiGiAs0E8tdf.RutFK', 'UwjnE9Bh0ZG8aSvwTaxxnHLMlOEl0l9P5EKiOzpnTsA9y9hdvZVFYOv4FXvyOiRH894BQn5REjnyNNViZab9ri8KRve9vDsY32giKyDIix2kVOrJlJj1M9CMWpP73kUB'),
(11, 'markBitchBOy', 'itchboy@hotmail.com', '$2y$10$zy/jKmp2S04rzxkIsMIgNe8xW6MGEW3h49AVcKN0TgfMGOi5GcdR.', 'CB9fc0Qpbv0JyEkALy1OMNQK4uZeBeaCS5CJOG3WU5G48UftXeWZkEuYJh6f8Gxb0XXAjI8Qw3fMBx2J1hIxKS0zgq6DwvL70cbPF858ZoGRVyIlXIns3uoxGXZpNHSq'),
(9, 'Hallo', '26275@student.glu.nl', '$2y$10$Cn4UrH81isKhy4tB2vAtHexd/DMXnKDLAWeAYPdKvxGDDAgj2HE5S', 'yOHaMRYSxrDMWNwTyD1EubV1l8CucKU1EHa5OeeDf3ra3oDDQYauIZTJeb7OvLIH8s1SctSijxDqyR8fwaIdiGdju6Z0bGTgZ6fxZBTOLTcyqcZJyfCOgfVM8Uf4fsrG'),
(10, 'Heartdavid', '24569@student.glu.nl', '$2y$10$ah/7Zg37EYoVCdSbCYwhe.RKv3QCs52gZNkGgKY7Vddt8VTafLUj6', ''),
(7, 'davidjans', 'davidjejans@hotmail.nl', '$2y$10$zLLKM4ufjevfTQ8jalY.ou2ep6b5QoNX6JCsI9vlK1Gfnp4tQzR92', 'HO6aTjpzGCdgL5ZklxHmajPtrhjfTLDMJBMEFacYVgRkfhfOO1k2nQy48BTvODPsDMkvinRK3hoMBQnGaSO4sL91Hjm9BTUwpkLJOYpT3GMBPMoWn7bup2Cm8oG9hwQW'),
(8, 'baaan', 'ktogoelova@gmail.com', '$2y$10$i5yEWP1Qzz6piazyfIyOx.8qW1WOiagZGZMJTR0r9/57GLD8zR5y2', 'vaOz62VkZ31so42y2ptJ7WgznYU91om5Mv6tRb4TYKMrm39IJrHOjLlkNmBkq4prVegKtH6QQOpOdq9gjRNhnYjs67aTI7lbVkipYAZazfUzV90bLDL7jy9YgeCPRx9h');

-- --------------------------------------------------------

--
-- Table structure for table `ships`
--

CREATE TABLE `ships` (
  `id` int(11) NOT NULL,
  `shiptype` int(2) NOT NULL,
  `attackspeedlevel` int(11) NOT NULL,
  `damagelevel` int(11) NOT NULL,
  `armorlevel` int(11) NOT NULL,
  `speedlevel` int(11) NOT NULL,
  `healthlevel` int(11) NOT NULL,
  `credits` int(11) NOT NULL,
  `difficulty` int(11) NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `ships`
--

INSERT INTO `ships` (`id`, `shiptype`, `attackspeedlevel`, `damagelevel`, `armorlevel`, `speedlevel`, `healthlevel`, `credits`, `difficulty`, `user_id`) VALUES
(1, 1, 8, 25, 8, 3, 1, 112, 32, 7),
(2, 2, 2, 2, 1, 1, 1, 0, 1, 7),
(3, 3, 28, 28, 1, 28, 1, 1760, 19, 7),
(4, 4, 2, 1, 2, 1, 2, 55, 1, 7),
(5, 1, 1, 2, 2, 1, 1, 0, 1, 8),
(6, 2, 2, 2, 1, 1, 1, 0, 1, 8),
(7, 3, 2, 1, 1, 2, 1, 0, 1, 8),
(8, 4, 1, 1, 2, 1, 2, 0, 1, 8),
(9, 1, 1, 2, 2, 1, 1, 0, 1, 9),
(10, 2, 2, 2, 1, 1, 1, 0, 1, 9),
(11, 3, 2, 1, 1, 2, 1, 0, 1, 9),
(12, 4, 1, 1, 2, 1, 2, 0, 1, 9),
(13, 1, 1, 2, 2, 1, 1, 0, 1, 10),
(14, 2, 2, 2, 1, 1, 1, 0, 1, 10),
(15, 3, 2, 1, 1, 2, 1, 0, 1, 10),
(16, 4, 1, 1, 2, 1, 2, 0, 1, 10),
(17, 1, 1, 2, 2, 1, 1, 0, 1, 11),
(18, 2, 2, 2, 1, 1, 1, 0, 1, 11),
(19, 3, 2, 1, 1, 2, 1, 0, 1, 11),
(20, 4, 1, 1, 2, 1, 2, 0, 1, 11),
(21, 1, 1, 2, 2, 1, 1, 0, 1, 12),
(22, 2, 2, 2, 1, 1, 1, 0, 1, 12),
(23, 3, 2, 1, 1, 2, 1, 0, 1, 12),
(24, 4, 1, 1, 2, 1, 2, 0, 1, 12);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indexes for table `ships`
--
ALTER TABLE `ships`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accounts`
--
ALTER TABLE `accounts`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
--
-- AUTO_INCREMENT for table `ships`
--
ALTER TABLE `ships`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
