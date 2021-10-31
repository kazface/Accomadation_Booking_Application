-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Aug 31, 2021 at 06:48 PM
-- Server version: 5.7.24
-- PHP Version: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `database1`
--

-- --------------------------------------------------------

--
-- Table structure for table `block`
--

CREATE TABLE `block` (
  `Block_ID` int(11) NOT NULL,
  `Block_Name` varchar(1) NOT NULL,
  `Block_Gender` varchar(10) NOT NULL,
  `Block_Floors` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `block`
--

INSERT INTO `block` (`Block_ID`, `Block_Name`, `Block_Gender`, `Block_Floors`) VALUES
(1, 'A', 'Male', 5),
(2, 'B', 'Female', 4);

-- --------------------------------------------------------

--
-- Table structure for table `bookings`
--

CREATE TABLE `bookings` (
  `Booking_ID` int(11) NOT NULL,
  `User_ID` int(11) NOT NULL,
  `Booking_Start_Date` date NOT NULL,
  `Booking_End_Date` date NOT NULL,
  `Booking_Status` varchar(25) NOT NULL,
  `Booking_Type` varchar(25) NOT NULL,
  `Booking_Block` varchar(35) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `bookings`
--

INSERT INTO `bookings` (`Booking_ID`, `User_ID`, `Booking_Start_Date`, `Booking_End_Date`, `Booking_Status`, `Booking_Type`, `Booking_Block`) VALUES
(1, 2, '2021-08-01', '2021-08-24', 'Rejected', 'Standart', 'B'),
(3, 2, '2021-08-31', '2021-11-14', 'Approved', 'Standart', 'B'),
(5, 2, '2021-08-15', '2021-10-15', 'Rejected', 'Standart', 'B'),
(2, 3, '2021-08-17', '2021-12-22', 'Approved', 'Suite', 'B'),
(4, 3, '2021-08-15', '2022-02-15', 'Rejected', 'Standart', 'B'),
(6, 4, '2021-08-20', '2021-11-21', 'Approved', 'Standart', 'A'),
(7, 5, '2021-08-29', '2022-04-01', 'Approved', 'Suite', 'A'),
(8, 6, '2021-09-09', '2021-12-09', 'Rejected', 'Premium', 'B'),
(14, 6, '2021-10-06', '2022-03-03', 'Approved', 'Standart', 'B'),
(13, 7, '2021-10-01', '2022-01-01', 'New', 'Standart', 'A'),
(9, 8, '2021-09-29', '2022-03-29', 'Approved', 'Suite', 'A'),
(10, 9, '2021-08-31', '2021-09-04', 'Approved', 'Suite', 'B'),
(11, 10, '2021-09-01', '2021-12-01', 'Approved', 'Standart', 'A'),
(12, 11, '2021-11-01', '2022-01-01', 'Approved', 'Suite', 'A');

-- --------------------------------------------------------

--
-- Table structure for table `change_req`
--

CREATE TABLE `change_req` (
  `Change_Req_ID` int(11) NOT NULL,
  `Booking_ID` int(11) NOT NULL,
  `Change_Block` varchar(25) NOT NULL,
  `Change_Type` varchar(25) NOT NULL,
  `Change_Req_Status` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `change_req`
--

INSERT INTO `change_req` (`Change_Req_ID`, `Booking_ID`, `Change_Block`, `Change_Type`, `Change_Req_Status`) VALUES
(1, 1, 'B', 'Premium', 'Rejected'),
(2, 7, 'A', 'Premium', 'Approved'),
(3, 10, 'B', 'Premium', 'Approved'),
(4, 12, 'A', 'Premium', 'New');

-- --------------------------------------------------------

--
-- Table structure for table `feedbacks`
--

CREATE TABLE `feedbacks` (
  `Feedback_ID` int(11) NOT NULL,
  `Feedback_Type` varchar(25) NOT NULL,
  `Feedback_Description` varchar(200) NOT NULL,
  `Feedback_Status` varchar(25) NOT NULL,
  `User_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `feedbacks`
--

INSERT INTO `feedbacks` (`Feedback_ID`, `Feedback_Type`, `Feedback_Description`, `Feedback_Status`, `User_ID`) VALUES
(1, 'Cleaning', 'VERY DIRTY', 'New', 2),
(2, 'Cleaning', 'IT IS VERY VERY DIRTY!', 'New', 2),
(3, 'Breaking', 'AAAA HELP!', 'In Process', 3),
(4, 'Cleaning', 'When I checked in my room was so dirty, why is that? This also applies to a bathroom with a toilet. Moreover, there was a fierce horror under the bed!', 'New', 3),
(5, 'Facilities', 'When I checked in my room was so dirty, why is that? This also applies to a bathroom with a toilet. Moreover, there was a fierce horror under the bed!', 'New', 3),
(6, 'Breaking', 'When I checked in my room was so dirty, why is that? This also applies to a bathroom with a toilet. Moreover, there was a fierce horror under the bed!', 'Complated', 3),
(7, 'Another', 'When I checked in my room was so dirty, why is that? This also applies to a bathroom with a toilet. Moreover, there was a fierce horror under the bed!', 'New', 3),
(8, 'Cleaning', 'Please clean my room. It is very very dirty! OMG! HELP ME!', 'New', 5),
(9, 'Cleaning', 'HERE IS VERY DIRTY! WHY ARE YOU DONT CLEAN THIS APPARTMENTS!!! HELP ME! I WANT TO LIVE IN CLEAN PLACE!!!!', 'Complated', 9);

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE `rooms` (
  `Room_ID` int(11) NOT NULL,
  `Room_Name` varchar(25) NOT NULL,
  `Room_Type` varchar(25) NOT NULL,
  `Block_ID` int(11) NOT NULL,
  `Room_Status` varchar(20) NOT NULL,
  `Room_Floor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`Room_ID`, `Room_Name`, `Room_Type`, `Block_ID`, `Room_Status`, `Room_Floor`) VALUES
(1, 'A-1-S', 'Standart', 1, '', 1),
(2, 'A-1-P', 'Premium', 1, '', 1),
(3, 'A-1-ST', 'Suite', 1, '', 1),
(4, 'A-2-S', 'Standart', 1, '', 2),
(5, 'A-2-P', 'Premium', 1, '', 2),
(6, 'A-2-ST', 'Suite', 1, '', 2),
(7, 'A-3-S', 'Standart', 1, '', 3),
(8, 'A-3-P', 'Premium', 1, '', 3),
(9, 'A-3-ST', 'Suite', 1, '', 3),
(10, 'A-4-S', 'Standart', 1, '', 4),
(11, 'A-4-P', 'Premium', 1, '', 4),
(12, 'A-4-ST', 'Suite', 1, '', 4),
(13, 'A-5-S', 'Standart', 1, '', 5),
(14, 'A-5-P', 'Premium', 1, '', 5),
(15, 'A-5-ST', 'Suite', 1, '', 5),
(16, 'B-1-S', 'Standart', 2, '', 1),
(17, 'B-1-P', 'Premium', 2, '', 1),
(18, 'B-1-ST', 'Suite', 2, '', 1),
(19, 'B-2-S', 'Standart', 2, '', 2),
(20, 'B-2-P', 'Premium', 2, '', 2),
(21, 'B-2-ST', 'Suite', 2, '', 2),
(22, 'B-3-S', 'Standart', 2, '', 3),
(23, 'B-3-P', 'Premium', 2, '', 3),
(24, 'B-3-ST', 'Suite', 2, '', 3),
(25, 'B-4-S', 'Standart', 2, '', 4),
(26, 'B-4-P', 'Premium', 2, '', 0),
(27, 'B-4-ST', 'Suite', 2, '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `room_id-user_id`
--

CREATE TABLE `room_id-user_id` (
  `Room_ID` int(11) NOT NULL,
  `User_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `room_id-user_id`
--

INSERT INTO `room_id-user_id` (`Room_ID`, `User_ID`) VALUES
(16, 2),
(24, 3),
(7, 4),
(22, 6),
(12, 8),
(23, 9),
(1, 10),
(9, 11);

-- --------------------------------------------------------

--
-- Table structure for table `terminations_req`
--

CREATE TABLE `terminations_req` (
  `Ter_ID` int(11) NOT NULL,
  `Ter_Description` varchar(250) NOT NULL,
  `Ter_Check_Out` date NOT NULL,
  `Ter_Status` varchar(25) NOT NULL,
  `User_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `terminations_req`
--

INSERT INTO `terminations_req` (`Ter_ID`, `Ter_Description`, `Ter_Check_Out`, `Ter_Status`, `User_ID`) VALUES
(2, 'I want to leave the room, since I decided to rent an apartment with friends, and besides, it comes out much cheaper for me.', '2021-08-15', 'New', 2),
(3, 'Just let me get out of here, please! I WANT TO QUIT !!!!!', '2021-08-15', 'Rejected', 2),
(4, 'I want to go away please!!!!!! I WANT TO LIVE IN APPARTMENT PLEASE PLEASE PLEASE PLEASE PLEASE PLEASE PLEASE PLEASE PLEASE PLEASE PLEASE !!!!!', '2021-09-10', 'Rejected', 5),
(5, 'I want to go away please!\nI want to go away please!\nI want to go away please!\nI want to go away please!\nI want to go away please!\nI want to go away please!\nI want to go away please!\n', '2021-09-10', 'Approved', 5),
(6, 'I want to exit from accomadation, becouse i dont have anough money for paying. Pricing for me is very high! Help ME!', '2021-09-04', 'Approved', 9),
(7, 'LET ME GO OUT PLEASE I WANT TO GO OUT PLEASE! I CANT LEAVE HERE!!! HHEEEEELLPPPP!!!!!!! AAAAA!', '2021-10-01', 'New', 10);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `login` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL,
  `name` varchar(64) NOT NULL,
  `email` varchar(64) NOT NULL,
  `warden` int(1) NOT NULL,
  `gender` varchar(7) NOT NULL,
  `Phone` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `login`, `password`, `name`, `email`, `warden`, `gender`, `Phone`) VALUES
(1, 'Admin', 'Admin12345', 'Kakimov Batyrkhan', 'batyr200288@gmail.com', 1, 'Male', ''),
(2, 'Dilyalala', 'Dilnaz12345', 'Bakhtiyarova Dilnaz', 'Dilyalala02@gmail.com', 0, 'Female', '+77070225287'),
(3, 'Aisulu123', 'Aisulu12345', 'Kongreyeva Aisulu', 'Ais20000@gmail.com', 0, 'Female', '+77070225287'),
(4, 'Batyr', 'Batyr12345', 'Kakimov Batyrkhan', 'batyr200288@gmail.com', 0, 'Male', '+77070225287'),
(5, 'Muhamed123', 'Muhamed12346', 'Muhamed', 'Muhamed@mail.com', 0, 'Male', '+7707024323'),
(6, 'Gulzhan76', 'Gulzhan1234', 'Yerzhanova Gulzhian', 'gulzhian@mail.ru', 0, 'Female', '+77070225289'),
(7, 'Imanbek228', 'Imanbek123', 'Imanbek', 'Imanbek123@mail.kz', 0, 'Male', '+7707024322'),
(8, 'Android123', 'Android123', 'Asif Khan', 'Khan@mail.com', 0, 'Male', '+7707024323'),
(9, 'Elsacat', 'Elsacat123', 'Elsa Koshka', 'Elza@mail.com', 0, 'Female', '+77474888872'),
(10, 'Muhtar', 'Muha12345', 'Bazylkhanov Muhtar', 'Muha@mail.com', 0, 'Male', '+7747777232'),
(11, 'Alikhan', 'Alikhan123', 'Tulegenov Alikhan', 'alih@mail.com', 0, 'Male', '+77070223342');

-- --------------------------------------------------------

--
-- Stand-in structure for view `view1`
-- (See below for the actual view)
--
CREATE TABLE `view1` (
`Room_Name` varchar(25)
,`User_ID` int(11)
,`name` varchar(64)
,`Booking_Start_Date` date
,`Booking_End_Date` date
);

-- --------------------------------------------------------

--
-- Structure for view `view1`
--
DROP TABLE IF EXISTS `view1`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view1`  AS  select `r`.`Room_Name` AS `Room_Name`,`ru`.`User_ID` AS `User_ID`,`u`.`name` AS `name`,`b`.`Booking_Start_Date` AS `Booking_Start_Date`,`b`.`Booking_End_Date` AS `Booking_End_Date` from (((`rooms` `r` left join `room_id-user_id` `ru` on((`ru`.`Room_ID` = `r`.`Room_ID`))) left join `users` `u` on((`u`.`id` = `ru`.`User_ID`))) left join `bookings` `b` on((`ru`.`User_ID` = `b`.`User_ID`))) where ((`b`.`Booking_Status` = 'Approved') and (`b`.`Booking_Start_Date` is not null) and (`b`.`Booking_End_Date` is not null)) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `block`
--
ALTER TABLE `block`
  ADD PRIMARY KEY (`Block_ID`),
  ADD UNIQUE KEY `Block_Name` (`Block_Name`);

--
-- Indexes for table `bookings`
--
ALTER TABLE `bookings`
  ADD PRIMARY KEY (`User_ID`,`Booking_ID`),
  ADD KEY `Booking_ID` (`Booking_ID`),
  ADD KEY `fk_bookings_blocks1` (`Booking_Block`);

--
-- Indexes for table `change_req`
--
ALTER TABLE `change_req`
  ADD PRIMARY KEY (`Change_Req_ID`,`Booking_ID`),
  ADD KEY `Booking_ID` (`Booking_ID`);

--
-- Indexes for table `feedbacks`
--
ALTER TABLE `feedbacks`
  ADD PRIMARY KEY (`Feedback_ID`),
  ADD KEY `fk_feedbacks_users1` (`User_ID`);

--
-- Indexes for table `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`Room_ID`,`Block_ID`),
  ADD KEY `fk_rooms_block_idx` (`Block_ID`);

--
-- Indexes for table `room_id-user_id`
--
ALTER TABLE `room_id-user_id`
  ADD PRIMARY KEY (`Room_ID`,`User_ID`),
  ADD KEY `fk_Room_ID-User_ID_users1_idx` (`User_ID`);

--
-- Indexes for table `terminations_req`
--
ALTER TABLE `terminations_req`
  ADD PRIMARY KEY (`Ter_ID`),
  ADD KEY `fk_termination_req_user1` (`User_ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `block`
--
ALTER TABLE `block`
  MODIFY `Block_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `bookings`
--
ALTER TABLE `bookings`
  MODIFY `Booking_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `change_req`
--
ALTER TABLE `change_req`
  MODIFY `Change_Req_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `feedbacks`
--
ALTER TABLE `feedbacks`
  MODIFY `Feedback_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `Room_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `terminations_req`
--
ALTER TABLE `terminations_req`
  MODIFY `Ter_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bookings`
--
ALTER TABLE `bookings`
  ADD CONSTRAINT `fk_bookings_blocks1` FOREIGN KEY (`Booking_Block`) REFERENCES `block` (`Block_Name`),
  ADD CONSTRAINT `fk_bookings_users1` FOREIGN KEY (`User_ID`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `change_req`
--
ALTER TABLE `change_req`
  ADD CONSTRAINT `change_req_ibfk_1` FOREIGN KEY (`Booking_ID`) REFERENCES `bookings` (`Booking_ID`);

--
-- Constraints for table `feedbacks`
--
ALTER TABLE `feedbacks`
  ADD CONSTRAINT `fk_feedbacks_users1` FOREIGN KEY (`User_ID`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `rooms`
--
ALTER TABLE `rooms`
  ADD CONSTRAINT `fk_rooms_block` FOREIGN KEY (`Block_ID`) REFERENCES `block` (`Block_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `room_id-user_id`
--
ALTER TABLE `room_id-user_id`
  ADD CONSTRAINT `fk_Room_ID-User_ID_rooms1` FOREIGN KEY (`Room_ID`) REFERENCES `rooms` (`Room_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Room_ID-User_ID_users1` FOREIGN KEY (`User_ID`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `terminations_req`
--
ALTER TABLE `terminations_req`
  ADD CONSTRAINT `fk_termination_req_user1` FOREIGN KEY (`User_ID`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
