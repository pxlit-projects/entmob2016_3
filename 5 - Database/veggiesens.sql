-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Gegenereerd op: 05 nov 2016 om 10:30
-- Serverversie: 10.1.16-MariaDB
-- PHP-versie: 5.6.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `veggiesens`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `growable_items`
--

CREATE TABLE `growable_items` (
  `ID` int(5) NOT NULL,
  `NAME` varchar(30) NOT NULL,
  `DESCRIPTION` varchar(255) NOT NULL,
  `IMAGE` varchar(255) NOT NULL,
  `TEMPERATURE_FK` int(5) NOT NULL,
  `HUMIDITY_FK` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `growable_items`
--

INSERT INTO `growable_items` (`ID`, `NAME`, `DESCRIPTION`, `IMAGE`, `TEMPERATURE_FK`, `HUMIDITY_FK`) VALUES
(1, 'Red Tomato', 'Red tomato is the edible, red fruit of Solanum lycopersicum, commonly known as a tomato plant, which belongs to the nightshade family', 'ms-appx:///images/Vegetables/Tomato.png', 1, 3),
(2, 'Bean', 'Bean is a common name for large seeds of several genera of the flowering plant family Fabaceae (also known as Leguminosae) which are used for human or animal food.', 'ms-appx:///images/Vegetables/Beans.png', 2, 3),
(3, 'Bell Pepper', 'Bell pepper is a cultivar group of the species Capsicum annuum. Cultivars of the plant produce fruits in different colors, including red, yellow, orange, green, chocolate/brown, vanilla/white, and purple.', 'ms-appx:///Images/Vegetables/Bell_Pepper.png', 3, 3),
(4, 'Cabbage', 'Cabbage or headed cabbage is a leafy green or purple biennial plant, grown as an annual vegetable crop for its dense-leaved heads.', 'ms-appx:///Images/Vegetables/Cabbage.png', 4, 3),
(5, 'Garlic', 'Allium sativum, commonly known as garlic, is a species in the onion genus.', 'ms-appx:///Images/Vegetables/Garlic.png', 5, 3),
(6, 'Potato', 'The potato is a starchy, tuberous crop from the perennial nightshade Solanum tuberosum.', 'ms-appx:///Images/Vegetables/Potato.png', 6, 2),
(7, 'Strawberry', 'The garden strawberry is a widely grown hybrid species of the genus Fragaria.', 'ms-appx:///Images/Vegetables/Strawberry.png', 7, 3),
(8, 'Red cabbage', 'The red cabbage is a kind of cabbage, also known as purple cabbage, red kraut, or blue kraut after preparation. Its leaves are coloured dark red/purple.', 'ms-appx:///Images/Vegetables/Red_Cabbage.png', 8, 3),
(9, 'Chives', 'Chives is the common name of Allium schoenoprasum, an edible species of the Allium genus.', 'ms-appx:///Images/Vegetables/Chive.png', 9, 4),
(11, 'Pumpkin', 'A pumpkin is a cultivar of a squash plant, most commonly of Cucurbita pepo, that is round, with smooth, slightly ribbed skin, and deep yellow to orange coloration.', 'ms-appx:///images/Vegetables/Pumpkin.png', 11, 3);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `humidity`
--

CREATE TABLE `humidity` (
  `HUMIDITY_ID` int(5) NOT NULL,
  `MIN_IDEAL_HUMIDITY` int(5) NOT NULL,
  `MAX_IDEAL_HUMIDITY` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `humidity`
--

INSERT INTO `humidity` (`HUMIDITY_ID`, `MIN_IDEAL_HUMIDITY`, `MAX_IDEAL_HUMIDITY`) VALUES
(1, 0, 30),
(2, 30, 50),
(3, 50, 60),
(4, 60, 90);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `humidity_registered_values`
--

CREATE TABLE `humidity_registered_values` (
  `HUM_REG_ID` int(11) NOT NULL,
  `HUM_DATE` date NOT NULL,
  `HUM_VALUE` double NOT NULL,
  `HUM_FK` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `humidity_registered_values`
--

INSERT INTO `humidity_registered_values` (`HUM_REG_ID`, `HUM_DATE`, `HUM_VALUE`, `HUM_FK`) VALUES
(1, '2016-10-20', 64, 2),
(2, '2016-10-21', 58, 2),
(3, '2016-10-22', 52, 2),
(4, '2016-10-23', 45, 2),
(5, '2016-10-24', 82, 2),
(6, '2016-10-25', 80, 2),
(7, '2016-10-26', 74, 2);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `sensortype`
--

CREATE TABLE `sensortype` (
  `SENSORTYPE_ID` int(11) NOT NULL,
  `SENSOR_NAME` varchar(50) NOT NULL,
  `SENSOR_UNIT` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `sensortype`
--

INSERT INTO `sensortype` (`SENSORTYPE_ID`, `SENSOR_NAME`, `SENSOR_UNIT`) VALUES
(1, 'Temperature Sensor', '(°C)'),
(2, 'Humidity Sensor', '(%)');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `temperature`
--

CREATE TABLE `temperature` (
  `TEMPERATURE_ID` int(5) NOT NULL,
  `MIN_IDEAL_TEMPERATURE` int(5) NOT NULL,
  `MAX_IDEAL_TEMPERATURE` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `temperature`
--

INSERT INTO `temperature` (`TEMPERATURE_ID`, `MIN_IDEAL_TEMPERATURE`, `MAX_IDEAL_TEMPERATURE`) VALUES
(1, 20, 23),
(2, 10, 15),
(3, 18, 23),
(4, 16, 25),
(5, 25, 30),
(6, 17, 19),
(7, 18, 20),
(8, 20, 22),
(9, 24, 26),
(11, 22, 26);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `temperature_registered_values`
--

CREATE TABLE `temperature_registered_values` (
  `TEMP_REG_ID` int(11) NOT NULL,
  `TEMP_DATE` date NOT NULL,
  `TEMP_VALUE` double NOT NULL,
  `TEMP_FK` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `temperature_registered_values`
--

INSERT INTO `temperature_registered_values` (`TEMP_REG_ID`, `TEMP_DATE`, `TEMP_VALUE`, `TEMP_FK`) VALUES
(1, '2016-10-20', 26.5, 1),
(2, '2016-10-21', 23.7, 1),
(3, '2016-10-22', 22.2, 1),
(4, '2016-10-23', 18.8, 1),
(5, '2016-10-24', 20.3, 1),
(6, '2016-10-25', 26.9, 1),
(7, '2016-10-26', 30.5, 1);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

CREATE TABLE `users` (
  `USER_ID` int(5) NOT NULL,
  `USERNAME` varchar(30) NOT NULL,
  `PASSWORD` varchar(800) NOT NULL,
  `ROLE` varchar(50) NOT NULL,
  `ENABLED` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`USER_ID`, `USERNAME`, `PASSWORD`, `ROLE`, `ENABLED`) VALUES
(1, 'arno', 'fe3f6933bcb74a310dcbd0fc58ab022caa218a5727124f3da5b3800439da87dd', 'ROLE_ADMIN', b'1');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `growable_items`
--
ALTER TABLE `growable_items`
  ADD PRIMARY KEY (`ID`);

--
-- Indexen voor tabel `humidity`
--
ALTER TABLE `humidity`
  ADD PRIMARY KEY (`HUMIDITY_ID`);

--
-- Indexen voor tabel `humidity_registered_values`
--
ALTER TABLE `humidity_registered_values`
  ADD PRIMARY KEY (`HUM_REG_ID`);

--
-- Indexen voor tabel `sensortype`
--
ALTER TABLE `sensortype`
  ADD PRIMARY KEY (`SENSORTYPE_ID`);

--
-- Indexen voor tabel `temperature`
--
ALTER TABLE `temperature`
  ADD PRIMARY KEY (`TEMPERATURE_ID`);

--
-- Indexen voor tabel `temperature_registered_values`
--
ALTER TABLE `temperature_registered_values`
  ADD PRIMARY KEY (`TEMP_REG_ID`);

--
-- Indexen voor tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`USER_ID`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `growable_items`
--
ALTER TABLE `growable_items`
  MODIFY `ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT voor een tabel `humidity`
--
ALTER TABLE `humidity`
  MODIFY `HUMIDITY_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;
--
-- AUTO_INCREMENT voor een tabel `humidity_registered_values`
--
ALTER TABLE `humidity_registered_values`
  MODIFY `HUM_REG_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT voor een tabel `sensortype`
--
ALTER TABLE `sensortype`
  MODIFY `SENSORTYPE_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT voor een tabel `temperature`
--
ALTER TABLE `temperature`
  MODIFY `TEMPERATURE_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;
--
-- AUTO_INCREMENT voor een tabel `temperature_registered_values`
--
ALTER TABLE `temperature_registered_values`
  MODIFY `TEMP_REG_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `USER_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
