-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 18, 2021 at 10:39 AM
-- Server version: 8.0.27
-- PHP Version: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bitnami_redmine`
--

-- --------------------------------------------------------

--
-- Table structure for table `issues`
--

CREATE TABLE `issues` (
  `id` int NOT NULL,
  `tracker_id` int NOT NULL,
  `project_id` int NOT NULL,
  `subject` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `description` longtext COLLATE utf8mb4_unicode_ci,
  `due_date` date DEFAULT NULL,
  `category_id` int DEFAULT NULL,
  `status_id` int NOT NULL,
  `assigned_to_id` int DEFAULT NULL,
  `priority_id` int NOT NULL,
  `fixed_version_id` int DEFAULT NULL,
  `author_id` int NOT NULL,
  `lock_version` int NOT NULL DEFAULT '0',
  `created_on` timestamp NULL DEFAULT NULL,
  `updated_on` timestamp NULL DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `done_ratio` int NOT NULL DEFAULT '0',
  `estimated_hours` float DEFAULT NULL,
  `parent_id` int DEFAULT NULL,
  `root_id` int DEFAULT NULL,
  `lft` int DEFAULT NULL,
  `rgt` int DEFAULT NULL,
  `is_private` tinyint(1) NOT NULL DEFAULT '0',
  `closed_on` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `issues`
--

INSERT INTO `issues` (`id`, `tracker_id`, `project_id`, `subject`, `description`, `due_date`, `category_id`, `status_id`, `assigned_to_id`, `priority_id`, `fixed_version_id`, `author_id`, `lock_version`, `created_on`, `updated_on`, `start_date`, `done_ratio`, `estimated_hours`, `parent_id`, `root_id`, `lft`, `rgt`, `is_private`, `closed_on`) VALUES
(4, 1, 2, 'Controller_KH Thêm khách hàng chưa lưu vào database', 'Khi thêm khách hàng mới nhấn nút submit.Kiểm tra lại không thấy thông tin trên database.', NULL, NULL, 1, NULL, 3, NULL, 1, 1, '2021-12-18 09:29:31', '2021-12-18 09:34:09', '2021-12-18', 0, NULL, NULL, 4, 1, 2, 0, NULL),
(5, 1, 2, 'Controller_NV Không cập nhật password mới khi đổi password', 'Khi Sửa thông tin nhân viên nhấn submit.Quay lại danh sách kiểm tra không thấy mật khẩu cập nhật.', NULL, NULL, 1, NULL, 2, NULL, 1, 0, '2021-12-18 09:33:19', '2021-12-18 09:33:19', '2021-12-18', 0, NULL, NULL, 5, 1, 2, 0, NULL),
(6, 1, 2, 'Controller_HD Mã hóa đơn không làm mới', 'Khi xem chi tiết 1 hóa đơn sau đó quay lại trang danh sách bấm thêm hóa đơn mới mã hóa đơn bị trúng với hóa đơn trước đó và không thay đổi được.', NULL, NULL, 1, NULL, 3, NULL, 1, 0, '2021-12-18 09:38:54', '2021-12-18 09:38:54', '2021-12-18', 0, NULL, NULL, 6, 1, 2, 0, NULL),
(7, 1, 2, 'Controller_HD ràng buộc mã hóa đơn,trùng thuốc', 'Khi thêm thuốc mới mã hóa đơn thay đổi được không đồng bộ,thuốc thêm có thể bị trùng trong hóa đơn.', NULL, NULL, 1, NULL, 3, NULL, 1, 0, '2021-12-18 09:52:03', '2021-12-18 09:52:03', '2021-12-18', 0, NULL, NULL, 7, 1, 2, 0, NULL),
(8, 1, 2, 'Controller_Login: Đăng ký thiếu ràng buộc xác nhận password', 'Khi đăng ký, mục xác nhận password không có ràng buộc, nhập sai xác nhận vẫn lưu vào database', NULL, NULL, 5, 8, 2, NULL, 8, 7, '2021-12-18 10:02:52', '2021-12-18 10:08:10', '2021-12-18', 100, NULL, NULL, 8, 1, 2, 0, '2021-12-18 17:08:10');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `issues`
--
ALTER TABLE `issues`
  ADD PRIMARY KEY (`id`),
  ADD KEY `issues_project_id` (`project_id`),
  ADD KEY `index_issues_on_status_id` (`status_id`),
  ADD KEY `index_issues_on_category_id` (`category_id`),
  ADD KEY `index_issues_on_assigned_to_id` (`assigned_to_id`),
  ADD KEY `index_issues_on_fixed_version_id` (`fixed_version_id`),
  ADD KEY `index_issues_on_tracker_id` (`tracker_id`),
  ADD KEY `index_issues_on_priority_id` (`priority_id`),
  ADD KEY `index_issues_on_author_id` (`author_id`),
  ADD KEY `index_issues_on_created_on` (`created_on`),
  ADD KEY `index_issues_on_root_id_and_lft_and_rgt` (`root_id`,`lft`,`rgt`),
  ADD KEY `index_issues_on_parent_id` (`parent_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `issues`
--
ALTER TABLE `issues`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
