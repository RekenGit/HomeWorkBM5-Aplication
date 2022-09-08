-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 07 Wrz 2022, 13:41
-- Wersja serwera: 10.4.17-MariaDB
-- Wersja PHP: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `hospital`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `doctors`
--

CREATE TABLE `doctors` (
  `id` int(11) NOT NULL,
  `firstName` text NOT NULL,
  `secondName` text NOT NULL,
  `academicTittle` text NOT NULL,
  `email` text NOT NULL,
  `phoneNumber` text NOT NULL,
  `specialization` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `doctors`
--

INSERT INTO `doctors` (`id`, `firstName`, `secondName`, `academicTittle`, `email`, `phoneNumber`, `specialization`) VALUES
(1, 'Damian', 'Nowakowski', 'Profesor', '123456@gmail.com', '000111222', 1),
(2, 'Dawid', 'Kowalski', 'Lekarz', '654321@gmail.com', '123456789', 2),
(3, 'Dawid', 'Sakowski', 'Doktor', 'DS-doctor@gmail.com', '101022233', 3),
(4, 'Bartosz', 'Kolanko', 'Lekarz', 'loremIpsum@gmail.com', '333222111', 4),
(5, 'Maria', 'Skoczek', 'Doktor', 'MSMS@gmail.com', '999888777', 3),
(6, 'Ivan', 'Bobrov', 'Lekarz', 'IBmail@gmail.com', '454545454', 5);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `specialization`
--

CREATE TABLE `specialization` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `specialization`
--

INSERT INTO `specialization` (`id`, `name`) VALUES
(1, 'Chirurgia ogólna'),
(2, 'Choroby zakaźne'),
(3, 'Hematologia'),
(4, 'Diagnostyka laboratoryjna'),
(5, 'Nefrologia');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `workplace`
--

CREATE TABLE `workplace` (
  `id` int(11) NOT NULL,
  `doctorId` int(11) NOT NULL,
  `jobName` text NOT NULL,
  `cityName` text NOT NULL,
  `streetName` text NOT NULL,
  `streetNumber` text NOT NULL,
  `apartment` text DEFAULT NULL,
  `zipCode` text NOT NULL,
  `province` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `workplace`
--

INSERT INTO `workplace` (`id`, `doctorId`, `jobName`, `cityName`, `streetName`, `streetNumber`, `apartment`, `zipCode`, `province`) VALUES
(1, 1, 'Szpital Kliniczny', 'Kraków', 'Koniecznych', '5a', NULL, '31-123', 'Małopolskie'),
(2, 1, 'Szpital nr.15', 'Kraków', 'Zakopanych', '11', '12', '31-123', 'Małopolskie'),
(3, 2, 'Weterynaria', 'Warszawa', 'Krzyżówki', '1', NULL, '03-191', 'Mazowieckie'),
(4, 2, 'Szpital Główny', 'Warszawa', 'Żelazna', '90', NULL, '01-004', 'Mazowieckie'),
(5, 3, 'Szpital Wojskowy', 'Otwock', 'Reymonta', '83', '91', '05-400', 'Mazowieckie'),
(6, 4, 'Szpital Główny', 'Warszawa', 'Żelazna', '90', NULL, '01-004', 'Mazowieckie'),
(7, 5, 'Szpital nr.15', 'Kraków', 'Zakopanych', '11', '10', '31-123', 'Małopolskie'),
(8, 5, 'Szpital Główny', 'Warszawa', 'Żelazna', '90', NULL, '01-004', 'Mazowieckie'),
(9, 6, 'Szpital Kliniczny', 'Kraków', 'Koniecznych', '5a', NULL, '31-123', 'Małopolskie');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `doctors`
--
ALTER TABLE `doctors`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `specialization`
--
ALTER TABLE `specialization`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `workplace`
--
ALTER TABLE `workplace`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `doctors`
--
ALTER TABLE `doctors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT dla tabeli `specialization`
--
ALTER TABLE `specialization`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `workplace`
--
ALTER TABLE `workplace`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
