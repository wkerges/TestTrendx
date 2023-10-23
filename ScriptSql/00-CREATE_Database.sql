USE [master]
GO

/****** Object:  Database [TASK_BD]    Script Date: 19/10/2023 14:04:23 ******/
CREATE DATABASE [TASK_BD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TASK_BD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.BANCOLOCAL\MSSQL\DATA\TASK_BD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TASK_BD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.BANCOLOCAL\MSSQL\DATA\TASK_BD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TASK_BD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [TASK_BD] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [TASK_BD] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [TASK_BD] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [TASK_BD] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [TASK_BD] SET ARITHABORT OFF 
GO

ALTER DATABASE [TASK_BD] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [TASK_BD] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [TASK_BD] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [TASK_BD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [TASK_BD] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [TASK_BD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [TASK_BD] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [TASK_BD] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [TASK_BD] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [TASK_BD] SET  DISABLE_BROKER 
GO

ALTER DATABASE [TASK_BD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [TASK_BD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [TASK_BD] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [TASK_BD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [TASK_BD] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [TASK_BD] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [TASK_BD] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [TASK_BD] SET RECOVERY FULL 
GO

ALTER DATABASE [TASK_BD] SET  MULTI_USER 
GO

ALTER DATABASE [TASK_BD] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [TASK_BD] SET DB_CHAINING OFF 
GO

ALTER DATABASE [TASK_BD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [TASK_BD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [TASK_BD] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [TASK_BD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [TASK_BD] SET QUERY_STORE = OFF
GO

ALTER DATABASE [TASK_BD] SET  READ_WRITE 
GO

