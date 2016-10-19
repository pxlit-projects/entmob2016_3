-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Gegenereerd op: 18 okt 2016 om 11:31
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
(1, 'Red Tomato', 'Red tomato is the edible, red fruit of Solanum lycopersicum, commonly known as a tomato plant, which belongs to the nightshade family', 'ms-appx:///Images/Vegetables/Tomato.png', 1, 4),
(2, 'Beans', 'Bean is a common name for large seeds of several genera of the flowering plant family Fabaceae (also known as Leguminosae) which are used for human or animal food.', 'ms-appx:///Images/Vegetables/Cabbage.png', 2, 3),
(3, 'Bell Pepper', 'Bell pepper is a cultivar group of the species Capsicum annuum. Cultivars of the plant produce fruits in different colors, including red, yellow, orange, green, chocolate/brown, vanilla/white, and purple.', 'ms-appx:///Images/Vegetables/Bell_Pepper.png', 3, 3),
(4, 'Cabbage', 'Cabbage or headed cabbage is a leafy green or purple biennial plant, grown as an annual vegetable crop for its dense-leaved heads.', 'ms-appx:///Images/Vegetables/Cabbage.png', 4, 3),
(5, 'Garlic', 'Allium sativum, commonly known as garlic, is a species in the onion genus.', 'ms-appx:///Images/Vegetables/Garlic.png', 5, 3),
(6, 'Potato', 'The potato is a starchy, tuberous crop from the perennial nightshade Solanum tuberosum.', 'ms-appx:///Images/Vegetables/Potato.png', 6, 2),
(7, 'Strawberry', 'The garden strawberry is a widely grown hybrid species of the genus Fragaria.', 'ms-appx:///Images/Vegetables/Strawberry.png', 7, 3),
(8, 'Red cabbage', 'The red cabbage is a kind of cabbage, also known as purple cabbage, red kraut, or blue kraut after preparation. Its leaves are coloured dark red/purple.', 'ms-appx:///Images/Vegetables/Red_Cabbage.png', 8, 3),
(9, 'Chives', 'Chives is the common name of Allium schoenoprasum, an edible species of the Allium genus.', 'ms-appx:///Images/Vegetables/Chive.png', 9, 4);

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
(4, 16, 25),
(5, 25, 30),
(6, 17, 19),
(7, 18, 20),
(8, 20, 22),
(9, 24, 26);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `usergroups`
--

CREATE TABLE `usergroups` (
  `USERGROUP_ID` int(5) NOT NULL,
  `GROUPNAME` varchar(30) NOT NULL,
  `PERMISSION_LEVEL` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

CREATE TABLE `users` (
  `USER_ID` int(5) NOT NULL,
  `USERGROUP_FK` int(5) NOT NULL,
  `USERNAME` varchar(30) NOT NULL,
  `PASSWORD` varchar(800) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
-- Indexen voor tabel `temperature`
--
ALTER TABLE `temperature`
  ADD PRIMARY KEY (`TEMPERATURE_ID`);

--
-- Indexen voor tabel `usergroups`
--
ALTER TABLE `usergroups`
  ADD PRIMARY KEY (`USERGROUP_ID`);

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
  MODIFY `ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT voor een tabel `humidity`
--
ALTER TABLE `humidity`
  MODIFY `HUMIDITY_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT voor een tabel `temperature`
--
ALTER TABLE `temperature`
  MODIFY `TEMPERATURE_ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT voor een tabel `usergroups`
--
ALTER TABLE `usergroups`
  MODIFY `USERGROUP_ID` int(5) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `USER_ID` int(5) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
